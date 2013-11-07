using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCII
{
    public class SoldierBigFactory : SoldierStrongFactory
    {
        public override ISoldier CreateSoldier()
        {
            ISoldier soldier = base.CreateSoldier();
            return soldier;
        }
    }
}
