using ComSoft.ViewModel.EmpresaSucursal;
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
    /// Lógica de interacción para VMP_EmpresaSucursal.xaml
    /// </summary>
    public partial class VMP_EmpresaSucursal : Page
    {
        public VMP_EmpresaSucursal()
        {
            InitializeComponent();
            DataContext = new VMMP_EmpresaSucursal();
        }
    }
}
