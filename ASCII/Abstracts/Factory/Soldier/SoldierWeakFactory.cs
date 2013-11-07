using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCII
{
    public abstract class SoldierWeakFactory : SoldierFactory
    {
        public override ISoldier CreateSoldier()
        {
            ISoldier soldier = new Soldier();
            soldier.AttackBehaviour = new SoldierDefaultAttackBehaviour(soldier);
            soldier.MoveBehaviour = new SoldierDefaultMoveBeaviour(soldier);
            soldier.Health = 75;
            soldier.Level = 1;
            soldier.Strength = 10;
            soldier.Name = "Weak Soldier";
            soldier.Description = "A Weak Soldier";
            soldier.Speed = 3;

            return soldier;
        }

        public override int Delay
        {
            get
            {
                return 8000;
            }
        }
    }
}
