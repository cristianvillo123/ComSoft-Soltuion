using ComSoft.ViewModel.Cotizacion;
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

namespace ComSoft.View.Cotizacion
{
    /// <summary>
    /// Lógica de interacción para VPG_Cotizacion.xaml
    /// </summary>
    public partial class VPG_Cotizacion : Page
    {
        public VPG_Cotizacion()
        {
            InitializeComponent();
            DataContext = new VMPG_Cotizacion();
        }
    }
}
