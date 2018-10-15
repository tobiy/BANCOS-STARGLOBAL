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
    }
}
