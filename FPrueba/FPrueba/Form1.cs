using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Office.Interop.Excel;

namespace IMC_WF
{
    public partial class Form1 : Form
    {

        double[] peso,talla,resultados;// Declaracion 
        string[] personas;
        int ct=0,ct2=0,ct3=0,numero;
        
        public Form1()
        {
         InitializeComponent();
       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Microsoft.Office.Interop.Excel.Application xls = new Microsoft.Office.Interop.Excel.Application();
            //Workbook wb = xls.Workbooks.Add(XlSheetType.xlWorksheet);
            //Worksheet ws = (Worksheet)xls.ActiveSheet;

            //xls.Visible = true;

            //for (int i = 0; i <res.Rows.Count-1 ; i++)
            //{
            //    for (int j = 0; j <res.Columns.Count; j++)
            //    {
            //        if ((res.Rows[i].Cells[j].Value == null) == false)
            //            ws.Cells[i + 1, j + 1] = res.Rows[i].Cells[j].Value.ToString();
            //    }
            //}
            ExportarDataGridViewExcel(res,tabla);
            //this.Close();

        }
        public void ExportarDataGridViewExcel(DataGridView grd, DataGridView inf)
        {
            try
            {

                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                fichero.FileName = "ArchivoExportado";
                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application aplicacion;
                    Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                    Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;

                    aplicacion = new Microsoft.Office.Interop.Excel.Application();
                    libros_trabajo = aplicacion.Workbooks.Add();
                    hoja_trabajo =
                        (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);

                    hoja_trabajo.Cells[1, 2] = "Nombre";
                    hoja_trabajo.Cells[1, 3] = "Peso Kg";
                    hoja_trabajo.Cells[1, 4] = "Talla Mts";
                    hoja_trabajo.Cells[1, 5] = "IMC";
                    hoja_trabajo.Cells[1, 6] = "Clasificación";

                    hoja_trabajo.Cells[1, 8] = "Clasificación";
                    hoja_trabajo.Cells[1, 9] = "Cantidad";
                    hoja_trabajo.Cells[1, 10] = "Porcentaje";

                    hoja_trabajo.Cells[2, 8] = "Delgadez Severa";
                    hoja_trabajo.Cells[3, 8] = "Delgadez Moderada";
                    hoja_trabajo.Cells[4, 8] = "Delgadez Aceptable";
                    hoja_trabajo.Cells[5, 8] = "Peso Adecuado";
                    hoja_trabajo.Cells[6, 8] = "Sobrepeso";
                    hoja_trabajo.Cells[7, 8] = "Obesidad";
                    hoja_trabajo.Cells[8, 8] = "Obesidad T II";
                    hoja_trabajo.Cells[9, 8] = "Obesidad T III";


                    //Recorremos el DataGridView rellenando la hoja de trabajo
                    for (int i = 0; i < grd.Rows.Count; i++)
                    {
                        for (int j = 0; j < grd.Columns.Count; j++)
                        {
                            if ((grd.Rows[i].Cells[j].Value == null) == false)
                            {
                                hoja_trabajo.Cells[i + 2, j + 2] = grd.Rows[i].Cells[j].Value.ToString();
                            }
                        }
                    }
                    // recorremos el segundo dataGrid
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if ((inf.Rows[i].Cells[j].Value == null) == false)
                            {
                                hoja_trabajo.Cells[j + 2, i + 9] = inf.Rows[i].Cells[j].Value.ToString();
                            }
                        }
                    }
                    libros_trabajo.SaveAs(fichero.FileName,
                        Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                    libros_trabajo.Close(true);
                    aplicacion.Quit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar la informacion debido a: " + ex.ToString());
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
          //  dgvEjemplo.RowCount = 3;
            enlace.Links.Remove(enlace.Links[0]);
            enlace.Links.Add(0, enlace.Text.Length, "http://www.who.int/mediacentre/factsheets/fs311/es/");
            tabla.RowCount = 2; // cantidad de renglones
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button5.Enabled = false;

        }

        void Insertar(double x, double[] num)
        {
           //listBox1.Items.Add(x); // lista visual
           num[ct] = x;
           ct++;
          
        }
        void Insertar2(double x, double[] num)
        {
           // listBox1.Items.Add(x); // lista visual
            num[ct2] = x;
            ct2++;

        }

