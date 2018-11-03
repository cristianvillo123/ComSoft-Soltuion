using ComSoft.ViewModel.Documento;
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

namespace ComSoft.View.Documento
{
    /// <summary>
    /// Lógica de interacción para VMP_Documento.xaml
    /// </summary>
    public partial class VMP_Documento : Page
    {
        public VMP_Documento()
        {
            InitializeComponent();
            DataContext = new VMMP_Documento();
        }
    }
}
