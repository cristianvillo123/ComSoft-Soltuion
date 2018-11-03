/*************************************************************
 * CREADO POR : GRUPO COMSOFT
 * Cristian Hernandez Villo
 * FECHA CREA : 06/09/2018
**************************************************************/

namespace ComSoft.ViewModel.EmpresaSucursal
{
    using ComSoft.Model.Business;
    using ComSoft.Model.Entity;
    using CristianHernandez;
    using CristianHernandez.WPF;
    using CristianHernandez.WPF.Controls.ModalDialog;
    using CristianHernandez.WPF.Enums.Message;
    using CristianHernandez.WPF.Enums.Notificacion;
    using CristianHernandez.WPF.Interfaces;
    using CristianHernandez.WPF.Message;
    using CristianHernandez.WPF.Notification;
    using System;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;

    public class VMPG_EmpresaSucursal : CHNavigationService, CHINavigation
    {
        public object Parameter
        {
            set
            {
                if (value is CHNavigationParameter vrCHNavigationParameter)
                {
                    Property_VisibilityNewPage = vrCHNavigationParameter.VisibilityNewPage;
                    Property_VisibilityNavigationPage = vrCHNavigationParameter.VisibilityNavigationPage;
                    Method_CargaDatos();
                }
            }
        }

        #region PROPERTY

        private bool _Property_IsIndeterminate;
        public bool Property_IsIndeterminate
        {
            get
            {
                return _Property_IsIndeterminate;
            }
            set
            {
                _Property_IsIndeterminate = value;
                OnPropertyChanged("Property_IsIndeterminate");
            }
        }

        private Visibility _Property_VisibilityNewPage;
        public Visibility Property_VisibilityNewPage
        {
            get
            {
                return _Property_VisibilityNewPage;
            }
            set
            {
                _Property_VisibilityNewPage = value;
                OnPropertyChanged("Property_VisibilityNewPage");
            }
        }

        private Visibility _Property_VisibilityNavigationPage;
        public Visibility Property_VisibilityNavigationPage
        {
            get
            {
                return _Property_VisibilityNavigationPage;
            }
            set
            {
                _Property_VisibilityNavigationPage = value;
                OnPropertyChanged("Property_VisibilityNavigationPage");
            }
        }

        #endregion

        #region COLLECTION

        private CHObservableCollection<EComSoft_EmpresaSucursal> _Collection_DatoEmpresaSucursal;
        public CHObservableCollection<EComSoft_EmpresaSucursal> Collection_DatoEmpresaSucursal
        {
            get
            {
                if (_Collection_DatoEmpresaSucursal == null)
                    _Collection_DatoEmpresaSucursal = new CHObservableCollection<EComSoft_EmpresaSucursal>();
                return _Collection_DatoEmpresaSucursal;
            }
        }

        #endregion

        #region ICOMMAND

        public ICommand IAlmacen
        {
            get
            {
                return CHICommand.GetICommand(T =>
                {
                    var inst = (EComSoft_EmpresaSucursal)T;
                    Go(CHPage.GetPage("VPG_Almacen"), new CHNavigationParameter() { Parameter = inst, TypeViewPage = CHTypeView.NavigationPage }, null, "MyFrameEmpresaSucursal");
                    Method_CargaDatos();
                });
            }
        }

        public ICommand INuevo
        {
            get
            {
                return CHICommand.GetICommand(T =>
                {
                    CHModalDialog.GetContent().ShowDialog(CHPage.GetPage("VMP_EmpresaSucursal"), new EComSoft_EmpresaSucursal() { Opcion = "I" });
                    Method_CargaDatos();
                });
            }
        }

        public ICommand IEditar
        {
            get
            {
                return CHICommand.GetICommand(T =>
                {
                    var inst = (EComSoft_EmpresaSucursal)T;
                    inst.Opcion = "U";
                    CHModalDialog.GetContent().ShowDialog(CHPage.GetPage("VMP_EmpresaSucursal"), inst);
                    Method_CargaDatos();
                });
            }
        }

        public ICommand IEliminar
        {
            get
            {
                return CHICommand.GetICommand(T =>
                {
                    CHMessageBox.Show(ComSoftMensaje.TituloDocumento, ComSoftMensajeAccion.TituloPreguntaEliminar, CHMessageTypeButton.AceptCancel, async () =>
                    {
                        await Task.Factory.StartNew(() =>
                        {
                            try
                            {
                                var inst = (EComSoft_EmpresaSucursal)T;
                                inst.Opcion = "D";
                                new BComSoft_EmpresaSucursal().SET_EmpresaSucursal(inst);
                                Method_CargaDatos();
                            }
                            catch (Exception ex)
                            {
                                CHMessageBox.Show(ComSoftMensaje.TituloDocumento, ex.Message, CHMessageTypeButton.Acept);
                            }
                        });
                    });
                });
            }
        }

        public ICommand IActualizar
        {
            get
            {
                return CHICommand.GetICommand(T =>
                {
                   Method_CargaDatos();
                });
            }
        }

        public ICommand ISalir
        {
            get
            {
                return CHICommand.GetICommand(T =>
                {
                    Back();
                });
            }
        }

        #endregion

        #region METHOD

        private async void Method_CargaDatos()
        {
            try
            {
                await Task.Factory.StartNew(() =>
                {
                    Property_IsIndeterminate = true;
                    Collection_DatoEmpresaSucursal.Sources = new BComSoft_EmpresaSucursal().GET_EmpresaSucursal();
                    Property_IsIndeterminate = false;
                });
            }
            catch (Exception ex)
            {
                Property_IsIndeterminate = false;
                CHMessageBox.Show(ComSoftMensaje.TituloEmpresaSucursal, ex.Message, CHMessageTypeButton.Acept);
            }
        }

        #endregion

    }
}
