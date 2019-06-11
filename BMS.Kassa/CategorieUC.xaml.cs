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
using System.Globalization;
using System.ComponentModel;

namespace BMS.Kassa
{
    /// <summary>
    /// Interaction logic for CategorieUC.xaml
    /// </summary>
    public partial class CategorieUC : UserControl
    {
        Bierkroeg _bierkroeg;
        KassaUC _kuc;
        ProductCategorie _pc;
        BMSModelContainer _db;

        public CategorieUC(Bierkroeg b, BMSModelContainer db, ProductCategorie pc,KassaUC kuc)
        {
            InitializeComponent();
            _bierkroeg = b;
            _db = db;
            _pc = pc;
            _kuc = kuc;
            ic_Producten.ItemsSource = _bierkroeg.Producten.Where(p => p.ProductCategorieId == _pc.Id).OrderBy(p => p.ProductNaam).ToList();
            
        }

        private void productClick(object sender, RoutedEventArgs e)
        {
            int id = int.Parse((sender as Button).Tag.ToString());
            Product product = _db.Producten.First(p => p.Id == id);
            _kuc.AddProduct(product);
        }

        private void productRightClick(object sender, MouseButtonEventArgs e)
        {
            int id = int.Parse((sender as Button).Tag.ToString());
            Product product = _db.Producten.First(p => p.Id == id);
            _kuc.RemoveProduct(product);
        }

        private void unload(object sender, RoutedEventArgs e)
        {
            _db.SaveChanges();
        }
      
   
}
  
}
