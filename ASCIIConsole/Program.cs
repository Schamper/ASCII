using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ISimulation sim = Simulation.getInstance();
            sim.Display = Display.getInstance();
            sim.Start();
        }
    }
}
