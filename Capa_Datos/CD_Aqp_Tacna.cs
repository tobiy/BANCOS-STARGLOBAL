using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class CD_Aqp_Tacna
    {        
        private CD_Conexion conexionA = new CD_Conexion();
        private CD_Conexion conexionT = new CD_Conexion();
        
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();
        string fecha = "DECLARE @inicio DATE,@final DATE set @inicio=(SELECT LTRIM(RIGHT('0' + LTRIM(RTRIM(MONTH(GETDATE()))),2))+'/'+RIGHT('0' + LTRIM(RTRIM(DAY((GETDATE())-getdate()))),2) +'/'+ LTRIM(RTRIM(YEAR(GETDATE()))))set @final=(SELECT LTRIM(RIGHT('0' + LTRIM(RTRIM(MONTH(GETDATE()))),2))+'/'+RIGHT('0' + LTRIM(RTRIM(DAY(GETDATE()-1))),2) +'/'+ LTRIM(RTRIM(YEAR(GETDATE()))))";

        public void EjecutarBbva()
        {
            comando.Connection = conexionA.AbrirConexionA();
            comando.CommandText = "SP_VALIDA_CARGOS_BBVASOL";
            comando.CommandType = CommandType.StoredProcedure;

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
        public void EjecutarBcp()
        {
            comando.Connection = conexionA.AbrirConexionA();
            comando.CommandText = "SP_VALIDA_CARGOS_BCPSOL";
            comando.CommandType = CommandType.StoredProcedure;

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
        public void EjecutarInterbank()
        {
            comando.Connection = conexionA.AbrirConexionA();
            comando.CommandText = "SP_VALIDA_CARGOS_INTSOL";
            comando.CommandType = CommandType.StoredProcedure;

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
        public void EjecutarScotiabank()
        {
            comando.Connection = conexionA.AbrirConexionA();
            comando.CommandText = "SP_VALIDA_CARGOS_SCOSOL";
            comando.CommandType = CommandType.StoredProcedure;

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }       
        public DataTable SelectDatosAqp()
        {
            comando.Connection = conexionA.AbrirConexionA();
            comando.CommandText = "SELECT [NR_COB],[NR_CONTRATO], [NR_SER_FAT], [NR_FAT], [NR_SER_NT_CRED],[NR_NT_CRED],[VL_PAG_FAT],[DT_PAG_FAT],[CD_AGTCOB],[RES],[OBS],[Moneda],[Flat1] FROM [TMP_CAS] Order by [DT_PAG_FAT]";
            comando.CommandType = CommandType.Text;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexionA.CerrarConexionA();
            return tabla;
        }
        public void EjecutarSpcasAqp()
        {
            comando.Connection = conexionA.AbrirConexionA();
            comando.CommandText = "sp_cas";
            comando.CommandType = CommandType.StoredProcedure;

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
        public DataTable EliminarDatosAqp()
        {
            comando.Connection = conexionA.AbrirConexionA();
            comando.CommandText = "delete tmp_cas where res = 1";
            comando.CommandType = CommandType.Text;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexionA.CerrarConexionA();
            return tabla;
        }
        public DataTable ErrorAqp()
        {
            comando.Connection = conexionA.AbrirConexionA();
            comando.CommandText = "select count(*) from TMP_CAS_ERROR";
            comando.CommandType = CommandType.Text;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexionA.CerrarConexionA();
            return tabla;
        }
        public DataTable SelectDatosTacna()
        {
            comando.Connection = conexionT.AbrirConexionT();
            comando.CommandText = "SELECT [NR_COB],[NR_CONTRATO], [NR_SER_FAT], [NR_FAT], [NR_SER_NT_CRED],[NR_NT_CRED],[VL_PAG_FAT],[DT_PAG_FAT],[CD_AGTCOB],[RES],[OBS],[Moneda],[Flat1] FROM [TMP_CAS] Order by [DT_PAG_FAT]";
            comando.CommandType = CommandType.Text;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexionT.CerrarConexionT();
            return tabla;
        }
        public void EjecutarSpcasTacna()
        {
            comando.Connection = conexionT.AbrirConexionT();
            comando.CommandText = "sp_cas";
            comando.CommandType = CommandType.StoredProcedure;

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
        public DataTable EliminarDatosTacna()
        {
            comando.Connection = conexionT.AbrirConexionT();
            comando.CommandText = "delete tmp_cas where res = 1";
            comando.CommandType = CommandType.Text;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexionT.CerrarConexionT();
            return tabla;
        }
        public DataTable ErrorTacna()
        {
            comando.Connection = conexionA.AbrirConexionA();
            comando.CommandText = "select * from TMP_CAS_ERROR";
            comando.CommandType = CommandType.Text;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexionA.CerrarConexionA();
            return tabla;
        }
        //revisar esta parte a detalle para poder pasar cobranza correctamente
        public void CobranzaAqp()
        {
            comando.Connection = conexionT.AbrirConexionT();
            comando.CommandText = "exec SP_ATUALIZA_CONTABILIDADE '"+fecha+"', '09/20/2018' ,'7'";
            comando.CommandType = CommandType.StoredProcedure;

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }

        public DataTable FechaCobranza()
        {
            comando.Connection = conexionA.AbrirConexionA();
            comando.CommandText = fecha+ "select convert(varchar,@final,103)";
            comando.CommandType = CommandType.Text;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexionA.CerrarConexionA();
            return tabla;
        }
    }
}
