using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Services
{
    /// <summary>
    /// MemberService is a singelton
    /// </summary>
    public sealed class MemberService
    {
        private static MemberService ms = new MemberService();

        private MemberService() { }

        public static MemberService Instance
        {
            get
            {
                return ms;
            }
        }
        /// <summary>
        /// Create a new member with the ctor of member and add him 
        /// in the member list
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        public Member CreateMember(string login, string password)
        {
            Member m = new Member(login, password);
            if(Members.Instance.AddMember(m))
            {
                SaveMembers save = SaveMembers.Instance;
                return m;
            }
            return null;
        }

        /// <summary>
        /// See if the login and password correspond to a member in the list
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns>If the member is authenticated </returns>
        public bool Authenticate(string login, string password)
        {
            foreach (Member member in Members.Instance.MemberList)
            {
                if (member.Login.Equals(login)) return member.Password.Equals(password);
            }
            return false;
        }

        public Member SearchMember(string login, string password)
        {
            if (Members.Instance == null) return null;
            foreach (Member member in Members.Instance.MemberList)
            {
                if (member.Login.Equals(login) && member.Password.Equals(password)) return member;
            }
            return null;
        }

        public void DownToMember(Member adminDown)
        {
            foreach (Member admin in Administrators.Instance.AdministratorList)
            {
                if (admin.CompareTo(adminDown) == 0)
                {
                    Members.Instance.AddMember((Member)adminDown);
                    AdministratorService.Instance.DeleteAdmin(adminDown);
                    return;
                }
            }
        }

        public void DeleteMember(Member m)
        {
            Members.Instance.DeleteMember(m);
        }

        public bool AddMonster(Member member, Monster monster)
        {
            return member.AddMonster((Monster)monster.Clone());
        }

        public void DeleteMonster(Member member, Monster monster)
        {
            member.DeleteMonster(monster);
        }

    }
}
