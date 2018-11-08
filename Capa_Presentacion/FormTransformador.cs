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
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;

namespace Capa_Presentacion
{
    public partial class FormTransformador : Form
    {
        //llamada de funciones de las capa de negocio de arequipá y tacna
        CN_Bancos objetoCN = new CN_Bancos();
        CN_Aqp_Tacna objetos = new CN_Aqp_Tacna();
        public FormTransformador()
        {
            InitializeComponent();
        }
        private void FormTransformador_Load(object sender, EventArgs e)
        {

        }
        //funciones para poder listar la informacion de la base de datos y llenarla en un excel para poder comparar montos desiguales 
        private void TablaBbva()
        {
            CN_Aqp_Tacna objetos = new CN_Aqp_Tacna();
            GritConvert.DataSource = objetos.TablaBbva();
        }
        private void TablaBcp()
        {
            CN_Aqp_Tacna objetos = new CN_Aqp_Tacna();
            GritConvert.DataSource = objetos.TablaBcp();
        }
        private void TablaInterbank()
        {
            CN_Aqp_Tacna objetos = new CN_Aqp_Tacna();
            GritConvert.DataSource = objetos.TablaInterbank();
        }
        private void TablaScotiabank()
        {
            CN_Aqp_Tacna objetos = new CN_Aqp_Tacna();
            GritConvert.DataSource = objetos.TablaScotiabank();
        }
        private void DatoSapiensBbva()
        {
            CN_Bancos objetos = new CN_Bancos();
            GritConvert.DataSource = objetos.DatoSapiensBbva();
        }
        private void DatoSapiensBcp()
        {
            CN_Bancos objetos = new CN_Bancos();
            GritConvert.DataSource = objetos.DatoSapiensBcp();
        }
        private void DatoSapiensInterbank()
        {
            CN_Bancos objetos = new CN_Bancos();
            GritConvert.DataSource = objetos.DatoSapiensInterbank();
        }
        private void DatoSapiensScotiabank()
        {
            CN_Bancos objetos = new CN_Bancos();
            GritConvert.DataSource = objetos.DatoSapiensScotiabank();
        }
        //seccion de botones para poder procesar el llenado de los datos de los excel
        private void BtnConvertirBbva_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            pictureBox2.Visible = true;
            while (DateTime.Now < now.AddSeconds(5))
            {
                Application.DoEvents();
                // Tratamiento del proceso
            }
            pictureBox2.Visible = false;


            Microsoft.Office.Interop.Excel.Application
            app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook libros;
            Microsoft.Office.Interop.Excel.Worksheet hoja1, hoja2;
            libros = app.Workbooks.Add();
            libros.Sheets.Add();

            TablaBbva();

            hoja1 = (Microsoft.Office.Interop.Excel.Worksheet)libros.Worksheets.get_Item(1);
            hoja1.Name = "Exported from gridview";
            for (int i = 0; i < GritConvert.Rows.Count - 1; i++)
            {
                for (int j = 0; j < GritConvert.Columns.Count; j++)
                {
                    hoja1.Cells[i + 1, j + 1] = GritConvert.Rows[i].Cells[j].Value.ToString();
                }
            }

            DatoSapiensBbva();

            hoja2 = (Microsoft.Office.Interop.Excel.Worksheet)libros.Worksheets.get_Item(2);
            hoja2.Name = "Exported from gridview2";
            for (int i = 0; i < GritConvert.Rows.Count - 1; i++)
            {
                for (int j = 0; j < GritConvert.Columns.Count; j++)
                {
                    hoja2.Cells[i + 1, j + 1] = GritConvert.Rows[i].Cells[j].Value.ToString();
                }
            }

            libros.SaveAs(@"C:\Users\arni_\OneDrive\Documentos\trabajo para hacer  star global\prueba\ComparaBbva.xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            app.Quit();

        }