        void InsertarNombre(string n, string[] nom)
        {
            nom[ct3]=n;
            ct3++;
        }
        void InsertarDatos(double t, double p, string n, double[] ta, double[] pe, string[] nom)
        {
            ta[ct] = t;
            pe[ct] = p;
            nom[ct] = n;
            ct++;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            double kg=0 ;
            double estatura=0;
            string nombres="";
            if (textBox1.Text == " " || textBox2.Text == " " || textBox3.Text==" ")
                MessageBox.Show("Porfavor ingrese el dato faltante");
            else 
            {
                try
                {

                    if (ct < numero)
                    {
                        kg = double.Parse(textBox1.Text);
                        estatura = double.Parse(textBox2.Text);
                        nombres = textBox3.Text;
                        InsertarDatos(estatura, kg, nombres, talla, peso, personas);
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox3.Focus();

                    }
                    else
                        MessageBox.Show("El Arreglo esta lleno");

                    if (ct == numero)
                    {
                        textBox1.Enabled = false;
                        textBox2.Enabled = false;
                        button2.Enabled = true;
                        button3.Enabled = false;
                        button2.BackColor = Color.Gold;
                        button2.Focus();
                    }
                }

                catch (FormatException ms)
                {
                    MessageBox.Show(ms.Message+" Ingrese los datos faltantes...");
                }
         
            }           
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            label4.Visible = true;
            tabla.Visible = true;
            button5.Enabled = true;
            label7.Visible = true;
            label6.Visible = true;
            res.Visible = true;
            int condelgadezsevera=0,condelgadezmoderada=0,condelgadezaceptable=0, conadecuado=0,  consobrepeso=0 ,  conobesidad = 0, conobesidad2=0,conobesidad3=0;
            for (int i = 0; i < resultados.Length; i++)
			{
                resultados[i] = peso[i]/ Math.Pow(talla[i], 2); // FORMULA DEL IMC....

                res[0, i].Value = personas[i];
                res[1, i].Value = peso[i];
                res[2, i].Value = talla[i];
                res[3, i].Value = resultados[i].ToString("N2");
                if (resultados[i]<16)
                {
                    res.Rows[i].DefaultCellStyle.BackColor = Color.Aqua;
                    condelgadezsevera++;
                    res[4, i].Value = "Delgadez Severa";
                }
                if (resultados[i] >= 16 && resultados[i]<=16.99)
                {
                    res.Rows[i].DefaultCellStyle.BackColor = Color.Aquamarine;
                    condelgadezmoderada++;
                    res[4, i].Value = "Delgadez Moderada";
                }
                if (resultados[i] >= 17 && resultados[i] <= 18.49)
                {
                    res.Rows[i].DefaultCellStyle.BackColor = Color.AliceBlue;
                    condelgadezaceptable++;
                    res[4, i].Value = "Delgadez Aceptable";
                }
                if (resultados[i] >= 30 && resultados[i]<=34.99)
                {
                    res.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    //listBox1.Items.Add( "PESO: " + peso[i] + "Kg |" + " TALLA: " + talla[i] + "mts |" + " IMC: " + resultados[i].ToString("N2"));
                    conobesidad++;
                    res[4, i].Value = "Obesidad";
                }
                if (resultados[i]>=18.50 && resultados[i] <= 24.99)
                {
                    res.Rows[i].DefaultCellStyle.BackColor = DefaultBackColor; 
                    conadecuado++;
                    res[4, i].Value = "Peso Adecuado";
                    //listBox1.Items.Add("PESO: " + peso[i] + "Kg |" + " TALLA: " + talla[i] + "mts |" + " IMC: " + resultados[i].ToString("N2"));
                  
                }
                if (resultados[i] >= 25 && resultados[i] <= 29.99)
                {
                    res.Rows[i].DefaultCellStyle.BackColor = Color.MediumSlateBlue;
                    consobrepeso++;
                    res[4, i].Value = "Sobrepeso";
                    //listBox1.Items.Add(Color.Blue+"PESO:" + peso[i] + "Kg |" + " TALLA: " + talla[i] + "mts |" + " IMC: " + resultados[i].ToString("N2"));
                }
                if (resultados[i] >= 35 && resultados[i] <= 40)
                {
                    conobesidad2++;
                    res.Rows[i].DefaultCellStyle.BackColor = Color.MediumSlateBlue;
                    res[4, i].Value = "Obesidad Tipo II";
                }               
                if (resultados[i] > 40)
                {
                    res.Rows[i].DefaultCellStyle.BackColor = Color.MediumSlateBlue;
                    conobesidad3++;
                    res[4, i].Value = "Obesidad Tipo III";
                
                }
                    
			}
            double total = conadecuado + conobesidad + consobrepeso+conobesidad2+conobesidad3+condelgadezaceptable+condelgadezmoderada+condelgadezsevera;
            
            double poradecuado = (conadecuado / total)*100;
            double porsobrepeso = (consobrepeso / total) * 100;
            double porobesidad = (conobesidad / total) * 100;
            double pordsevera = (condelgadezsevera / total) * 100;
            double pordmoderada = (condelgadezmoderada / total) * 100;
            double pordaceptable = (condelgadezaceptable / total) * 100;
            double porot2 = (conobesidad2 / total) * 100;
            double porot3 = (conobesidad3 / total) * 100;

            tabla[0, 0].Value = condelgadezsevera; 
            tabla[1, 0].Value = condelgadezmoderada;
            tabla[2, 0].Value = condelgadezaceptable;
            tabla[3, 0].Value = conadecuado;
            tabla[4, 0].Value = consobrepeso;
            tabla[5, 0].Value = conobesidad;
            tabla[6, 0].Value = conobesidad2;
            tabla[7, 0].Value = conobesidad3;

            tabla[0, 1].Value = pordsevera.ToString("N1")+"%";
            tabla[1, 1].Value = pordmoderada.ToString("N1")+"%";
            tabla[2, 1].Value = pordaceptable.ToString("N1")+"%";
            tabla[3, 1].Value = poradecuado.ToString("N1") + "%";
            tabla[4, 1].Value = porsobrepeso.ToString("N1") + "%";
            tabla[5, 1].Value = porobesidad.ToString("N1") + "%";
            tabla[6, 1].Value = porot2.ToString("N1") + "%";
            tabla[7, 1].Value = porot3.ToString("N1") + "%";
           
            if (conobesidad > 0)
                MessageBox.Show(" Alerta!!!, el Sistema indica que Existen "+conobesidad+" Personas con Obesidad, en la lista aparecen con color ROJO", "IMC",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            res.RowCount = (int)numericUpDown1.Value;
            numero = (int)numericUpDown1.Value;
            peso = new double[numero];
            personas = new string[numero];
            talla = new double[numero];
            resultados = new double[numero];
            MessageBox.Show("Sistema Creado de " + numero + " Elementos...");
            numericUpDown1.Enabled = false;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            button4.Enabled = false; button4.BackColor = Color.Gray;
            button3.Enabled = true;
            textBox3.Enabled = true;
            textBox3.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            ct = 0; ct2 = 0; ct3=0; numero = 0; // reiniciar variables de arreglos
            Array.Clear(talla, 0, talla.Length); // Limpiar arreglos
            Array.Clear(peso, 0, peso.Length);
            Array.Clear(personas,0,personas.Length);
            numericUpDown1.Enabled = true; textBox1.Enabled = false; textBox2.Enabled = false;
            button3.Enabled = false; button2.Enabled = false; button2.BackColor = Color.Gray;
            numericUpDown1.Focus(); button4.Enabled = true; res.Visible = false; tabla.Visible = false;
            label7.Visible = false; label3.Visible = false; label4.Visible = false; textBox3.Enabled = false;
            //for (int i = 0; i <= 1; i++)
            //{
            //    for (int j = 0; j <= 2; j++) 
            //    {
            //        tabla[j, i].Value = "";
            //    }
                
            //}
              
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            button4.BackColor = Color.Gold;
        }

        private void enlace_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo(e.Link.LinkData.ToString());
            Process.Start(sInfo);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

    }
}
