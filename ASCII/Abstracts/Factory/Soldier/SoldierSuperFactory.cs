using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCII
{
    public abstract class SoldierSuperFactory : SoldierFactory
    {
        public override ISoldier CreateSoldier()
        {
            ISoldier soldier = new Soldier();
            soldier.AttackBehaviour = new SoldierDefaultAttackBehaviour(soldier);
            soldier.MoveBehaviour = new SoldierDefaultMoveBeaviour(soldier);
            soldier.Health = 200;
            soldier.Level = 4;
            soldier.Strength = 25;
            soldier.Name = "Super Soldier";
            soldier.Description = "A Super Soldier";
            soldier.Speed = 1;

            return soldier;
        
        }

        public override int Delay
        {
            get
            {
                return 15000;
            }
        }
    }
}
