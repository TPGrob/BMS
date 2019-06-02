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
    /// Interaction logic for BierkroegWindow.xaml
    /// </summary>
    public partial class BierkroegWindow : Window
    {
        BMSModelContainer _db;

        public BierkroegWindow(BMSModelContainer db)
        {
            _db = db;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (txtBierkroegNAam.Text != "") { }
            Bierkroeg b = new Bierkroeg();
            b.Naam = txtBierkroegNAam.Text;
            _db.Bierkroegen.Add(b);
            _db.SaveChanges();

            this.Close();
        }
    }
}
