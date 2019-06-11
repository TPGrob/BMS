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

namespace BMS.Holder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BMSModelContainer _db;
        public Bierkroeg _bierkroeg;
        public Dag _dag;

        public MainWindow()
        {
            InitializeComponent();

        }
        private void ContentRenderd(object sender, EventArgs e)
        {
            try
            {
                _db = new BMSModelContainer();

                getBierkroeg();

                //setData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Fout met database", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                w_error.setError("Fout met de database", "Er kon geen verbinding gemaakt worden met de database.");

                return;
            }
            switchUC();
        }
        void getBierkroeg()
        {
            if (_db.Bierkroegen.Count() != 0)
            {
                _bierkroeg = _db.Bierkroegen.ToList().Last();
                _dag = _bierkroeg.Dagen.ToList().Last();
                this.Title = "BMS 3.0 - editie: " + _bierkroeg.Naam + " - " + _dag.Naam;
            }
            else
            {
                w_error.setError("Fout", "Er is nog geen bierkroeg editie aangemaakt.");
                return;
            }
        }
        void switchUC()
        {
            g_Placeholder.Children.Clear();
            
        }

        private void Bierkroeg_Click(object sender, RoutedEventArgs e)
        {
            BierkroegWindows bw = new BierkroegWindows(_db, this, _bierkroeg, _dag);
            bw.ShowDialog();
            this.Title = "BMS 3.0 - editie: " + _bierkroeg.Naam + " - " + _dag.Naam;
            switchUC();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {

        }
    }
}
