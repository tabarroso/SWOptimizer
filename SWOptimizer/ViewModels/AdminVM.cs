using DAL;
using Entities;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWOptimizer.ViewModels
{
    class AdminVM : ViewModelBase
    {
        private ObservableCollection<Member> _memberList;
        private Member _member;
        public DelegateCommand PromoteCommand { get; private set; }
        public DelegateCommand SwitchCommand { get; private set; }
        public DelegateCommand DeleteCommand { get; private set; }
        private string _textPromote = "Promote";
        private string _textList = "Admins";
        private bool _isMember = true;

        public AdminVM()
        {
            MemberList = Members.Instance.MemberList;
            Member = MemberList.First();
            PromoteCommand = new DelegateCommand(PromoteOnExecuteClick);
            SwitchCommand = new DelegateCommand(SwitchOnExecuteClick);
            DeleteCommand = new DelegateCommand(DeleteOnExecuteClick);
        }

        public Member Member
        {
            get
            {
                return _member;
            }

            set
            {
                _member = value;
                NotifyPropertyChanged("Member");
            }
        }

        public ObservableCollection<Member> MemberList
        {
            get
            {
                return _memberList;
            }
            set
            {
                _memberList = value;
                NotifyPropertyChanged("MemberList");
            }
        }

        public string TextPromote
        {
            get
            {
                return _textPromote;
            }

            set
            {
                _textPromote = value;
                NotifyPropertyChanged("TextPromote");
            }
        }

        public string TextList
        {
            get
            {
                return _textList;
            }

            set
            {
                _textList = value;
                NotifyPropertyChanged("TextList");
            }
        }

        private void PromoteOnExecuteClick(object obj)
        {
            SaveAdministrators saveA;
            SaveMembers saveM;
            if (_isMember) { AdministratorService.Instance.UpToAdministrator(Member); saveM = SaveMembers.Instance; }
            else { MemberService.Instance.DownToMember(Member); saveA = SaveAdministrators.Instance; }
        }

        private void SwitchOnExecuteClick(object obj)
        {
            if(_isMember) { TextList = "Members"; TextPromote = "Demote"; _isMember = false; MemberList = Administrators.Instance.AdministratorList; }
            else { TextList = "Admins"; TextPromote = "Promote"; _isMember = true; MemberList = Members.Instance.MemberList; }
            Member = MemberList.First();
        }

        private void DeleteOnExecuteClick(object obj)
        {
            SaveAdministrators saveA;
            SaveMembers saveM;
            if (_isMember) { MemberService.Instance.DeleteMember(Member); saveM = SaveMembers.Instance; }
            else { AdministratorService.Instance.DeleteAdmin(Member); saveA = SaveAdministrators.Instance; }
        }

    }
}
