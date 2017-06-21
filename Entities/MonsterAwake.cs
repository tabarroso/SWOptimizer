using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class MonsterAwake : Monster
    {
        public MonsterAwake(int nbStarsNat, int nbStars, string name, int atk, int pv, int def, int spd, int crirate, int cridom, int res, int acc, string monster, string attribute, string help) :
            base(nbStarsNat, nbStars, name, atk, pv, def, spd, crirate, cridom, res, acc, monster, attribute, help)
        { }
        public MonsterAwake() { }

        public override string ToString()
        {
            return Name;
        }
    }
}
