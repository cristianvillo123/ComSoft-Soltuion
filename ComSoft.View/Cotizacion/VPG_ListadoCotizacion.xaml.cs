using ComSoft.ViewModel.Cotizacion;
using CristianHernandez.WPF;
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
    /// Lógica de interacción para VPG_ListadoCotizacion.xaml
    /// </summary>
    public partial class VPG_ListadoCotizacion : Page
    {
        public VPG_ListadoCotizacion()
        {
            InitializeComponent();
            DataContext = new VMPG_ListadoCotizacion();
            Loaded += (x, y) => { CHPage.AddPage(new VPG_Cotizacion()); };
        }
    }
}
