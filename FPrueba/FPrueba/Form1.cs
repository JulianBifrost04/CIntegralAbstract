﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Office.Interop.Excel;
using EfectoMovimiento;

namespace FPrueba

{
    public partial class Form1 : Form
    {

        double[] peso,talla,resultados;// Declaracion 
        string[] personas;
        int ct=0,numero=0;
        Validacion obj = new Validacion();
        Class1 efect= new Class1();
        int seg = 0;
        
        public Form1()
        {
         InitializeComponent();
         picGalery.Parent = this;
       
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
            //timGalery.Start();
            enlace.Links.Remove(enlace.Links[0]);
            enlace.Links.Add(0, enlace.Text.Length, "http://www.who.int/mediacentre/factsheets/fs311/es/");
            tabla.RowCount = 2; // cantidad de renglones
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            btnCalcular.Enabled = false;
            btnAñadir.Enabled = false;
            picReiniciar.Enabled = false;
            picExportar.Enabled = false;
            picImprimir.Enabled = false;

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
            
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            
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
            btnCrear.Enabled = false; btnCrear.BackColor = DefaultBackColor;
            btnAñadir.Enabled = true;
            textBox3.Enabled = true;
            textBox3.Focus();
        }

        
       
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            btnCrear.BackColor = Color.Gold;
        }

        private void enlace_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo(e.Link.LinkData.ToString());
            Process.Start(sInfo);
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            picExportar.Image = Properties.Resources.logoexcel1;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            picExportar.Image = Properties.Resources.logoexcel;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ExportarDataGridViewExcel(res, tabla);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult ok;

            ok = MessageBox.Show("¿De Verdad desea eliminar los datos?, si es así presione en Sí, tome en cuenta que los datos se perderan, se le aconseja que los exporte o los imprima previamente. Para cancelar de clic en No","Limpieza de Datos",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (ok==DialogResult.Yes)
            {
                ct = 0; numero = 0; // reiniciar variables de arreglos
                Array.Clear(talla, 0, talla.Length); // Limpiar arreglos
                Array.Clear(peso, 0, peso.Length);
                Array.Clear(personas, 0, personas.Length);
                Array.Clear(resultados, 0, resultados.Length);
                numericUpDown1.Enabled = true; textBox1.Enabled = false; textBox2.Enabled = false;
                btnAñadir.Enabled = false; btnCalcular.Enabled = false; btnCalcular.BackColor = Color.Transparent;
                numericUpDown1.Focus(); btnCrear.Enabled = true; res.Visible = false; tabla.Visible = false;
                label7.Visible = false; label3.Visible = false; label4.Visible = false; textBox3.Enabled = false;
                picExportar.Enabled = false; picReiniciar.Enabled = false; picImprimir.Enabled = false;   
            }
            
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            picReiniciar.Image = Properties.Resources.reset2;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            picReiniciar.Image = Properties.Resources.reset1;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
           // Validaciones.ValidarDecimal((System.Windows.Forms.TextBox)sender);
        }

