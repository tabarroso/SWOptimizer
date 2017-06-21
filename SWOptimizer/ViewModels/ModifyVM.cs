using Entities;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWOptimizer.ViewModels
{
    public class ModifyVM : ViewModelBase
    {

        public Monster Monster
        {
            get
            {
                return monster;
            }

            set
            {
                monster = value;
            }
        }

        private Monster monsterSave;
        private Monster monster;
        private bool isAwake;
        private bool _isClick = true;

        public ModifyVM()
        {
            isAwake = MainWindowVM.Instance.IsAwake;
            Monster = MainWindowVM.Instance.Monster;
            monsterSave = (Monster)Monster.Clone();
            CloseCommand = new DelegateCommand(CloseOnExecuteClick, CanExecuteClick);
            ConfCommand = new DelegateCommand(ConfOnExecuteClick, CanExecuteClick);
        }

        private void CloseOnExecuteClick(object obj)
        {
            if (isAwake)
            {
                MonsterService.Instance.DeleteMonsterAwake((MonsterAwake)Monster);
                MonsterService.Instance.AddMonsterAwake((MonsterAwake)monsterSave);
            }
            else
            {
                MonsterService.Instance.DeleteMonsterNonAwake((MonsterNonAwake)Monster);
                MonsterService.Instance.AddMonsterNonAwake((MonsterNonAwake)monsterSave);
            }
            MainWindowVM.Instance.Monster = monsterSave;
            OnClose(obj);
        }

        private void ConfOnExecuteClick(object obj)
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
