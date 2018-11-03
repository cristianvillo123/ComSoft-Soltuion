using ComSoft.View.Documento;
using ComSoft.View.EmpresaSucursal;
using ComSoft.ViewModel.Empresa;
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

namespace ComSoft.View.Empresa
{
    /// <summary>
    /// Lógica de interacción para VPG_Empresa.xaml
    /// </summary>
    public partial class VPG_Empresa : Page
    {
        public VPG_Empresa()
        {
            InitializeComponent();
            DataContext = new VMPG_Empresa();
            Loaded += (x, y) => 
            {
                CHPage.AddPage(new VPG_EmpresaSucursal());
                CHPage.AddPage(new VPG_Documento());
            };
        }
    }
}
