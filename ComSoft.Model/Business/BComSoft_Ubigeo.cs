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

    public class BComSoft_Ubigeo
    {
        public CHObservableCollection<EComSoft_Ubigeo> GET_Departamento()
        {
            try
            {
                var instCHSqlClient = new CHSqlClient(ComSoftLocal.CadenaConexion);
                var instList = new CHObservableCollection<EComSoft_Ubigeo>();
                instCHSqlClient.CommandProcedure("spGET_ComSoft_BusquedaGeneral");
                instCHSqlClient.AddParameter("@Opcion", SqlDbType.VarChar, "GET_Departamento");
                instCHSqlClient.AddParameter("@Filtro", SqlDbType.VarChar, "%");
                instCHSqlClient.AddParameter("@ParametroId", SqlDbType.Int, 0);
                instCHSqlClient.AddParameter("@ParametroIdAux", SqlDbType.Int, 0);
                var dt = instCHSqlClient.ExecuteDataTable();
                for (int x = 0; x < dt.Rows.Count; x++)
                {
                    instList.Add(new EComSoft_Ubigeo()
                    {
                        CodUbigeo = (dt.Rows[x]["CodDepartamento"]!=DBNull.Value)? Convert.ToString(dt.Rows[x]["CodDepartamento"]):string.Empty,
                        Departamento =(dt.Rows[x]["Departamento"] !=DBNull.Value)? Convert.ToString(dt.Rows[x]["Departamento"]):string.Empty,
                    });
                }
                return instList;
            }
            catch (Exception )
            {
                throw;
            }
        }
        public CHObservableCollection<EComSoft_Ubigeo> GET_Provincia(string Filtro = "%")
        {
            try
            {
                var instCHSqlClient = new CHSqlClient(ComSoftLocal.CadenaConexion);
                var instList = new CHObservableCollection<EComSoft_Ubigeo>();
                instCHSqlClient.CommandProcedure("spGET_ComSoft_BusquedaGeneral");
                instCHSqlClient.AddParameter("@Opcion", SqlDbType.VarChar, "GET_Provincia");
                instCHSqlClient.AddParameter("@Filtro", SqlDbType.VarChar, Filtro);
                instCHSqlClient.AddParameter("@ParametroId", SqlDbType.Int, 0);
                instCHSqlClient.AddParameter("@ParametroIdAux", SqlDbType.Int, 0);
                var dt = instCHSqlClient.ExecuteDataTable();
                for (int x = 0; x < dt.Rows.Count; x++)
                {
                    instList.Add(new EComSoft_Ubigeo()
                    {
                        CodUbigeo = (dt.Rows[x]["CodProvincia"] != DBNull.Value) ? Convert.ToString(dt.Rows[x]["CodProvincia"]) : string.Empty,
                        Provincia = (dt.Rows[x]["Provincia"] != DBNull.Value) ? Convert.ToString(dt.Rows[x]["Provincia"]) : string.Empty,
                    });
                }
                return instList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public CHObservableCollection<EComSoft_Ubigeo> GET_Distrito(string Filtro = "%")
        {
            try
            {
                var instCHSqlClient = new CHSqlClient(ComSoftLocal.CadenaConexion);
                var instList = new CHObservableCollection<EComSoft_Ubigeo>();
                instCHSqlClient.CommandProcedure("spGET_ComSoft_BusquedaGeneral");
                instCHSqlClient.AddParameter("@Opcion", SqlDbType.VarChar, "GET_Distrito");
                instCHSqlClient.AddParameter("@Filtro", SqlDbType.VarChar, Filtro);
                instCHSqlClient.AddParameter("@ParametroId", SqlDbType.Int, 0);
                instCHSqlClient.AddParameter("@ParametroIdAux", SqlDbType.Int, 0);
                var dt = instCHSqlClient.ExecuteDataTable();
                for (int x = 0; x < dt.Rows.Count; x++)
                {
                    instList.Add(new EComSoft_Ubigeo()
                    {
                        CodUbigeo = (dt.Rows[x]["CodUbigeo"] != DBNull.Value) ? Convert.ToString(dt.Rows[x]["CodUbigeo"]) : string.Empty,
                        Distrito = (dt.Rows[x]["Distrito"] != DBNull.Value) ? Convert.ToString(dt.Rows[x]["Distrito"]) : string.Empty,
                    });
                }
                return instList;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
