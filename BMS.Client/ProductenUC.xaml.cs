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
using System.IO;

namespace BMS.Client
{
    /// <summary>
    /// Interaction logic for ProductenUC.xaml
    /// </summary>
    public partial class ProductenUC : UserControl
    {

        BMSModelContainer _db;
        Product _product = new Product();
        List<Inhoud> inhouden = new List<Inhoud>();
        bool productNieuw = true;
        bool immageSet = false;

        GridViewColumnHeader _lastHeaderClicked = null;
        ListSortDirection _lastDirection = ListSortDirection.Ascending;
        string[] headers = new string[] { "Naam", "Prijs", "categorie" };
        string[] bindings = new string[] { "ProductNaam", "Prijs", "ProductCategorie.Naam" };

        public ProductenUC(BMSModelContainer db)
        {
            _db = db;
            InitializeComponent();

            getProducten();
            getFilterCategorie();
            getCategorie();
            getBrouwerij();
            getType();
            getGisting();
            setBindings();
            setIhoud();
        }

        #region product
        void getProducten()
        {
            int categorie;
            ComboBoxItem cbi = cb_filterCategorie.SelectedItem as ComboBoxItem;
            if (cb_filterCategorie.SelectedIndex != -1)
            {
                categorie = int.Parse(cbi.Tag.ToString());
            }
            else
            {
                categorie = -1;
            }
            if (categorie == -1)
            {
                lv_producten.ItemsSource = _db.Producten.OrderBy(p => p.ProductNaam).ToList();
            }
            else
            {
                lv_producten.ItemsSource = _db.Producten.Where(p => p.ProductCategorieId == categorie).OrderBy(p => p.ProductNaam).ToList();
            }

        }
        void getFilterCategorie()
        {
            cb_filterCategorie.Items.Clear();
            ComboBoxItem cbi = new ComboBoxItem();
            cbi.Content = "Alle categorieen";
            cbi.Tag = -1;
            cb_filterCategorie.Items.Add(cbi);
            foreach (ProductCategorie px in _db.ProductCategorieen.OrderBy(p => p.Naam).ToList())
            {
                cbi = new ComboBoxItem();
                cbi.Content = px.Naam;
                cbi.Tag = px.Id;
                cb_filterCategorie.Items.Add(cbi);
            }
        }

        void getCategorie()
        {
            Boolean isBier = false;
            if (_product.GetType().Name == "Bier" || _product.GetType().BaseType.Name == "Bier") { isBier = true; }
            cb_categorie.ItemsSource = _db.ProductCategorieen.Where(p => p.Isbier == isBier).OrderBy(p => p.Naam).ToList();
            cb_categorie.IsEnabled = true;
        }

        void getBrouwerij()
        {
            cb_Brouwerij.ItemsSource = _db.Brouwerijen.OrderBy(b => b.Naam).ToList();
        }

        void getType()
        {
            cb_Type.ItemsSource = _db.BierTypes.OrderBy(t => t.Type).ToList();
        }

        void getGisting()
        {
            cb_Gisting.ItemsSource = _db.BierGistingen.OrderBy(g => g.Gisting).ToList();
        }

        void setBindings()
        {
            g_Product.DataContext = _product;
            if (_product != null)
            {
                imgEtiket.Source = DBToImage(_product.IMG);
            }
        }
        void setIhoud()
        {
            inhouden.Add(new Inhoud { name = "25cl", value = 25 });
            inhouden.Add(new Inhoud { name = "33cl", value = 33 });
            inhouden.Add(new Inhoud { name = "37.5cl", value = decimal.Parse("37,5") });
            inhouden.Add(new Inhoud { name = "75cl", value = 75 });
            cb_Inhod.ItemsSource = inhouden;
        }
        #endregion

        public byte[] imageToDB(BitmapImage imageC)
        {
            MemoryStream memStream = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageC));
            encoder.Save(memStream);
            return memStream.GetBuffer();
        }

        private static BitmapImage DBToImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();

            return image;
        }

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
        #endregion

        private void cb_categorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_categorie.SelectedItem != null && (cb_categorie.SelectedItem as ProductCategorie).Naam == "Bier")
            {
                txt_Alcohol.IsEnabled = cb_Brouwerij.IsEnabled = cb_Type.IsEnabled = cb_Inhod.IsEnabled = cb_Gisting.IsEnabled = txt_aantal.IsEnabled = true;
            }
            else
            {
                txt_Alcohol.IsEnabled = cb_Brouwerij.IsEnabled = cb_Type.IsEnabled = cb_Inhod.IsEnabled = cb_Gisting.IsEnabled = txt_aantal.IsEnabled = false;
            }
        }

        private void btn_Opslaan_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (immageSet)
                {
                    _product.IMG = imageToDB(imgEtiket.Source as BitmapImage);
                    immageSet = false;
                }
                if (productNieuw)
                {
                    _db.Producten.Add(_product);
                    productNieuw = false;
                }
                _db.SaveChanges();
            }
            catch (Exception)
            {
            }
            getProducten();
        }

        private void btn_productNieuw_Click(object sender, RoutedEventArgs e)
        {
            lv_producten.SelectedItems.Clear();
            _product = new Product();
            productNieuw = true;
            getCategorie();
            setBindings();
        }

        private void btn_bierNieuw_Click(object sender, RoutedEventArgs e)
        {
            lv_producten.SelectedItems.Clear();
            _product = new Bier();
            _product.ProductNaam = "";
            productNieuw = true;

            getCategorie();
            setBindings();
        }

        private void lv_productenSC(object sender, SelectionChangedEventArgs e)
        {
            if (lv_producten.SelectedItem != null)
            {
                _product = (lv_producten.SelectedItem as Product);
                productNieuw = false;
                getCategorie();
                setBindings();
            }
        }
        private void cb_filterCategorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            getProducten();
        }
        private void btn_ImageClick(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".jpg";
            dlg.Filter = "foto (.jpg, .png)|*.jpg; *.png|All Files (.*)|*.*";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                Uri filename = new Uri(dlg.FileName);
                imgEtiket.Source = new BitmapImage(filename);
                immageSet = true;
            }
        }

    }
}
