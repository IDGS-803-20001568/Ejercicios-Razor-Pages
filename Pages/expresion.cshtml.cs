using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CglrApp001Ejercicio.Pages
{
    public class expresionModel : PageModel
    {
        //DEFINIMOS LOS ATRIBUTOS
        [BindProperty]
        public string a { get; set; } = "";
        [BindProperty]
        public string b { get; set; } = "";
        [BindProperty]
        public string x { get; set; } = "";
        [BindProperty]
        public string y { get; set; } = "";
        [BindProperty]
        public string n { get; set; } = "";
        public double CalculoUno = 0;
        public double CalculoDos = 0;

        public void OnPost()
        {
            double A = Convert.ToDouble(a);
            double B = Convert.ToDouble(b);
            double X = Convert.ToDouble(x);
            double Y = Convert.ToDouble(y);
            double N = Convert.ToDouble(n);
            CalculoUno = Math.Pow((A * X) + (B * Y), N);

            CalculoDos = 0;
            for (int k = 0; k <= N; k++)
            {
                double coeficienteBinomial = CalcularCoeficienteBinomial(N, k);
                double potenciaAX = Math.Pow(A * X, N - k);
                double potenciaBY = Math.Pow(B * Y, k);

                CalculoDos += coeficienteBinomial * potenciaAX * potenciaBY;
            }


            ModelState.Clear();
        }

        private double CalcularCoeficienteBinomial(double n, double k)
        {
            if (k == 0 || k == n)
            {
                return 1;
            }
            else
            {
                return CalcularCoeficienteBinomial(n - 1, k - 1) + CalcularCoeficienteBinomial(n - 1, k);
            }
        }
    }
}
