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
using System.Printing;
using BMS.DA;

namespace BMS.Kassa
{
   
    public partial class KassaUC : UserControl
    {
        BMSModelContainer _db;
        Bestelling _bestelling = new Bestelling();
        Bierkroeg _bierkroeg;
        Dag _dag;
        public KassaUC(Bierkroeg b, BMSModelContainer db, Dag d)
        {
            InitializeComponent();

            _bierkroeg = b;
            _dag = d;
            _db = db;

            //_db.Configuration.AutoDetectChangesEnabled = true;

            getData();
        }
        void getData()
        {
            //_db = new BMSModelContainer();
            _bierkroeg = _db.Bierkroegen.First(b => b.Id == _bierkroeg.Id);
            getCategorieen();
        }
        void setBindings()
        {
            ic_Producten.ItemsSource = _bestelling.BestellingPrutucten.OrderBy(b => b.Product.ProductCategorie.Id).OrderBy(b => b.Product.ProductNaam);
            ic_Producten.Items.Refresh();
        }
        void getCategorieen()
        {
            tc_Producten.Items.Clear();
            foreach (ProductCategorie pc in _db.ProductCategorieen.ToList())
            {
                TabItem ti = new TabItem();
                ti.Header = pc.Naam;
                ti.Padding = new Thickness(15, 10, 15, 10);
                ti.Margin = new Thickness(0, 0, 5, 0);
                Grid g = new Grid();
                g.Children.Add(new CategorieUC(_bierkroeg, _db, pc, this));
                ti.Content = g;
                tc_Producten.Items.Add(ti);
            }
        }
        public void AddProduct(Product p)
        {
            if (p.GetType().Name == "Bier" || p.GetType().BaseType.Name == "Bier")
            {
                Bier b = p as Bier;

                //MessageBox.Show(b.Aantal.ToString() );
                if (b.Aantal != 0)
                {
                    b.Aantal--;
                }
                else
                {
                    MessageBox.Show(p.ProductNaam + " is niet meer vooradig", "Niet in vooraad", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }

            bool nieuw = true;

            foreach (BestellingProtuct bp in _bestelling.BestellingPrutucten)
            {
                if (bp.Product == p)
                {
                    bp.Aantal++;
                    bp.Totaal = (p.Prijs * bp.Aantal);
                    nieuw = false;
                    break;
                }

            }
            if (nieuw)
            {
                BestellingProtuct bp = new BestellingProtuct();
                bp.Product = p;
                bp.Aantal = 1;
                bp.Totaal = (p.Prijs * bp.Aantal);
                _bestelling.BestellingPrutucten.Add(bp);
            }



            totaalPrijs();
            setBindings();
        }
        public void RemoveProduct(Product p)
        {

            foreach (BestellingProtuct bp in _bestelling.BestellingPrutucten)
            {
                if (bp.Product == p)
                {
                    if (p.GetType().Name == "Bier" || p.GetType().BaseType.Name == "Bier")
                    {
                        Bier b = p as Bier;
                        b.Aantal++;
                    }
                    if (bp.Aantal > 1)
                    {
                        bp.Aantal--;
                        bp.Totaal = (p.Prijs * bp.Aantal);

                    }
                    else
                    {
                        _bestelling.BestellingPrutucten.Remove(bp);
                    }

                    break;
                }
            }
            totaalPrijs();
            setBindings();
        }

        void totaalPrijs()
        {
            int totaalaantal = 0;
            decimal totaal = 0;
            foreach (BestellingProtuct bp in _bestelling.BestellingPrutucten)
            {
                totaal += bp.Totaal;
                totaalaantal += bp.Aantal;
            }
            _bestelling.Totaal = totaal;
            lbl_Aantal.Content = totaalaantal;
            lbl_totaal.Content = "€ " + totaal.ToString();
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_bestelling.BestellingPrutucten.Count > 0)
                {
                    
                    _bestelling.Tafel = tafelnr.Text;
                    _bestelling.Dag = _dag;
                    _bestelling.OpdienerId = 1;
                    _bestelling.IsPrinted = false;
                    _bestelling.IsBezorcht = false;
                    _bestelling.IsKlaarKeuken = false;
                    _bestelling.TS = DateTime.Now.ToString();
                    _bestelling.IsBezorchtTS = "";
                    _bestelling.IsKlaarKeukenTS = "";

                    _db.Bestellingen.Add(_bestelling);
                    _db.SaveChanges();

                                         

                    

                    _bestelling = new Bestelling();
                    tafelnr.Text = "";
                    setBindings();
                    totaalPrijs();
                    getData();
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }


     
        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            foreach (BestellingProtuct bp in _bestelling.BestellingPrutucten)
            {
                if (bp.Product.GetType().Name == "Bier" || bp.Product.GetType().BaseType.Name == "Bier")
                {
                    Bier b = bp.Product as Bier;
                    b.Aantal += bp.Aantal;
                }
            }
            _bestelling = new Bestelling();
            setBindings();
            totaalPrijs();
            getData();
        }

        private void RemoveProductFromList(object sender, MouseButtonEventArgs e)
        {
            RemoveProduct((sender as Grid).Tag as Product);
        }
    }
}
