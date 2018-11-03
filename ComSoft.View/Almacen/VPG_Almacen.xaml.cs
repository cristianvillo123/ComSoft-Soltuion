using ComSoft.ViewModel.Almacen;
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

namespace ComSoft.View.Almacen
{
    /// <summary>
    /// Lógica de interacción para VPG_Almacen.xaml
    /// </summary>
    public partial class VPG_Almacen : Page
    {
        public VPG_Almacen()
        {
            InitializeComponent();
            DataContext = new VMPG_Almacen();
            Loaded += (x, y) =>
             {
                 CHPage.AddPage(new VMP_Almacen());
             };
        }
    }
}
