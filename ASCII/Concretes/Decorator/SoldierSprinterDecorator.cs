using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCII
{
    public class SoldierSprinterDecorator : SoldierDecorator
    {
        public SoldierSprinterDecorator(ISoldier baseSoldier)
            : base(baseSoldier)
        {

        }

        public override int Speed
        {
            get
            {
                return (int) Math.Floor(_BaseSoldier.Speed * 1.5);
            }
        }
    }
}
