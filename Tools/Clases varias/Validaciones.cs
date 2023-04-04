using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tools
{
    public class Validaciones
    {
        public void ValidaSoloNumero(KeyPressEventArgs e)
        {

            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) &&
                (e.KeyChar != (char)Keys.ControlKey) && e.KeyChar.ToString() != "v")
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        public void ValidaSoloTextoNumero(KeyPressEventArgs e)
        {

            if (!(char.IsLetterOrDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten Letras, números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }

        }

        public void ValidaSoloTextoNumeroDecimal(KeyPressEventArgs e)
        {

            if (!(char.IsLetterOrDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && e.KeyChar.ToString() != ".")
            {
                MessageBox.Show("Solo se permiten Letras, números y puntos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }

        }

        public void ValidaSoloTextoNumeroEspacio(KeyPressEventArgs e)
        {

            if (!(char.IsLetterOrDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten Letras, números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }

        }

        public void ValidaSoloTextoNumGuion(KeyPressEventArgs e)
        {
            if (!(char.IsLetterOrDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && e.KeyChar.ToString() != "-")
            {
                MessageBox.Show("Solo se permiten Letras, números y Guión", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        public void ValidaSoloTextoCaracter(KeyPressEventArgs e)
        {
            if (!(char.IsLetterOrDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && e.KeyChar.ToString() != "-" && e.KeyChar.ToString() != "," && e.KeyChar.ToString() != "." && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten Letras, números, punto, coma y Guión", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        public void ValidaSoloNumeroDecimal(KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Enter))
            {
                if (e.KeyChar.ToString() != ".")
                {
                    MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Handled = true;
                    return;
                }
            }
        }

        public void ValidaSoloTexto(KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar.ToString() != "/"))
            {
                MessageBox.Show("Solo se permiten Letras Sin espacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        public bool validarEmail(string email)
        {
            if (email != "")
            {
                try
                {
                    new MailAddress(email);
                    return true;
                }
                catch (FormatException)
                {
                    MessageBox.Show("Por favor digitar correctamente el correo electronico", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            return true;
        }
    }
}
