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

    public class BComSoft_FormaPago
    {
        public CHObservableCollection<EComSoft_FormaPago> GET_FormaPago()
        {
            try
            {
                var instCHSqlClient = new CHSqlClient(ComSoftLocal.CadenaConexion);
                var instCollection = new CHObservableCollection<EComSoft_FormaPago>();
                instCHSqlClient.CommandProcedure("spGET_ComSoft_BusquedaGeneral");
                instCHSqlClient.AddParameter("@Opcion", SqlDbType.VarChar, "GET_FormaPago");
                instCHSqlClient.AddParameter("@Filtro", SqlDbType.VarChar, "%");
                instCHSqlClient.AddParameter("@ParametroId", SqlDbType.Int, 0);
                instCHSqlClient.AddParameter("@ParametroIdAux", SqlDbType.Int, 0);
                var dt = instCHSqlClient.ExecuteDataTable();
                for (var x = 0; x < dt.Rows.Count; x++)
                {
                    instCollection.Add(new EComSoft_FormaPago()
                    {
                        IdFormaPago = (dt.Rows[x]["IdFormaPago"] != DBNull.Value) ? Convert.ToInt32(dt.Rows[x]["IdFormaPago"]) : 0,
                        FormaPago = (dt.Rows[x]["FormaPago"] != DBNull.Value) ? Convert.ToString(dt.Rows[x]["FormaPago"]) : string.Empty,
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
