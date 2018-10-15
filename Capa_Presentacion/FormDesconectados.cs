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

namespace Capa_Presentacion
{
    public partial class Lbl_Monto_Consolidado : Form
    {
        CN_Aqp_Tacna objetos = new CN_Aqp_Tacna();
    
           
        public Lbl_Monto_Consolidado()
        {
            InitializeComponent();
        }

        private void BtnBbva_Click(object sender, EventArgs e)
        {

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
            mmsg.Body = "se corrio la cobranza con fecha: " + totalcobranza.ToString();
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
            EnviarCorreo();
            
        }
    }
}
