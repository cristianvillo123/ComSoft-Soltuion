/*************************************************************
 * CREADO POR : GRUPO COMSOFT
 *              Cristian Hernandez Villo
 * FECHA CREA : 06/10/2018
**************************************************************/

namespace ComSoft.ViewModel.Cotizacion
{
    using ComSoft.Model.Business;
    using ComSoft.Model.Entity;
    using CristianHernandez;
    using CristianHernandez.WPF.Enums.Message;
    using CristianHernandez.WPF.Interfaces;
    using CristianHernandez.WPF.Message;
    using CristianHernandez.WPF.Notification;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Input;

    public class VMPG_Cotizacion : CHNavigationService, CHINavigation
    {
        private EComSoft_Cotizacion _EComSoft_Cotizacion;
        public EComSoft_Cotizacion EComSoft_Cotizacion
        {
            get
            {
                if (_EComSoft_Cotizacion == null)
                    _EComSoft_Cotizacion = new EComSoft_Cotizacion();
                return _EComSoft_Cotizacion;
            }
            set
            {
                _EComSoft_Cotizacion = value;
                OnPropertyChanged("EComSoft_Cotizacion");
            }
        }

        public object Parameter
        {
            set
            {
                if (value is EComSoft_Cotizacion vrEComSoft_Cotizacion)
                {
                    EComSoft_Cotizacion = vrEComSoft_Cotizacion;
                    Method_CargaDato();
                }
            }
        }

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

        private CHObservableCollection<EComSoft_Plazo> _Collection_DatoPlazo;
        public CHObservableCollection<EComSoft_Plazo> Collection_DatoPlazo
        {
            get
            {
                if (_Collection_DatoPlazo == null)
                    _Collection_DatoPlazo = new CHObservableCollection<EComSoft_Plazo>();
                return _Collection_DatoPlazo;
            }
        }

        private CHObservableCollection<EComSoft_FormaPago> _Collection_DatoFormaPago;
        public CHObservableCollection<EComSoft_FormaPago> Collection_DatoFormaPago
        {
            get
            {
                if (_Collection_DatoFormaPago == null)
                    _Collection_DatoFormaPago = new CHObservableCollection<EComSoft_FormaPago>();
                return _Collection_DatoFormaPago;
            }
        }

        private CHObservableCollection<EComSoft_Moneda> _Collection_DatoMoneda;
        public CHObservableCollection<EComSoft_Moneda> Collection_DatoMoneda
        {
            get
            {
                if (_Collection_DatoMoneda == null)
                    _Collection_DatoMoneda = new CHObservableCollection<EComSoft_Moneda>();
                return _Collection_DatoMoneda;
            }
        }


        #endregion

        #region PROPERTY

        private EComSoft_EmpresaSucursal _Property_SelectItemEmpresaSucursal;
        public EComSoft_EmpresaSucursal Property_SelectItemEmpresaSucursal
        {
            get
            {
                return _Property_SelectItemEmpresaSucursal;
            }
            set
            {
                _Property_SelectItemEmpresaSucursal = value;
                if (value != null)
                    Method_CargaAlmacen();
                OnPropertyChanged("Property_SelectItemEmpresaSucursal");
            }
        }

        private EComSoft_Almacen _Property_SelectItemAlmacen;
        public EComSoft_Almacen Property_SelectItemAlmacen
        {
            get
            {
                return _Property_SelectItemAlmacen;
            }
            set
            {
                _Property_SelectItemAlmacen = value;
                OnPropertyChanged("Property_SelectItemAlmacen");
            }
        }

        private EComSoft_Plazo _Property_SelectItemPlazo;
        public EComSoft_Plazo Property_SelectItemPlazo
        {
            get
            {
                return _Property_SelectItemPlazo;
            }
            set
            {
                _Property_SelectItemPlazo = value;
                OnPropertyChanged("Property_SelectItemPlazo");
            }
        }

        private EComSoft_FormaPago _Property_SelectItemFormaPago;
        public EComSoft_FormaPago Property_SelectItemFormaPago
        {
            get
            {
                return _Property_SelectItemFormaPago;
            }
            set
            {
                _Property_SelectItemFormaPago = value;
                OnPropertyChanged("Property_SelectItemFormaPago");
            }
        }

        private EComSoft_Moneda _Property_SelectItemMoneda;
        public EComSoft_Moneda Property_SelectItemMoneda
        {
            get
            {
                return _Property_SelectItemMoneda;
            }
            set
            {
                _Property_SelectItemMoneda = value;
                OnPropertyChanged("Property_SelectItemMoneda");
            }
        }

