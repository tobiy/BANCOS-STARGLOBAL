using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Presentacion
{
    public partial class FromSeleccionarDIa : Form
    {
        public FromSeleccionarDIa()
        {
            InitializeComponent();
        }

        private void BtnDomingo_Click(object sender, EventArgs e)
        {
            FormBancosDomingo frm = new FormBancosDomingo();
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }        

        private void BtnSemana_Click(object sender, EventArgs e)
        {
            FormBancos frm = new FormBancos();
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
