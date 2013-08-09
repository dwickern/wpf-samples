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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ViewFirstComposition
{
    /// <summary>
    /// Interaction logic for Top200View.xaml
    /// </summary>
    public partial class Top200View : UserControl
    {
        public Top200View(Top200ViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
