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
                Random r = new Random(this.GetHashCode());
                int rn = r.Next(_Decorators.Length);
                ISoldier s = Factory.CreateSoldier();
                s = Decorate(s, _Decorators[rn]);
                ISimulation sim = Simulation.getInstance();
                ILivable l = new Livable(s, sim);
                sim.AddLivable(l);
                Thread.Sleep(Delay);
            }
        }
    }
}
