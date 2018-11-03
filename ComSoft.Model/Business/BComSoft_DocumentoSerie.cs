using ComSoft.Model.Entity;
using CristianHernandez;
using CristianHernandez.ServerAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComSoft.Model.Business
{
    public class BComSoft_DocumentoSerie
    {
        public void SET_Documento(EComSoft_DocumentoSerie EComSoft_DocumentoSerie)
        {
            try
            {
                var instCHSqlClient = new CHSqlClient(ComSoftLocal.CadenaConexion);
                instCHSqlClient.CommandProcedure("spComSoft_SET_Documento");
                instCHSqlClient.AddParameter("@Opcion", SqlDbType.VarChar, EComSoft_DocumentoSerie.Opcion);
                instCHSqlClient.AddParameter("@CodDocumento", SqlDbType.VarChar, EComSoft_DocumentoSerie.IdDocumentoSerie);
                instCHSqlClient.AddParameter("@Descripcion", SqlDbType.VarChar, EComSoft_DocumentoSerie.EComSoft_Documento.CodDocumento);
                instCHSqlClient.AddParameter("@Descripcion", SqlDbType.VarChar, EComSoft_DocumentoSerie.EComSoft_EmpresaSucursal.IdEmpresaSucursal);
                instCHSqlClient.AddParameter("@Descripcion", SqlDbType.VarChar, EComSoft_DocumentoSerie.Serie);
                instCHSqlClient.AddParameter("@Descripcion", SqlDbType.VarChar, EComSoft_DocumentoSerie.Correlativo);
                instCHSqlClient.AddParameter("@Descripcion", SqlDbType.VarChar, EComSoft_DocumentoSerie.Longitud);
                instCHSqlClient.AddParameter("@Sunat", SqlDbType.Bit, EComSoft_DocumentoSerie.Sunat);
                instCHSqlClient.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public CHObservableCollection<EComSoft_Documento> GET_Documento()
        {
            try
            {
                var instCHSqlClient = new CHSqlClient(ComSoftLocal.CadenaConexion);
                var instList = new CHObservableCollection<EComSoft_Documento>();
                instCHSqlClient.CommandProcedure("spGET_ComSoft_BusquedaGeneral");
                instCHSqlClient.AddParameter("@Opcion", SqlDbType.VarChar, "GET_Documento");
                instCHSqlClient.AddParameter("@Filtro", SqlDbType.VarChar, "%");
                instCHSqlClient.AddParameter("@ParametroId", SqlDbType.Int, 0);
                instCHSqlClient.AddParameter("@ParametroIdAux", SqlDbType.Int, 0);
                var dt = instCHSqlClient.ExecuteDataTable();
                for (int x = 0; x < dt.Rows.Count; x++)
                {
                    instList.Add(new EComSoft_Documento()
                    {
                        CodDocumento = (dt.Rows[x]["CodDocumento"] != DBNull.Value) ? Convert.ToString(dt.Rows[x]["CodDocumento"]) : string.Empty,
                        Descripcion = (dt.Rows[x]["Descripcion"] != DBNull.Value) ? Convert.ToString(dt.Rows[x]["Descripcion"]) : string.Empty,
                        Sunat = (dt.Rows[x]["Sunat"] != DBNull.Value) ? Convert.ToBoolean(dt.Rows[x]["Sunat"]) : false,
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
