using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCII
{
    public class SoldierDefaultAttackBehaviour : SoldierBehaviour
    {
        public SoldierDefaultAttackBehaviour(ISoldier baseSoldier) : base(baseSoldier)
        {
        }

        public override void DoBehaviour()
        {
            Console.WriteLine("Default Attack");
        }
    }
}
