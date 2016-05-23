using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Diagnostics;


namespace FPrueba
{
    public partial class Form1 : Form
    {
        Validaciones obj = new Validaciones();
        double[] peso,talla,resultados;// Declaracion 
        string[] personas;
        int ct=0,numero=0;

        
        public Form1()
        {
         InitializeComponent();
       
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            
         

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
                    Cursor = Cursors.AppStarting;
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
                    try
                    {
                        libros_trabajo.SaveAs(fichero.FileName,
                        Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                        libros_trabajo.Close(true);
                        aplicacion.Quit();
                        MessageBox.Show("Archivo creado con exito","Archivo Excel",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        Cursor = Cursors.Default;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error al crear el archivo","Archivo Excel",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        Cursor = Cursors.Default;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar la informacion debido a: " + ex.ToString());
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        
            enlace.Links.Remove(enlace.Links[0]);
            enlace.Links.Add(0, enlace.Text.Length, "http://www.who.int/mediacentre/factsheets/fs311/es/");
            tabla.RowCount = 2; // cantidad de renglones
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            pictureBox3.Enabled = false;
            pictureBox2.Enabled = false;

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
            //if (textBox1.Text =="" || textBox2.Text == "" || textBox3.Text=="")
            double kg=0 ;
            double estatura=0;
            string nombres="";
            if (!obj.ValidaTextBoxVacios(this))
                MessageBox.Show("Porfavor ingrese el dato faltante", "Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        if (ct+1==numero)
                        {
                            button3.BackColor = Color.BurlyWood;
                        }
                    }
                    else
                        MessageBox.Show("El Arreglo esta lleno");

                    if (ct == numero)
                    {
                        textBox1.Enabled = false;
                        textBox2.Enabled = false;
                        textBox3.Enabled = true;
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
            label7.Visible = true;
            label6.Visible = true;
            pictureBox2.Enabled = true;
            pictureBox3.Enabled = true;
            button2.BackColor = DefaultBackColor;
            button2.Enabled = false;
           
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
                    res.Rows[i].DefaultCellStyle.BackColor = Color.LightSeaGreen;
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
                    res.Rows[i].DefaultCellStyle.BackColor = Color.LightYellow;
                    consobrepeso++;
                    res[4, i].Value = "Sobrepeso";
                    //listBox1.Items.Add(Color.Blue+"PESO:" + peso[i] + "Kg |" + " TALLA: " + talla[i] + "mts |" + " IMC: " + resultados[i].ToString("N2"));
                }
                if (resultados[i] >= 35 && resultados[i] <= 40)
                {
                    conobesidad2++;
                    res.Rows[i].DefaultCellStyle.BackColor = Color.OrangeRed;
                    res[4, i].Value = "Obesidad Tipo II";
                }               
                if (resultados[i] > 40)
                {
                    res.Rows[i].DefaultCellStyle.BackColor = Color.Red;
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

            tabla.ClearSelection();
            res.ClearSelection();
           
            if (conobesidad > 0)
                MessageBox.Show(" Alerta!!!, el Sistema indica que Existen "+conobesidad+" Persona(s) con Obesidad,\n en la lista aparecen con color Verde", "IMC",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            if (conobesidad2 > 0)
                MessageBox.Show(" Alerta!!!, el Sistema indica que Existen " + conobesidad2 + " Persona(s) con Obesidad Tipo II,\n en la lista aparecen de Color Naranja", "IMC", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            if (conobesidad3 > 0)
                MessageBox.Show(" Alerta!!!, el Sistema indica que Existen " + conobesidad3 + " Persona(s) con Obesidad Tipo III,\n en la lista aparecen de Color Rojo", "IMC", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            res.RowCount = (int)numericUpDown1.Value;
            numero = (int)numericUpDown1.Value;
            peso = new double[numero];
            personas = new string[numero];
            talla = new double[numero];
            resultados = new double[numero];
            MessageBox.Show("Sistema Creado de " + numero + " Elementos...","IMC",MessageBoxButtons.OK,MessageBoxIcon.Information);
            numericUpDown1.Enabled = false;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            button4.Enabled = false; button4.BackColor = DefaultBackColor;
            button3.Enabled = true;
            textBox3.Enabled = true;
            textBox3.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
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

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.logoexcel1;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.logoexcel;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ExportarDataGridViewExcel(res, tabla);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ct = 0; numero = 0; // reiniciar variables de arreglos
            Array.Clear(talla, 0, talla.Length); // Limpiar arreglos
            Array.Clear(peso, 0, peso.Length);
            Array.Clear(personas, 0, personas.Length);
            Array.Clear(resultados, 0, resultados.Length);
            numericUpDown1.Enabled = true; textBox1.Enabled = false; textBox2.Enabled = false;
            button3.Enabled = false; button2.Enabled = false; button2.BackColor = DefaultBackColor;
            numericUpDown1.Focus(); button4.Enabled = true; res.Visible = false; tabla.Visible = false;
            label7.Visible = false; label3.Visible = false; label4.Visible = false; textBox3.Enabled = false;
            pictureBox2.Enabled = false; pictureBox3.Enabled = false;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.reset2;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.reset1;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
           // Validaciones.ValidarDecimal((System.Windows.Forms.TextBox)sender);
        }

        private void ValidarDecimal(object sender, KeyPressEventArgs e)
        {
            obj.Validardecimal(e, (System.Windows.Forms.TextBox)sender);
        }

    }
}
