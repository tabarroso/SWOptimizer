using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ButtonPressedEvent
    {
        #region Singleton

        private static ButtonPressedEvent _evenement = new ButtonPressedEvent();
        private ButtonPressedEvent()
        {

        }

        public static ButtonPressedEvent GetInstance()
        {
            return _evenement;
        }

        #endregion

        public event EventHandler Handler;

        public void OnButtonPressedHandler(EventArgs e)
        {
            if (Handler != null)
            {
                Handler(this, e);
            }
        }

    }
}
