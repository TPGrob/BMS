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
    /// Interaction logic for BierkroegUC.xaml
    /// </summary>
    /// 
    public partial class BierkroegUC : UserControl
    {

        BMSModelContainer _db;
        Bierkroeg _b;
        List<Bestelling> _bestellingen;

        public BierkroegUC(BMSModelContainer db)
        {
            _db = db;
            
            InitializeComponent();

            GetData();
        }

        void GetData() {

            cbBierkroeg.ItemsSource = _db.Bierkroegen.ToList();
            if (_db.Bierkroegen.Count() != 0)
            {
                cbBierkroeg.SelectedItem = _db.Bierkroegen.ToList().Last();
            }
            cbBierkroeg.UpdateLayout();

            if (_b != null) {
                gDagen.IsEnabled = true;
                foreach(Dag d in _b.Dagen)
                {
                    CheckBox cb = new CheckBox();
                    cb.Tag = d;
                    cb.Content = d.Naam;
                    cb.IsChecked = true;
                    cb.Checked += checkedChanged;
                    cb.Unchecked += checkedChanged;
                    cb.Margin = new Thickness(0, 0, 10, 0);
                    wpDagen.Children.Add(cb);
                }
            }
            else { gDagen.IsEnabled = false; }
        }
       
        private void cbBierkroeg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _b = (Bierkroeg)cbBierkroeg.SelectedItem;
        }

        private void BierkroegNieuw(object sender, RoutedEventArgs e)
        {
            BierkroegWindow bw = new BierkroegWindow(_db);
            bw.ShowDialog();

            GetData();
        }

        private void ProductenClick(object sender, RoutedEventArgs e)
        {

        }

        private void NieuweDagClick(object sender, RoutedEventArgs e)
        {
            DagenWindow bw = new DagenWindow(_db,_b);
            bw.ShowDialog();

            GetData();
        }

        private void checkedChanged( object sender, RoutedEventArgs e)
        {
            _bestellingen = new List<Bestelling>();
            foreach (CheckBox cb in wpDagen.Children) {
                if (cb.IsChecked == true)
                {
                    Dag d = (Dag)cb.Tag;
                    _bestellingen.AddRange(d.Bestellingen);
                }
            }
        }
    }
}
