using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace DataLayer
{
    public class DataAccess : ConexionBase
    {
        public DataTable ObtenPersonas()
        {
            DataSet ds = new DataSet();

            try
            {
                Conectar();
                ds = SQLHelper.ExecuteDataSet(Conexion, "sp_ObtenPersonas", CommandType.StoredProcedure, null);

                return ds.Tables[0];
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ds.Dispose();
                ds = null;
                Desconectar();
            }
        }

        

        public int InsertarPersona(SqlParameter[] sqlparam)
        {

            try
            {
                int intRespuesta = 0;
                Conectar();
                return intRespuesta = SQLHelper.ExecuteNonQuery(Conexion, "sp_InsertarPersona", CommandType.StoredProcedure, sqlparam);

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

                Desconectar();
            }
        }

    }
}
