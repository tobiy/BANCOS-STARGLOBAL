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
        //declaracion de variables para almacenar datos de una sentencia slq para ahorrar espacio en el codigo
        string fecha = "DECLARE @total1 float,@total2 float,@suma_total float,@FEC_REG DATETIME SET @FEC_REG = (SELECT LTRIM(RTRIM(YEAR(GETDATE())))+'-'+RIGHT('0' + LTRIM(RTRIM(MONTH(GETDATE()))),2)+'-'+RIGHT('0' + LTRIM(RTRIM(DAY(GETDATE()-1))),2))";
        string FechaDomingo = "DECLARE @total1 float,@total2 float,@suma_total float,@FEC_REG DATETIME SET @FEC_REG = (SELECT LTRIM(RTRIM(YEAR(GETDATE())))+'-'+RIGHT('0' + LTRIM(RTRIM(MONTH(GETDATE()))),2)+'-'+RIGHT('0' + LTRIM(RTRIM(DAY(GETDATE()-2))),2))";
        string FechaBcpLunes = "DECLARE @total1 float,@total2 float,@suma_total float,@FEC_REG DATETIME,@total3 float,@total4 float,@suma_total1 float,@FEC_REG1 DATETIME,@suma_total2 float SET @FEC_REG = (SELECT LTRIM(RTRIM(YEAR(GETDATE())))+'-'+RIGHT('0' + LTRIM(RTRIM(MONTH(GETDATE()))),2)+'-'+RIGHT('0' + LTRIM(RTRIM(DAY(GETDATE()-1))),2)) SET @FEC_REG1 = (SELECT LTRIM(RTRIM(YEAR(GETDATE())))+'-'+RIGHT('0' + LTRIM(RTRIM(MONTH(GETDATE()))),2)+'-'+RIGHT('0' + LTRIM(RTRIM(DAY(GETDATE()-2))),2))";

        //funciones para llenar fechas de acuerdo al dia que se le asigna en el codigo 
        public void EditarTodasFechas()
        {           
            comando.Connection = conexionA.AbrirConexionA();
            comando.CommandText = "update TMP_BCPR set col004 =(SELECT (CONVERT(VARCHAR(10),GETDATE()-1,112)))";
            comando.CommandType = CommandType.Text;

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
        public void EditarTodasFechasSolo()
        {
            comando.Connection = conexionA.AbrirConexionA();
            comando.CommandText = "update TMP_BCPR set col004 =(SELECT (CONVERT(VARCHAR(10),GETDATE()-2,112)))";
            //comando.CommandText = "update TMP_BCPR set col004 =(SELECT LTRIM(RTRIM(YEAR(GETDATE())))+RIGHT('0' + LTRIM(RTRIM(MONTH(GETDATE())-1)),2)+RIGHT('0' + LTRIM(RTRIM(DAY(GETDATE()-2))),2))";
            //comando.CommandText = "update TMP_BCPR set col004 ='20181102'";
            comando.CommandType = CommandType.Text;

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
        public void FechaBcp()
        {
            
            comando.Connection = conexionA.AbrirConexionA();
            comando.CommandText = "update TMP_BCPR set col004 =(SELECT (CONVERT(VARCHAR(10),GETDATE()-2,112))) where col004 in (Select col004 from TMP_BCPR where col004 < (SELECT (CONVERT(VARCHAR(10),GETDATE()-1,112))))";
            comando.CommandType = CommandType.Text;

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }

        // autocompletar de ceros en los datos extraidos en el consolidado para poder procesar los bancos.
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

        //ver cantidad de datos borrados en el datagridview para poder llenar un label en la pantalla principal
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
        //llenar la base de datos de spues de haber analizado los txt para poder obtener los ingresos de los bancos ese dia
        public void InsertarData(string abonado, string fecha, string limite,string dinero)
        {
            comando.Connection = conexionA.AbrirConexionA();
            comando.CommandText = string.Format("INSERT INTO TMP_BCPR (COL002,COL004,COL005,COL006) VALUES ({0},{1},{2},{3})", abonado, fecha, limite, dinero);
            comando.CommandType = CommandType.Text;

            cantidad = comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }

        //crear tablas en la base de datos 117 para poder tener un historial de datos cuando se quiera comparar los datos 
        public DataTable DatoSapiensBbva()
        {
            comando.Connection = conexionA.AbrirConexionA();
            comando.CommandText = fecha +"select rtrim(rtrim(clii.NM_CLI)+' '+rtrim(clii.NM_PAI)+' '+rtrim(clii.NM_MAE))as nombre, sum(-movi.vl_mov) as vl_mov from MOV_CONTARECEBER movi INNER JOIN CONTAS_RECEBER cri ON movi.sq_ctarec = cri.sq_ctarec inner join contratos cnti on movi.nr_contrato = cnti.nr_contrato inner join CLIENTES clii on clii.CD_CLI=cnti.CD_CLI where movi.CD_AGTCOB = 76 and  movi.dt_mov = @FEC_REG and  movi.cd_mov = 3 group by rtrim(rtrim(clii.NM_CLI)+' '+rtrim(clii.NM_PAI)+' '+rtrim(clii.NM_MAE)) UNION select rtrim(rtrim(clii.NM_CLI)+' '+rtrim(clii.NM_PAI)+' '+rtrim(clii.NM_MAE))as nombre, sum(-movi.vl_mov) as vl_mov from [spnetsrvtac-bak].[SapiensNet].[dbo].[MOV_CONTARECEBER] movi INNER JOIN [spnetsrvtac-bak].[SapiensNet].[dbo].CONTAS_RECEBER cri ON movi.sq_ctarec = cri.sq_ctarec inner join [spnetsrvtac-bak].[SapiensNet].[dbo].contratos cnti on movi.nr_contrato = cnti.nr_contrato inner join [spnetsrvtac-bak].[SapiensNet].[dbo].CLIENTES clii on clii.CD_CLI=cnti.CD_CLI where movi.CD_AGTCOB = 403 and  movi.dt_mov = @FEC_REG and  movi.cd_mov = 3 group by rtrim(rtrim(clii.NM_CLI)+' '+rtrim(clii.NM_PAI)+' '+rtrim(clii.NM_MAE)) order by nombre";
            comando.CommandType = CommandType.Text;
            comando.CommandTimeout = 200;
            leer = comando.ExecuteReader();

            tabla.Load(leer);

            conexionA.CerrarConexionA();

            return tabla;
        }
        public DataTable DatoSapiensBcp()
        {
            comando.Connection = conexionA.AbrirConexionA();
            comando.CommandText = fecha + "select rtrim(rtrim(clii.NM_CLI)+' '+rtrim(clii.NM_PAI)+' '+rtrim(clii.NM_MAE))as nombre, sum(-movi.vl_mov) as vl_mov from MOV_CONTARECEBER movi INNER JOIN CONTAS_RECEBER cri ON movi.sq_ctarec = cri.sq_ctarec inner join contratos cnti on movi.nr_contrato = cnti.nr_contrato inner join CLIENTES clii on clii.CD_CLI=cnti.CD_CLI where movi.CD_AGTCOB = 55 and  movi.dt_mov = @FEC_REG and  movi.cd_mov = 3 group by rtrim(rtrim(clii.NM_CLI)+' '+rtrim(clii.NM_PAI)+' '+rtrim(clii.NM_MAE)) UNION select rtrim(rtrim(clii.NM_CLI)+' '+rtrim(clii.NM_PAI)+' '+rtrim(clii.NM_MAE))as nombre, sum(-movi.vl_mov) as vl_mov from [spnetsrvtac-bak].[SapiensNet].[dbo].[MOV_CONTARECEBER] movi INNER JOIN [spnetsrvtac-bak].[SapiensNet].[dbo].CONTAS_RECEBER cri ON movi.sq_ctarec = cri.sq_ctarec inner join [spnetsrvtac-bak].[SapiensNet].[dbo].contratos cnti on movi.nr_contrato = cnti.nr_contrato inner join [spnetsrvtac-bak].[SapiensNet].[dbo].CLIENTES clii on clii.CD_CLI=cnti.CD_CLI where movi.CD_AGTCOB = 387 and  movi.dt_mov = @FEC_REG and  movi.cd_mov = 3 group by rtrim(rtrim(clii.NM_CLI)+' '+rtrim(clii.NM_PAI)+' '+rtrim(clii.NM_MAE)) order by nombre";
            comando.CommandType = CommandType.Text;
            comando.CommandTimeout = 200;
            leer = comando.ExecuteReader();

            tabla.Load(leer);

            conexionA.CerrarConexionA();

            return tabla;
        }
        public DataTable DatoSapiensInterbank()
        {
            comando.Connection = conexionA.AbrirConexionA();
            comando.CommandText = "select rtrim(rtrim(clii.NM_CLI)+' '+rtrim(clii.NM_PAI)+' '+rtrim(clii.NM_MAE))as nombre, sum(-movi.vl_mov) as vl_mov from MOV_CONTARECEBER movi INNER JOIN CONTAS_RECEBER cri ON movi.sq_ctarec = cri.sq_ctarec inner join contratos cnti on movi.nr_contrato = cnti.nr_contrato inner join CLIENTES clii on clii.CD_CLI=cnti.CD_CLI where movi.CD_AGTCOB = 63 and  movi.dt_mov = '2018-10-31' and  movi.cd_mov = 3 group by rtrim(rtrim(clii.NM_CLI)+' '+rtrim(clii.NM_PAI)+' '+rtrim(clii.NM_MAE)) UNION select rtrim(rtrim(clii.NM_CLI)+' '+rtrim(clii.NM_PAI)+' '+rtrim(clii.NM_MAE))as nombre, sum(-movi.vl_mov) as vl_mov from [spnetsrvtac-bak].[SapiensNet].[dbo].[MOV_CONTARECEBER] movi INNER JOIN [spnetsrvtac-bak].[SapiensNet].[dbo].CONTAS_RECEBER cri ON movi.sq_ctarec = cri.sq_ctarec inner join [spnetsrvtac-bak].[SapiensNet].[dbo].contratos cnti on movi.nr_contrato = cnti.nr_contrato inner join [spnetsrvtac-bak].[SapiensNet].[dbo].CLIENTES clii on clii.CD_CLI=cnti.CD_CLI where movi.CD_AGTCOB = 391 and  movi.dt_mov = '2018-10-31' and  movi.cd_mov = 3 group by rtrim(rtrim(clii.NM_CLI)+' '+rtrim(clii.NM_PAI)+' '+rtrim(clii.NM_MAE)) order by nombre";
            comando.CommandType = CommandType.Text;
            comando.CommandTimeout = 200;
            leer = comando.ExecuteReader();

            tabla.Load(leer);

            conexionA.CerrarConexionA();

            return tabla;
        }
        public DataTable DatoSapiensScotiabank()
        {
            comando.Connection = conexionA.AbrirConexionA();
            comando.CommandText = fecha + "select rtrim(rtrim(clii.NM_CLI)+' '+rtrim(clii.NM_PAI)+' '+rtrim(clii.NM_MAE))as nombre, sum(-movi.vl_mov) as vl_mov from MOV_CONTARECEBER movi INNER JOIN CONTAS_RECEBER cri ON movi.sq_ctarec = cri.sq_ctarec inner join contratos cnti on movi.nr_contrato = cnti.nr_contrato inner join CLIENTES clii on clii.CD_CLI=cnti.CD_CLI where movi.CD_AGTCOB = 86 and  movi.dt_mov = @FEC_REG and  movi.cd_mov = 3 group by rtrim(rtrim(clii.NM_CLI)+' '+rtrim(clii.NM_PAI)+' '+rtrim(clii.NM_MAE)) UNION select rtrim(rtrim(clii.NM_CLI)+' '+rtrim(clii.NM_PAI)+' '+rtrim(clii.NM_MAE))as nombre, sum(-movi.vl_mov) as vl_mov from [spnetsrvtac-bak].[SapiensNet].[dbo].[MOV_CONTARECEBER] movi INNER JOIN [spnetsrvtac-bak].[SapiensNet].[dbo].CONTAS_RECEBER cri ON movi.sq_ctarec = cri.sq_ctarec inner join [spnetsrvtac-bak].[SapiensNet].[dbo].contratos cnti on movi.nr_contrato = cnti.nr_contrato inner join [spnetsrvtac-bak].[SapiensNet].[dbo].CLIENTES clii on clii.CD_CLI=cnti.CD_CLI where movi.CD_AGTCOB = 414 and  movi.dt_mov = @FEC_REG and  movi.cd_mov = 3 group by rtrim(rtrim(clii.NM_CLI)+' '+rtrim(clii.NM_PAI)+' '+rtrim(clii.NM_MAE)) order by nombre";
            comando.CommandType = CommandType.Text;
            comando.CommandTimeout = 200;
            leer = comando.ExecuteReader();

            tabla.Load(leer);

            conexionA.CerrarConexionA();

            return tabla;
        }

    }
}
