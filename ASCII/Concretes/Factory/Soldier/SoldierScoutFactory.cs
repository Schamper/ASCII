using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCII
{
    public class SoldierScoutFactory : SoldierWeakFactory
    {
        public override ISoldier CreateSoldier()
        {
            ISoldier soldier = base.CreateSoldier();
            soldier.Speed = 5;
            soldier.Strength = 6;
            return soldier;
        }
    }
}
