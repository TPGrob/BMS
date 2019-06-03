﻿using System;
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
        public System.Windows.Threading.DispatcherTimer dispatcherTimer ;

        public BierkroegUC(BMSModelContainer db)
        {
            _db = db;
            
            InitializeComponent();
            
            GetData();
            setStats();
            setVerkoop();
          
           
            
        }

        void GetData() {

            cbBierkroeg.ItemsSource = _db.Bierkroegen.ToList();
            if (_db.Bierkroegen.Count() != 0)
            {
                cbBierkroeg.SelectedItem = _db.Bierkroegen.ToList().Last();
            }
            cbBierkroeg.UpdateLayout();

          
        }
        void setData() {
            if (_b != null)
            {
                gDagen.IsEnabled = true;
                wpDagen.Children.Clear();
                foreach (Dag d in _b.Dagen)
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
            setStats();
        }

        void setStats()
        {
            lblOpdieners.Content = _b.Opdieners.Count().ToString();
            lblAantalDagen.Content = _b.Dagen.Count.ToString();
            lblBieren.Content = _b.Producten.Where(p => p.ProductCategorieId == 1).Count().ToString();
            lblProducten.Content = _b.Producten.Count().ToString();
        }

        void setVerkoop()
        {
            Bierkroeg bk = _db.Bierkroegen.First(b => b.Id == _b.Id);
            List<Dag> dagen = new List<Dag>();
            List<Bestelling> bestellingen = new List<Bestelling>();
            int aantalbestelingen = 0;
            int bieren = 0;
            int keuken = 0;
            int andere = 0;
            decimal totaal_verkocht = 0;

            foreach (CheckBox cb in wpDagen.Children)
            {
                if (cb.IsChecked == true)
                {
                    dagen.Add((Dag)cb.Tag);
                }
            }


            foreach (Dag d in bk.Dagen)
            {
                if (dagen.Contains(d))
                {
                    bestellingen.AddRange(d.Bestellingen);
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

            lblVerkopen.Content = aantalbestelingen.ToString();
            lblBierenVerkoop.Content = bieren.ToString();
            lblAndereVerkoop.Content = andere.ToString();
            lblKeukenVerkoop.Content = keuken.ToString();
            lblOmzet.Content = "€ " + totaal_verkocht.ToString();
        }

        private void cbBierkroeg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _b = (Bierkroeg)cbBierkroeg.SelectedItem;
            setData();

        }

        private void BierkroegNieuw(object sender, RoutedEventArgs e)
        {
            BierkroegWindow bw = new BierkroegWindow(_db);
            bw.ShowDialog();
            _
            GetData();

        }

        private void ProductenClick(object sender, RoutedEventArgs e)
        {
            BierkoregProductenWindow bpw = new BierkoregProductenWindow(_db, _b);
            bpw.ShowDialog();
            setStats();

        }

        private void NieuweDagClick(object sender, RoutedEventArgs e)
        {
            DagenWindow bw = new DagenWindow(_db,_b);
            bw.ShowDialog();

            setData();
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

        private void opdienersClick(object sender, RoutedEventArgs e)
        {
            OpdienersWindow ow = new OpdienersWindow(_db, _b);
            ow.ShowDialog();
            GetData();
            setStats();
        }

        private void refreshStart(object sender, RoutedEventArgs e)
        {
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1);
            dispatcherTimer.Start();
        }

        private void refreshStop(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {

            setVerkoop();
        }
    }
}
