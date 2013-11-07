using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASCII;

namespace ASCIIConsole
{
    public interface ILivable
    {
        ISoldier Soldier { get; set; }

        ISimulation Simulation { get; set; }

        int Id { get; }

        void Die();

        void Run();
    }
}
