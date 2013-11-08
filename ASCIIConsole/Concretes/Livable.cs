using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASCII;
using System.Diagnostics;
using System.Threading;

namespace ASCIIConsole
{
    public class Livable : ILivable
    {
        private ISoldier _Soldier;
        private ISimulation _Simulation;
        private int _Id;

        public Livable(ISoldier soldier, ISimulation simulation)
        {
            _Soldier = soldier;
            _Simulation = simulation;
            _Id = this.GetHashCode();
            //Debug.Print("New livable: " + _Id);
        }



        public ISoldier Soldier
        {
            get
            {
                return _Soldier;
            }
            set
            {
                _Soldier = value;
            }
        }

        public ISimulation Simulation
        {
            get
            {
                return _Simulation;
            }
            set
            {
                _Simulation = value;
            }
        }

        public int[] Location
        {
            get
            {
                return Soldier.Location;
            }
            set
            {
                Soldier.Location = value;
            }
        }

        public int Level
        {
            get
            {
                return Soldier.Level;
            }
        }

        public int Id
        {
            get
            {
                return _Id;
            }
        }

        public void Die()
        {
            Simulation.RemoveLivable(this);
            _Running = false;
        }

        bool _Running = true;
        
        public void Run()
        {
            //Debug.Print(this.GetHashCode() + " is now running");
            int speed = Soldier.Speed;
            int rate = (200 / speed) + new Random(this.GetHashCode()).Next(500);
            while (_Running)
            {
                Thread.Sleep(rate);
                Soldier.Location[0]++;
                Simulation.UpdateLivable(this);
            }
        }
    }
}
