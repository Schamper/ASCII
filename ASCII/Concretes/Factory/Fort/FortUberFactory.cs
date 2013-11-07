using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCII
{
    public class FortUberFactory : FortFactory
    {
        public override IFort CreateFort()
        {
            IFort fort = new Fort();
            fort.Health = 200;
            fort.Defense = 200;
            return fort;
        }
    }
}
