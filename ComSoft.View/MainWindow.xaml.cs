using ComSoft.View.Login;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ComSoft.View
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private delegate void ShowDelegate(string txt);
        ShowDelegate showDelegate;
        Thread loadingThread;
        public MainWindow()
        {
            InitializeComponent();
            showDelegate = new ShowDelegate(this.showText);
            Loaded += (x, y) =>
            {
                loadingThread = new Thread(Load);
                loadingThread.Start();
            };
           
        }
        private void showText(string txt)
        {
            txtLoading.Text = txt;
        }
        public void Load()
        {
            Thread.Sleep(1000);
            this.Dispatcher.Invoke(showDelegate, "Cargando icono...");
            Thread.Sleep(2000);
            Thread.Sleep(1000);
            this.Dispatcher.Invoke(showDelegate, "Cargando ventanas del sistema...");
            Thread.Sleep(2000);
            Thread.Sleep(1000);
            this.Dispatcher.Invoke(showDelegate, "Cargando menu del sistema...");
            Thread.Sleep(2000);
            Thread.Sleep(1000);
            this.Dispatcher.Invoke(showDelegate, "Cargando configuración...");
            Thread.Sleep(2000);
            Thread.Sleep(1000);
            this.Dispatcher.Invoke(showDelegate, "Obteniendo cadena conexión...");
            Thread.Sleep(2000);
            Thread.Sleep(1000);
            this.Dispatcher.Invoke(showDelegate, "Verificando servicios de SQL...");
            Thread.Sleep(2000);
            Thread.Sleep(1000);
            this.Dispatcher.Invoke(showDelegate, "Conectando al servidor...");
            Thread.Sleep(2000);
            Thread.Sleep(1000);
            this.Dispatcher.Invoke(showDelegate, "Obteniendo usuario...");
            Thread.Sleep(2000);
            Thread.Sleep(1000);
            this.Dispatcher.Invoke(showDelegate, "Iniciando aplicación...");
            Thread.Sleep(2000);
            Thread.Sleep(1000);
            this.Dispatcher.Invoke(showDelegate, "Abriendo ventana de inicio de sesión...");
            Thread.Sleep(2000);
            Thread.Sleep(1000);
            Application.Current.BeginInvoke(() =>
            {
                new MWLogin().Show();
                this.Close();
            });

        }
    }
}
