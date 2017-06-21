using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Monster : IComparable<Monster>, ICloneable
    {
        private int nbStarsNat;
        public int NbStarsNat
        {
            get
            {
                return nbStarsNat;
            }

            set
            {
                nbStarsNat = value;
            }
        }

        private int nbStars;
        public int NbStars
        {
            get
            {
                return nbStars;
            }

            set
            {
                nbStars = value;
            }
        }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        private string monsterN;
        public string MonsterN
        {
            get
            {
                return monsterN;
            }

            set
            {
                monsterN = value;
            }
        }

        private string attribute;
        public string Attribute
        {
            get
            {
                return attribute;
            }

            set
            {
                attribute = value;
            }
        }

        private string imagePath;
        public string ImagePath
        {
            get
            {
                return imagePath;
            }

            set
            {
                imagePath = value;
            }
        }

        private int atk;
        public int Atk
        {
            get
            {
                return atk;
            }
            set
            {
                atk = value;
            }
        }

        private int pv;
        public int Pv
        {
            get
            {
                return pv;
            }
            set
            {
                pv = value;
            }
        }

        private int def;
        public int Def
        {
            get
            {
                return def;
            }
            set
            {
                def = value;
            }
        }

        private int spd;
        public int Spd
        {
            get
            {
                return spd;
            }
            set
            {
                spd = value;
            }
        }

        private int crirate;
        public int Crirate
        {
            get
            {
                return crirate;
            }
            set
            {
                crirate = value;
            }
        }

        private int cridom;
        public int Cridom
        {
            get
            {
                return cridom;
            }
            set
            {
                cridom = value;
            }
        }

        private int res;
        public int Res
        {
            get
            {
                return res;
            }
            set
            {
                res = value;
            }
        }

        private int acc;
        public int Acc
        {
            get
            {
                return acc;
            }
            set
            {
                acc = value;
            }
        }

        private string help;
        public string Help
        {
            get
            {
                return help;
            }
            set
            {
                help = value;
            }
        }

        public Monster(int nbStarsNat, int nbStars, string name, int atk, int pv, int def, int spd, int crirate, int cridom, int res, int acc, string monster, string attribute, string help)
        {
            NbStarsNat = nbStarsNat;
            NbStars = nbStars;
            Name = name;
            Atk = atk;
            Pv = pv;
            Def = def;
            Spd = spd;
            Crirate = crirate;
            Cridom = cridom;
            Res = res;
            Acc = acc;
            MonsterN = monster;
            Attribute = attribute;
            Help = help;
        }

        public Monster(Monster m)
        {
            
            NbStarsNat = m.NbStarsNat;
            NbStars = m.NbStars;
            Name = m.Name;
            Atk = m.Atk;
            Pv = m.Pv;
            Def = m.Def;
            Spd = m.Spd;
            Crirate = m.Crirate;
            Cridom = m.Cridom;
            Res = m.Res;
            Acc = m.Acc;
            MonsterN = m.MonsterN;
            Attribute = m.Attribute;
            ImagePath = m.ImagePath;
            Help = m.Help;
        }

        public Monster() { }

        public int CompareTo(Monster other)
        {
            return Name.CompareTo(other.Name);
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
