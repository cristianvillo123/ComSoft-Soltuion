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
    public class BComSoft_Empresa
    {
        public CHObservableCollection<EComSoft_Empresa> GET_Empresa()
        {
            try
            {
                var instCHSqlClient = new CHSqlClient(ComSoftLocal.CadenaConexion);
                var instList = new CHObservableCollection<EComSoft_Empresa>();
                instCHSqlClient.CommandProcedure("spGET_ComSoft_BusquedaGeneral");
                instCHSqlClient.AddParameter("@Opcion", SqlDbType.VarChar, "GET_Empresa");
                instCHSqlClient.AddParameter("@Filtro", SqlDbType.VarChar, "%");
                instCHSqlClient.AddParameter("@ParametroId", SqlDbType.Int, 0);
                instCHSqlClient.AddParameter("@ParametroIdAux", SqlDbType.Int, 0);
                var dt = instCHSqlClient.ExecuteDataTable();
                for (int x = 0; x < dt.Rows.Count; x++)
                {
                    instList.Add(new EComSoft_Empresa()
                    {
                        Condicion = (dt.Rows[x]["Condicion"] != DBNull.Value) ? Convert.ToString(dt.Rows[x]["Condicion"]) : string.Empty,
                        DireccionFiscal = (dt.Rows[x]["DireccionFiscal"] != DBNull.Value) ? Convert.ToString(dt.Rows[x]["DireccionFiscal"]) : string.Empty,
                        Estado =(dt.Rows[x]["Estado"] != DBNull.Value) ? Convert.ToString(dt.Rows[x]["Estado"]) : string.Empty,
                        IdEmpresa =(dt.Rows[x]["IdEmpresa"] !=DBNull.Value)?Convert.ToInt32(dt.Rows[x]["IdEmpresa"]):0,
                        NombreLegal =  (dt.Rows[x]["NombreLegal"] !=DBNull.Value)?Convert.ToString(dt.Rows[x]["NombreLegal"]):string.Empty,
                        RazonSocial = (dt.Rows[x]["RazonSocial"] !=DBNull.Value)?Convert.ToString(dt.Rows[x]["RazonSocial"]):string.Empty,
                        RepresentanteLegal= (dt.Rows[x]["RepresentanteLegal"] !=DBNull.Value)?Convert.ToString(dt.Rows[x]["RepresentanteLegal"]):string.Empty,
                        Ruc= (dt.Rows[x]["Ruc"] !=DBNull.Value)?Convert.ToString(dt.Rows[x]["Ruc"]):string.Empty,
                        TipoContribuyente = (dt.Rows[x]["TipoContribuyente"] != DBNull.Value) ? Convert.ToString(dt.Rows[x]["TipoContribuyente"]) : string.Empty,
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