        private void BtnConvertirBcp_Click(object sender, EventArgs e)
        {
            //objetos.BorrarBcp();
            //objetos.BorrarRegistroBcp();
            objetos.ConsolidadoBcp();
            objetos.ComparacionBcp();

            Microsoft.Office.Interop.Excel.Application
            app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook libros;
            Microsoft.Office.Interop.Excel.Worksheet hoja1, hoja2;
            libros = app.Workbooks.Add();
            libros.Sheets.Add();

            TablaBcp();

            hoja1 = (Microsoft.Office.Interop.Excel.Worksheet)libros.Worksheets.get_Item(1);
            hoja1.Name = "Exported from gridview";
            for (int i = 0; i < GritConvert.Rows.Count - 1; i++)
            {
                for (int j = 0; j < GritConvert.Columns.Count; j++)
                {
                    hoja1.Cells[i + 1, j + 1] = GritConvert.Rows[i].Cells[j].Value.ToString();
                }
            }

            DatoSapiensBcp();

            hoja2 = (Microsoft.Office.Interop.Excel.Worksheet)libros.Worksheets.get_Item(2);
            hoja2.Name = "Exported from gridview2";
            for (int i = 0; i < GritConvert.Rows.Count - 1; i++)
            {
                for (int j = 0; j < GritConvert.Columns.Count; j++)
                {
                    hoja2.Cells[i + 1, j + 1] = GritConvert.Rows[i].Cells[j].Value.ToString();
                }
            }

            libros.SaveAs(@"C:\Users\arni_\OneDrive\Documentos\trabajo para hacer  star global\prueba\ComparaBcp.xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            app.Quit();

        }

        private void BtnConvertirInterbank_Click(object sender, EventArgs e)
        {
            objetos.BorrarInterbank();
            objetos.BorrarRegistroInterbank();
            objetos.ConsolidadoInterbank();
            objetos.ComparacionInterbank();
            Microsoft.Office.Interop.Excel.Application
            app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook libros;
            Microsoft.Office.Interop.Excel.Worksheet hoja1, hoja2;
            libros = app.Workbooks.Add();
            libros.Sheets.Add();

            TablaInterbank();

            hoja1 = (Microsoft.Office.Interop.Excel.Worksheet)libros.Worksheets.get_Item(1);
            hoja1.Name = "Exported from gridview";
            for (int i = 0; i < GritConvert.Rows.Count - 1; i++)
            {
                for (int j = 0; j < GritConvert.Columns.Count; j++)
                {
                    hoja1.Cells[i + 1, j + 1] = GritConvert.Rows[i].Cells[j].Value.ToString();
                }
            }

            DatoSapiensInterbank();

            hoja2 = (Microsoft.Office.Interop.Excel.Worksheet)libros.Worksheets.get_Item(2);
            hoja2.Name = "Exported from gridview2";
            for (int i = 0; i < GritConvert.Rows.Count - 1; i++)
            {
                for (int j = 0; j < GritConvert.Columns.Count; j++)
                {
                    hoja2.Cells[i + 1, j + 1] = GritConvert.Rows[i].Cells[j].Value.ToString();
                }
            }

            libros.SaveAs(@"C:\Users\arni_\OneDrive\Documentos\trabajo para hacer  star global\prueba\ComparaInterbank.xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            app.Quit();
        }

        private void BtnConvertirScotiabank_Click(object sender, EventArgs e)
        {          
            Microsoft.Office.Interop.Excel.Application
            app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook libros;
            Microsoft.Office.Interop.Excel.Worksheet hoja1, hoja2;
            libros = app.Workbooks.Add();
            libros.Sheets.Add();

            TablaScotiabank();

            hoja1 = (Microsoft.Office.Interop.Excel.Worksheet)libros.Worksheets.get_Item(1);
            hoja1.Name = "Exported from gridview";
            for (int i = 0; i < GritConvert.Rows.Count - 1; i++)
            {
                for (int j = 0; j < GritConvert.Columns.Count; j++)
                {
                    hoja1.Cells[i + 1, j + 1] = GritConvert.Rows[i].Cells[j].Value.ToString();
                }
            }

            DatoSapiensScotiabank();

            hoja2 = (Microsoft.Office.Interop.Excel.Worksheet)libros.Worksheets.get_Item(2);
            hoja2.Name = "Exported from gridview2";
            for (int i = 0; i < GritConvert.Rows.Count - 1; i++)
            {
                for (int j = 0; j < GritConvert.Columns.Count; j++)
                {
                    hoja2.Cells[i + 1, j + 1] = GritConvert.Rows[i].Cells[j].Value.ToString();
                }
            }

            libros.SaveAs(@"C:\Users\arni_\OneDrive\Documentos\trabajo para hacer  star global\prueba\ComparaScotiabank.xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            app.Quit();

        }        

    }
}
