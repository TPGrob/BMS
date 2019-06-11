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

namespace BMS.Holder
{
    /// <summary>
    /// Interaction logic for Wait.xaml
    /// </summary>
    public partial class WaitUC : UserControl
    {
        public WaitUC()
        {
            InitializeComponent();
        }
        public void setError(string titel, string boodschap)
        {
            txt_titel.Content = titel;
            txt_boodschap.Content = boodschap;
            errorIMG.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
