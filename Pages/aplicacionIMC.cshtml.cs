using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CglrApp001Ejercicio.Pages
{
    public class aplicacionIMCModel : PageModel
    {
        //Definamos los atributos para el formulario 
        [BindProperty]
        public double Peso { get; set; }

        [BindProperty]
        public double Altura { get; set; }


        public double IMC { get; private set; }
        public string Clasificacion { get; private set; }

        public void OnPost()
        {
            if (Peso > 0 && Altura > 0)
            {
                IMC = Peso / (Altura * Altura);
                Clasificacion = ClasificarIMC(IMC);
            }
            ModelState.Clear();
        }

        private string ClasificarIMC(double imc)
        {
            if (imc < 18)
                return "Peso Bajo";
            else if (imc >= 18 && imc < 25)
                return "Peso Normal";
            else if (imc >= 25 && imc < 27)
                return "Sobrepeso";
            else if (imc >= 27 && imc < 30)
                return "Obesidad grado I";
            else if (imc >= 30 && imc < 40)
                return "Obesidad grado II";
            else
                return "Obesidad grado III";
        }
    }
}