using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCII
{
    public class SoldierUberFactory : SoldierSuperFactory
    {
        public override ISoldier CreateSoldier()
        {
            ISoldier soldier = base.CreateSoldier();
            return soldier;
        }
    }
}
