using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entities
{
    /// <summary>
    /// This singelton is the awaken bestiary
    /// </summary>
    [Serializable]
    public sealed class BestiaryAwake
    {
        private static BestiaryAwake bestiary = new BestiaryAwake();
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

        private BestiaryAwake()
        {
            ListBestiary = new ObservableCollection<Monster>();
        }

        public static BestiaryAwake Instance
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
        /// Add an awake monster to the bestiary
        /// </summary>
        /// <param name="monsterAdd"></param>
        public bool AddMonster(MonsterAwake monsterAdd)
        {
            int i = 0;
            foreach (MonsterAwake monster in ListBestiary)
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

        public void RemoveMonster(MonsterAwake monsterAdd)
        {
            int i = 0;
            foreach (MonsterAwake monster in ListBestiary)
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
