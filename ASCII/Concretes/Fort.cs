using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCII
{
    class Fort : IFort
    {

        private int _Health;
        public int Health
        {
            get
            {
                return _Health;
            }
            set
            {
                _Health = value;
            }
        }

        private int _Defense;
        public int Defense
        {
            get
            {
                return _Defense;
            }
            set
            {
                _Defense = value;
            }
        }

        public void Damage(int amount)
        {
            Health = Health - amount;
            if (Health < 0)
            {
                Die();
            }
        }

        private bool _Dead = false;
        public bool isDead()
        {
            return _Dead;
        }

        public void Die()
        {
            _Dead = true;
        }
    }
}
