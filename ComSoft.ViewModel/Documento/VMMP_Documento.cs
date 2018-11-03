/**************************************************************
 * CREADO POR : CRISTIAN HERNANDEZ VILLO
 * FECHA CREA : 06/09/2018
**************************************************************/

namespace ComSoft.ViewModel.Documento
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

    public class VMMP_Documento : CHNavigationService, CHIModalDialog
    {

        private EComSoft_Documento _EComSoft_Documento;
        public EComSoft_Documento EComSoft_Documento
        {
            get
            {
                if (_EComSoft_Documento == null)
                    _EComSoft_Documento = new EComSoft_Documento();
                return _EComSoft_Documento;
            }
            set
            {
                _EComSoft_Documento = value;
                OnPropertyChanged("EComSoft_Documento");
            }
        }

        public object Parameter
        {
            set
            {
                if (value is EComSoft_Documento)
                {
                    EComSoft_Documento = (EComSoft_Documento)value;
                    Method_GET_DocumentoSunat();
                    Property_IsCheckedDocumentoElectronico = EComSoft_Documento.Sunat;
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

        private EComSoft_KeyValue _Property_SelectItemDocumentoSunat;
        public EComSoft_KeyValue Property_SelectItemDocumentoSunat
        {
            get
            {
                return _Property_SelectItemDocumentoSunat;
            }
            set
            {
                _Property_SelectItemDocumentoSunat = value;
                if (value != null)
                {
                    EComSoft_Documento.CodDocumento = value.Key;
                    EComSoft_Documento.Descripcion = value.Value;
                }
                OnPropertyChanged("Property_SelectItemDocumentoSunat");
            }
        }

        private bool _Property_IsCheckedDocumentoElectronico;
        public bool Property_IsCheckedDocumentoElectronico
        {
            get
            {
                return _Property_IsCheckedDocumentoElectronico;
            }
            set
            {
                _Property_IsCheckedDocumentoElectronico = value;
                EComSoft_Documento.Sunat = value;
                Property_IsEnableCodDocumento = !value;
                Method_GET_DocumentoSunat();
                Property_SelectItemDocumentoSunat = null;
                EComSoft_Documento.Descripcion = EComSoft_Documento.CodDocumento = string.Empty;
                OnPropertyChanged("Property_IsCheckedDocumentoElectronico");
            }
        }

        private bool _Property_IsEnableCodDocumento;
        public bool Property_IsEnableCodDocumento
        {
            get
            {
                return _Property_IsEnableCodDocumento;
            }
            set
            {
                _Property_IsEnableCodDocumento = value;
                OnPropertyChanged("Property_IsEnableCodDocumento");
            }
        }

        #endregion

        #region COLLECTION

        private CHObservableCollection<EComSoft_KeyValue> _Collection_DatosDocumentoSunat;
        public CHObservableCollection<EComSoft_KeyValue> Collection_DatosDocumentoSunat
        {
            get
            {
                if (_Collection_DatosDocumentoSunat == null)
                    _Collection_DatosDocumentoSunat = new CHObservableCollection<EComSoft_KeyValue>();
                return _Collection_DatosDocumentoSunat;
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
                            new BComSoft_Documento().SET_Documento(EComSoft_Documento);
                            Application.Current.Dispatcher.Invoke(() =>
                            {
                                CHModalDialog.GetContent().Close();
                            });
                        }
                        catch (Exception ex)
                        {
                            CHMessageBox.Show(ComSoftMensaje.TituloDocumento, ex.Message, CHMessageTypeButton.Acept);
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

        private void Method_GET_DocumentoSunat()
        {
            try
            {
                Property_IsIndeterminate = true;
                var CollectionDocumento = new CHObservableCollection<EComSoft_KeyValue>();
                CollectionDocumento.Add(new EComSoft_KeyValue() { Key = "CTZ", Value = "COTIZACIÓN" });
                CollectionDocumento.Add(new EComSoft_KeyValue() { Key = "ORC", Value = "ORDEN DE COMPRA" });
                CollectionDocumento.Add(new EComSoft_KeyValue() { Key = "ORS", Value = "ORDEN DE SERVICIO" });
                Collection_DatosDocumentoSunat.Sources = (Property_IsCheckedDocumentoElectronico) ? new BComSoft_KeyValue().GET_DocumentoSunat() : CollectionDocumento;
                Property_IsIndeterminate = false;
            }
            catch (Exception ex)
            {
                CHMessageBox.Show(ComSoftMensaje.TituloDocumento, ex.Message, CHMessageTypeButton.Acept);
                Property_IsIndeterminate = false;
            }
        }

        #endregion

    }
}
