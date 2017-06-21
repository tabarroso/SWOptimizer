using DAL;
using Entities;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SWOptimizer.ViewModels
{
    public sealed class MainWindowVM : ViewModelBase
    {
        private static MainWindowVM singelton = new MainWindowVM();
        private LoadBestiary _lb;
        private LoadAdministrators _la;
        private LoadMembers _lm;
        public DelegateCommand AddCommand { get; private set; }
        public DelegateCommand LogCommand { get; private set; }
        public DelegateCommand DeleteCommand { get; private set; }
        public DelegateCommand Awake { get; private set; }
        public DelegateCommand ModifyCommand { get; private set; }
        public DelegateCommand AddListCommand { get; private set; }
        public DelegateCommand MyMonstersCommand { get; private set; }
        public DelegateCommand AdminCommand { get; private set; }
        private ObservableCollection<Monster> listMonster;
        private Monster _m;
        private string _textButton="AWAKE";
        private string _logButton = "LOGIN";
        private string _pseudo;
        private bool _IsAwake = false;
        private Add _aview;
        private Modify _mview;
        private Log _lview;
        private AdminView _adminview;
        private bool _IsVisible;
        private bool _isClick;
        private bool _memberVisibility = false;
        private bool _adminVisibility = false;
        private bool _isMyList = false;
        private Member _member;
        private Member _admin;

        private MainWindowVM()
        {
            _lb = LoadBestiary.Instance;
            _la = LoadAdministrators.Instance;
            _lm = LoadMembers.Instance;
            ListMonster = BestiaryNonAwake.Instance.ListBestiary;
            AddCommand = new DelegateCommand(AddOnExecuteClick);
            Awake = new DelegateCommand(AwakeOnExecuteClick);
            DeleteCommand = new DelegateCommand(DeleteOnExecuteClick, CanExecuteClick);
            ModifyCommand = new DelegateCommand(ModifyOnExecuteClick, CanExecuteClick);
            AddListCommand = new DelegateCommand(AddListOnExecuteClick);
            LogCommand = new DelegateCommand(LogOnExecuteClick);
            MyMonstersCommand = new DelegateCommand(MyMonstersOnExecuteClick);
            AdminCommand = new DelegateCommand(SeeMembersOnExecuteClick);
            IsVisible = true;
            _isClick = true;
            _aview = new Add();
            _lview = new Log();
            _adminview = new AdminView();
            Monster = BestiaryNonAwake.Instance.ListBestiary.First();
        }

        public static MainWindowVM Instance
        {
            get
            {
                return singelton;
            }
            set
            {
                singelton = value;
            }
        }

        public bool IsAwake
        {
            get
            {
                return _IsAwake;
            }
            set
            {
                _IsAwake = value;
                NotifyPropertyChanged("IsAwake");
            }
        }
        public bool IsVisible
        {
            get
            {
                return _IsVisible;
            }

            set
            {
                _IsVisible = value;
                NotifyPropertyChanged("IsVisible");
            }
        }

        public string TextButton
        {
            get
            {
                return _textButton;
            }
            set
            {
                _textButton = value;
                NotifyPropertyChanged("TextButton");
            }
        }

        public string LogButton
        {
            get
            {
                return _logButton;
            }
            set
            {
                _logButton = value;
                NotifyPropertyChanged("LogButton");
            }
        }

        public ObservableCollection<Monster> ListMonster
        {
            get
            {
                return listMonster;
            }
            set
            {
                listMonster = value;
                NotifyPropertyChanged("ListMonster");
            }
        }

        public Monster Monster
        {
            get
            {
                return _m;
            }
            set
            {
                _m = value;
                NotifyPropertyChanged("Monster");
            }
        }

        public bool IsClick
        {
            get
            {
                return _isClick;
            }
            set
            {
                _isClick = value;
                NotifyPropertyChanged("IsClick");
            }
        }

        public bool MemberVisibility
        {
            get
            {
                return _memberVisibility;
            }

            set
            {
                _memberVisibility = value;
                NotifyPropertyChanged("MemberVisibility");
            }
        }

        public bool AdminVisibility
        {
            get
            {
                return _adminVisibility;
            }

            set
            {
                _adminVisibility = value;
                NotifyPropertyChanged("AdminVisibility");
            }
        }

        public string Pseudo
        {
            get
            {
                return _pseudo;
            }

            set
            {
                _pseudo = value;
                NotifyPropertyChanged("Pseudo");
            }
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
            }
        }

        public Member Admin
        {
            get
            {
                return _admin;
            }

            set
            {
                _admin = value;
            }
        }

        public bool IsMyList
        {
            get
            {
                return _isMyList;
            }

            set
            {
                _isMyList = value;
            }
        }

        private void LogOnExecuteClick(object obj)
        {
            if (LogButton == "LOGIN")
            {
                try
                {
                    _lview.Show();
                }
                catch
                {
                    _lview = new Log();
                    _lview.Show();
                }
                ButtonPressedEvent.GetInstance().Handler += OnCloseLog;
                return;
            }
            LogButton = "LOGIN";
            TextButton = "AWAKE";
            ListMonster = BestiaryNonAwake.Instance.ListBestiary;
            LogVM.Instance.Member = null;
            LogVM.Instance.Admin = null;
            LogVM.Instance.Password = "";
            Pseudo = "";
            MemberVisibility = false;
            AdminVisibility = false;
            
        }

        private void OnCloseLog (object sender, EventArgs e)
        {
            _lview.Close();
            if (LogVM.Instance.Member != null) { MemberVisibility = true; Member = LogVM.Instance.Member; Pseudo = LogVM.Instance.Member.Login; LogButton = "LOGOUT"; }
            if (LogVM.Instance.Admin != null) { MemberVisibility = true;  AdminVisibility = true; Admin = LogVM.Instance.Admin; Pseudo = LogVM.Instance.Admin.Login; LogButton = "LOGOUT"; }
            ButtonPressedEvent.GetInstance().Handler -= OnCloseLog;
        }

        private void AddListOnExecuteClick(object obj)
        {
            SaveMembers saveM;
            if (!AdminVisibility) { if (!MemberService.Instance.AddMonster(Member, Monster)) MessageBox.Show("This monster is already in your list"); saveM = SaveMembers.Instance; return; }
            if (!AdministratorService.Instance.AddMonster(Admin, Monster)) MessageBox.Show("This monster is already in your list");
            SaveAdministrators saveA = SaveAdministrators.Instance;
        }


        private void OnClose(object sender, EventArgs e)
        {
            _aview.Close();
            ButtonPressedEvent.GetInstance().Handler -= OnClose;
        }

        private void AddOnExecuteClick(object obj)
        {
            try
            {
                _aview.Show();
            }
            catch
            {
                _aview = new Add();
                _aview.Show();
            }

            ButtonPressedEvent.GetInstance().Handler += OnClose;
        }

        private void ModifyOnExecuteClick(object obj)
        {
            if (Monster != null)
            {
                _mview = new Modify();
                _mview.Show();
                ButtonPressedEvent.GetInstance().Handler += OnCloseModify;
            }
            else
            {
                MessageBox.Show("Select a monster.");
            }

        }

        private void AwakeOnExecuteClick(object obj)
        {
            IsMyList = false;
            if (!IsAwake)
            {
                TextButton = "NON-AWAKE";
                IsAwake = true;
                Monster = MonsterService.Instance.SearchMonsterAwake(Monster);
                ListMonster = BestiaryAwake.Instance.ListBestiary;
            }
            else
            {
                TextButton = "AWAKE";
                IsAwake = false;
                Monster = MonsterService.Instance.SearchMonsterNonAwake(Monster);
                ListMonster = BestiaryNonAwake.Instance.ListBestiary;
            }
        }

        private void DeleteOnExecuteClick(object obj)
        {
            if (Monster != null)
            {
                if (IsMyList)
                {
                    if (!AdminVisibility) { MemberService.Instance.DeleteMonster(Member, Monster); SaveMembers sa = SaveMembers.Instance; }
                    else { AdministratorService.Instance.DeleteMonster(Admin, Monster); SaveAdministrators sa = SaveAdministrators.Instance; }
                }
                else
                {
                    if (IsAwake)
                    {
                        MonsterService.Instance.DeleteMonsterNonAwake(MonsterService.Instance.SearchMonsterNonAwake(Monster));
                        MonsterService.Instance.DeleteMonsterAwake(MonsterService.Instance.SearchMonsterAwake(Monster));
                    }
                    else
                    {
                        MonsterService.Instance.DeleteMonsterAwake(MonsterService.Instance.SearchMonsterAwake(Monster));
                        MonsterService.Instance.DeleteMonsterNonAwake(MonsterService.Instance.SearchMonsterNonAwake(Monster));
                    }
                    SaveBestiary sb = SaveBestiary.Instance;
                }
            }
            else
            {
                MessageBox.Show("Select a monster.");
            }
        }

        private void MyMonstersOnExecuteClick(object obj)
        {
            IsMyList = true;
            if (LogVM.Instance.Admin == null) ListMonster = LogVM.Instance.Member.MyMonsters;
            else ListMonster = LogVM.Instance.Admin.MyMonsters;
        }

        private void SeeMembersOnExecuteClick(object obj)
        {
            try
            {
                _adminview.Show();
            }
            catch
            {
                _adminview = new AdminView();
                _adminview.Show();
            }
            ButtonPressedEvent.GetInstance().Handler += OnCloseAdmin;

        }

        public bool CanExecuteClick(object obj)
        {
            return _isClick;
        }

        public void OnCloseModify(object sender, EventArgs e)
        {
            _mview.Close();
            ButtonPressedEvent.GetInstance().Handler -= OnCloseModify;
        }

        public void OnCloseAdmin(object sender, EventArgs e)
        {
            _adminview.Close();
            ButtonPressedEvent.GetInstance().Handler -= OnCloseAdmin;
        }
    }


}
