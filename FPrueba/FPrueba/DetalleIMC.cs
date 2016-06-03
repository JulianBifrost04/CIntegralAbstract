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
    public partial class DetalleIMC
    {
        public string Nombre { get; set; }
        public double Peso { get; set; }
        public double Talla { get; set; }
        public double IMC { get; set; }
        public string Clasificaciom { get; set; }
    }
}
