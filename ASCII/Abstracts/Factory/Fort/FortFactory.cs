using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCII
{
    public abstract class FortFactory : IFortFactory
    {
        public abstract IFort CreateFort();
    }
}
