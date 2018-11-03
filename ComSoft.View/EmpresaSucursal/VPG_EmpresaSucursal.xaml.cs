using ComSoft.View.Almacen;
using ComSoft.View.Documento;
using ComSoft.ViewModel.EmpresaSucursal;
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

namespace ComSoft.View.EmpresaSucursal
{
    /// <summary>
    /// Lógica de interacción para VPG_EmpresaSucursal.xaml
    /// </summary>
    public partial class VPG_EmpresaSucursal : Page
    {
        public VPG_EmpresaSucursal()
        {
            InitializeComponent();
            DataContext = new VMPG_EmpresaSucursal();
            Loaded += (x, y) => 
            {
                CHPage.AddPage(new VMP_EmpresaSucursal());
                CHPage.AddPage(new VPG_Almacen());
            };
        }
    }
}
