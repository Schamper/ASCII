using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCII
{
    public class Soldier : ISoldier
    {
        private int _Level;

        public int Level
        {
            get { return _Level; }
            set { _Level = value; }
        }


        private int _Strength;

        public int Strength
        {
            get { return _Strength; }
            set { _Strength = value; }
        }

        private int _Health;

        public int Health
        {
            get { return _Health; }
            set { _Health = value; }
        }


        private int _Speed;

        public int Speed
        {
            get { return _Speed; }
            set { _Speed = value; }
        }

        private int[] _Location;

        public int[] Location
        {
            get { return _Location; }
            set { _Location = value; }
        }

        private String _Desc;

        public String Description
        {
            get { return _Desc; }
            set { _Desc = value; }
        }

        private String _Name;

        public String Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public IBehaviour AttackBehaviour
        {
            get;
            set;
        }

        public IBehaviour MoveBehaviour
        {
            get;
            set;
        }

        public void Attack()
        {
            this.AttackBehaviour.DoBehaviour();
        }

        public bool ReceiveDamage(int amount)
        {
            Health = Health - amount;
            if (Health < 0) 
            {
                return true;
            }
            return false;
        }

        public bool Move()
        {
            this.MoveBehaviour.DoBehaviour();
            return true;
        }

    }
}
