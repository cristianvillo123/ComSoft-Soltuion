/**************************************************************
 * CREADO POR : GRUPO COMSOFT
 *              Cristian Hernandez Villo
 * FECHA CREA : 06/09/2018
**************************************************************/

namespace ComSoft.Model.Entity
{
    public class EComSoft_Empresa
    {
        public int IdEmpresa { get; set; }
        public string RazonSocial { get; set; }
        public string NombreLegal { get; set; }
        public string Ruc { get; set; }
        public string DireccionFiscal { get; set; }
        public string RepresentanteLegal { get; set; }
        public string Estado { get; set; }
        public string Condicion { get; set; }
        public string TipoContribuyente { get; set; }
    }
}
