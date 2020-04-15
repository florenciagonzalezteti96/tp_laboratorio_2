using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    static class Calculadora
    {
        static string ValidarOperador(string operador)
        {
            StringBuilder sb = new StringBuilder();

            switch(operador)
            {
                case "+":
                    sb.Append(operador);
                    break;
                case "-":
                    sb.Append(operador);
                    break;
                case "/":
                    sb.Append(operador);
                    break;
                case "*":
                    sb.Append(operador);
                    break;
                default:
                    sb.Append("+");
                    break;
            }

            return sb.ToString();
        }
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;

            switch (Calculadora.ValidarOperador(operador))
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
            }
            return resultado;
        }
    }
}
