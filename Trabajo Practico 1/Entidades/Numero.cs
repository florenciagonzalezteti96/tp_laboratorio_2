using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Numero
    {
        double numero;
        public Numero()
        {
            numero = 0;
        }
        double ValidarNumero(string strNumero)
        {
            double numeroValidado;

            double.TryParse(strNumero, out numeroValidado);

            return numeroValidado;
        }
        public static string DecimalBinario(double numero)
        {
            string numeroEnBinario;
            int numeroAEntero;

            numeroAEntero = (int) numero;
            //numero = (int)Math.Round(numeroAConvertir);

            numeroEnBinario = Convert.ToString(numeroAEntero, 2);

            return numeroEnBinario;
        }
        public static double BinarioDecimal(string numeroAConvertir)
        {
            double numeroEnEntero = 0;

            numeroEnEntero = Convert.ToInt32(numeroAConvertir, 2);

            return numeroEnEntero;
        }
    }
}
