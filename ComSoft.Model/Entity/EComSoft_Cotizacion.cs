/*************************************************************
 * CREADO POR : GRUPO COMSOFT
 *              Cristian Hernandez Villo
 * FECHA CREA : 06/10/2018
**************************************************************/



namespace ComSoft.Model.Entity
{
    using System;

    public class EComSoft_Cotizacion
    {
        public string Opcion { get; set; }
        public int IdCotizacion { get; set; }

        public EComSoft_EmpresaSucursal EComSoft_EmpresaSucursal { get; set; }
        public EComSoft_Almacen EComSoft_Almacen { get; set; }
        public EComSoft_Plazo EComSoft_Plazo { get; set; }
        public EComSoft_FormaPago EComSoft_FormaPago { get; set; }
        public EComSoft_Moneda EComSoft_Moneda { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaVencimiento { get; set; }
    }
}