        private DateTime _Property_SelectDateFechaEmision;
        public DateTime Property_SelectDateFechaEmision
        {
            get
            {
                return _Property_SelectDateFechaEmision;
            }
            set
            {
                _Property_SelectDateFechaEmision = value;
                OnPropertyChanged("Property_SelectDateFechaEmision");
            }
        }

        private DateTime _Property_SelectDateFechaVencimiento;
        public DateTime Property_SelectDateFechaVencimiento
        {
            get
            {
                return _Property_SelectDateFechaVencimiento;
            }
            set
            {
                _Property_SelectDateFechaVencimiento = value;
                OnPropertyChanged("Property_SelectDateFechaVencimiento");
            }
        }


        #endregion

        #region ICOMMAND

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

        private async void Method_CargaDato()
        {
            await Task.Factory.StartNew(() =>
            {
                try
                {
                    #region CARGA DATOS

                    Collection_DatoEmpresaSucursal.Sources = new BComSoft_EmpresaSucursal().GET_EmpresaSucursal();
                    Collection_DatoPlazo.Sources = new BComSoft_Plazo().GET_Plazo();
                    Collection_DatoFormaPago.Sources = new BComSoft_FormaPago().GET_FormaPago();
                    Collection_DatoMoneda.Sources = new BComSoft_Moneda().GET_Moneda();

                    #endregion

                    #region SELECCION DEFECTO

                    Property_SelectItemEmpresaSucursal = (EComSoft_Cotizacion.Opcion == "U") 
                                                         ? Collection_DatoEmpresaSucursal.FirstOrDefault(x => x.IdEmpresaSucursal == EComSoft_Cotizacion.EComSoft_EmpresaSucursal.IdEmpresaSucursal) 
                                                         : Collection_DatoEmpresaSucursal.FirstOrDefault(x => x.Principal);
                    Property_SelectItemPlazo = (EComSoft_Cotizacion.Opcion == "U") 
                                               ? Collection_DatoPlazo.FirstOrDefault(x => x.IdPlazo == EComSoft_Cotizacion.EComSoft_Plazo.IdPlazo) 
                                               : Collection_DatoPlazo.FirstOrDefault();
                    Property_SelectItemFormaPago = (EComSoft_Cotizacion.Opcion == "U") 
                                                   ? Collection_DatoFormaPago.FirstOrDefault(x => x.IdFormaPago == EComSoft_Cotizacion.EComSoft_FormaPago.IdFormaPago) 
                                                   : Collection_DatoFormaPago.FirstOrDefault();
                    Property_SelectItemMoneda = (EComSoft_Cotizacion.Opcion == "U")
                                                ? Collection_DatoMoneda.FirstOrDefault(x => x.CodMoneda == EComSoft_Cotizacion.EComSoft_Moneda.CodMoneda)
                                                : Collection_DatoMoneda.FirstOrDefault(x => x.Nacional);

                    Property_SelectDateFechaEmision = (EComSoft_Cotizacion.Opcion == "U") ? EComSoft_Cotizacion.FechaEmision : DateTime.Now;
                    Property_SelectDateFechaVencimiento = (EComSoft_Cotizacion.Opcion == "U") ? EComSoft_Cotizacion.FechaVencimiento : DateTime.Now;

                    #endregion



                }
                catch (Exception ex)
                {
                    CHMessageBox.Show(ComSoftMensaje.TituloCotizacion, ex.Message, CHMessageTypeButton.Acept);
                }
            });
        }

        private async void Method_CargaAlmacen()
        {
            await Task.Factory.StartNew(() =>
            {
                try
                {
                    Collection_DatoAlmacen.Sources = new BComSoft_Almacen().GET_Almacen(Property_SelectItemEmpresaSucursal.IdEmpresaSucursal);
                    Property_SelectItemAlmacen = (EComSoft_Cotizacion.Opcion == "U") 
                                                 ? Collection_DatoAlmacen.FirstOrDefault(x => x.IdAlmacen == EComSoft_Cotizacion.EComSoft_Almacen.IdAlmacen) 
                                                 : Collection_DatoAlmacen.FirstOrDefault();
                }
                catch (Exception ex)
                {
                    CHMessageBox.Show(ComSoftMensaje.TituloCotizacion, ex.Message, CHMessageTypeButton.Acept);
                }
            });
        }

        #endregion
    }
}
