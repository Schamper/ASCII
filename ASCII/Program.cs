using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCII
{
    class Program
    {
        static void Main(string[] args)
        {
            ISoldierFactory f = new SoldierRegularFactory();
            ISoldier s = f.CreateSoldier();
            s.Move();
            s.Attack();
            Console.ReadKey();
        }
    }
}
