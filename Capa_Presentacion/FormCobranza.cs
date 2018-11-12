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
        private void Desconectados_Load(object sender, EventArgs e)
        {

        }
        private void cobranza()
        {
            CN_Aqp_Tacna objeto = new CN_Aqp_Tacna();
            dataGridCargarBancos.DataSource = objeto.FechaCobranza();
        }

        public void EnviarCorreoA()
        {          
            //Creamos un nuevo Objeto de mensaje
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            //Direccion de correo electronico a la que queremos enviar el mensaje
            mmsg.To.Add("ecolca@lscvsystems.com,jnunez@lscvsystems.com");

            //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario

            cobranza();

            var cobranzaqp = this.dataGridCargarBancos.CurrentCell.Value.ToString();
            var totalcobranza = Convert.ToString(cobranzaqp);
            //Asunto
            mmsg.Subject = "Fecha de cobranza";
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            //Direccion de correo electronico que queremos que reciba una copia del mensaje
            mmsg.Bcc.Add("jnunez@lscvsystems.com"); //Opcional
            //Cuerpo del Mensaje
            mmsg.Body = "Se Corrio la Cobranza de Arequipa con Fecha: " + totalcobranza.ToString();
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = false; //Si no queremos que se envíe como HTML

            //Correo electronico desde la que enviamos el mensaje
            mmsg.From = new System.Net.Mail.MailAddress("jnunez@lscvsystems.com");

            //Creamos un objeto de cliente de correo
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            //Hay que crear las credenciales del correo emisor
            cliente.Credentials =
                new System.Net.NetworkCredential("jnunez@lscvsystems.com", "ingresar correo");

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

        public void EnviarCorreoT()
        {
            //Creamos un nuevo Objeto de mensaje
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            //Direccion de correo electronico a la que queremos enviar el mensaje
            mmsg.To.Add("ecolca@lscvsystems.com,jnunez@lscvsystems.com");

            //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario

            cobranza();

            var cobranzaqp = this.dataGridCargarBancos.CurrentCell.Value.ToString();
            var totalcobranza = Convert.ToString(cobranzaqp);
            //Asunto
            mmsg.Subject = "Fecha de cobranza";
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            //Direccion de correo electronico que queremos que reciba una copia del mensaje
            mmsg.Bcc.Add("jnunez@lscvsystems.com"); //Opcional
            //Cuerpo del Mensaje
            mmsg.Body = "Se Corrio la Cobranza de Tacna con Fecha: " + totalcobranza.ToString();
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = false; //Si no queremos que se envíe como HTML

            //Correo electronico desde la que enviamos el mensaje
            mmsg.From = new System.Net.Mail.MailAddress("jnunez@lscvsystems.com");

            //Creamos un objeto de cliente de correo
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            //Hay que crear las credenciales del correo emisor
            cliente.Credentials =
                new System.Net.NetworkCredential("jnunez@lscvsystems.com", "ingresar correo");

            cliente.Host = "mail.lscvsystems.com"; //Para Gmail "smtp.gmail.com";

            try
            {
                //Enviamos el mensaje      
                cliente.Send(mmsg);
            }
            catch (System.Net.Mail.SmtpException ex)
            {

            }
        }

        private void BtnCargarAqpTacna_Click(object sender, EventArgs e)
        {            
            objetos.CobranzaTacna();
            //EnviarCorreoA();
            
        }      

        private void BtnDesconectadosAqp_Click(object sender, EventArgs e)
        {
            objetos.CobranzaAqp();
            //EnviarCorreoT();
        }
    }
}
