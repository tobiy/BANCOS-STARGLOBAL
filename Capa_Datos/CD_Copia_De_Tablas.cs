using System;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class CD_Copia_De_Tablas
    {
        private CD_Conexion conexionA = new CD_Conexion();
        private CD_Conexion conexionT = new CD_Conexion();

        SqlCommand comando = new SqlCommand();
        public void CopiaBva()
        {
            comando.Connection = conexionA.AbrirConexionA();
            comando.CommandText = "SELECT * INTO RegistroBbva FROM HISTORIAL";
            comando.CommandType = CommandType.Text;

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
    }
}
