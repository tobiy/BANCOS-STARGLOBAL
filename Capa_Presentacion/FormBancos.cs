﻿using System;
using System.Windows.Forms;
using Capa_Negocio;
using System.IO;

namespace Capa_Presentacion
{
    public partial class FormBancos : Form
    {
        //declarar dos varialbes para poder hacer el llamado de datos de la capa de negocio

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


        //creacion de variables para dar formato a la fecha 

        DateTime carpeta = DateTime.Today.AddDays(0);
        DateTime carpeta1 = DateTime.Today.AddDays(-1);

        


        public FormBancos()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
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
        private void SumaBbva()
        {
            CN_Bancos objeto = new CN_Bancos();
            dataGridView1.DataSource = objeto.SumaBbva();
        }
        private void SumaBcp()
        {
            CN_Bancos objeto = new CN_Bancos();
            dataGridView1.DataSource = objeto.SumaBcp();
        }
        private void SumaBcpLunes()
        {
            CN_Bancos objeto = new CN_Bancos();
            dataGridView1.DataSource = objeto.SumaBcpLunes();
        }
        private void SumaInterbank()
        {
            CN_Bancos objeto = new CN_Bancos();
            dataGridView1.DataSource = objeto.SumaInterbank();
        }
        private void SumaScotiabank()
        {
            CN_Bancos objeto = new CN_Bancos();
            dataGridView1.DataSource = objeto.SumaScotiabank();
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
                        Lbl_Total.Text = lineas.ToString();
                        Lbl_Monto_Consolidado.Text = monto.ToString();
                    }
                }                
            }
            catch
            {
                Lbl_Error_archivo.Text = "Nombre del Archivo no coincise debe abrir Nuevo documento de texto";
                LimpiarLbl();
            }
            objetoCN.EditarTodoCampoFecha();

            //borrar base de datos 
            //poner codigo para poder crear base de datos para podercomparar en caso de error
            
            //objetos.ConsolidadoBbva();
            //objetos.ComparacionBbva();

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

            SumaBbva();
            var contarBbva = this.dataGridView1.CurrentCell.Value.ToString();
            var contarBbva1 = Convert.ToDouble(contarBbva);
            Lbl_Monto_Sapiens.Text = contarBbva1.ToString();

            var restadito = monto - contarBbva1;
            Lbl_Diferencia_Dinero.Text = restadito.ToString();

            var TotalDeDatos = contaraqp + contartacna;
            Lbl_Total_De_Datos.Text = TotalDeDatos.ToString();
        }

        public void bancoBcp()
        {
            //verificacion de transformacion e incercin de datos si es el dia lunes
            objetoCN.BorrarDat();            
            try
            {
                //ruta para leer el archivo de texto
                string path = string.Format(@"\\192.168.101.36\Documentos - Sistemas\Progs\BCP\{0}\{1}\{2}\CDPG2225.TXT", carpeta.ToString("yyyy"), carpeta.ToString("MM"), carpeta.ToString("dd"));
                //lectura de datos especificos delimitados por una matriz
                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.Peek() >= 0)
                    {
                        string linea = sr.ReadLine();
                        char tipo = Convert.ToChar(linea.Substring(0, 1));
                        switch (tipo)
                        {
                            //extraer detalle datos de la cabecera del txt
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
                        Lbl_Total.Text = lineas.ToString();
                        Lbl_Monto_Consolidado.Text = monto.ToString();
                    }
                }                 
                
            }
            //mensaje de comprovacion error al seleccionar el archivo txt
            catch
            {
                Lbl_Error_archivo.Text = "Nombre del Archivo no coincide debe abrir CDPG2225";
                LimpiarLbl();
            }

            if (carpeta.ToString("dddd") == dia)
            {
                objetoCN.FechaBcp();
            }
            //ejecutar lo contenido en el else si no es dia lunes 
            else
            {
                objetoCN.EditarTodoCampoFecha();
            }
            //objetos.ConsolidadoBcp();
            //objetos.ComparacionBcp();

            //darle formato de insert a la tabla tmp_bcpr
            objetoCN.CeroBcp();

            objetos.EjecutarBc();

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

            if (carpeta.ToString("dddd") == dia)
            {
                SumaBcpLunes();
            }
            else
            {
                SumaBcp();
            }            
            var contarBcp = this.dataGridView1.CurrentCell.Value.ToString();
            var contarBcp1 = Convert.ToDouble(contarBcp);
            Lbl_Monto_Sapiens.Text = contarBcp1.ToString();

            var restadito = monto - contarBcp1;
            Lbl_Diferencia_Dinero.Text = restadito.ToString();

            var TotalDeDatos = contaraqp + contartacna;
            Lbl_Total_De_Datos.Text = TotalDeDatos.ToString();
        }

        public void bancoScotiabank()
        {
            objetoCN.BorrarDat();            
            try
            {
                //ruta para leer el archivo de texto
                string path = string.Format(@"\\192.168.101.36\Documentos - Sistemas\Progs\Scotiabank\{0}\{1}\{2}\sbp{3}.txt", carpeta.ToString("yyyy"), carpeta.ToString("MM"), carpeta.ToString("dd"), carpeta1.ToString("MMdd"));
                //lectura de datos especificos delimitados por una matriz
                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.Peek() >= 0)
                    {
                        string linea = sr.ReadLine();
                        char tipo = Convert.ToChar(linea.Substring(0, 1));
                        switch (tipo)
                        {
                            //extraer detalle datos de la cabecera del txt
                            case 'C':
                                
                                    cabecera ++;
                                if (cabecera ==1)
                                {
                                    fecha_cabecera = Convert.ToString(linea.Substring(14, 8));
                                    lineas = Convert.ToInt32(linea.Substring(23, 8));
                                    monto = Convert.ToDouble(linea.Substring(32, 14)) / 100;
                                    break;
                                }                               
                    
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
            //mensaje de comprovacion error al seleccionar el archivo txt
            catch
            {                
                Lbl_Error_archivo.Text = string.Format("Nombre del Archivo no coincise debe abrir sbp{0}", carpeta1.ToString("MMdd"));
                LimpiarLbl();
            }
            objetoCN.EditarTodoCampoFecha();

            objetos.ConsolidadoScotiabank();
            objetos.ComparacionScotiabank();

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

            SumaScotiabank();
            var contarScotiabank = this.dataGridView1.CurrentCell.Value.ToString();
            var contarScotiabank1 = Convert.ToDouble(contarScotiabank);
            Lbl_Monto_Sapiens.Text = contarScotiabank1.ToString();

            var restadito = monto - contarScotiabank1;
            Lbl_Diferencia_Dinero.Text = restadito.ToString();

            var TotalDeDatos = contaraqp + contartacna;
            Lbl_Total_De_Datos.Text = TotalDeDatos.ToString();
        }

        //transformacion de datos y llenado en la base de datos
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
                                try
                                {
                                    cabecera = 2;
                                    lineas = Convert.ToInt32(linea1.Substring(31, 8));
                                    monto = Convert.ToDouble(linea1.Substring(42, 12));
                                }
                                catch
                                { }
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
                Lbl_Error_archivo.Text = string.Format("Nombre del Archivo no coincise debe abrir 22073390118{0}", carpeta.ToString("MMdd"));
                LimpiarLbl();
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

            objetoCN.EditarTodoCampoFecha();

            //objetos.ConsolidadoInterbank();
            //objetos.ComparacionInterbank();

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

            SumaInterbank();
            var contarInterbank = this.dataGridView1.CurrentCell.Value.ToString();
            var contarInterbank1 = Convert.ToDouble(contarInterbank);
            Lbl_Monto_Sapiens.Text = contarInterbank1.ToString();

            var restadito = monto - contarInterbank1;
            Lbl_Diferencia_Dinero.Text = restadito.ToString();

            var TotalDeDatos = contaraqp + contartacna;
            Lbl_Total_De_Datos.Text = TotalDeDatos.ToString();
        }

        //secciones de botones para el funcionaiento del sistema

        private void BtnBbva_Click(object sender, EventArgs e)
        {
            LimpiarLbl();
            //objetos.BorrarBbva();
            //objetos.BorrarRegistroBbva();
            bancoBbva();            
        }
        private void BtnBcp_Click(object sender, EventArgs e)
        {
            LimpiarLbl();
            //objetos.BorrarBcp();
            //objetos.BorrarRegistroBcp();            
            bancoBcp();           
        }
        private void BtnInterbank_Click(object sender, EventArgs e)
        {
            LimpiarLbl();
            //objetos.BorrarInterbank();
            //objetos.BorrarRegistroInterbank();            
            bancoInterbank();        
        }
        private void BtnScotiabank_Click(object sender, EventArgs e)
        {
            LimpiarLbl();
            //objetos.BorrarScotiabank();
            //objetos.BorrarRegistroScotiabank();            
            bancoScotiabank();
        }        

        //funcion para limpiar los datos de los label del sistema
        public void LimpiarLbl()
        {
            Lbl_Total.Text = "";
            Lbl_Monto_Consolidado.Text = "";
            Lbl_Monto_Sapiens.Text = "";
            Lbl_Diferencia_Dinero.Text = "";
            Lbl_Total_Aqp.Text = "";
            Lbl_Total_Tacna.Text = "";
            Lbl_Total_De_Datos.Text = "";
            Lbl_Total_Error.Text = "";
        }
    }
}
