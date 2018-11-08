using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Capa_Datos;

namespace Capa_Negocio
{
    public class CN_Bancos
    {
        private CD_Bancos objetoCD = new CD_Bancos();

        //llamar a todas las funciones de la capa de datos 
        public void EditarTodoCampoFecha() 
        {
            objetoCD.EditarTodasFechas();
        }
        public void EditarTodoCampoFechaSolo()
        {
            objetoCD.EditarTodasFechasSolo();
        }
        public void FechaBcp()
        {
            objetoCD.FechaBcp();
        }
        public void CeroBcp()
        {
            objetoCD.CerosBcp();
        }
        public void CeroBbva()
        {
            objetoCD.CerosBbva();
        }
        public void CeroInterbank()
        {
            objetoCD.CerosInterbank();
        }
        public void CeroScotiabank()
        {
            objetoCD.CerosScotiabank();
        }
        //llenar el datagridview para poder extraer los datos  y mostrarlos en un label
        
        public DataTable BorrarDat()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.BorrarData();
            return tabla;
        }
        public DataTable SumaBbva()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.SumaBbva();
            return tabla;
        }
        public DataTable SumaBbvaDomingo()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.SumaBbvaDomingo();
            return tabla;
        }
        public DataTable SumaBcp()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.SumaBcp();
            return tabla;
        }
        public DataTable SumaBcpLunes()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.SumaBcpLunes();
            return tabla;
        }
        public DataTable SumaInterbank()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.SumaInterbank();
            return tabla;
        }
        public DataTable SumaInterbankDomingo()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.SumaInterbankDomingo();
            return tabla;
        }
        public DataTable SumaScotiabank()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.SumaScotiabank();
            return tabla;
        }
        public DataTable SumaScotiabankDomingo()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.SumaScotiabankDomingo();
            return tabla;
        }
        public void insertarDat(string abonado, string fecha, string limite, string dinero)
        {
            objetoCD.InsertarData(abonado,fecha,limite,dinero);           
        }
        public DataTable DatoSapiensBbva()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.DatoSapiensBbva();
            return tabla;
        }
        public DataTable DatoSapiensBcp()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.DatoSapiensBcp();
            return tabla;
        }
        public DataTable DatoSapiensInterbank()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.DatoSapiensInterbank();
            return tabla;
        }
        public DataTable DatoSapiensScotiabank()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.DatoSapiensScotiabank();
            return tabla;
        }
    }
}
