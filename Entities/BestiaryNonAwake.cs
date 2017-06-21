using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// This singelton is the non awaken bestiary
    /// </summary>
    [Serializable]
    public sealed class BestiaryNonAwake
    {
        private static BestiaryNonAwake bestiary = new BestiaryNonAwake();
        private ObservableCollection<Monster> _listBestiary;
        public ObservableCollection<Monster> ListBestiary
        {
            get
            {
                return _listBestiary;
            }
            set
            {
                _listBestiary = value;

            }
        }

        private BestiaryNonAwake()
        {
            ListBestiary = new ObservableCollection<Monster>();
        }
        public static BestiaryNonAwake Instance
        {
            get
            {
                return bestiary;
            }
            set
            {
                bestiary = value;
            }
        }

        /// <summary>
        /// Add a non awaken monster to the bestiary
        /// </summary>
        /// <param name="monsterAdd"></param>
        public bool AddMonster(MonsterNonAwake monsterAdd)
        {
            int i = 0;
            foreach (MonsterNonAwake monster in ListBestiary)
            {
                if (monsterAdd.CompareTo(monster) == 0) return false;
                if (monsterAdd.CompareTo(monster) <= 0)
                {
                    ListBestiary.Insert(i, monsterAdd);
                    return true;
                }
                i++;
            }
            ListBestiary.Add(monsterAdd);
            return true;
        }

        public void RemoveMonster(MonsterNonAwake monsterAdd)
        {
            int i = 0;
            foreach (MonsterNonAwake monster in ListBestiary)
            {
                if (monsterAdd.CompareTo(monster) == 0)
                {
                    ListBestiary.RemoveAt(i);
                    return;
                }
                i++;
            }
        }
    }
}

