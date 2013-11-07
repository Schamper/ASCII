using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCII
{
    public class SoldierDecorator : ISoldier
    {
        protected ISoldier _BaseSoldier;

        public SoldierDecorator(ISoldier baseSoldier)
        {
            this._BaseSoldier = baseSoldier;
        }

        public IBehaviour AttackBehaviour
        {
            get
            {
                return this._BaseSoldier.AttackBehaviour;
            }
            set
            {
                this._BaseSoldier.AttackBehaviour = value;
            }
        }

        public IBehaviour MoveBehaviour
        {
            get
            {
                return this._BaseSoldier.MoveBehaviour;
            }
            set
            {
                this._BaseSoldier.MoveBehaviour = value;
            }
        }

        public int Level
        {
            get
            {
                return this._BaseSoldier.Level;
            }
            set
            {
                this._BaseSoldier.Level = value;
            }
        }

        public virtual int Strength
        {
            get
            {
                return this._BaseSoldier.Strength;
            }
            set
            {
                this._BaseSoldier.Strength = value;
            }
        }

        public int Health
        {
            get
            {
                return this._BaseSoldier.Health;
            }
            set
            {
                this._BaseSoldier.Health = value;
            }
        }

        public virtual int Speed
        {
            get
            {
                return this._BaseSoldier.Speed;
            }
            set
            {
                this._BaseSoldier.Speed = value;
            }
        }

        public int[] Location
        {
            get
            {
                return this._BaseSoldier.Location;
            }
            set
            {
                this._BaseSoldier.Location = value;
            }
        }

        public string Description
        {
            get
            {
                return this._BaseSoldier.Description;
            }
            set
            {
                this._BaseSoldier.Description = value;
            }
        }

        public string Name
        {
            get
            {
                return this._BaseSoldier.Name;
            }
            set
            {
                this._BaseSoldier.Name = value;
            }
        }

        public void Attack()
        {
            this._BaseSoldier.Attack();
        }

        public Boolean ReceiveDamage(int amount)
        {
            return this._BaseSoldier.ReceiveDamage(amount);
        }

        public bool Move()
        {
            return this._BaseSoldier.Move();
        }
    }
}
