using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Capa_Datos;

namespace Capa_Negocio
{
    public class CN_Aqp_Tacna
    {
        private CD_Aqp_Tacna objetoCD = new CD_Aqp_Tacna();

        //tipo de ejecucion de cada banco 
        public void EjecutarBbv()
        {           
            objetoCD.EjecutarBbva();
        }
        public void EjecutarBc()
        {
            objetoCD.EjecutarBcp();            
        }
        public void EjecutarInterban()
        {
            objetoCD.EjecutarInterbank();
        }
        public void EjecutarScotiaban()
        {            
            objetoCD.EjecutarScotiabank();           
        }  
        
        //Funcion para poder capturar el dato de la tabla sql para poder ver los mensajes por medio de un data    gridview
        public DataTable SelectDatosAq()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.SelectDatosAqp();
            return tabla;
        }
        public void EjecutarSpcasAq()
        {
           objetoCD.EjecutarSpcasAqp();
        }
        public DataTable EliminarDatosAq()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.EliminarDatosAqp();
            return tabla;
        }
        public DataTable ErrorAq()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.ErrorAqp();
            return tabla;
        }
        public DataTable SelectDatosTacn()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.SelectDatosTacna();
            return tabla;
        }
        public void EjecutarSpcasTacn()
        {
            objetoCD.EjecutarSpcasTacna();
        }
        public DataTable EliminarDatosTacn()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.EliminarDatosTacna();
            return tabla;
        }
        public DataTable ErrorTacn()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.ErrorTacna();
            return tabla;
        }
        public DataTable FechaCobranza()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.FechaCobranza();
            return tabla;
        }
        //crear lka funcion cobranza para poder llamarla mas adelante para poder ponerla en un boton
        public void CobranzaAqp()
        {
            objetoCD.CobranzaAqp();
        }
        public void CobranzaTacna()
        {
            objetoCD.CobranzaTacna();
        }
        public void ConsolidadoBbva()
        {
            objetoCD.ConsolidadoBbva();
        }
        public void ComparacionBbva()
        {
            objetoCD.ComparacionBbva();            
        }
        public void ConsolidadoBcp()
        {
            objetoCD.ConsolidadoBcp();
        }
        public void ComparacionBcp()
        {
           objetoCD.ComparacionBcp();
        }
        public void ConsolidadoInterbank()
        {
            objetoCD.ConsolidadoInterbank();
        }
        public void ComparacionInterbank()
        {
            objetoCD.ComparacionInterbank();            
        }
        public void ConsolidadoScotiabank()
        {
            objetoCD.ConsolidadoScotiabank();
        }
        public void ComparacionScotiabank()
        {
            objetoCD.ComparacionScotiabank();
        }
        public DataTable TablaBbva()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.TablaBbva();
            return tabla;
        }
        public DataTable TablaBcp()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.TablaBcp();
            return tabla;
        }
        public DataTable TablaInterbank()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.TablaInterbank();
            return tabla;
        }
        public DataTable TablaScotiabank()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.TablaScotiabank();
            return tabla;
        }
        public void BorrarBbva()
        {
            objetoCD.BorrarBbva();
        }
        //borrar la tabla an labase de datos 117 para guardar espacio al comparar registros

        public void BorrarBcp()
        {
            objetoCD.BorrarBcp();
        }
        public void BorrarInterbank()
        {
            objetoCD.BorrarInterbank();
        }
        public void BorrarScotiabank()
        {
            objetoCD.BorrarScotiabank();
        }
        public void BorrarRegistroBbva()
        {
            objetoCD.BorrarRegistroBbva();
        }
        public void BorrarRegistroBcp()
        {
            objetoCD.BorrarRegistroBcp();
        }
        public void BorrarRegistroInterbank()
        {
            objetoCD.BorrarRegistroInterbank();
        }
        public void BorrarRegistroScotiabank()
        {
            objetoCD.BorrarRegistroScotiabank();
        }
    }
}
