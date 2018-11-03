/**************************************************************
 * CREADO POR : CRISTIAN HERNANDEZ VILLO
 * FECHA CREA : 06/09/2018
 * DESCRIPCION: ENTIDAD PARA LA TABLA UBIGEO
**************************************************************/

namespace ComSoft.ViewModel.Empresa
{
    using ComSoft.Model.Business;
    using ComSoft.Model.Entity;
    using CristianHernandez;
    using CristianHernandez.WPF;
    using CristianHernandez.WPF.Enums.Message;
    using CristianHernandez.WPF.Enums.Notificacion;
    using CristianHernandez.WPF.Interfaces;
    using CristianHernandez.WPF.Message;
    using CristianHernandez.WPF.Notification;
    using System;
    using System.Threading.Tasks;
    using System.Windows.Input;

    public class VMPG_Empresa : CHNavigationService, CHINavigation
    {
        public object Parameter
        {
            set { MethodCargarDatos(); }
        }

        #region COLLECTION

        private CHObservableCollection<EComSoft_Empresa> _Collection_DatoEmpresa;
        public CHObservableCollection<EComSoft_Empresa> Collection_DatoEmpresa
        {
            get
            {
                if (_Collection_DatoEmpresa == null)
                    _Collection_DatoEmpresa = new CHObservableCollection<EComSoft_Empresa>();
                return _Collection_DatoEmpresa;
            }
        }

        #endregion

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

        #endregion

        #region ICOMMAND


        public ICommand IDocumento
        {
            get
            {
                return CHICommand.GetICommand(T =>
                {
                    Go(CHPage.GetPage("VPG_Documento"), new CHNavigationParameter() { TypeViewPage = CHTypeView.NavigationPage}, null, "MyFrameEmpresa");
                });
            }
        }

        public ICommand ISucursal
        {
            get
            {
                return CHICommand.GetICommand(T =>
                {
                    Go(CHPage.GetPage("VPG_EmpresaSucursal"), new CHNavigationParameter() { TypeViewPage = CHTypeView.NavigationPage }, null, "MyFrameEmpresa");
                });
            }
        }

        public ICommand ICancelar
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


        public async void MethodCargarDatos()
        {
            await Task.Factory.StartNew(() =>
            {
                try
                {
                    Property_IsIndeterminate = true;
                    Collection_DatoEmpresa.Sources = new BComSoft_Empresa().GET_Empresa();
                    Property_IsIndeterminate = false;
                }
                catch (Exception ex)
                {
                    Property_IsIndeterminate = false;
                    CHMessageBox.Show(ComSoftMensaje.TituloEmpresa, ex.Message, CHMessageTypeButton.Acept);
                }
            });
        }

        #endregion
    }
}
