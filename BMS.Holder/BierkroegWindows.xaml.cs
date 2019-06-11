using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BMS.DA;

namespace BMS.Holder
{
    /// <summary>
    /// Interaction logic for BierkroegWindows.xaml
    /// </summary>
    public partial class BierkroegWindows : Window
    {
        MainWindow _mw;
        BMSModelContainer _db;
        Bierkroeg _b;
        Dag _d; 
        public BierkroegWindows(BMSModelContainer db, MainWindow mw, Bierkroeg b, Dag d)
        {
            _db = db;
            _mw = mw;
            _b = b;
            _d = d;

            InitializeComponent();
            cbBierkroegen.ItemsSource = _db.Bierkroegen.ToList();
            if (cbBierkroegen.Items.Count != 0 && _b != null)
            {
                cbBierkroegen.SelectedItem = _b; ;
                cbDag.ItemsSource = _b.Dagen.ToList();

                if (cbDag.Items.Count != 0 && _d != null)
                {
                    cbDag.SelectedItem = _d;
                }
            }
        }

     

        private void cbBierkroegen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _b = (Bierkroeg)cbBierkroegen.SelectedItem;
            cbDag.ItemsSource = _b.Dagen.ToList();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (cbDag.SelectedItem != null)
            {
                _mw._dag = (Dag)cbDag.SelectedItem;
                _mw._bierkroeg = (Bierkroeg)cbBierkroegen.SelectedItem;
                this.Close();
            }
        }
    }
}
