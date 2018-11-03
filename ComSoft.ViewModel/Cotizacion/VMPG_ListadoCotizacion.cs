/*************************************************************
 * CREADO POR : GRUPO COMSOFT
 *              Cristian Hernandez Villo
 * FECHA CREA : 06/10/2018
**************************************************************/

namespace ComSoft.ViewModel.Cotizacion
{
    using ComSoft.Model.Entity;
    using CristianHernandez;
    using CristianHernandez.WPF;
    using CristianHernandez.WPF.Interfaces;
    using CristianHernandez.WPF.Notification;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;

    public class VMPG_ListadoCotizacion : CHNavigationService, CHINavigation
    {
        public object Parameter
        {
            set
            {
            }
        }

        #region ICOMMAND

        public ICommand INuevo
        {
            get
            {
                return CHICommand.GetICommand(T =>
                {
                    Go(CHPage.GetPage("VPG_Cotizacion"), new EComSoft_Cotizacion() { Opcion = "I" });
                });
            }
        }

        #endregion
    }
}
