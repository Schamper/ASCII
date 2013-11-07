using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASCII;

namespace ASCIIConsole
{
    public interface ISpawner
    {
        ISoldierFactory Factory { get; set; }

        ISoldier Decorate(ISoldier soldier, String decorator);

        String[] Decorators { get; set; }

        int Delay { get; set; }

        void Run();

        void Stop();
    }
}
