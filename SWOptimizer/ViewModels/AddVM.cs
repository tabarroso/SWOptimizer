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
    public class AddVM : ViewModelBase
    {
        private MonsterAwake ma;
        private MonsterNonAwake mn;
        private MonsterService monsterS = MonsterService.Instance;
        private bool _isClick = true;

        public AddVM()
        {
            Ma = new MonsterAwake();
            Mn = new MonsterNonAwake();
            ConfCommand = new DelegateCommand(ConfOnExecuteClick, CanExecuteClick);
            CloseCommand = new DelegateCommand(CloseOnExecuteClick, CanExecuteClick);
        }

        public MonsterAwake Ma
        {
            get
            {
                return ma;
            }
            set
            {
                ma = value;
            }
        }
        public MonsterNonAwake Mn
        {
            get       
            {
                return mn;
            }
            set
            {
                mn = value;
            }
        }

        private void ConfOnExecuteClick(object obj)
        {
            mn.Name = ma.Name;
            mn.MonsterN = ma.MonsterN;
            mn.Help = ma.Help;
            mn.NbStars = ma.NbStars;
            mn.NbStarsNat = ma.NbStarsNat;
            mn.Attribute = ma.Attribute;
            if (MonsterService.Instance.AddMonsterNonAwake(Mn))
            {
                if (MonsterService.Instance.AddMonsterAwake(Ma))
                {
                    SaveBestiary sb = SaveBestiary.Instance;
                    OnClose(obj);
                }
            }
            else MessageBox.Show("This Monster already exist.");
        }

        private void CloseOnExecuteClick(object obj)
        {
            OnClose(obj);
        }

        public bool CanExecuteClick(object obj)
        {
            return _isClick;
        }

        public void OnClose(object obj)
        {
            ButtonPressedEvent.GetInstance().OnButtonPressedHandler(EventArgs.Empty);
        }
    }
}
