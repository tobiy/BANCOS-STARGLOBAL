using System;
using System.Windows.Forms;
using Capa_Negocio;
using System.IO;

namespace Capa_Presentacion
{
    public partial class FormBancosDomingo : Form
    {
        CN_Bancos objetoCN = new CN_Bancos();
        CN_Aqp_Tacna objetos = new CN_Aqp_Tacna();

        //declaramos las variables para trabajar la transformacion de datos de los bancos

        int cabecera = 0;
        int detalle = 0;
        int contador = 0;
        int lineas = 0;
        int pie = 0;
        String fecha_cabecera = "";
        Double monto = 0;
        string abonado = "";
        string fecha = "";
        string limite = "";
        string dinero = "";
        string dia = "lunes";
        int a = 0;

        //creacion de variables para dar formato a la fecha 

        DateTime carpeta = DateTime.Today.AddDays(-1);
        DateTime carpeta1 = DateTime.Today.AddDays(-2);        

        public FormBancosDomingo()
        {
            InitializeComponent();
        }

        private void FormBancosDomingo_Load(object sender, EventArgs e)
        {

        }   

        //inicializacion de la calse error para mostar cantidad de errores en el proceso de bancos
        private void ErrorAqp()
        {
            CN_Aqp_Tacna objeto = new CN_Aqp_Tacna();
            dataGridView1.DataSource = objeto.ErrorAq();
        }
        //inicializacion de la calse para poder contar cantidad de datos que se procesan en arequipa    
        private void SelectDatosAqp()
        {
            CN_Aqp_Tacna objeto = new CN_Aqp_Tacna();
            dataGridView1.DataSource = objeto.SelectDatosAq();
        }
        //inicializacion de los datos para poder borrar datos en aqp
        private void EliminarDatosAqp()
        {
            CN_Aqp_Tacna objeto = new CN_Aqp_Tacna();
            dataGridView1.DataSource = objeto.EliminarDatosAq();
        }
        //calses creadas para poder la cantidad de pagos que se realizan en cada uno de los bancos
        private void SumaBbvaDomingo()
        {
            CN_Bancos objeto = new CN_Bancos();
            dataGridView1.DataSource = objeto.SumaBbvaDomingo();
        }        
        private void SumaInterbankDomingo()
        {
            CN_Bancos objeto = new CN_Bancos();
            dataGridView1.DataSource = objeto.SumaInterbankDomingo();
        }
        private void SumaScotiabankDomingo()
        {
            CN_Bancos objeto = new CN_Bancos();
            dataGridView1.DataSource = objeto.SumaScotiabankDomingo();
        }

        private void SelectDatosTacna()
        {
            CN_Aqp_Tacna objeto = new CN_Aqp_Tacna();
            dataGridView1.DataSource = objeto.SelectDatosTacn();
        }
        private void EliminarDatosTacna()
        {
            CN_Aqp_Tacna objeto = new CN_Aqp_Tacna();
            dataGridView1.DataSource = objeto.EliminarDatosTacn();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //transformacion y llenado de datos delo banco bcp        

        public void bancoBbva()
        {
            objetoCN.BorrarDat();
            try
            {
                string path = string.Format(@"\\192.168.101.36\Documentos - Sistemas\Progs\BBVA\{0}\{1}\{2}\Nuevo documento de texto.txt", carpeta.ToString("yyyy"), carpeta.ToString("MM"), carpeta.ToString("dd"));
                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.Peek() >= 0)
                    {
                        string linea = sr.ReadLine();
                        char tipo = Convert.ToChar(linea.Substring(1, 1));
                        string datos = linea.Substring(1);
                        switch (tipo)
                        {
                            case '1':
                                cabecera++;
                                fecha_cabecera = Convert.ToString(linea.Substring(19, 8));
                                break;

                            case '2':
                                detalle++;
                                abonado = Convert.ToString(linea.Substring(32, 8));
                                fecha = Convert.ToString(linea.Substring(135, 8));
                                limite = Convert.ToString(linea.Substring(40, 12));
                                dinero = Convert.ToString(linea.Substring(84, 11));

                                objetoCN.insertarDat(abonado, fecha, limite, dinero);

                                break;

                            case '3':
                                pie++;
                                lineas = Convert.ToInt32(linea.Substring(6, 5));
                                monto = Convert.ToDouble(linea.Substring(16, 10)) / 100;
                                break;

                            default:
                                contador++;
                                break;
                        }
                    }
                }
                Lbl_Total.Text = lineas.ToString();
                Lbl_Monto_Consolidado.Text = monto.ToString();
            }
            catch
            {
                Lbl_Error_archivo.Text = "Nombre del Archivo no coincise debe abrir Nuevo documento de texto";
                LimpiarLbl();
            }
            
            objetoCN.EditarTodoCampoFechaSolo();
           
