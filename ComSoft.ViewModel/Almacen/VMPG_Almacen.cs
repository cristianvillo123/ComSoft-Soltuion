/**************************************************************
 * CREADO POR : GRUPO COMSOFT
 *              Cristian Hernandez Villo
 * FECHA CREA : 06/09/2018
**************************************************************/

namespace ComSoft.ViewModel.Almacen
{
    using ComSoft.Model.Business;
    using ComSoft.Model.Entity;
    using CristianHernandez;
    using CristianHernandez.WPF;
    using CristianHernandez.WPF.Controls.ModalDialog;
    using CristianHernandez.WPF.Enums.Message;
    using CristianHernandez.WPF.Interfaces;
    using CristianHernandez.WPF.Message;
    using CristianHernandez.WPF.Notification;
    using System;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;

    public class VMPG_Almacen : CHNavigationService, CHINavigation
    {
        private EComSoft_EmpresaSucursal _EComSoft_EmpresaSucursal;
        public EComSoft_EmpresaSucursal EComSoft_EmpresaSucursal
        {
            get
            {
                if (_EComSoft_EmpresaSucursal == null)
                    _EComSoft_EmpresaSucursal = new EComSoft_EmpresaSucursal();
                return _EComSoft_EmpresaSucursal;
            }
            set
            {
                _EComSoft_EmpresaSucursal = value;
                OnPropertyChanged("EComSoft_EmpresaSucursal");
            }
        }

        public object Parameter
        {
            set
            {
                if (value is CHNavigationParameter vrCHNavigationParameter)
                {
                    Property_VisibilityNewPage = vrCHNavigationParameter.VisibilityNewPage;
                    Property_VisibilityNavigationPage = vrCHNavigationParameter.VisibilityNavigationPage;
                    EComSoft_EmpresaSucursal = (EComSoft_EmpresaSucursal)vrCHNavigationParameter.Parameter;
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

        private CHObservableCollection<EComSoft_Almacen> _Collection_DatoAlmacen;
        public CHObservableCollection<EComSoft_Almacen> Collection_DatoAlmacen
        {
            get
            {
                if (_Collection_DatoAlmacen == null)
                    _Collection_DatoAlmacen = new CHObservableCollection<EComSoft_Almacen>();
                return _Collection_DatoAlmacen;
            }
        }

        #endregion

        #region ICOMMAND

        public ICommand INuevo
        {
            get
            {
                return CHICommand.GetICommand(T =>
                {
                    CHModalDialog.GetContent().ShowDialog(CHPage.GetPage("VMP_Almacen"), new EComSoft_Almacen() { Opcion = "I", EComSoft_EmpresaSucursal = EComSoft_EmpresaSucursal });
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
                    var inst = (EComSoft_Almacen)T;
                    inst.Opcion = "U";
                    inst.EComSoft_EmpresaSucursal = EComSoft_EmpresaSucursal;
                    CHModalDialog.GetContent().ShowDialog(CHPage.GetPage("VMP_Almacen"), inst);
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
                    CHMessageBox.Show(ComSoftMensaje.TituloAlmacen, ComSoftMensajeAccion.TituloPreguntaEliminar, CHMessageTypeButton.AceptCancel, async () =>
                    {
                        await Task.Factory.StartNew(() =>
                        {
                            try
                            {
                                var inst = (EComSoft_Almacen)T;
                                inst.Opcion = "D";
                                new BComSoft_Almacen().SET_Almacen(inst);
                                Method_CargaDatos();
                            }
                            catch (Exception ex)
                            {
                                CHMessageBox.Show(ComSoftMensaje.TituloAlmacen, ex.Message, CHMessageTypeButton.Acept);
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
                    Collection_DatoAlmacen.Sources = new BComSoft_Almacen().GET_Almacen(EComSoft_EmpresaSucursal.IdEmpresaSucursal);
                    Property_IsIndeterminate = false;
                });
            }
            catch (Exception ex)
            {
                Property_IsIndeterminate = false;
                CHMessageBox.Show(ComSoftMensaje.TituloAlmacen, ex.Message, CHMessageTypeButton.Acept);
            }
        }

        #endregion
    }
}
