using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCII
{
    public abstract class SoldierNormalFactory : SoldierFactory
    {
        public override ISoldier CreateSoldier()
        {
            ISoldier soldier = new Soldier();
            soldier.AttackBehaviour = new SoldierDefaultAttackBehaviour(soldier);
            soldier.MoveBehaviour = new SoldierDefaultMoveBeaviour(soldier);
            soldier.Health = 100;
            soldier.Level = 2;
            soldier.Strength = 20;
            soldier.Name = "Normal Soldier";
            soldier.Description = "A Normal Soldier";
            soldier.Speed = 3;

            return soldier;
        }

        public override int Delay
        {
            get
            {
                return 10000;
            }
        }
    }
}
