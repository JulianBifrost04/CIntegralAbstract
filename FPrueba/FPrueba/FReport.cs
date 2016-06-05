using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FPrueba
{
    public partial class FReport : Form
    {
        public FReport()
        {
            InitializeComponent();
        }
        public List<ClasificacionIMC> Clasificacion = new List<ClasificacionIMC>(); // LISTA DONDE SE GUARDARAN LOS DATOS
        public List<DetalleIMC> Datos = new List<DetalleIMC>();
        private void FReport_Load(object sender, EventArgs e)
        {

            reportViewer1.LocalReport.DataSources.Clear(); // LIMPIAMOS ALGUN RASTRO
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", Clasificacion)); // AGREGAMOS AL REPORTE LA LISTA EN EJECUCION
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", Datos)); // AGREGAMOS AL REPORTE LA LISTA EN EJECUCION
            
            this.reportViewer1.RefreshReport(); // ACTUALIZAMOS EL REPORTE
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
