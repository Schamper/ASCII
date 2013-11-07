using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCII
{
    public abstract class SoldierFactory : ISoldierFactory
    {
        public abstract ISoldier CreateSoldier();

        public abstract int Delay { get; }
    }
}
