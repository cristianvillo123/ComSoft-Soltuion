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
    using CristianHernandez.WPF.Enums.Message;
    using CristianHernandez.WPF.Interfaces;
    using CristianHernandez.WPF.Message;
    using CristianHernandez.WPF.Notification;
    using System;
    using System.Threading.Tasks;
    using System.Linq;
    using System.Windows;
    using System.Windows.Input;
    using CristianHernandez.WPF.Controls.ModalDialog;

    public class VMMP_Almacen : CHNavigationService, CHIModalDialog
    {

        private EComSoft_Almacen _EComSoft_Almacen;
        public EComSoft_Almacen EComSoft_Almacen
        {
            get
            {
                if (_EComSoft_Almacen == null)
                    _EComSoft_Almacen = new EComSoft_Almacen();
                return _EComSoft_Almacen;
            }
            set
            {
                _EComSoft_Almacen = value;
                OnPropertyChanged("EComSoft_Almacen");
            }
        }

        public object Parameter
        {
            set
            {
                if( value is EComSoft_Almacen vrEComSoft_Almacen)
                {
                    EComSoft_Almacen = vrEComSoft_Almacen;
                    Method_CargaDepartamento();
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

        #region COLLECTION

        private CHObservableCollection<EComSoft_Ubigeo> _Collection_DatoDepartamento;
        public CHObservableCollection<EComSoft_Ubigeo> Collection_DatoDepartamento
        {
            get
            {
                if (_Collection_DatoDepartamento == null)
                    _Collection_DatoDepartamento = new CHObservableCollection<EComSoft_Ubigeo>();
                return _Collection_DatoDepartamento;
            }
        }

        private CHObservableCollection<EComSoft_Ubigeo> _Collection_DatoProvincia;
        public CHObservableCollection<EComSoft_Ubigeo> Collection_DatoProvincia
        {
            get
            {
                if (_Collection_DatoProvincia == null)
                    _Collection_DatoProvincia = new CHObservableCollection<EComSoft_Ubigeo>();
                return _Collection_DatoProvincia;
            }
        }

        private CHObservableCollection<EComSoft_Ubigeo> _Collection_DatoDistrito;
        public CHObservableCollection<EComSoft_Ubigeo> Collection_DatoDistrito
        {
            get
            {
                if (_Collection_DatoDistrito == null)
                    _Collection_DatoDistrito = new CHObservableCollection<EComSoft_Ubigeo>();
                return _Collection_DatoDistrito;
            }
        }

        #endregion

        #region OBJ SECUNDARIO

        private EComSoft_Ubigeo _Property_SelectItemDepartamento;
        public EComSoft_Ubigeo Property_SelectItemDepartamento
        {
            get
            {
                return _Property_SelectItemDepartamento;
            }
            set
            {
                _Property_SelectItemDepartamento = value;
                if (value != null)
                    Method_CargaProvincia();
                OnPropertyChanged("Property_SelectItemDepartamento");
            }
        }

        private EComSoft_Ubigeo _Property_SelectItemProvincia;
        public EComSoft_Ubigeo Property_SelectItemProvincia
        {
            get
            {
                return _Property_SelectItemProvincia;
            }
            set
            {
                _Property_SelectItemProvincia = value;
                if (value != null)
                    Method_CargaDistrito();
                OnPropertyChanged("Property_SelectItemProvincia");
            }
        }

        private EComSoft_Ubigeo _Property_SelectItemDistrito;
        public EComSoft_Ubigeo Property_SelectItemDistrito
        {
            get
            {
                return _Property_SelectItemDistrito;
            }
            set
            {
                _Property_SelectItemDistrito = value;
                if (value != null)
                    EComSoft_Almacen.EComSoft_Ubigeo = value;
                OnPropertyChanged("Property_SelectItemDistrito");
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
                            Method_ValidaDatos();
                            new BComSoft_Almacen().SET_Almacen(EComSoft_Almacen);
                            Application.Current.Dispatcher.Invoke(() =>
                            {
                                CHModalDialog.GetContent().Close();
                            });
                        }
                        catch(Exception ex)
                        {
                            CHMessageBox.Show(ComSoftMensaje.TituloAlmacen, ex.Message, CHMessageTypeButton.Acept);
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

        private async void Method_CargaDepartamento()
        {
            await Task.Factory.StartNew(() =>
            {
                try
                {
                    Collection_DatoDepartamento.Sources = new BComSoft_Ubigeo().GET_Departamento();
                    if (!string.IsNullOrEmpty(EComSoft_Almacen.EComSoft_Ubigeo.CodUbigeo))
                        Property_SelectItemDepartamento = Collection_DatoDepartamento.FirstOrDefault(x => x.CodUbigeo == ((EComSoft_Almacen.Opcion == "U") ? EComSoft_Almacen.EComSoft_Ubigeo.CodUbigeo?.Substring(0, 2) : string.Empty));
                }
                catch (Exception ex)
                {
                    CHMessageBox.Show(ComSoftMensaje.TituloAlmacen, ex.Message, CHMessageTypeButton.Acept);
                }
            });
        }

        private async void Method_CargaProvincia()
        {
            await Task.Factory.StartNew(() =>
            {
                try
                {
                    Collection_DatoProvincia.Sources = new BComSoft_Ubigeo().GET_Provincia(Property_SelectItemDepartamento.CodUbigeo);
                    if (!string.IsNullOrEmpty(EComSoft_Almacen.EComSoft_Ubigeo.CodUbigeo))
                        Property_SelectItemProvincia = Collection_DatoProvincia.FirstOrDefault(x => x.CodUbigeo == ((EComSoft_Almacen.Opcion == "U") ? EComSoft_Almacen.EComSoft_Ubigeo.CodUbigeo?.Substring(0, 4) : string.Empty));
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        Collection_DatoDistrito.Clear();
                    });
                }
                catch (Exception ex)
                {
                    CHMessageBox.Show(ComSoftMensaje.TituloAlmacen, ex.Message, CHMessageTypeButton.Acept);
                }
            });
        }

        private async void Method_CargaDistrito()
        {
            await Task.Factory.StartNew(() =>
            {
                try
                {
                    Collection_DatoDistrito.Sources = new BComSoft_Ubigeo().GET_Distrito(Property_SelectItemProvincia.CodUbigeo);
                    if (!string.IsNullOrEmpty(EComSoft_Almacen.EComSoft_Ubigeo.CodUbigeo))
                        Property_SelectItemDistrito = Collection_DatoDistrito.FirstOrDefault(x => x.CodUbigeo == ((EComSoft_Almacen.Opcion == "U") ? EComSoft_Almacen.EComSoft_Ubigeo.CodUbigeo : string.Empty));
                }
                catch (Exception ex)
                {
                    CHMessageBox.Show(ComSoftMensaje.TituloAlmacen, ex.Message, CHMessageTypeButton.Acept);
                }
            });
        }

        private void Method_ValidaDatos()
        {
            if (string.IsNullOrEmpty(EComSoft_Almacen.Almacen))
                throw new Exception("Ingrese el nombre del almacén");
            if(Property_SelectItemDepartamento == null)
                throw new Exception("Seleccione un departamento");
            if (Property_SelectItemProvincia== null)
                throw new Exception("Seleccione una provincia");
            if (Property_SelectItemDistrito== null)
                throw new Exception("Seleccione un distrito");
            if (string.IsNullOrEmpty(EComSoft_Almacen.Direccion))
                throw new Exception("Ingrese la dirección del almacén");
        }

        #endregion


    }
}
