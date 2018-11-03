/**************************************************************
 * CREADO POR : CRISTIAN HERNANDEZ VILLO
 * FECHA CREA : 06/09/2018
**************************************************************/

namespace ComSoft.ViewModel.Documento
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

    public class VMPG_DocumentoSerie : CHNavigationService, CHINavigation
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

        #region COLLECTION

        private CHObservableCollection<EComSoft_Documento> _Collection_DatoDocumentoSerie;
        public CHObservableCollection<EComSoft_Documento> Collection_DatoDocumentoSerie
        {
            get
            {
                if (_Collection_DatoDocumentoSerie == null)
                    _Collection_DatoDocumentoSerie = new CHObservableCollection<EComSoft_Documento>();
                return _Collection_DatoDocumentoSerie;
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

        #region ICOMMAND


        public ICommand INuevo
        {
            get
            {
                return CHICommand.GetICommand(T =>
                {
                    CHModalDialog.GetContent().ShowDialog(CHPage.GetPage("VMP_DocumentoSerie"), new EComSoft_DocumentoSerie() { Opcion = "I" });
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
                                var inst = (EComSoft_DocumentoSerie)T;
                                inst.Opcion = "D";
                                //new BComSoft_Documento().SET_Documento(inst);
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
            await Task.Factory.StartNew(() =>
            {
                try
                {
                    Property_IsIndeterminate = true;
                    Collection_DatoDocumentoSerie.Sources = new BComSoft_Documento().GET_Documento();
                    Property_IsIndeterminate = false;
                }
                catch (Exception ex)
                {
                    Property_IsIndeterminate = false;
                    CHMessageBox.Show(ComSoftMensaje.TituloDocumento, ex.Message, CHMessageTypeButton.Acept);
                }
            });
        }

        #endregion
    }
}