        private void ValidarDecimal(object sender, KeyPressEventArgs e)
        {
            obj.Validardecimal(e, (System.Windows.Forms.TextBox)sender);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            FReport f = new FReport();
            foreach (DataGridViewRow row in res.Rows)
            {
                DetalleIMC detalle = new DetalleIMC();
                detalle.Nombre = Convert.ToString(row.Cells["Column12"].Value);
                detalle.Peso = Convert.ToDouble(row.Cells["Column4"].Value);
                detalle.Talla = Convert.ToDouble(row.Cells["Column5"].Value);
                detalle.IMC = Convert.ToDouble(row.Cells["Column6"].Value);
                detalle.Clasificaciom = Convert.ToString(row.Cells["Column13"].Value);

                f.Datos.Add(detalle);
            }

            ClasificacionIMC cimc = new ClasificacionIMC();
            cimc.CantidadDS = Convert.ToInt32(tabla[0,0].Value);
            cimc.CantidadDM = Convert.ToInt32(tabla[1,0].Value);
            cimc.CantidadDA = Convert.ToInt32(tabla[2,0].Value);
            cimc.CantidadPA = Convert.ToInt32(tabla[3,0].Value);
            cimc.CantidadS = Convert.ToInt32(tabla[4,0].Value);
            cimc.CantidadO = Convert.ToInt32(tabla[5,0].Value);
            cimc.CantidadOII = Convert.ToInt32(tabla[6,0].Value);
            cimc.CantidadOIII = Convert.ToInt32(tabla[7,0].Value);
            
            cimc.PorcentajeDS = Convert.ToString(tabla[0,1].Value);
            cimc.PorcentajeDM = Convert.ToString(tabla[1,1].Value);
            cimc.PorcentajeDA = Convert.ToString(tabla[2,1].Value);
            cimc.PorcentajePA = Convert.ToString(tabla[3,1].Value);
            cimc.PorcentajeS = Convert.ToString(tabla[4,1].Value);
            cimc.PorcentajeO = Convert.ToString(tabla[5,1].Value);
            cimc.PorcentajeOII = Convert.ToString(tabla[6,1].Value);
            cimc.PorcentajeOIII = Convert.ToString(tabla[7, 1].Value);

            f.Clasificacion.Add(cimc);
            
            f.Show();


        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            label3.Visible = true;
            label4.Visible = true;
            tabla.Visible = true;
            label7.Visible = true;
            label6.Visible = true;
            picExportar.Enabled = true;
            picReiniciar.Enabled = true;
            picImprimir.Enabled = true;
            btnCalcular.BackColor = DefaultBackColor;
            btnCalcular.Enabled = false;

            res.Visible = true;
            int condelgadezsevera = 0, condelgadezmoderada = 0, condelgadezaceptable = 0, conadecuado = 0, consobrepeso = 0, conobesidad = 0, conobesidad2 = 0, conobesidad3 = 0;
            for (int i = 0; i < resultados.Length; i++)
            {
                resultados[i] = peso[i] / Math.Pow(talla[i], 2); // FORMULA DEL IMC....

                res[0, i].Value = personas[i];
                res[1, i].Value = peso[i];
                res[2, i].Value = talla[i];
                res[3, i].Value = resultados[i].ToString("N2");
                if (resultados[i] < 16)
                {
                    res.Rows[i].DefaultCellStyle.BackColor = Color.Aqua;
                    condelgadezsevera++;
                    res[4, i].Value = "Delgadez Severa";
                }
                if (resultados[i] >= 16 && resultados[i] <= 16.99)
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
                if (resultados[i] >= 30 && resultados[i] <= 34.99)
                {
                    res.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    //listBox1.Items.Add( "PESO: " + peso[i] + "Kg |" + " TALLA: " + talla[i] + "mts |" + " IMC: " + resultados[i].ToString("N2"));
                    conobesidad++;
                    res[4, i].Value = "Obesidad";
                }
                if (resultados[i] >= 18.50 && resultados[i] <= 24.99)
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
            double total = conadecuado + conobesidad + consobrepeso + conobesidad2 + conobesidad3 + condelgadezaceptable + condelgadezmoderada + condelgadezsevera;

            double poradecuado = (conadecuado / total) * 100;
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

            tabla[0, 1].Value = pordsevera.ToString("N1") + "%";
            tabla[1, 1].Value = pordmoderada.ToString("N1") + "%";
            tabla[2, 1].Value = pordaceptable.ToString("N1") + "%";
            tabla[3, 1].Value = poradecuado.ToString("N1") + "%";
            tabla[4, 1].Value = porsobrepeso.ToString("N1") + "%";
            tabla[5, 1].Value = porobesidad.ToString("N1") + "%";
            tabla[6, 1].Value = porot2.ToString("N1") + "%";
            tabla[7, 1].Value = porot3.ToString("N1") + "%";

            if (conobesidad > 0)
                MessageBox.Show(" Alerta!!!, el Sistema indica que Existen " + conobesidad + " Personas con Obesidad, en la lista aparecen con color ROJO", "IMC", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void pictureBox2_Click_2(object sender, EventArgs e)
        {

            double kg = 0;
            double estatura = 0;
            string nombres = "";
            if (textBox1.Text == " " || textBox2.Text == " " || textBox3.Text == " ")
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
                        textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox3.Focus();
                        if (ct + 1 == numero)
                            btnAñadir.BackColor = Color.White;
                    }
                    else
                        MessageBox.Show("El Arreglo esta lleno");
                    if (ct == numero)
                    {
                        textBox1.Enabled = false;
                        textBox2.Enabled = false;
                        textBox3.Enabled = true;
                        btnCalcular.Enabled = true;
                        btnAñadir.Enabled = false;
                        btnCalcular.BackColor = Color.FromArgb(31, 118, 195);
                        btnCalcular.Focus();
                    }
                }

                catch (FormatException ms)
                {
                    MessageBox.Show(ms.Message + " Ingrese los datos faltantes...");
                }

            }           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void timGalery_Tick(object sender, EventArgs e)
        {
           // picGalery.Visible = false;
            seg++;

            if (seg==20)
            {
               
                picGalery.Image = Properties.Resources.Cover_Session_71;
                //efect.Animate(picGalery, Class1.Effect.Roll, 1000, 180);
               
            }
           // picGalery.Visible = true;
            if (seg==40)
            {
                picGalery.Image = Properties.Resources.familiadietac;
                //efect.Animate(picGalery, Class1.Effect.Roll, 1000, 180);
               
            }
            if (seg == 60)
            {
                picGalery.Image = Properties.Resources.familiasaludable;
               // efect.Animate(picGalery, Class1.Effect.Roll, 1000, 180);
                
                seg = 0;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timGalery.Stop();
        }

        bool Buscar(string TextoABuscar, string Columna, DataGridView grid)
        {
            bool encontrado = false;
            if (TextoABuscar == string.Empty) return false;
            if (grid.RowCount == 0) return false;
            grid.ClearSelection();
            if (Columna == string.Empty)
            {
                foreach (DataGridViewRow row in grid.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                        if (cell.Value.ToString() == TextoABuscar)
                        {
                            row.Selected = true;
                            return true;
                        }
                }
            }
            else
            {
                foreach (DataGridViewRow row in grid.Rows)
                {

                    if (row.Cells[Columna].Value.ToString().Contains(TextoABuscar))
                    {
                        
                        row.Selected = true;
                        //listBox1.Items[1]=(row.Cells[Columna].Value.ToString());
                        //listBox1.SelectedItem[2]=
                        return true;
                    }
                  
                }
            }
            return encontrado;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Buscar(textBox4.Text, "Column12", res);
        }

        bool BuscarLINQ(string TextoABuscar, string Columna, DataGridView grid)
        {
            bool encontrado = false;
            if (TextoABuscar == string.Empty) return false;
            if (grid.RowCount == 0) return false;
            grid.ClearSelection();
            if (Columna == string.Empty)
            {
                IEnumerable<DataGridViewRow> obj = (from DataGridViewRow row in grid.Rows.Cast<DataGridViewRow>()
                                                    from DataGridViewCell cells in row.Cells
                                                    where cells.OwningRow.Equals(row) && cells.Value.ToString() == TextoABuscar
                                                    select row);
                if (obj.Any())
                {
                    grid.Rows[obj.FirstOrDefault().Index].Selected = true;
                    return true;
                }

            }
            else
            {
                IEnumerable<DataGridViewRow> obj = (from DataGridViewRow row in grid.Rows.Cast<DataGridViewRow>()
                                                    where row.Cells[Columna].Value.ToString() == TextoABuscar
                                                    select row);
                if (obj.Any())
                {
                    grid.Rows[obj.FirstOrDefault().Index].Selected = true;
                    return true;
                }

            }
            return encontrado;


        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Buscar(textBox4.Text, "Column12", res);
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

    }
}
