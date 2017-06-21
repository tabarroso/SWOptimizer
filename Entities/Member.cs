using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// The member is a loged user
    /// </summary>
    [Serializable]
    public class Member : IComparable<Member>
    {
        private string login;
        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                login = value;
            }
        }

        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        private ObservableCollection<Monster> myMonsters;
        public ObservableCollection<Monster> MyMonsters
        {
            get
            {
                return myMonsters;
            }

            set
            {
                myMonsters = value;
            }
        }

        public Member(string login, string password)
        {
            Login = login;
            Password = password;
            MyMonsters = new ObservableCollection<Monster>();
        }

        public Member()
        {
            MyMonsters = new ObservableCollection<Monster>();
        }

        public override string ToString()
        {
            return "login: " + login;
        }

        /// <summary>
        /// Add a monster to the personnal list of the member
        /// </summary>
        /// <param name="monsterAdd"></param>
        public bool AddMonster(Monster monsterAdd)
        {
            int i = 0;
            foreach (Monster monster in MyMonsters)
            {
                i++;
                if (monster.CompareTo(monsterAdd) == 0) return false;
                if (monster.CompareTo(monsterAdd) > 0)
                {
                    MyMonsters.Insert(i - 1, monsterAdd);
                    return true;
                }
            }
            MyMonsters.Add(monsterAdd);
            return true;
            
        }

        public void DeleteMonster(Monster monsterDelete)
        {
            if (MyMonsters.Remove(monsterDelete)) return;
        }

        public int CompareTo(Member other)
        {
            return Login.CompareTo(other.Login);
        }
    }
}
