/**************************************************************
 * CREADO POR : GRUPO COMSOFT
 *              Cristian Hernandez Villo
 * FECHA CREA : 06/09/2018
**************************************************************/
namespace ComSoft.Model.Entity
{
    public class EComSoft_DocumentoSerie
    {
        public string Opcion { get; set; }
        public int IdDocumentoSerie { get; set; }
        public EComSoft_Documento EComSoft_Documento { get; set; }
        public EComSoft_EmpresaSucursal EComSoft_EmpresaSucursal { get; set; }
        public string Serie { get; set; }
        public string Correlativo { get; set; }
        public string Longitud { get; set; }
        public bool Sunat { get; set; }
    }
}
