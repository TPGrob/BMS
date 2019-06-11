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
using System.Threading;
using BMS.DA;

namespace BMS.Holder
{
    /// <summary>
    /// Interaction logic for StatsUC.xaml
    /// </summary>
    public partial class StatsUC : UserControl
    {
        BMSModelContainer _db;
        Bierkroeg _b;
        public StatsUC(BMSModelContainer db, Bierkroeg bierkroeg)
        {

            _db = db;
            _b = bierkroeg;

            InitializeComponent();

            _b = _db.Bierkroegen.First(b => b.Id == _b.Id);
            
            WpDagen.Children.Clear();
            foreach (Dag d in _b.Dagen)
            {
                CheckBox cb = new CheckBox();
                cb.Tag = d;
                cb.Content = d.Naam;
                Color color = (Color)ColorConverter.ConvertFromString("#FFAAAAAA");
                cb.Foreground = new System.Windows.Media.SolidColorBrush(color);
              
                cb.IsChecked = true;
                cb.Margin = new Thickness(10);
                WpDagen.Children.Add(cb);
            }

            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1);
            dispatcherTimer.Start();
        }

        void setVerkoop()
        {
            using (BMSModelContainer db = new BMSModelContainer())
            {
                //db.Configuration.LazyLoadingEnabled = true;
                Bierkroeg _bk = db.Bierkroegen.First(b => b.Id == _b.Id);

                List<Dag> dagen = new List<Dag>();
                List<Bestelling> bestellingen = new List<Bestelling>();
                int aantalbestelingen = 0;
                int bieren = 0;
                int keuken = 0;
                int andere = 0;
                decimal totaal_verkocht = 0;

                foreach (CheckBox cb in WpDagen.Children)
                {
                    if (cb.IsChecked == true)
                    {
                        Dag d = (Dag)cb.Tag;
                        bestellingen.AddRange(d.Bestellingen.ToList());
                    }
                }

                foreach (Bestelling b in bestellingen)
                {
                    foreach (BestellingProtuct p in b.BestellingPrutucten)
                    {
                        if (p.Product.ProductCategorie.Id == 1)
                        {
                            bieren += p.Aantal;
                        }
                        if (p.Product.ProductCategorie.Id == 2)
                        {
                            andere += p.Aantal;
                        }
                        if (p.Product.ProductCategorie.Id == 3)
                        {
                            keuken += p.Aantal;
                        }

                    }
                    totaal_verkocht += b.Totaal;
                    aantalbestelingen += 1;
                }

                lblBestelingen.Content = aantalbestelingen.ToString();
                lblBieren.Content = bieren.ToString();
                lblAndereDranken.Content = andere.ToString();
                lblKeuken.Content = keuken.ToString();
                lblTotaal.Content = "€ " + totaal_verkocht.ToString();
            }


        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            setVerkoop();
        }
    }
}
