using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    class CD_Conexion
    {       
        //private SqlConnection ConexionA = new SqlConnection("data source = .; initial catalog = 06SapiensNet2AQP; user id = sapiensnet; password = sapiensnet");
        private SqlConnection ConexionA = new SqlConnection("data source = 192.168.101.9; initial catalog = SapiensNet2; user id = sapiensnet; password = sapiensnet");
        public SqlConnection AbrirConexionA()
        {
            if (ConexionA.State == ConnectionState.Closed)
                ConexionA.Open();
            return ConexionA;
        }

        public SqlConnection CerrarConexionA()
        {
            if (ConexionA.State == ConnectionState.Open)
                ConexionA.Close();
            return ConexionA;
        }

        //private SqlConnection ConexionT = new SqlConnection("data source = .; initial catalog = 06SapiensNet2AQP; user id = sapiensnet; password = sapiensnet");
        private SqlConnection ConexionT = new SqlConnection("data source = 192.168.101.8; initial catalog = SapiensNet; user id = sapiensnet; password = sapiensnet");
        public SqlConnection AbrirConexionT()
        {
            if (ConexionT.State == ConnectionState.Closed)
                ConexionT.Open();
            return ConexionT;
        }
        public SqlConnection CerrarConexionT()
        {
            if (ConexionT.State == ConnectionState.Open)
                ConexionT.Close();
            return ConexionT;
        }
        //conexion para la base de datos 117 para poder guardar yt hacer la comparacion de los datos cuando se quiera hacer una comapracion
        private SqlConnection Conexion117 = new SqlConnection("data source = 192.168.101.117; initial catalog = 06SapiensNet2AQP; user id = sapiensnet; password = sapiensnet");
        public SqlConnection AbrirConexion117()
        {
            if (Conexion117.State == ConnectionState.Closed)
                Conexion117.Open();
            return Conexion117;
        }

        public SqlConnection CerrarConexion117()
        {
            if (Conexion117.State == ConnectionState.Open)
                Conexion117.Close();
            return Conexion117;
        }
    }
}
