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
using System.ComponentModel;

namespace BMS.Client
{
    /// <summary>
    /// Interaction logic for BrouwerijUC.xaml
    /// </summary>
    public partial class BrouwerijUC : UserControl
    {
        BMSModelContainer _db;
        Brouwerij _brouwerij;
        Boolean _brouwerijNieuw = true;

        GridViewColumnHeader _lastHeaderClicked = null;
        ListSortDirection _lastDirection = ListSortDirection.Ascending;
        string[] headers = new string[] { "Brouwerij", "Locatie" };
        string[] bindings = new string[] { "Naam", "Locatie" };

        public BrouwerijUC(BMSModelContainer db)
        {

            _db = db;
            InitializeComponent();
            _brouwerij = new Brouwerij();
            _brouwerijNieuw = true;
            setBindings();
            getBrouwerijen();
        }
        #region Brouwerij
        void getBrouwerijen()
        {
            lv_brouwrijen.ItemsSource = _db.Brouwerijen.OrderBy(b => b.Naam).ToList();
        }

        void setBindings()
        {
            g_Brouwerij.DataContext = _brouwerij;
        }

        private void btn_brouwerijNieuw_Click(object sender, RoutedEventArgs e)
        {
            _brouwerij = new Brouwerij();
            _brouwerijNieuw = true;
            setBindings();
            getBrouwerijen();
        }
        private void lv_brouwerijSC(object sender, SelectionChangedEventArgs e)
        {
            if (lv_brouwrijen.SelectedItems.Count != -1)
            {
                _brouwerij = (lv_brouwrijen.SelectedItem as Brouwerij);
                _brouwerijNieuw = false;
                setBindings();
            }
        }

        private void btn_brouwerijOpslaan_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_brouwerijNieuw)
                {

                    _db.Brouwerijen.Add(_brouwerij);

                }
                _db.SaveChanges();
            }
            catch (Exception)
            {
            }
            getBrouwerijen();
        }
        #endregion
        #region lvsort
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
                Sort(bindings[Array.IndexOf(headers, header)], direction, lv_brouwrijen);

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
        #endregion
    }
}
