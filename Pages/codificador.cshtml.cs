using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CglrApp001Ejercicio.Pages
{
    public class codificadorModel : PageModel
    {
        [BindProperty]
        public string MensajeEntrada { get; set; }

        [BindProperty]
        public int Shift { get; set; }

        [BindProperty]
        public string Operacion { get; set; }

        public string MensajeSalida { get; set; }

        public void OnPost()
        {
            if (!string.IsNullOrEmpty(MensajeEntrada))
            {
                switch (Operacion)
                {
                    case "Codificar":
                        MensajeSalida = Cipher(MensajeEntrada, Shift);
                        break;
                    case "Decodificar":
                        MensajeSalida = Cipher(MensajeEntrada, 26 - Shift);
                        break;
                    default:
                        MensajeSalida = "Operación desconocida.";
                        break;
                }
            }
        }

        private string Cipher(string message, int shift)
        {
            shift = shift % 26;
            char[] buffer = message.ToUpper().ToCharArray();

            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];

                if (char.IsLetter(letter))
                {
                    char d = (char)((letter + shift - 'A') % 26 + 'A');
                    buffer[i] = d;
                }
            }
            return new string(buffer);
        }
    }
}
