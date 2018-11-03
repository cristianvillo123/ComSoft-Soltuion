/*************************************************************
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

    public class BComSoft_EmpresaSucursal
    {
        public void SET_EmpresaSucursal(EComSoft_EmpresaSucursal EComSoft_EmpresaSucursal)
        {
            try
            {
                var instCHSqlClient = new CHSqlClient(ComSoftLocal.CadenaConexion);
                instCHSqlClient.CommandProcedure("spComSoft_SET_EmpresaSucursal");
                instCHSqlClient.AddParameter("@Opcion", SqlDbType.VarChar, EComSoft_EmpresaSucursal.Opcion);
                instCHSqlClient.AddParameter("@IdEmpresaSucursal", SqlDbType.VarChar, EComSoft_EmpresaSucursal.IdEmpresaSucursal);
                instCHSqlClient.AddParameter("@Sucursal", SqlDbType.VarChar, EComSoft_EmpresaSucursal.Sucursal);
                instCHSqlClient.AddParameter("@Principal", SqlDbType.VarChar, EComSoft_EmpresaSucursal.Principal);
                instCHSqlClient.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public CHObservableCollection<EComSoft_EmpresaSucursal> GET_EmpresaSucursal()
        {
            try
            {
                var instCHSqlClient = new CHSqlClient(ComSoftLocal.CadenaConexion);
                var instCollection = new CHObservableCollection<EComSoft_EmpresaSucursal>();
                instCHSqlClient.CommandProcedure("spGET_ComSoft_BusquedaGeneral");
                instCHSqlClient.AddParameter("@Opcion", SqlDbType.VarChar, "GET_EmpresaSucursal");
                instCHSqlClient.AddParameter("@Filtro", SqlDbType.VarChar, "%");
                instCHSqlClient.AddParameter("@ParametroId", SqlDbType.Int, 0);
                instCHSqlClient.AddParameter("@ParametroIdAux", SqlDbType.Int, 0);
                var dt = instCHSqlClient.ExecuteDataTable();
                for (var x = 0; x < dt.Rows.Count; x++)
                {
                    instCollection.Add(new EComSoft_EmpresaSucursal()
                    {
                        IdEmpresaSucursal = (dt.Rows[x]["IdEmpresaSucursal"] != DBNull.Value) ? Convert.ToInt32(dt.Rows[x]["IdEmpresaSucursal"]) : 0,
                        Sucursal = (dt.Rows[x]["Sucursal"] != DBNull.Value) ? Convert.ToString(dt.Rows[x]["Sucursal"]) : string.Empty,
                        Principal = (dt.Rows[x]["Principal"] != DBNull.Value) ? Convert.ToBoolean(dt.Rows[x]["Principal"]) : false,
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
