using DAL;
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
    class CreateVM : ViewModelBase
    {
        public DelegateCommand CancelCommand { get; private set; }
        public DelegateCommand ConfirmCommand { get; private set; }
        private string _login;
        private string _password = "";
        private string _confPassword = "";
        private Member _m;

        public CreateVM()
        {
            CancelCommand = new DelegateCommand(CancelOnExecuteClick);
            ConfirmCommand = new DelegateCommand(ConfirmOnExecuteClick);
        }

        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }

        public string Login
        {
            get
            {
                return _login;
            }

            set
            {
                _login = value;
            }
        }

        public string ConfPassword
        {
            get
            {
                return _confPassword;
            }

            set
            {
                _confPassword = value;
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
                    for (int i = 0; i < Password.Length - 1; i++)
                    {
                        _pass = _pass + Password.ElementAt(i);
                    }
                    Password = _pass;
                }
                NotifyPropertyChanged("PasswordChar");
            }
        }

        public string ConfPasswordChar
        {
            get
            {
                string _pass = "";
                foreach (char c in ConfPassword)
                {
                    _pass = _pass + "*";
                }
                return _pass;
            }

            set
            {
                if (value.Length > ConfPassword.Length) ConfPassword = ConfPassword + value.Last();
                if (value.Length < ConfPassword.Length)
                {
                    string _pass = "";
                    for (int i = 0; i < ConfPassword.Length - 1; i++)
                    {
                        _pass = _pass + ConfPassword.ElementAt(i);
                    }
                    ConfPassword = _pass;
                }
                NotifyPropertyChanged("ConfPasswordChar");
            }
        }

        private void CancelOnExecuteClick(object obj)
		{
			OnClose(obj);
        }

        private void ConfirmOnExecuteClick(object obj)
        {
            if (Password != ConfPassword) MessageBox.Show("Please enter the same password twice.");
            else
            {
                _m = MemberService.Instance.CreateMember(Login, Password);
                if(_m == null)
                {
                    MessageBox.Show("This login is already used");
                    return;
                }
                LogVM.Instance.Member = _m;
                SaveMembers sa = SaveMembers.Instance;
                OnClose(obj);
            }
        }

        public void OnClose(object obj)
        {
            ButtonPressedEvent.GetInstance().OnButtonPressedHandler(EventArgs.Empty);
        }
    }
}
