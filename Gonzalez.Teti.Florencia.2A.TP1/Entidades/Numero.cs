using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        #region Constructores y Set
        public Numero()
        {
            this.numero = 0;
        }
        public Numero(double numero)
        {
            SetNumero = numero.ToString();
        }
        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }
        private string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }
        #endregion

        #region Operadores
        public static double operator +(Numero n1, Numero n2)
        {
            double resultado;

            resultado = n1.numero + n2.numero;

            return resultado;
        }
        public static double operator -(Numero n1, Numero n2)
        {
            double resultado;

            resultado = n1.numero - n2.numero;

            return resultado;
        }
        public static double operator /(Numero n1, Numero n2)
        {
            double resultado;

            if (n2.numero == 0)
            {
                resultado = Double.MinValue;
            }
            else
            {
                resultado = n1.numero / n2.numero;
            }

            return resultado;
        }
        public static double operator *(Numero n1, Numero n2)
        {
            double resultado;

            resultado = n1.numero * n2.numero;

            return resultado;
        }
        #endregion

        #region Metodos
        private double ValidarNumero(string strNumero)
        {
            if (double.TryParse(strNumero, out double numeroValidado) == false)
            {
                numeroValidado = 0;
            }

            return numeroValidado;
        }
        public static string DecimalBinario(double numero)
        {
            return Convert.ToString((int)Math.Abs(numero), 2);
        }
        public static string DecimalBinario(string numero)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Valor Invalido");

            if (double.TryParse(numero, out double resultado))
            {
                sb.Replace("Valor Invalido", DecimalBinario(resultado));
            }

            return sb.ToString();
        }
        public static string BinarioDecimal(string binario)
        {
            bool esBinario = true;

            StringBuilder sb = new StringBuilder();
            sb.Append("Valor Invalido");

            if(!String.IsNullOrEmpty(binario))
            {
                foreach(char auxChar in binario)
                {
                    if(auxChar != '0' && auxChar != '1')
                    {
                        esBinario = false;
                        break;
                    }
                }
            }

            if (esBinario == true)
            {
                sb.Replace("Valor Invalido", Convert.ToInt32(binario, 2).ToString());
            }

            return sb.ToString();
        }
        #endregion
    }
}
