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
            string operadorRetornado = " ";

            switch(operador)
            {
                case "+":
                    operadorRetornado = operador;
                    break;
                case "-":
                    operadorRetornado = operador;
                    break;
                case "/":
                    operadorRetornado = operador;
                    break;
                case "*":
                    operadorRetornado = operador;
                    break;
                default:
                    operadorRetornado = "+";
                    break;
            }

            return operadorRetornado;
        }
        public static void Testear()
        {
            string operadorIngresado;
            string operadorRetornado;

            Console.WriteLine("Ingrese un operador: +, -, /, * ");
            operadorIngresado = Console.ReadLine();

            operadorRetornado = ValidarOperador(operadorIngresado);

            Console.WriteLine("El operador retornado es: " + operadorRetornado);

            Console.ReadKey();

        }
    }
}
