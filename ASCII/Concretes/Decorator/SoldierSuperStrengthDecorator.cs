using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCII
{
    class SoldierSuperStrengthDecorator : SoldierDecorator
    {
        public SoldierSuperStrengthDecorator(ISoldier baseSoldier)
            : base(baseSoldier)
        {

        }

        public override int Strength
        {
            get
            {
                return _BaseSoldier.Strength * 2;
            }
            set
            {
                _BaseSoldier.Strength = value;
            }
        }
    }
}
