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
using BMS.DA;

namespace BMS.Client
{
    /// <summary>
    /// Interaction logic for OpdienersWindow.xaml
    /// </summary>
    public partial class OpdienersWindow : Window
    {

        BMSModelContainer _db;
        public OpdienersWindow(BMSModelContainer db)
        {
            _db = db;
            InitializeComponent();

            getdata();
        }
        void getdata() {
            lbOpdieners.ItemsSource = _db.Opdieneren.ToList();
        }
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            Opdiener o = new Opdiener();
            o.Naam = txtNaam.Text;
            _db.Opdieneren.Add(o);
            _db.SaveChanges();
            getdata();
            lbOpdieners.UpdateLayout();
        }
    }
}
