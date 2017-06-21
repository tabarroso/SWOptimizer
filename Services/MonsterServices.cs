using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    /// <summary>
    /// MonsterService is a singelton
    /// </summary>
    public sealed class MonsterService
    {
        private static MonsterService ms = new MonsterService();

        private MonsterService() { }

        public static MonsterService Instance
        {
            get
            {
                return ms;
            }
        }


        /// <summary>
        /// Create a new monster with the ctor of Monster and add to the monster lists
        /// </summary>
        /// <param name="nbStarsNat"></param>
        /// <param name="nbStars"></param>
        /// <param name="name"></param>
        /// <param name="atk"></param>
        /// <param name="pv"></param>
        /// <param name="def"></param>
        /// <param name="spd"></param>
        /// <param name="crirate"></param>
        /// <param name="cridom"></param>
        /// <param name="res"></param>
        /// <param name="acc"></param>
        /// <param name="monster"></param>
        /// <param name="attribute"></param>
        /// <param name="imagePath"></param>
        public bool CreateMonsterAwake(int nbStarsNat, int nbStars, string name, int atk, int pv, int def, int spd, int crirate, int cridom, int res, int acc, string monster, string attribute, string help)
        {
            MonsterAwake m = new MonsterAwake(nbStarsNat, nbStars, name, atk, pv, def, spd, crirate, cridom, res, acc, monster, attribute, help);
            return AddMonsterAwake(m);
        }

        public bool CreateMonsterNonAwake(int nbStarsNat, int nbStars, string name, int atk, int pv, int def, int spd, int crirate, int cridom, int res, int acc, string monster, string attribute, string help)
        {
            MonsterNonAwake m = new MonsterNonAwake(nbStarsNat, nbStars, name, atk, pv, def, spd, crirate, cridom, res, acc, monster, attribute, help);
            return AddMonsterNonAwake(m);
        }

        public bool AddMonsterAwake (MonsterAwake ma)
        {
            ma.ImagePath = GetPath(ma.Name);
            if (BestiaryAwake.Instance.AddMonster(ma)) return true;
            return false;
        }

        public bool AddMonsterNonAwake(MonsterNonAwake mn)
        {
            mn.ImagePath = GetPath(mn.MonsterN + mn.Attribute);
            if(BestiaryNonAwake.Instance.AddMonster(mn)) return true;
            return false;
        }

        public void DeleteMonsterAwake(MonsterAwake ma)
        {
            BestiaryAwake.Instance.RemoveMonster(ma);
        }

        public void DeleteMonsterNonAwake(MonsterNonAwake mn)
        {
            BestiaryNonAwake.Instance.RemoveMonster(mn);
        }

        public string GetPath(string name)
        {
            return Path.GetFullPath(Path.Combine("photos/", name + ".png"));
        }

        public MonsterAwake SearchMonsterAwake(Monster m)
        {
            if (BestiaryAwake.Instance == null) return null;
            foreach (MonsterAwake monster in BestiaryAwake.Instance.ListBestiary)
            {
                if (monster.CompareTo(m) == 0) return monster;
            }
            return null;
        }

        public MonsterNonAwake SearchMonsterNonAwake(Monster m)
        {
            if (BestiaryNonAwake.Instance == null) return null;
            foreach (MonsterNonAwake monster in BestiaryNonAwake.Instance.ListBestiary)
            {
                if (monster.CompareTo(m) == 0) return monster;
            }
            return null;
        }
    }
}
