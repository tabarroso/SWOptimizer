using Entities;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SWOptimizer.ViewModels
{
    public sealed class LogVM : ViewModelBase
    {
        private static LogVM singelton = new LogVM();
        public DelegateCommand CancelCommand { get; private set; }
        public DelegateCommand CreateCommand { get; private set; }
        public DelegateCommand AnonymCommand { get; private set; }
        private AdminView _mwv;
        private CreateAccount _cv;
        private string login;
        private string password = "";
        private Member _member;
        private Member _admin;
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

        public static LogVM Instance
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

        public string PasswordChar
        {
            get
            {
                string _pass = "";
                foreach (char c in Password)
                {
                    _pass = _pass + "*";
                }
                return _pass;
            }

            set
            {
                if (value.Length > Password.Length) Password = Password + value.Last();
                if (value.Length < Password.Length)
                {
                    string _pass = "";
                    for(int i = 0; i<Password.Length-1; i++)
                    {
                        _pass = _pass + Password.ElementAt(i);
                    }
                    Password = _pass;
                }
                NotifyPropertyChanged("PasswordChar");
            }
        }

        private LogVM()
        {
            CreateCommand = new DelegateCommand(CreateOnExecuteclick);
            CancelCommand = new DelegateCommand(CancelOnExecuteClick);
            ConfCommand = new DelegateCommand(ConfOnExecuteClick);
            AnonymCommand = new DelegateCommand(AnonymOnExecuteClick);
            _mwv = new AdminView();
            _cv = new CreateAccount();

        }
        
        private void CancelOnExecuteClick(object obj)
        {
            Login = "";
            Password = "";
            OnClose(obj);
        }

         private void CreateOnExecuteclick(object obj)
        {
            try
            {
                _cv.Show();
            }
            catch
            {
                _cv = new CreateAccount();
                _cv.Show();
            }
            ButtonPressedEvent.GetInstance().Handler += OnCloseCreate;
        }

        private void ConfOnExecuteClick(object obj)
        {
            if (Login == null || Password == null) MessageBox.Show("Please enter a login and a password.");
            else
            {
                if (MemberService.Instance.Authenticate(Login, Password))
                {
                     _member = MemberService.Instance.SearchMember(Login, Password);
                    OnClose(obj);
                    return;
                }
                if (AdministratorService.Instance.Authenticate(Login, Password))
                {
                    _admin = AdministratorService.Instance.SearchAdministrator(Login, Password);
                    OnClose(obj);
                    return;
                }
                else MessageBox.Show("Invalid login or password.");
            }
        }

        public void AnonymOnExecuteClick(object obj)
        {
            Member = null;
            Admin = null;
            OnClose(obj);
        }

        public void OnCloseCreate(object sender, EventArgs e)
        {
            _cv.Close();
            ButtonPressedEvent.GetInstance().Handler -= OnCloseCreate;
        }

        public void OnCloseCancel(object sender, EventArgs e)
        {
            _mwv.Close();
            ButtonPressedEvent.GetInstance().OnButtonPressedHandler(EventArgs.Empty);
        }

        public void OnClose(object obj)
        {
            ButtonPressedEvent.GetInstance().OnButtonPressedHandler(EventArgs.Empty);
        }

    }
}
