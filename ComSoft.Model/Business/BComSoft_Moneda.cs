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

    public class BComSoft_Moneda
    {
        public CHObservableCollection<EComSoft_Moneda> GET_Moneda()
        {
            try
            {
                var instCHSqlClient = new CHSqlClient(ComSoftLocal.CadenaConexion);
                var instCollection = new CHObservableCollection<EComSoft_Moneda>();
                instCHSqlClient.CommandProcedure("spGET_ComSoft_BusquedaGeneral");
                instCHSqlClient.AddParameter("@Opcion", SqlDbType.VarChar, "GET_Moneda");
                instCHSqlClient.AddParameter("@Filtro", SqlDbType.VarChar, "%");
                instCHSqlClient.AddParameter("@ParametroId", SqlDbType.Int, 0);
                instCHSqlClient.AddParameter("@ParametroIdAux", SqlDbType.Int, 0);
                var dt = instCHSqlClient.ExecuteDataTable();
                for (var x = 0; x < dt.Rows.Count; x++)
                {
                    instCollection.Add(new EComSoft_Moneda()
                    {
                        CodMoneda = (dt.Rows[x]["CodMoneda"] != DBNull.Value) ? Convert.ToString(dt.Rows[x]["CodMoneda"]) : string.Empty,
                        Moneda = (dt.Rows[x]["Moneda"] != DBNull.Value) ? Convert.ToString(dt.Rows[x]["Moneda"]) : string.Empty,
                        Simbolo = (dt.Rows[x]["Simbolo"] != DBNull.Value) ? Convert.ToString(dt.Rows[x]["Simbolo"]) : string.Empty,
                        Nacional = (dt.Rows[x]["Nacional"] != DBNull.Value) ? Convert.ToBoolean(dt.Rows[x]["Nacional"]) : false,
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
