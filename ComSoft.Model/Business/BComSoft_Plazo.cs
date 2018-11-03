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

    public class BComSoft_Plazo
    {
        public CHObservableCollection<EComSoft_Plazo> GET_Plazo()
        {
            try
            {
                var instCHSqlClient = new CHSqlClient(ComSoftLocal.CadenaConexion);
                var instCollection = new CHObservableCollection<EComSoft_Plazo>();
                instCHSqlClient.CommandProcedure("spGET_ComSoft_BusquedaGeneral");
                instCHSqlClient.AddParameter("@Opcion", SqlDbType.VarChar, "GET_Plazo");
                instCHSqlClient.AddParameter("@Filtro", SqlDbType.VarChar, "%");
                instCHSqlClient.AddParameter("@ParametroId", SqlDbType.Int, 0);
                instCHSqlClient.AddParameter("@ParametroIdAux", SqlDbType.Int, 0);
                var dt = instCHSqlClient.ExecuteDataTable();
                for (var x = 0; x < dt.Rows.Count; x++)
                {
                    instCollection.Add(new EComSoft_Plazo()
                    {
                        IdPlazo = (dt.Rows[x]["IdPlazo"] != DBNull.Value) ? Convert.ToInt32(dt.Rows[x]["IdPlazo"]) : 0,
                        Plazo = (dt.Rows[x]["Plazo"] != DBNull.Value) ? Convert.ToString(dt.Rows[x]["Plazo"]) : string.Empty,
                        DiasPlazo = (dt.Rows[x]["DiasPlazo"] != DBNull.Value) ? Convert.ToInt32(dt.Rows[x]["DiasPlazo"]) : 0,
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

