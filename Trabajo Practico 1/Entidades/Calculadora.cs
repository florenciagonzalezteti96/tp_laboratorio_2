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
            string operadorRetornado;

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
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;
            string operacion;

            operacion = Calculadora.ValidarOperador(operador);

            switch (operacion)
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
                default:
                    
                    break;
            }
            return resultado;
        }

        public static void TestearCalculadora()
        {
            string operadorIngresado;
            string operadorRetornado;

            Console.WriteLine("Ingrese un operador: +, -, /, * ");
            operadorIngresado = Console.ReadLine();

            operadorRetornado = ValidarOperador(operadorIngresado);

            Console.WriteLine("El operador retornado es: " + operadorRetornado);

            Numero numero1 = new Numero();
            Numero numero2 = new Numero();



            //Operar()

            //Console.ReadKey();

        }
        
    }
}
