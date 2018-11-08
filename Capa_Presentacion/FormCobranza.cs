using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Negocio;
using System.IO;
using Microsoft.Office.Interop;
using Excel = Microsoft.Office.Interop.Excel;


namespace Capa_Presentacion
{
    public partial class FormCobranza : Form
    {
        CN_Aqp_Tacna objetos = new CN_Aqp_Tacna();
        CN_Bancos objetoCN = new CN_Bancos();


        public FormCobranza()
        {
            InitializeComponent();
        }

        private void BtnBbva_Click(object sender, EventArgs e)
        {
            //~~> Define your Excel Objects
            Excel.Application xlApp = new Excel.Application();

            Excel.Workbook xlWorkBook;

            //~~> Start Excel and open the workbook.
            xlWorkBook = xlApp.Workbooks.Open(@"C:\Users\arni_\OneDrive\Documentos\trabajo para hacer  star global\prueba\output.xlsx");

            //~~> Run the macros by supplying the necessary arguments
            xlApp.Run("COMPARACION", "Hello from C# Client", "Demo to run Excel macros from C#");

            //~~> Clean-up: Close the workbook
            xlWorkBook.Close(false);

            //~~> Quit the Excel Application
            xlApp.Quit();

            //~~> Clean Up
            releaseObject(xlApp);
            releaseObject(xlWorkBook);
            //objetos.CobranzaTacna();
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }
        private void Desconectados_Load(object sender, EventArgs e)
        {

        }
        private void cobranza()
        {
            CN_Aqp_Tacna objeto = new CN_Aqp_Tacna();
            dataGridCargarBancos.DataSource = objeto.FechaCobranza();
        }

        public void EnviarCorreo()
        {
            /*-------------------------MENSAJE DE CORREO----------------------*/

            //Creamos un nuevo Objeto de mensaje
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            //Direccion de correo electronico a la que queremos enviar el mensaje
            mmsg.To.Add("ecolca@lscvsystems.com");

            //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario

            cobranza();

            var cobranzaqp = this.dataGridCargarBancos.CurrentCell.Value.ToString();
            var totalcobranza = Convert.ToString(cobranzaqp);
            //Asunto
            mmsg.Subject = "Ejecucion de cobranza";
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            //Direccion de correo electronico que queremos que reciba una copia del mensaje
            mmsg.Bcc.Add("jnunez@lscvsystems.com,atovar@lscvsystems.com"); //Opcional
            //Cuerpo del Mensaje
            mmsg.Body = "Se Corrio la Cobranza de Arequipa y Tacna con Fecha: " + totalcobranza.ToString();
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = false; //Si no queremos que se envíe como HTML

            //Correo electronico desde la que enviamos el mensaje
            mmsg.From = new System.Net.Mail.MailAddress("atovar@lscvsystems.com");


            /*-------------------------CLIENTE DE CORREO----------------------*/

            //Creamos un objeto de cliente de correo
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            //Hay que crear las credenciales del correo emisor
            cliente.Credentials =
                new System.Net.NetworkCredential("atovar@lscvsystems.com", "Seguridad2018");

            //Lo siguiente es obligatorio si enviamos el mensaje desde Gmail
            /*
            cliente.Port = 587;
            cliente.EnableSsl = true;
            */

            cliente.Host = "mail.lscvsystems.com"; //Para Gmail "smtp.gmail.com";


            /*-------------------------ENVIO DE CORREO----------------------*/

            try
            {
                //Enviamos el mensaje      
                cliente.Send(mmsg);
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                //Aquí gestionamos los errores al intentar enviar el correo
            }
        }

        private void BtnCargarAqpTacna_Click(object sender, EventArgs e)
        {
            //objetos.CobranzaAqp();
            objetos.CobranzaTacna();
            //EnviarCorreo();
            
        }      

        private void BtnDesconectadosAqp_Click(object sender, EventArgs e)
        {
            objetos.CobranzaAqp();            
        }

        //froma de como generar txt para subida de bancos


        //TextWriter sw = new StreamWriter(@"C:\Users\arni_\OneDrive\Documentos\trabajo para hacer  star global\prueba\bbva11.txt");
        //int rowcount = dataGridDesconectadosAqp.Rows.Count;
        //for (int i = 0; i < rowcount - 1; i++)
        //{
        //    sw.WriteLine(dataGridDesconectadosAqp.Rows[i].Cells[0].Value.ToString());
        //}
        //sw.Close();     //Don't Forget Close the TextWriter Object(sw)

    }

}
