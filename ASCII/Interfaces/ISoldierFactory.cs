using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCII
{
    public interface ISoldierFactory
    {
        ISoldier CreateSoldier();

        int Delay { get; }
    }
}
