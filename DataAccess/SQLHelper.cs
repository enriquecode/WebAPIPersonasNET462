using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class SQLHelper
    {

        public static DataSet ExecuteDataSet(SqlConnection connection, string cmdText, CommandType type, SqlParameter[] sqlparams)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection conn = connection)
                {
                    using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                    {
                        cmd.CommandType = type;

                        if (sqlparams != null)
                        {
                            foreach (SqlParameter p in sqlparams)
                            {
                                cmd.Parameters.Add(p);
                            }
                        }

                        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                        dataAdapter.Fill(ds);
                        return ds;

                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " error al obtener DataSet");

            }
        }

        public static DataSet ExecuteDataSet(SqlConnection connection, string cmdText, CommandType type)
        {
            return ExecuteDataSet(connection, cmdText, type);
        }

        public static int ExecuteNonQuery(SqlConnection connection, string cmdText, CommandType type, SqlParameter[] sqlparams)
        {
            using (SqlConnection conn = connection)
            {
                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.CommandType = type;
                    if (sqlparams != null)
                    {
                        foreach (SqlParameter p in sqlparams)
                        {
                            cmd.Parameters.Add(p);
                        }
                    }

                    int respuestaSQL = cmd.ExecuteNonQuery();
                    return respuestaSQL;
                }
            }
        }


    }
}
