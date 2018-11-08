using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Capa_Presentacion
{
    public partial class ContenedorPrincipal : Form
    {
        public ContenedorPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //proporcion de codigo que funciona para poder mover la pantalla con el cursor

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void Barra_Titulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //funcion para poder abrir el form dentro de un panel
       
        public void AbrirFormHija(object formhija)
        {
            if (this.Panel_Principal.Controls.Count > 0)
                this.Panel_Principal.Controls.RemoveAt(0);
            Form fh = formhija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.Panel_Principal.Controls.Add(fh);
            this.Panel_Principal.Tag = fh;
            fh.Show();
        }      
        //seccioin de botones para poder dar funcionamieto al form principal
        private void Btn_Cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Btn_Maximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Btn_Maximizar.Visible = false;
            Btn_Restaurar.Visible = true;
        }

        private void Btn_Restaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            Btn_Restaurar.Visible = false;
            Btn_Maximizar.Visible = true;
        }

        private void Btn_Minimisar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SubmenuBancos.Visible = true;
        }
        private void Btn_Domingo_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new FormBancosDomingo());
            SubmenuBancos.Visible = false;
        }
        private void Btn_Semana_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new FormBancos());
            SubmenuBancos.Visible = false;
        }
        public void Btn_Abrir_Cobranza_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new FormCobranza());
        }
        private void Btn_Abrir_Comparacion_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new FormTransformador());
        }

        private void Btn_Correr_Click(object sender, EventArgs e)
        {
            if (Menu_Vertical.Width == 220)
            {
                Menu_Vertical.Width = 50;
            }
            else
                Menu_Vertical.Width = 220;
        }
    }
}
