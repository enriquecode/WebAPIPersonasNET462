using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace DataLayer
{
    public class ConexionBase
    {
        private SqlConnection _conexion;

        public SqlConnection Conexion
        {
            get { return _conexion; }
            set { _conexion = value; }
        }

        public void Conectar()
        {
            try
            {
                Desconectar();
                Conexion = new SqlConnection();
                Conexion.ConnectionString = Obten_Conexion();
                if (Conexion.State != ConnectionState.Open)
                {
                    Conexion.Open();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Desconectar()
        {
            try
            {
                if (_conexion != null)
                {
                    _conexion.Close();
                    _conexion.Dispose();
                    _conexion = null;
                }
            }
            catch (Exception ex)
            {
            }
        }

        public string Obten_Conexion()
        {
            try
            {

                return ConfigurationManager.ConnectionStrings["ConexionPersonas"].ConnectionString.ToString();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " Obten_Conexion");
            }
        }
    }
}
