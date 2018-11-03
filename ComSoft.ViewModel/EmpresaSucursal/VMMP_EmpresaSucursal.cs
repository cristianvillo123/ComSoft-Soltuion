/*************************************************************
 * CREADO POR : GRUPO COMSOFT
 * 	            Cristian Hernandez Villo
 * FECHA CREA : 06/09/2018
**************************************************************/

namespace ComSoft.ViewModel.EmpresaSucursal
{
    using ComSoft.Model.Business;
    using ComSoft.Model.Entity;
    using CristianHernandez;
    using CristianHernandez.WPF.Controls.ModalDialog;
    using CristianHernandez.WPF.Enums.Message;
    using CristianHernandez.WPF.Interfaces;
    using CristianHernandez.WPF.Message;
    using CristianHernandez.WPF.Notification;
    using System;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;

    public class VMMP_EmpresaSucursal : CHNavigationService, CHIModalDialog
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
                if (value is EComSoft_EmpresaSucursal vrEComSoft_EmpresaSucursal)
                {
                    Property_IsIndeterminate = true;
                    EComSoft_EmpresaSucursal = vrEComSoft_EmpresaSucursal;
                    Property_IsIndeterminate = false;
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

        #endregion

        #region ICOMMAND

        public ICommand IGuardar
        {
            get
            {
                return CHICommand.GetICommand(async T =>
                {
                    await Task.Factory.StartNew(() =>
                    {
                        try
                        {
                            Property_IsIndeterminate = true;
                            Method_ValidaDatos();
                            new BComSoft_EmpresaSucursal().SET_EmpresaSucursal(EComSoft_EmpresaSucursal);
                            Property_IsIndeterminate = false;
                            Application.Current.Dispatcher.Invoke(() =>
                            {
                                CHModalDialog.GetContent().Close();
                            });
                        }
                        catch (Exception ex)
                        {
                            Property_IsIndeterminate = false;
                            CHMessageBox.Show(ComSoftMensaje.TituloEmpresaSucursal, ex.Message, CHMessageTypeButton.Acept);
                        }
                    });
                });
            }
        }

        public ICommand ISalir
        {
            get
            {
                return CHICommand.GetICommand(T =>
                {
                    CHModalDialog.GetContent().Close();
                });
            }
        }
        #endregion

        #region METHOD

        private void Method_ValidaDatos()
        {
            if (string.IsNullOrEmpty(EComSoft_EmpresaSucursal.Sucursal))
                throw new Exception("Ingrese una sucursal");
        }

        #endregion
    }
}