            objetoCN.CeroBbva();

            objetos.EjecutarBbv();

            SelectDatosAqp();
            var Contaraqp = this.dataGridView1.Rows.Count.ToString();
            var totalaqp = Convert.ToInt32(Contaraqp);
            var contaraqp = totalaqp - 1;
            Lbl_Total_Aqp.Text = contaraqp.ToString();

            objetos.EjecutarSpcasAq();

            EliminarDatosAqp();

            SelectDatosTacna();
            var Contartacna = this.dataGridView1.Rows.Count.ToString();
            var totaltacna = Convert.ToInt32(Contartacna);
            var contartacna = totaltacna - 1;
            Lbl_Total_Tacna.Text = contartacna.ToString();

            objetos.EjecutarSpcasTacn();

            EliminarDatosTacna();

            ErrorAqp();
            var contarerror = this.dataGridView1.CurrentCell.Value.ToString();
            var contarerror1 = Convert.ToInt32(contarerror);
            Lbl_Total_Error.Text = contarerror1.ToString();

            SumaBbvaDomingo();
            var contarBbva = this.dataGridView1.CurrentCell.Value.ToString();
            var contarBbva1 = Convert.ToDouble(contarBbva);
            Lbl_Monto_Sapiens.Text = contarBbva1.ToString();

            var restadito = monto - contarBbva1;
            Lbl_Diferencia_Dinero.Text = restadito.ToString();

            var TotalDeDatos = contaraqp + contartacna;
            Lbl_Total_De_Datos.Text = TotalDeDatos.ToString();
        }

       

