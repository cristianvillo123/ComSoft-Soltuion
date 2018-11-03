using ComSoft.ViewModel.Almacen;
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

namespace ComSoft.View.Almacen
{
    /// <summary>
    /// Lógica de interacción para VMP_Almacen.xaml
    /// </summary>
    public partial class VMP_Almacen : Page
    {
        public VMP_Almacen()
        {
            InitializeComponent();
            DataContext = new VMMP_Almacen();
        }
    }
}
