using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class MonsterNonAwake : Monster
    {
        public MonsterNonAwake(int nbStarsNat, int nbStars, string name, int atk, int pv, int def, int spd, int crirate, int cridom, int res, int acc, string monster, string attribute, string help) :
            base(nbStarsNat, nbStars, name, atk, pv, def, spd, crirate, cridom, res, acc, monster, attribute, help)
        { }

        public MonsterNonAwake() { }

        public override string ToString()
        {
            return MonsterN + " " + Attribute;
        }

        public new int CompareTo(Monster other)
        {
            if (MonsterN.CompareTo(other.MonsterN) == 0) return Attribute.CompareTo(other.Attribute);
            return MonsterN.CompareTo(other.MonsterN);
        }
    }
}
