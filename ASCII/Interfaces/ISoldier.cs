using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCII
{
    public interface ISoldier
    {
        IBehaviour AttackBehaviour { get; set; }

        IBehaviour MoveBehaviour { get; set; }

        int Level { get; set; }

        int Strength { get; set; }

        int Health { get; set; }

        int Speed { get; set; }

        int[] Location { get; set; }

        String Description { get; set; }

        String Name { get; set; }

        void Attack();

        Boolean ReceiveDamage(int amount);

        Boolean Move();

    }
}
