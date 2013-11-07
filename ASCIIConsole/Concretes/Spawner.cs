using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASCII;
using System.Threading;
using System.Diagnostics;

namespace ASCIIConsole
{
    class Spawner : ISpawner
    {
        private ISoldierFactory _Factory;
        public ISoldierFactory Factory
        {
            get
            {
                return _Factory;
            }
            set
            {
                _Factory = value;
            }
        }

        private IDisplay _Display;
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

        public ISoldier Decorate(ISoldier soldier, String decorator)
        {
            //TODO instantiate from string
            switch (decorator) {
                case "None":
                    //Debug.Print("Normal");
                    return soldier;
                case "SoldierSprinterDecorator":
                    //Debug.Print("This");
                    return new SoldierSprinterDecorator(soldier);
                case "SoldierSuperStrengthDecorator":
                    //Debug.Print("That");
                    return new SoldierSprinterDecorator(soldier);
                default:
                    //Debug.Print("Normal");
                    return soldier;
            }
        }

        private String[] _Decorators;
        public String[] Decorators
        {
            get
            {
                return _Decorators;
            }
            set
            {
                _Decorators = value;
            }
        }

        private int _Delay;
        public int Delay
        {
            get 
            {
                return _Delay;
            }
            set
            {
                _Delay = value;
            }
        }

        public void Stop()
        {
            _Running = false;
        }

        bool _Running = true;

        public void Run()
        {
            while (_Running)
            {
                Random r = new Random();
                int rn = r.Next(_Decorators.Length);
                ISoldier s = Factory.CreateSoldier();
                s = Decorate(s, _Decorators[rn]);
                ISimulation sim = Simulation.getInstance();
                //IAnimator anim = new Animator(Display, s);
                ILivable l = new Livable(s, Display, sim);
                Display.AddLivable(l);
                sim.AddLivable(l);
                //Display.AddAnimator(anim);
                //sim.AddAnimator(anim);
                //Display.AddEntity(s);
                Thread.Sleep(Delay);
            }
        }
    }
}
