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
using BMS.DA;

namespace BMS.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        BMSModelContainer _db;
        UserControl _uc;

        public MainWindow()
        {
            InitializeComponent();
          
        }

        private void ContentRenderd(object sender, EventArgs e)
        {
            _db = new BMSModelContainer();
            changeUI();
        }


        void changeUI(string page = "Bierkroeg")
        {
            g_Placeholder.Children.Clear();
            switch (page)
            {
                case "Producten":
                    _uc = new ProductenUC(_db);
               break;
                default:
                     _uc = new BierkroegUC(_db);
                break;
            }
            _uc.Height = g_Placeholder.Height;
            _uc.Width = g_Placeholder.Width;
            g_Placeholder.Children.Add(_uc);
        }

        private void Bierkroeg_Click(object sender, RoutedEventArgs e)
        {
            changeUI();
        }

        private void Opdieners_Click(object sender, RoutedEventArgs e)
        {
            OpdienersWindow ow = new OpdienersWindow(_db);
            ow.Show();
        }

        private void Producten_Click(object sender, RoutedEventArgs e)
        {
            changeUI("Producten");
        }
    }
}
