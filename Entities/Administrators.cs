using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public sealed class Administrators
    {
        private static Administrators administrators = new Administrators();
        private ObservableCollection<Member> administratorList;
        public ObservableCollection<Member> AdministratorList
        {
            get
            {
                return administratorList;
            }

            set
            {
                administratorList = value;
            }
        }

        private Administrators()
        {
            AdministratorList = new ObservableCollection<Member>();
        }

        public static Administrators Instance
        {
            get
            {
                return administrators;
            }
            set
            {
                administrators = value;
            }
        }

        public void AddAdministrator(Member administratorAdd)
        {
            int i = 0;
            foreach (Member administrator in AdministratorList)
            {
                if (administrator.CompareTo(administratorAdd) <= 0)
                {
                    AdministratorList.Insert(i, administratorAdd);
                    return;
                }
                i++;
            }
            AdministratorList.Add(administratorAdd);
        }

        public bool DeleteAdmin(Member admin)
        {
            return AdministratorList.Remove(admin);
        }
    }
}

