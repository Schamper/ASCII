using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCII
{
    public interface IFort
    {
        int Health { get; set; }

        int Defense { get; set; }

        bool isDead();

        void Damage(int amount);

        void Die();

    }
}
