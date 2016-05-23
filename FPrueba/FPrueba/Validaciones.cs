using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FPrueba
{
    public class Validaciones
    {
        // Estamos Probando la inserccion de Clases una de las formas más faciles de agrupar
        public static bool ValidarDecimal(TextBox Caja)
        {
            try
            {
                decimal d = Convert.ToDecimal(Caja.Text);
                return true;
            }
            catch (Exception)
            {
                Caja.Text = "0";
                Caja.Select(0, Caja.Text.Length);
                
                return false;
                
            }
        }

        public void Validardecimal(KeyPressEventArgs e ,TextBox Caja)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < Caja.Text.Length; i++)
            {
                if (Caja.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }
            }
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }


        public bool ValidaTextBoxVacios(Form formulario)
        {
            
         
            foreach (Control control in formulario.Controls)
            {

                if (control.GetType().Equals(typeof(TextBox)))
                {

                    if (control.Text.Equals(""))
                    {
                        return false;
                        
                    }
                }
            }
            return true;
        }
    }
}
