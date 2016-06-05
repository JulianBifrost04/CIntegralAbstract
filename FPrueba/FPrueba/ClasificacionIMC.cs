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
    public partial class ClasificacionIMC
    {
       public int CantidadDS { get; set; }
       public int CantidadDM { get; set; }
       public int CantidadDA { get; set; }
       public int CantidadPA { get; set; }
       public int CantidadS { get; set; }
       public int CantidadO { get; set; }
       public int CantidadOII { get; set; }
       public int CantidadOIII { get; set; }

       public string PorcentajeDS { get; set; }
       public string PorcentajeDM { get; set; }
       public string PorcentajeDA { get; set; }
       public string PorcentajePA { get; set; }
       public string PorcentajeS { get; set; }
       public string PorcentajeO { get; set; }
       public string PorcentajeOII { get; set; }
       public string PorcentajeOIII { get; set; }
        

    }
}
