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

        #region Constructores
        public Numero()
        {
            numero = 0;
        }
        #endregion

        double ValidarNumero(string strNumero)
        {
            double numeroValidado;

            if(double.TryParse(strNumero, out numeroValidado) == false)
            {
                numeroValidado = 0;
            }

            return numeroValidado;
        }


        #region Operadores
        public static double operator +(Numero numero1, Numero numero2)
        {
            double resultado;

            resultado = numero1.numero + numero2.numero;

            return resultado;
        }
        public static double operator -(Numero numero1, Numero numero2)
        {
            double resultado;

            resultado = numero1.numero - numero2.numero;

            return resultado;
        }
        public static double operator /(Numero numero1, Numero numero2)
        {
            double resultado;

            if(numero2.numero == 0)
            {
                resultado = Double.MinValue;
            }
            else
            {
                resultado = numero1.numero / numero2.numero;
            }
            
            return resultado;
        }
        public static double operator *(Numero numero1, Numero numero2)
        {
            double resultado;

            resultado = numero1.numero * numero2.numero;

            return resultado;
        }
        #endregion

        #region Metodos
       /* public static string DecimalBinario(double numero)
        {
            string numeroEnBinario;
            int numeroAEntero;

            numeroAEntero = (int) numero;

            numeroEnBinario = Convert.ToString(numeroAEntero, 2);

            return numeroEnBinario;
        }*/
        public static string BinarioDecimal(string binario)
        {
            string sePudo;
            int numero;

            numero = Convert.ToInt32(binario, 2);

            if(numero == 0)
            {
                sePudo = "Valor invalido";
            }
            else
            {
                sePudo = Convert.ToString(numero);
            }

            return sePudo;
        }
        #endregion
    }
}
