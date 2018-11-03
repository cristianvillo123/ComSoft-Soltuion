/**************************************************************
 * CREADO POR : GRUPO COMSOFT
 *              Cristian Hernandez Villo
 * FECHA CREA : 06/09/2018
**************************************************************/

namespace ComSoft.Model.Entity
{
    public class EComSoft_Almacen
    {
        public EComSoft_Almacen()
        {
            EComSoft_EmpresaSucursal = new EComSoft_EmpresaSucursal();
            EComSoft_Ubigeo = new EComSoft_Ubigeo();
        }

        public string Opcion { get; set; }
        public int IdAlmacen { get; set; }
        public string Almacen { get; set; }
        public string Direccion { get; set; }
        public EComSoft_EmpresaSucursal EComSoft_EmpresaSucursal { get; set; }
        public EComSoft_Ubigeo EComSoft_Ubigeo { get; set; }
    }
}
