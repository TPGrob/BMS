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
    /// Interaction logic for DagenWindow.xaml
    /// </summary>
    public partial class DagenWindow : Window
    {
        BMSModelContainer _db;
        Bierkroeg _b;

        public DagenWindow(BMSModelContainer db, Bierkroeg b)
        {
            _db = db;
            _b = b;
            InitializeComponent();
            this.Title = "Nieuwe dag : " + _b.Naam;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (txtBierkroegNAam.Text != "")
            {
                Dag d = new Dag();
                d.Naam = txtBierkroegNAam.Text;
                d.TS = DateTime.Now.ToString();
                d.Bierkroeg = _b;

                _db.Dagen.Add(d);
                _db.SaveChanges();

                this.Close();
            }
        }
    }
}
