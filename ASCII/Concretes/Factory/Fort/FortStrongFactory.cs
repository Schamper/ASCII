using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCII
{
    public class FortStrongFactory : FortFactory
    {
        public override IFort CreateFort()
        {
            IFort fort = new Fort();
            fort.Health = 100;
            fort.Defense = 100;
            return fort;
        }
    }
}
