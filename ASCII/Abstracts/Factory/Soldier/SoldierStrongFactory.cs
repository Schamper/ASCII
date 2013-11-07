using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCII
{
    public abstract class SoldierStrongFactory : SoldierFactory
    {
        public override ISoldier CreateSoldier()
        {
            ISoldier soldier = new Soldier();
            soldier.AttackBehaviour = new SoldierDefaultAttackBehaviour(soldier);
            soldier.MoveBehaviour = new SoldierDefaultMoveBeaviour(soldier);
            soldier.Health = 150;
            soldier.Level = 3;
            soldier.Strength = 15;
            soldier.Name = "Strong Soldier";
            soldier.Description = "A Strong Soldier";
            soldier.Speed = 2;

            return soldier;
        }

        public override int Delay
        {
            get
            {
                return 12000;
            }
        }
    }
}
