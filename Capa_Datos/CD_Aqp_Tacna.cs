using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class CD_Aqp_Tacna
    {        
        private CD_Conexion conexionA = new CD_Conexion();
        private CD_Conexion conexionT = new CD_Conexion();
        private CD_Conexion Conexion117 = new CD_Conexion();        

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();
        string fecha = "DECLARE @inicio varchar(10),@final varchar(10)set @inicio=(SELECT LTRIM(RIGHT('0' + LTRIM(RTRIM(MONTH(GETDATE()))),2))+'/'+RIGHT('0' + LTRIM(RTRIM(DAY((GETDATE())-getdate()))),2) +'/'+ LTRIM(RTRIM(YEAR(GETDATE()))))set @final=(SELECT LTRIM(RIGHT('0' + LTRIM(RTRIM(MONTH(GETDATE()))),2))+'/'+RIGHT('0' + LTRIM(RTRIM(DAY(GETDATE()-1))),2) +'/'+ LTRIM(RTRIM(YEAR(GETDATE()))))";
        
        //ejecucion de procedimientos almacenados para la validacion de bancos
        public void EjecutarBbva()
        {
            comando.Connection = conexionA.AbrirConexionA();
            comando.CommandText = "SP_VALIDA_CARGOS_BBVASOL";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandTimeout = 250;

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
        public void EjecutarBcp()
        {
            comando.Connection = conexionA.AbrirConexionA();
            comando.CommandText = "SP_VALIDA_CARGOS_BCPSOL";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandTimeout = 2250;

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
        public void EjecutarInterbank()
        {
            comando.Connection = conexionA.AbrirConexionA();
            comando.CommandText = "SP_VALIDA_CARGOS_INTSOL";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandTimeout = 250;

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
        public void EjecutarScotiabank()
        {
            comando.Connection = conexionA.AbrirConexionA();
            comando.CommandText = "SP_VALIDA_CARGOS_SCOSOL";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandTimeout = 250;

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }       

        //ejecucion de centencia sql para poder visualizar cantidad de datos que se tiene en Arequipa de cadad banco
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
            comando.CommandTimeout = 250;

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }

        //contar cantidad de datos eliminados en arequipa
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

        //cantidad de errores que hay en arequipa y tacna
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
            comando.CommandTimeout = 250;

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
        //funcion de generacion de fecha en sql para poder correr cobranza diariamente
        public void CobranzaAqp()
        {
            comando.Connection = conexionA.AbrirConexionA();
            comando.CommandText = fecha + "exec SP_ATUALIZA_CONTABILIDADE @inicio,@final,'7'";
            comando.CommandType = CommandType.Text;
            comando.CommandTimeout = 320;

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }

        public void CobranzaTacna()
        {
            comando.Connection = conexionT.AbrirConexionT();
            comando.CommandText = fecha + "exec SP_ATUALIZA_CONTABILIDADE @inicio,@final,'8'";
            comando.CommandType = CommandType.Text;
            comando.CommandTimeout = 320;

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }

        public DataTable FechaCobranza()
        {
            comando.Connection = conexionA.AbrirConexionA();
            comando.CommandText = fecha + "select @final";
            //comando.CommandText = "select * from tmp_bcpr order by col004";
            comando.CommandType = CommandType.Text;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexionA.CerrarConexionA();
            return tabla;
        }

        //funciones creadas para poder extraer lo datos de la tabnla sql y poder llenar los excel
        public void ConsolidadoBbva()
        {
            comando.Connection = Conexion117.AbrirConexion117();
            comando.CommandText = "select col002,cast(col006 as float)/100 as soles  INTO [HISTORIAL].[DBO].[Bbva] from [spnetsrvaqp-bak].[SapiensNet2].[dbo].[TMP_BCPR]";
            comando.CommandType = CommandType.Text;            

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }

        public void ComparacionBbva()
        {
            comando.Connection = Conexion117.AbrirConexion117();
            comando.CommandText = "SELECT rtrim(rtrim(cli.NM_CLI)+' '+rtrim(cli.NM_PAI)+' '+rtrim(cli.NM_MAE))as nombre,sum(scoti.soles)as soles  into [HISTORIAL].[DBO].[DatosBbva]  " +
                                  "FROM  [spnetsrvaqp-bak].[SapiensNet2].[dbo].contratos cnt  inner join [HISTORIAL].[DBO].[Bbva] scoti on cnt.nr_contrato = scoti.col002 " +
                                  "inner join [spnetsrvaqp-bak].[SapiensNet2].[dbo].CLIENTES cli on cli.CD_CLI=cnt.CD_CLI group by rtrim(rtrim(cli.NM_CLI)+' '+rtrim(cli.NM_PAI)+' '+rtrim(cli.NM_MAE)),scoti.soles " +
                                  "union select rtrim(rtrim(clii.NM_CLI)+' '+rtrim(clii.NM_PAI)+' '+rtrim(clii.NM_MAE))as nombre,sum(scoti.soles) as soles from [192.168.101.8].SapiensNet.dbo.contratos cnti " +
                                  "inner join [HISTORIAL].[DBO].[Bbva] scoti on  cnti.nr_contrato = scoti.col002 inner join [192.168.101.8].SapiensNet.dbo.CLIENTES clii on clii.CD_CLI=cnti.CD_CLI group by  rtrim(rtrim(clii.NM_CLI)+' '+rtrim(clii.NM_PAI)+' '+rtrim(clii.NM_MAE)),scoti.soles";

            comando.CommandType = CommandType.Text;

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }

        public void ConsolidadoBcp()
        {
            comando.Connection = Conexion117.AbrirConexion117();
            comando.CommandText = "select col002,cast(col006 as float)/100 as soles  INTO [HISTORIAL].[DBO].[Bcp] from [spnetsrvaqp-bak].[SapiensNet2].[dbo].[TMP_BCPR]";
            comando.CommandType = CommandType.Text;

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }

        public void ComparacionBcp()
        {
            comando.Connection = Conexion117.AbrirConexion117();
            comando.CommandText = "SELECT rtrim(rtrim(cli.NM_CLI)+' '+rtrim(cli.NM_PAI)+' '+rtrim(cli.NM_MAE))as nombre,sum(scoti.soles)as soles  into [HISTORIAL].[DBO].[DatosBcp]  " +
                                  "FROM  [spnetsrvaqp-bak].[SapiensNet2].[dbo].contratos cnt  inner join [HISTORIAL].[DBO].[Bcp] scoti on cnt.nr_contrato = scoti.col002 " +
                                  "inner join [spnetsrvaqp-bak].[SapiensNet2].[dbo].CLIENTES cli on cli.CD_CLI=cnt.CD_CLI group by rtrim(rtrim(cli.NM_CLI)+' '+rtrim(cli.NM_PAI)+' '+rtrim(cli.NM_MAE)),scoti.soles " +
                                  "union select rtrim(rtrim(clii.NM_CLI)+' '+rtrim(clii.NM_PAI)+' '+rtrim(clii.NM_MAE))as nombre,sum(scoti.soles) as soles from [192.168.101.8].SapiensNet.dbo.contratos cnti " +
                                  "inner join [HISTORIAL].[DBO].[Bcp] scoti on  cnti.nr_contrato = scoti.col002 inner join [192.168.101.8].SapiensNet.dbo.CLIENTES clii on clii.CD_CLI=cnti.CD_CLI group by  rtrim(rtrim(clii.NM_CLI)+' '+rtrim(clii.NM_PAI)+' '+rtrim(clii.NM_MAE)),scoti.soles";

            comando.CommandType = CommandType.Text;

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
        public void ConsolidadoInterbank()
        {
            comando.Connection = Conexion117.AbrirConexion117();
            comando.CommandText = "select col002,cast(col006 as float)/100 as soles  INTO [HISTORIAL].[DBO].[Interbank] from [spnetsrvaqp-bak].[SapiensNet2].[dbo].[TMP_BCPR]";
            comando.CommandType = CommandType.Text;

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }

        public void ComparacionInterbank()
        {
            comando.Connection = Conexion117.AbrirConexion117();
            comando.CommandText = "SELECT rtrim(rtrim(cli.NM_CLI)+' '+rtrim(cli.NM_PAI)+' '+rtrim(cli.NM_MAE))as nombre,sum(scoti.soles)as soles  into [HISTORIAL].[DBO].[DatosInterbank]  " +
                                  "FROM  [spnetsrvaqp-bak].[SapiensNet2].[dbo].contratos cnt  inner join [HISTORIAL].[DBO].[Interbank] scoti on cnt.nr_contrato = scoti.col002 " +
                                  "inner join [spnetsrvaqp-bak].[SapiensNet2].[dbo].CLIENTES cli on cli.CD_CLI=cnt.CD_CLI group by rtrim(rtrim(cli.NM_CLI)+' '+rtrim(cli.NM_PAI)+' '+rtrim(cli.NM_MAE)),scoti.soles " +
                                  "union select rtrim(rtrim(clii.NM_CLI)+' '+rtrim(clii.NM_PAI)+' '+rtrim(clii.NM_MAE))as nombre,sum(scoti.soles) as soles from [192.168.101.8].SapiensNet.dbo.contratos cnti " +
                                  "inner join [HISTORIAL].[DBO].[Interbank] scoti on  cnti.nr_contrato = scoti.col002 inner join [192.168.101.8].SapiensNet.dbo.CLIENTES clii on clii.CD_CLI=cnti.CD_CLI group by  rtrim(rtrim(clii.NM_CLI)+' '+rtrim(clii.NM_PAI)+' '+rtrim(clii.NM_MAE)),scoti.soles";

            comando.CommandType = CommandType.Text;

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
        public void ConsolidadoScotiabank()
        {
            comando.Connection = Conexion117.AbrirConexion117();
            comando.CommandText = "select col002,cast(col006 as float)/100 as soles  INTO [HISTORIAL].[DBO].[Scotiabank] from [spnetsrvaqp-bak].[SapiensNet2].[dbo].[TMP_BCPR]";
            comando.CommandType = CommandType.Text;

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }

        public void ComparacionScotiabank()
        {
            comando.Connection = Conexion117.AbrirConexion117();
            comando.CommandText = "SELECT rtrim(rtrim(cli.NM_CLI)+' '+rtrim(cli.NM_PAI)+' '+rtrim(cli.NM_MAE))as nombre,sum(scoti.soles)as soles  into [HISTORIAL].[DBO].[DatosScotiabank]  " +
                                  "FROM  [spnetsrvaqp-bak].[SapiensNet2].[dbo].contratos cnt  inner join [HISTORIAL].[DBO].[Scotiabank] scoti on cnt.nr_contrato = scoti.col002 " +
                                  "inner join [spnetsrvaqp-bak].[SapiensNet2].[dbo].CLIENTES cli on cli.CD_CLI=cnt.CD_CLI group by rtrim(rtrim(cli.NM_CLI)+' '+rtrim(cli.NM_PAI)+' '+rtrim(cli.NM_MAE)),scoti.soles " +
                                  "union select rtrim(rtrim(clii.NM_CLI)+' '+rtrim(clii.NM_PAI)+' '+rtrim(clii.NM_MAE))as nombre,sum(scoti.soles) as soles from [192.168.101.8].SapiensNet.dbo.contratos cnti " +
                                  "inner join [HISTORIAL].[DBO].[Scotiabank] scoti on  cnti.nr_contrato = scoti.col002 inner join [192.168.101.8].SapiensNet.dbo.CLIENTES clii on clii.CD_CLI=cnti.CD_CLI group by  rtrim(rtrim(clii.NM_CLI)+' '+rtrim(clii.NM_PAI)+' '+rtrim(clii.NM_MAE)),scoti.soles";

            comando.CommandType = CommandType.Text;

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
        //mostrar datos en el data grid view para poder asi llenar los excel
        public DataTable TablaBbva()
        {
            comando.Connection = Conexion117.AbrirConexion117();
            comando.CommandText = "select nombre,sum(soles)as soles from [HISTORIAL].[DBO].[DatosBbva] group by nombre order by nombre";            
            comando.CommandType = CommandType.Text;

            leer = comando.ExecuteReader();

            tabla.Load(leer);

            Conexion117.CerrarConexion117();

            return tabla;
        }
        public DataTable TablaBcp()
        {
            comando.Connection = Conexion117.AbrirConexion117();
            comando.CommandText = "select nombre,sum(soles)as soles from [HISTORIAL].[DBO].[DatosBcp] group by nombre order by nombre";
            comando.CommandType = CommandType.Text;

            leer = comando.ExecuteReader();

            tabla.Load(leer);

            Conexion117.CerrarConexion117();

            return tabla;
        }
        public DataTable TablaInterbank()
        {
            comando.Connection = Conexion117.AbrirConexion117();
            comando.CommandText = "select nombre,sum(soles)as soles from [HISTORIAL].[DBO].[DatosInterbank] group by nombre order by nombre";
            comando.CommandType = CommandType.Text;

            leer = comando.ExecuteReader();

            tabla.Load(leer);

            Conexion117.CerrarConexion117();

            return tabla;
        }
        public DataTable TablaScotiabank()
        {
            comando.Connection = Conexion117.AbrirConexion117();
            comando.CommandText = "select nombre,sum(soles)as soles from [HISTORIAL].[DBO].[DatosScotiabank] group by nombre order by nombre";
            comando.CommandType = CommandType.Text;

            leer = comando.ExecuteReader();

            tabla.Load(leer);

            Conexion117.CerrarConexion117();

            return tabla;
        }

        //funcions para poder eliminar los datos de la tabla anterior y crear una nueva
        public void BorrarBbva()
        {
            comando.Connection = Conexion117.AbrirConexion117();
            comando.CommandText = "drop table [HISTORIAL].[dbo].[Bbva]";
            comando.CommandType = CommandType.Text;
            comando.CommandTimeout = 250;

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
        public void BorrarBcp()
        {
            comando.Connection = Conexion117.AbrirConexion117();
            comando.CommandText = "drop table [HISTORIAL].[dbo].[Bcp]";
            comando.CommandType = CommandType.Text;
            comando.CommandTimeout = 250;

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
        public void BorrarInterbank()
        {
            comando.Connection = Conexion117.AbrirConexion117();
            comando.CommandText = "drop table [HISTORIAL].[dbo].[Interbank]";
            comando.CommandType = CommandType.Text;
            comando.CommandTimeout = 250;

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
        public void BorrarScotiabank()
        {
            comando.Connection = Conexion117.AbrirConexion117();
            comando.CommandText = "drop table [HISTORIAL].[dbo].[Scotiabank]";
            comando.CommandType = CommandType.Text;
            comando.CommandTimeout = 250;

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
        public void BorrarRegistroBbva()
        {
            comando.Connection = Conexion117.AbrirConexion117();
            comando.CommandText = "drop table [HISTORIAL].[dbo].[RegistroBbva]";
            comando.CommandType = CommandType.Text;
            comando.CommandTimeout = 250;

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
        public void BorrarRegistroBcp()
        {
            comando.Connection = Conexion117.AbrirConexion117();
            comando.CommandText = "drop table [HISTORIAL].[dbo].[DatosBcp]";
            comando.CommandType = CommandType.Text;
            comando.CommandTimeout = 250;

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
        public void BorrarRegistroInterbank()
        {
            comando.Connection = Conexion117.AbrirConexion117();
            comando.CommandText = "drop table [HISTORIAL].[dbo].[DatosInterbank]";
            comando.CommandType = CommandType.Text;
            comando.CommandTimeout = 250;

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
        public void BorrarRegistroScotiabank()
        {
            comando.Connection = Conexion117.AbrirConexion117();
            comando.CommandText = "drop table [HISTORIAL].[dbo].[DatosScotiabank]";
            comando.CommandType = CommandType.Text;
            comando.CommandTimeout = 250;

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
    }
}
