using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public sealed class Members
    {
        private static Members members = new Members();
        private ObservableCollection<Member> memberList;
        public ObservableCollection<Member> MemberList
        {
            get
            {
                return memberList;
            }

            set
            {
                memberList = value;
            }
        }

        private Members()
        {
            MemberList = new ObservableCollection<Member>();
        }

        public static Members Instance
        {
            get
            {
                return members;
            }
            set
            {
                members = value;
            }
        }

        public bool AddMember(Member memberAdd)
        {
            int i = 0;
            foreach (Member member in MemberList)
            {
                if (member.CompareTo(memberAdd) == 0) return false;
                if (member.CompareTo(memberAdd) < 0)
                {
                    MemberList.Insert(i, memberAdd);
                    return true;
                }
                i++;
            }
            MemberList.Add(memberAdd);
            return true;
        }

        public bool DeleteMember(Member member)
        {
            return MemberList.Remove(member);
        }
    }
}
