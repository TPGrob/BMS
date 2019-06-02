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
    /// Interaction logic for ProductenUC.xaml
    /// </summary>
    public partial class ProductenUC : UserControl
    {

        BMSModelContainer _db;

        public ProductenUC(BMSModelContainer db)
        {
            _db = db;
            InitializeComponent();
        }
    }
}
