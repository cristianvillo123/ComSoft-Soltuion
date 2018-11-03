/**************************************************************
 * CREADO POR : GRUPO COMSOFT
 *              Cristian Hernandez Villo
 * FECHA CREA : 06/09/2018
**************************************************************/

namespace ComSoft.Model.Entity
{
    using CristianHernandez;

    public class EComSoft_Documento : CHNotifyPropertyChanged
    {
        public EComSoft_Documento()
        {
            Sunat = true;
        }

        public string Opcion { get; set; }
        private string _CodDocumento;
        public string CodDocumento
        {
            get
            {
                return _CodDocumento;
            }
            set
            {
                _CodDocumento = value;
                OnPropertyChanged("CodDocumento");
            }
        }
        private string _Descripcion;
        public string Descripcion
        {
            get
            {
                return _Descripcion;
            }
            set
            {
                _Descripcion = value;
                OnPropertyChanged("Descripcion");
            }
        }
        public bool Sunat { get; set; }
    }
}
