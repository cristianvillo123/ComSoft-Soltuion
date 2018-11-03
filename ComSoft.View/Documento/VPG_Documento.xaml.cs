using ComSoft.ViewModel.Documento;
using CristianHernandez.WPF;
using CristianHernandez.WPF.Controls.ModalDialog;
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
    /// Lógica de interacción para VPG_Documento.xaml
    /// </summary>
    public partial class VPG_Documento : Page
    {
        public VPG_Documento()
        {
            InitializeComponent();
            DataContext = new VMPG_Documento();
            Loaded += (x, y) => { CHPage.AddPage(new VMP_Documento()); };
        }
    }
}
