using SWOptimizer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SWOptimizer
{
    /// <summary>
    /// Logique d'interaction pour AdminView.xaml
    /// </summary>
    public partial class AdminView : Window
    {
        private AdminVM _adVM;
        public AdminView()
        {
            InitializeComponent();
            _adVM = new AdminVM();
            DataContext = _adVM;
        }
    }
}
