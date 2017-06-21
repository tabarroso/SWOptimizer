using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public sealed class AdministratorService
    {
        private static AdministratorService admins = new AdministratorService();

        private AdministratorService() { }

        public static AdministratorService Instance
        {
            get
            {
                return admins;
            }
        }
        /// <summary>
        /// Create a new Administrator with the ctor of Administrator and add him 
        /// in the Administrator list
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        public void CreateAdministrator(string login, string password)
        {
            Member m = new Member(login, password);
            Administrators.Instance.AddAdministrator(m);
        }

        /// <summary>
        /// Create a new administrator from a member
        /// </summary>
        /// <param name="login"></param>
        /// <returns>True or false, if the member is found</returns>
        public bool UpToAdministrator(Member memberUp)
        {
            foreach (Member member in Members.Instance.MemberList)
            {
                if (member.CompareTo(memberUp) == 0)
                {
                    Administrators.Instance.AddAdministrator(memberUp);
                    MemberService.Instance.DeleteMember(memberUp);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// See if the login and password correspond to a Administrator in the list
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns>If the Administrator is authenticated </returns>
        public bool Authenticate(string login, string password)
        {
            foreach (Member administrator in Administrators.Instance.AdministratorList)
            {
                if (administrator.Login.Equals(login)) return administrator.Password.Equals(password);
            }
            return false;
        }

        public Member SearchAdministrator(string login, string password)
        {
            if (Administrators.Instance == null) return null;
            foreach (Member admin in Administrators.Instance.AdministratorList)
            {
                if (admin.Login.Equals(login) && admin.Password.Equals(password)) return admin;
            }
            return null;
        }

        public void DeleteAdmin(Member admin)
        {
            Administrators.Instance.DeleteAdmin(admin);
        }

        public bool AddMonster(Member admin, Monster monster)
        {
            return admin.AddMonster((Monster)monster.Clone());
        }

        public void DeleteMonster(Member admin, Monster monster)
        {
            admin.DeleteMonster(monster);
        }
    }
}
