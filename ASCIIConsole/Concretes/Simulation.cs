using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ASCII;
using System.Reflection;
using System.Collections.Concurrent;

namespace ASCIIConsole
{
    class Simulation : ISimulation
    {
        private static ISimulation _Instance = null;
        private IDisplay _Display = null;
        private bool _Running = false;
        private List<ISpawner> _SpawnerPool = new List<ISpawner>();
        private IFortFactory _FortFactory;
        private IFort _Fort;
        private int _SpawnerCount;
        private int _Difficulty = 1;
        private String[] _SoldierFactories = new String[] { "SoldierRegularFactory", "SoldierScoutFactory", "SoldierBigFactory", "SoldierUberFactory" };
        private String[] _SoldierDecorators = new String[] { "None", "SoldierSprinterDecorator", "SoldierSuperStrengthDecorator" };

        private volatile ConcurrentDictionary<ILivable, ILivable> _AnimationQueue = new ConcurrentDictionary<ILivable, ILivable>();
        [ThreadStatic]
        private volatile ILivable _CurrentAnimator;
        //[ThreadStatic]
        private volatile ConcurrentDictionary<ILivable, ILivable> _Livables = new ConcurrentDictionary<ILivable, ILivable>();

        public IDisplay Display
        {
            get
            {
                return _Display;
            }
            set
            {
                _Display = value;
            }
        }

        public int Difficulty
        {
            get
            {
                return _Difficulty;
            }
            set
            {
                _Difficulty = value;
            }
        }

        public int SpawnerCount
        {
            get
            {
                return _SpawnerCount;
            }
            set
            {
                _SpawnerCount = value;
            }
        }

        public void Init()
        {

        }

        public static ISimulation getInstance()
        {
            if (_Instance == null)
            {
                _Instance = new Simulation();
            }
            return _Instance;
        }

        private Simulation()
        {

        }

        private ISoldierFactory CreateFactory(String name)
        {
            //TODO instantiate from string
            switch (name)
            {
                case "SoldierRegularFactory":
                    return new SoldierRegularFactory();
                case "SoldierScoutFactory":
                    return new SoldierScoutFactory();
                case "SoldierBigFactory":
                    return new SoldierBigFactory();
                case "SoldierUberFactory":
                    return new SoldierUberFactory();
                default:
                    return new SoldierRegularFactory();
            }
        }

        public void AddSpawner(ISpawner spawner)
        {
            _SpawnerPool.Add(spawner);
        }

        public ISpawner GetSpawner(int i)
        {
            return _SpawnerPool[i];
        }

        public void RemoveSpawner(ISpawner spawner)
        {
            _SpawnerPool.Remove(spawner);
        }

        public void ClearSpawners()
        {
            _SpawnerPool.Clear();
        }

        public ISpawner CreateRandomSpawner()
        {
            ISpawner s = new Spawner();
            Random r = new Random(s.GetHashCode());
            int rs = r.Next(_SoldierFactories.Length);
            ISoldierFactory f = CreateFactory(_SoldierFactories[rs]);
            s.Factory = f;
            s.Decorators = _SoldierDecorators;
            s.Delay = f.Delay + r.Next(1000);
            return s;
        }

        public void AddLivable(ILivable livable)
        {
            _Livables.TryAdd(livable, livable);
            Thread th = new Thread(new ThreadStart(livable.Run));
            th.Start();
            Display.AddLivable(livable);
        }

        public void RemoveLivable(ILivable livable)
        {
            ILivable ded;
            _Livables.TryRemove(livable, out ded);
            _AnimationQueue.TryRemove(livable, out ded);
            Display.RemoveLivable(livable);

        }

        public void UpdateLivable(ILivable livable)
        {
            ISoldier s = livable.Soldier;
            int[] loc = s.Location;
            if (_Display.ReachedFort(loc))
            {
                _Fort.Damage(livable.Soldier.Strength);
                Display.UpdateFort();
                livable.Die();
            }
            else
            {
                _AnimationQueue.TryAdd(livable, livable);
            }
            CheckAnimationQueue();
        }

        public void CheckAnimationQueue()
        {
            if (_CurrentAnimator == null && _AnimationQueue.Count > 0)
            {
                //Console.SetCursorPosition(60, 0);
                //Console.Write(_AnimationQueue.Count);
                //int i = _AnimationQueue.Keys.Count;
                //Random r = new Random();
                //ILivable entity = _AnimationQueue.Keys.ToArray<ILivable>()[r.Next(i)];
                ILivable entity = _AnimationQueue.First().Key;
                _AnimationQueue.TryRemove(entity, out entity);
                //_Animators.Remove(entity);
                if (entity != null && !_Fort.isDead())
                {
                    _CurrentAnimator = entity;
                    Display.AnimateEntity(entity);
                    _CurrentAnimator = null;
                }
            }
        }

        public void Start()
        {
            //Check if we're ready
            if (Display == null)
            {
                throw new Exception();
            }
            Display.Initialize();
            Difficulty = Display.RequestDifficulty();
            switch (Difficulty)
            {
                case 1:
                    _FortFactory = new FortWeakFactory();
                    SpawnerCount = 3;
                    break;
                case 2:
                    _FortFactory = new FortNormalFactory();
                    SpawnerCount = 5;
                    break;
                case 3:
                    _FortFactory = new FortStrongFactory();
                    SpawnerCount = 8;
                    break;
                case 4:
                    _FortFactory = new FortUberFactory();
                    SpawnerCount = 10;
                    break;
                default:
                    _FortFactory = new FortNormalFactory();
                    SpawnerCount = 5;
                    break;
            }
            //Fill the spawner pool
            for (int i = 0; i < SpawnerCount; i++)
            {
                AddSpawner(CreateRandomSpawner());
            }

            //Start the simulation engine
            _Running = true;
            Thread th = new Thread(new ThreadStart(Run));
            th.Start();
        }

        private void Run()
        {
            if (!_Display.HasFort())
            {
                _Fort = _FortFactory.CreateFort();
                _Display.BuildFort(_Fort);
                for (int i = 0; i < _SpawnerPool.Count; i++)
                {
                    ISpawner s = GetSpawner(i);
                    Thread th = new Thread(new ThreadStart(s.Run));
                    th.Start();
                }
            }
            while (_Running)
            {
                if (_Fort.isDead())
                {
                    
                    foreach (var entry in _Livables)
                    {
                        entry.Key.Die();
                    }

                    //_Livables.Clear();
                    _AnimationQueue.Clear();

                    foreach (var entry in _SpawnerPool)
                    {
                        entry.Stop();
                    }
                    Display.End();
                    Display.Gameover();
                    _Running = false;
                }
            }
        }
    }
}
