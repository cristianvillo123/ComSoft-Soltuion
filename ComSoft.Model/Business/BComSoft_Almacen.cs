/**************************************************************
 * CREADO POR : GRUPO COMSOFT
 *              Cristian Hernandez Villo
 * FECHA CREA : 06/09/2018
**************************************************************/

namespace ComSoft.Model.Business
{
    using ComSoft.Model.Entity;
    using CristianHernandez;
    using CristianHernandez.ServerAccess;
    using System;
    using System.Data;

    public class BComSoft_Almacen
    {
        public void SET_Almacen(EComSoft_Almacen EComSoft_Almacen)
        {
            try
            {
                var instCHSqlClient = new CHSqlClient(ComSoftLocal.CadenaConexion);
                instCHSqlClient.CommandProcedure("spComSoft_SET_Almacen");
                instCHSqlClient.AddParameter("@Opcion", SqlDbType.VarChar, EComSoft_Almacen.Opcion);
                instCHSqlClient.AddParameter("@IdAlmacen", SqlDbType.Int, EComSoft_Almacen.IdAlmacen);
                instCHSqlClient.AddParameter("@CodUbigeo", SqlDbType.VarChar, EComSoft_Almacen.EComSoft_Ubigeo.CodUbigeo);
                instCHSqlClient.AddParameter("@IdEmpresaSucursal", SqlDbType.Int, EComSoft_Almacen.EComSoft_EmpresaSucursal.IdEmpresaSucursal);
                instCHSqlClient.AddParameter("@Almacen", SqlDbType.VarChar, EComSoft_Almacen.Almacen);
                instCHSqlClient.AddParameter("@Direccion", SqlDbType.VarChar, EComSoft_Almacen.Direccion);
                instCHSqlClient.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public CHObservableCollection<EComSoft_Almacen> GET_Almacen(int IdEmpresaSucursal = 0)
        {
            try
            {
                var instCHSqlClient = new CHSqlClient(ComSoftLocal.CadenaConexion);
                var instCollection = new CHObservableCollection<EComSoft_Almacen>();
                instCHSqlClient.CommandProcedure("spGET_ComSoft_BusquedaGeneral");
                instCHSqlClient.AddParameter("@Opcion", SqlDbType.VarChar, "GET_Almacen");
                instCHSqlClient.AddParameter("@Filtro", SqlDbType.VarChar, "%");
                instCHSqlClient.AddParameter("@ParametroId", SqlDbType.Int, IdEmpresaSucursal);
                instCHSqlClient.AddParameter("@ParametroIdAux", SqlDbType.Int, 0);
                var dt = instCHSqlClient.ExecuteDataTable();
                for (var x = 0; x < dt.Rows.Count; x++)
                {
                    instCollection.Add(new EComSoft_Almacen()
                    {
                        IdAlmacen =  (dt.Rows[x]["IdAlmacen"] != DBNull.Value) ? Convert.ToInt32(dt.Rows[x]["IdAlmacen"]) : 0,
                        Almacen = (dt.Rows[x]["Almacen"] !=DBNull.Value)? Convert.ToString(dt.Rows[x]["Almacen"]):string.Empty,
                        Direccion = (dt.Rows[x]["Direccion"] != DBNull.Value) ? Convert.ToString(dt.Rows[x]["Direccion"]) : string.Empty,
                        EComSoft_EmpresaSucursal = new EComSoft_EmpresaSucursal()
                        {
                            IdEmpresaSucursal = (dt.Rows[x]["IdEmpresaSucursal"] != DBNull.Value) ? Convert.ToInt32(dt.Rows[x]["IdEmpresaSucursal"]) : 0,
                        },
                        EComSoft_Ubigeo = new EComSoft_Ubigeo()
                        {
                            CodUbigeo = (dt.Rows[x]["CodUbigeo"] != DBNull.Value) ? Convert.ToString(dt.Rows[x]["CodUbigeo"]) : string.Empty,
                        }
                    });
                }
                return instCollection;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
