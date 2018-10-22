using System;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos{
    public class CD_Bancos
    {        
        private CD_Conexion conexionA = new CD_Conexion();
        private CD_Conexion conexionT = new CD_Conexion();

        SqlCommand comando = new SqlCommand();
        int cantidad = 0;        
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        string fecha = "DECLARE @total1 float,@total2 float,@suma_total float,@FEC_REG DATETIME SET @FEC_REG = (SELECT LTRIM(RTRIM(YEAR(GETDATE())))+'-'+RIGHT('0' + LTRIM(RTRIM(MONTH(GETDATE()))),2)+'-'+RIGHT('0' + LTRIM(RTRIM(DAY(GETDATE()-1))),2))";
        string FechaDomingo = "DECLARE @total1 float,@total2 float,@suma_total float,@FEC_REG DATETIME SET @FEC_REG = (SELECT LTRIM(RTRIM(YEAR(GETDATE())))+'-'+RIGHT('0' + LTRIM(RTRIM(MONTH(GETDATE()))),2)+'-'+RIGHT('0' + LTRIM(RTRIM(DAY(GETDATE()-2))),2))";
        string FechaBcpLunes = "DECLARE @total1 float,@total2 float,@suma_total float,@FEC_REG DATETIME,@total3 float,@total4 float,@suma_total1 float,@FEC_REG1 DATETIME,@suma_total2 float SET @FEC_REG = (SELECT LTRIM(RTRIM(YEAR(GETDATE())))+'-'+RIGHT('0' + LTRIM(RTRIM(MONTH(GETDATE()))),2)+'-'+RIGHT('0' + LTRIM(RTRIM(DAY(GETDATE()-1))),2)) SET @FEC_REG1 = (SELECT LTRIM(RTRIM(YEAR(GETDATE())))+'-'+RIGHT('0' + LTRIM(RTRIM(MONTH(GETDATE()))),2)+'-'+RIGHT('0' + LTRIM(RTRIM(DAY(GETDATE()-2))),2))";

        public void EditarTodasFechas()
        {           
            comando.Connection = conexionA.AbrirConexionA();
            comando.CommandText = "update TMP_BCPR set col004 =(SELECT LTRIM(RTRIM(YEAR(GETDATE())))+RIGHT('0' + LTRIM(RTRIM(MONTH(GETDATE()))),2)+RIGHT('0' + LTRIM(RTRIM(DAY(GETDATE()-1))),2))";
            comando.CommandType = CommandType.Text;

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
        public void EditarTodasFechasSolo()
        {
            comando.Connection = conexionA.AbrirConexionA();
            comando.CommandText = "update TMP_BCPR set col004 =(SELECT LTRIM(RTRIM(YEAR(GETDATE())))+RIGHT('0' + LTRIM(RTRIM(MONTH(GETDATE()))),2)+RIGHT('0' + LTRIM(RTRIM(DAY(GETDATE()-2))),2))";
            //comando.CommandText = "update TMP_BCPR set col004 ='20181020'";
            comando.CommandType = CommandType.Text;

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
        public void FechaBcp()
        {
            
            comando.Connection = conexionA.AbrirConexionA();
            comando.CommandText = "update TMP_BCPR set col004 =(SELECT LTRIM(RTRIM(YEAR(GETDATE())))+RIGHT('0' + LTRIM(RTRIM(MONTH(GETDATE()))),2)+RIGHT('0' + LTRIM(RTRIM(DAY(GETDATE()-2))),2)) where col004 in (Select col004 from TMP_BCPR where col004 < (SELECT LTRIM(RTRIM(YEAR(GETDATE())))+RIGHT('0' + LTRIM(RTRIM(MONTH(GETDATE()))),2)+RIGHT('0' + LTRIM(RTRIM(DAY(GETDATE()-1))),2) ))";
            comando.CommandType = CommandType.Text;

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
        public void CerosBcp()
        {           
            comando.Connection = conexionA.AbrirConexionA();
            comando.CommandText = "update TMP_BCPR Set COL002 = REPLACE(STR(COL002, 14), SPACE(1), '0') update TMP_BCPR Set COL006 = REPLACE(STR(COL006, 15), SPACE(1), '0')";
            comando.CommandType = CommandType.Text;

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }       
        public void CerosBbva()
        {
            comando.Connection = conexionA.AbrirConexionA();
            comando.CommandText = "update TMP_BCPR Set COL002 = REPLACE(STR(COL002, 8), SPACE(1), '0') update TMP_BCPR Set COL005 = REPLACE(STR(COL005, 12), SPACE(1), '0') update TMP_BCPR Set COL006 = REPLACE(STR(COL006, 15), SPACE(1), '0')";
            comando.CommandType = CommandType.Text;

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
        public void CerosInterbank()
        {
            comando.Connection = conexionA.AbrirConexionA();
            comando.CommandText = "update TMP_BCPR Set COL006 = REPLACE(STR(COL006, 13), SPACE(1), '0')";
            comando.CommandType = CommandType.Text;

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
        public void CerosScotiabank()
        {
            comando.Connection = conexionA.AbrirConexionA();
            comando.CommandText = "update TMP_BCPR Set COL002 = REPLACE(STR(COL002, 14), SPACE(1), '0') update TMP_BCPR Set COL006 = REPLACE(STR(COL006, 15), SPACE(1), '0')";
            comando.CommandType = CommandType.Text;

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
        public DataTable BorrarData()
        {
            comando.Connection = conexionA.AbrirConexionA();
            comando.CommandText = "DECLARE @borrados INT DELETE FROM dbo.TMP_BCPR; SET @borrados=@@rowcount select 'Afectadas  ' + CONVERT(VARCHAR(20),@borrados) + '  filas'";
            comando.CommandType = CommandType.Text;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexionA.CerrarConexionA();
            return tabla;
        }

        public DataTable SumaBbva()
        {
            comando.Connection = conexionA.AbrirConexionA();
            comando.CommandText = fecha+ "SELECT @total1=isnull(-SUM(vl_mov),0) FROM MOV_CONTARECEBER where CD_AGTCOB = 76 and  dt_mov = @FEC_REG and cd_mov in ( 3) SELECT @total2=isnull(-SUM(vl_mov),0) FROM [spnetsrvtac-bak].SapiensNet.[dbo].[MOV_CONTARECEBER] where CD_AGTCOB = 403 and  dt_mov = @FEC_REG and cd_mov in ( 3) SET @suma_total = @total1+@total2 SELECT @suma_total";
            comando.CommandType = CommandType.Text;
            comando.CommandTimeout = 200;
            leer = comando.ExecuteReader();

            tabla.Load(leer);

            conexionA.CerrarConexionA();

            return tabla;
        }

        public DataTable SumaBbvaDomingo()
        {
            comando.Connection = conexionA.AbrirConexionA();
            comando.CommandText = FechaDomingo + "SELECT @total1=isnull(-SUM(vl_mov),0) FROM MOV_CONTARECEBER where CD_AGTCOB = 76 and  dt_mov = @FEC_REG and cd_mov in ( 3) SELECT @total2=isnull(-SUM(vl_mov),0) FROM [spnetsrvtac-bak].SapiensNet.[dbo].[MOV_CONTARECEBER] where CD_AGTCOB = 403 and  dt_mov = @FEC_REG and cd_mov in ( 3) SET @suma_total = @total1+@total2 SELECT @suma_total";
            comando.CommandType = CommandType.Text;
            leer = comando.ExecuteReader();

            tabla.Load(leer);

            conexionA.CerrarConexionA();

            return tabla;
        }

        public DataTable SumaBcp()
        {
            comando.Connection = conexionA.AbrirConexionA();
            comando.CommandText = fecha+ "SELECT @total1=isnull(-SUM(vl_mov),0) FROM MOV_CONTARECEBER where CD_AGTCOB = 55 and  dt_mov = @FEC_REG and cd_mov in ( 3) SELECT @total2=isnull(-SUM(vl_mov),0) FROM [spnetsrvtac-bak].SapiensNet.[dbo].[MOV_CONTARECEBER] where CD_AGTCOB = 387 and  dt_mov = @FEC_REG and cd_mov in ( 3) SET @suma_total = @total1+@total2 SELECT @suma_total";
            comando.CommandType = CommandType.Text;
            leer = comando.ExecuteReader();

            tabla.Load(leer);

            conexionA.CerrarConexionA();

            return tabla;
        }
        public DataTable SumaBcpLunes()
        {
            comando.Connection = conexionA.AbrirConexionA();
            comando.CommandText = FechaBcpLunes + "SELECT @total1=isnull(-SUM(vl_mov),0) FROM MOV_CONTARECEBER where CD_AGTCOB = 55 and  dt_mov = @FEC_REG and cd_mov in ( 3) SELECT @total2=isnull(-SUM(vl_mov),0) FROM [spnetsrvtac-bak].SapiensNet.[dbo].[MOV_CONTARECEBER] where CD_AGTCOB = 387 and  dt_mov = @FEC_REG and cd_mov in ( 3) SET @suma_total = @total1+@total2 SELECT @total3=isnull(-SUM(vl_mov),0) FROM MOV_CONTARECEBER where CD_AGTCOB = 55 and  dt_mov = @FEC_REG1 and cd_mov in ( 3) SELECT @total4=isnull(-SUM(vl_mov),0) FROM [spnetsrvtac-bak].SapiensNet.[dbo].[MOV_CONTARECEBER] where CD_AGTCOB = 387 and  dt_mov = @FEC_REG1 and cd_mov in ( 3) SET @suma_total1 = @total3+@total4 SET @suma_total2 = @suma_total+@suma_total1 select @suma_total2";
            comando.CommandType = CommandType.Text;
            leer = comando.ExecuteReader();

            tabla.Load(leer);

            conexionA.CerrarConexionA();

            return tabla;
        }

        public DataTable SumaInterbank()
        {
            comando.Connection = conexionA.AbrirConexionA();
            comando.CommandText = fecha+"SELECT @total1=isnull(-SUM(vl_mov),0) FROM MOV_CONTARECEBER where CD_AGTCOB = 63 and  dt_mov = @FEC_REG and cd_mov in ( 3) SELECT @total2=isnull(-SUM(vl_mov),0) FROM [spnetsrvtac-bak].SapiensNet.[dbo].[MOV_CONTARECEBER] where CD_AGTCOB = 391 and  dt_mov = @FEC_REG and cd_mov in ( 3) SET @suma_total = @total1+@total2 SELECT @suma_total";
            comando.CommandType = CommandType.Text;
            leer = comando.ExecuteReader();

            tabla.Load(leer);

            conexionA.CerrarConexionA();

            return tabla;
        }

        public DataTable SumaInterbankDomingo()
        {
            comando.Connection = conexionA.AbrirConexionA();
            comando.CommandText = FechaDomingo + "SELECT @total1=isnull(-SUM(vl_mov),0) FROM MOV_CONTARECEBER where CD_AGTCOB = 63 and  dt_mov = @FEC_REG and cd_mov in ( 3) SELECT @total2=isnull(-SUM(vl_mov),0) FROM [spnetsrvtac-bak].SapiensNet.[dbo].[MOV_CONTARECEBER] where CD_AGTCOB = 391 and  dt_mov = @FEC_REG and cd_mov in ( 3) SET @suma_total = @total1+@total2 SELECT @suma_total";
            comando.CommandType = CommandType.Text;
            leer = comando.ExecuteReader();

            tabla.Load(leer);

            conexionA.CerrarConexionA();

            return tabla;
        }

        public DataTable SumaScotiabank()
        {
            comando.Connection = conexionA.AbrirConexionA();
            comando.CommandText = fecha+ "SELECT @total1=isnull(-SUM(vl_mov),0) FROM MOV_CONTARECEBER where CD_AGTCOB = 86 and  dt_mov = @FEC_REG and cd_mov in ( 3) SELECT @total2=isnull(-SUM(vl_mov),0) FROM [spnetsrvtac-bak].SapiensNet.[dbo].[MOV_CONTARECEBER] where CD_AGTCOB = 414 and  dt_mov = @FEC_REG and cd_mov in ( 3) SET @suma_total = @total1+@total2 SELECT @suma_total";           
            comando.CommandType = CommandType.Text;
            leer = comando.ExecuteReader();

            tabla.Load(leer);

            conexionA.CerrarConexionA();

            return tabla;
        }

        public DataTable SumaScotiabankDomingo()
        {
            comando.Connection = conexionA.AbrirConexionA();
            comando.CommandText = FechaDomingo + "SELECT @total1=isnull(-SUM(vl_mov),0) FROM MOV_CONTARECEBER where CD_AGTCOB = 86 and  dt_mov = @FEC_REG and cd_mov in ( 3) SELECT @total2=isnull(-SUM(vl_mov),0) FROM [spnetsrvtac-bak].SapiensNet.[dbo].[MOV_CONTARECEBER] where CD_AGTCOB = 414 and  dt_mov = @FEC_REG and cd_mov in ( 3) SET @suma_total = @total1+@total2 SELECT @suma_total";
            comando.CommandType = CommandType.Text;
            leer = comando.ExecuteReader();

            tabla.Load(leer);

            conexionA.CerrarConexionA();

            return tabla;
        }

        public void InsertarData(string abonado, string fecha, string limite,string dinero)
        {
            comando.Connection = conexionA.AbrirConexionA();
            comando.CommandText = string.Format("INSERT INTO TMP_BCPR (COL002,COL004,COL005,COL006) VALUES ({0},{1},{2},{3})", abonado, fecha, limite, dinero);
            comando.CommandType = CommandType.Text;

            cantidad = comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }        
    }
}