        public void bancoScotiabank()
        {
            objetoCN.BorrarDat();

            try
            {
                string path = string.Format(@"\\192.168.101.36\Documentos - Sistemas\Progs\Scotiabank\{0}\{1}\{2}\sbp{3}.txt", carpeta.ToString("yyyy"), carpeta.ToString("MM"), carpeta.ToString("dd"), carpeta1.ToString("MMdd"));
                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.Peek() >= 0)
                    {
                        string linea = sr.ReadLine();
                        char tipo = Convert.ToChar(linea.Substring(0, 1));
                        switch (tipo)
                        {
                            case 'C':
                                cabecera++;
                                fecha_cabecera = Convert.ToString(linea.Substring(14, 8));
                                lineas = Convert.ToInt32(linea.Substring(23, 8));
                                monto = Convert.ToDouble(linea.Substring(32, 14)) / 100;

                                break;
                            //extraer datos del cuerpo del txt
                            case 'D':
                                detalle++;
                                abonado = Convert.ToString(linea.Substring(14, 13));
                                fecha = Convert.ToString(linea.Substring(57, 8));
                                limite = Convert.ToString(linea.Substring(65, 8));
                                dinero = Convert.ToString(linea.Substring(74, 14));

                                objetoCN.insertarDat(abonado, fecha, limite, dinero);

                                break;

                            default:
                                contador++;
                                break;
                        }
                    }
                }
                Lbl_Total.Text = lineas.ToString();
                Lbl_Monto_Consolidado.Text = monto.ToString();
            }
            catch
            {
                Lbl_Error_archivo.Text = string.Format("Nombre del Archivo no coincise debe abrir sbp{0}", carpeta1.ToString("MMdd"));
                LimpiarLbl();
            }

            objetoCN.EditarTodoCampoFechaSolo();

            objetoCN.CeroScotiabank();

            objetos.EjecutarScotiaban();

            SelectDatosAqp();
            var Contaraqp = this.dataGridView1.Rows.Count.ToString();
            var totalaqp = Convert.ToInt32(Contaraqp);
            var contaraqp = totalaqp - 1;
            Lbl_Total_Aqp.Text = contaraqp.ToString();

            objetos.EjecutarSpcasAq();

            EliminarDatosAqp();

            SelectDatosTacna();
            var Contartacna = this.dataGridView1.Rows.Count.ToString();
            var totaltacna = Convert.ToInt32(Contartacna);
            var contartacna = totaltacna - 1;
            Lbl_Total_Tacna.Text = contartacna.ToString();

            objetos.EjecutarSpcasTacn();

            EliminarDatosTacna();

            ErrorAqp();
            var contarerror = this.dataGridView1.CurrentCell.Value.ToString();
            var contarerror1 = Convert.ToInt32(contarerror);
            Lbl_Total_Error.Text = contarerror1.ToString();

            SumaScotiabankDomingo();
            var contarScotiabank = this.dataGridView1.CurrentCell.Value.ToString();
            var contarScotiabank1 = Convert.ToDouble(contarScotiabank);
            Lbl_Monto_Sapiens.Text = contarScotiabank1.ToString();

            var restadito = monto - contarScotiabank1;
            Lbl_Diferencia_Dinero.Text = restadito.ToString();

            var TotalDeDatos = contaraqp + contartacna;
            Lbl_Total_De_Datos.Text = TotalDeDatos.ToString();
        }
        public void bancoInterbank()
        {
            objetoCN.BorrarDat();
            try
            {
                string path1 = string.Format(@"\\192.168.101.36\Documentos - Sistemas\Progs\INTERBANK\{0}\{1}\{2}\22073390118{3}.txt", carpeta.ToString("yyyy"), carpeta.ToString("MM"), carpeta.ToString("dd"), carpeta1.ToString("MMdd"));
                using (StreamReader sr1 = new StreamReader(path1))
                {
                    while (sr1.Peek() >= 0)
                    {
                        string linea1 = sr1.ReadLine();
                        char tipo1 = Convert.ToChar(linea1.Substring(0, 1));
                        string datos = linea1.Substring(1);
                        switch (tipo1)
                        {
                            case 'S':
                                cabecera++;
                                if (cabecera == 2)
                                {
                                    lineas = Convert.ToInt32(linea1.Substring(31, 8));
                                    monto = Convert.ToDouble(linea1.Substring(42, 12));
                                }
                                break;

                            default:
                                contador++;

                                break;
                        }
                    }
                }
                try
                {
                    string path = string.Format(@"\\192.168.101.36\Documentos - Sistemas\Progs\INTERBANK\{0}\{1}\{2}\21073390118{3}.txt", carpeta.ToString("yyyy"), carpeta.ToString("MM"), carpeta.ToString("dd"), carpeta1.ToString("MMdd"));
                    using (StreamReader sr = new StreamReader(path))
                    {
                        while (sr.Peek() >= 0)
                        {
                            string linea = sr.ReadLine();
                            char tipo = Convert.ToChar(linea.Substring(1, 1));
                            string datos = linea.Substring(1);
                            switch (tipo)
                            {
                                case '7':

                                    detalle++;
                                    fecha_cabecera = Convert.ToString(linea.Substring(82, 8));
                                    abonado = Convert.ToString(linea.Substring(9, 6));
                                    fecha = Convert.ToString(linea.Substring(82, 8));
                                    limite = Convert.ToString(linea.Substring(29, 8));
                                    dinero = Convert.ToString(linea.Substring(101, 8));

                                    objetoCN.insertarDat(abonado, fecha, limite, dinero);

                                    break;

                                default:
                                    contador++;
                                    break;
                            }
                        }
                    }
                }
                catch
                {
                    Lbl_Error_archivo.Text = string.Format("Nombre del Archivo no coincise debe abrir 21073390118{0}", carpeta.ToString("MMdd"));
                    LimpiarLbl();
                }

                Lbl_Total.Text = lineas.ToString();
                Lbl_Monto_Consolidado.Text = monto.ToString();
            }
            catch
            {
                Lbl_Error_archivo.Text = string.Format("Nombre del Archivo no coincise debe abrir 22073390118{0}", carpeta.ToString("MMdd"));
                LimpiarLbl();
            }
            objetoCN.EditarTodoCampoFecha();
            objetoCN.CeroInterbank();

            objetos.EjecutarInterban();

            SelectDatosAqp();
            var Contaraqp = this.dataGridView1.Rows.Count.ToString();
            var totalaqp = Convert.ToInt32(Contaraqp);
            var contaraqp = totalaqp - 1;
            Lbl_Total_Aqp.Text = contaraqp.ToString();

            objetos.EjecutarSpcasAq();

            EliminarDatosAqp();

            SelectDatosTacna();
            var Contartacna = this.dataGridView1.Rows.Count.ToString();
            var totaltacna = Convert.ToInt32(Contartacna);
            var contartacna = totaltacna - 1;
            Lbl_Total_Tacna.Text = contartacna.ToString();

            objetos.EjecutarSpcasTacn();

            EliminarDatosTacna();

            ErrorAqp();
            var contarerror = this.dataGridView1.CurrentCell.Value.ToString();
            var contarerror1 = Convert.ToInt32(contarerror);
            Lbl_Total_Error.Text = contarerror1.ToString();

            SumaInterbankDomingo();
            var contarInterbank = this.dataGridView1.CurrentCell.Value.ToString();
            var contarInterbank1 = Convert.ToDouble(contarInterbank);
            Lbl_Monto_Sapiens.Text = contarInterbank1.ToString();

            var restadito = monto - contarInterbank1;
            Lbl_Diferencia_Dinero.Text = restadito.ToString();

            var TotalDeDatos = contaraqp + contartacna;
            Lbl_Total_De_Datos.Text = TotalDeDatos.ToString();
        }
        public void LimpiarLbl()
        {
            Lbl_Total.Text = "";
        }

        private void BtnCerrar_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void siguiente_Click(object sender, EventArgs e)
        {
            FromSeleccionarDIa frm = new FromSeleccionarDIa();
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }
    }
}
