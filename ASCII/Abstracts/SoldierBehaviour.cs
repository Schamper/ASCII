using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCII
{
    public abstract class SoldierBehaviour : IBehaviour
    {
        private ISoldier _BaseSoldier;

        public SoldierBehaviour(ISoldier baseSoldier)
        {
            this._BaseSoldier = baseSoldier;
        }

        public abstract void DoBehaviour();
    }
}
