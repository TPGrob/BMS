using BMS.DA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace BMS.Client
{
    /// <summary>
    /// Interaction logic for BierkoregProductenWindow.xaml
    /// </summary>
    public partial class BierkoregProductenWindow : Window
    {
        BMSModelContainer _db;
        Bierkroeg _b;

        GridViewColumnHeader _lastHeaderClicked = null;
        ListSortDirection _lastDirection = ListSortDirection.Descending;
        string[] headers = new string[] { "Naam", "categorie" };
        string[] bindings = new string[] { "ProductNaam", "ProductCategorie.Naam" };

        public BierkoregProductenWindow(BMSModelContainer db, Bierkroeg b)
        {
            _db = db;
            _b = b;

            InitializeComponent();
            this.Title = "Bierkroeg Producten : " + _b.Naam;

            getData();
        }
        void getData()
        {
            getProducten();
        }

        void getProducten()
        {
            lv_producten.ItemsSource = _db.Producten.OrderBy(p => p.ProductNaam).ToList();

            for (int i = 0; i < lv_producten.Items.Count; i++)
            {
                if (_b.Producten.Contains((Product)lv_producten.Items[i]))
                {
                    lv_producten.SelectedItems.Add((Product)lv_producten.Items[i]);
                }
            }
            
        }

        private void GridViewColumnHeaderClickedHandler(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader headerClicked = e.OriginalSource as GridViewColumnHeader;
            ListSortDirection direction;

            if (headerClicked != null)
            {
                if (headerClicked != _lastHeaderClicked)
                {
                    direction = ListSortDirection.Ascending;
                }
                else
                {
                    if (_lastDirection == ListSortDirection.Ascending)
                    {
                        direction = ListSortDirection.Descending;
                    }
                    else
                    {
                        direction = ListSortDirection.Ascending;
                    }
                }
                string header = headerClicked.Column.Header.ToString();
                Sort(bindings[Array.IndexOf(headers, header)], direction, lv_producten);

                _lastHeaderClicked = headerClicked;
                _lastDirection = direction;
            }
        }
        private void Sort(string sortBy, ListSortDirection direction, ListView lv)
        {
            lv.Items.SortDescriptions.Clear();
            SortDescription sd = new SortDescription(sortBy, direction);
            lv.Items.SortDescriptions.Add(sd);
            lv.Items.Refresh();
        }

        public void save()
        {
                _b.Producten.Clear();
                foreach (Product p in lv_producten.SelectedItems)
                {
                    _b.Producten.Add(p);
                }
                _db.SaveChanges();
        
        }
        private void Unload(object sender, RoutedEventArgs e)
        {
            save();
        }
    }
}
