using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Program
    {
        static void Main(string[] args)
        {
            Numero num1 = new Numero(80.75);
            Numero num2 = new Numero("asasa");
            Numero num3 = new Numero("2525");
            Numero num4 = new Numero(30);

            Numero.Mostrar(num1);//80.75
            Numero.Mostrar(num2);//0
            Numero.Mostrar(num3);//2525
            Numero.Mostrar(num4);//30

            Console.WriteLine(Calculadora.Operar(num1, num2, "*"));//80.75*0 = 0

            Console.WriteLine(Calculadora.Operar(num4, num2, "/"));//30/0 = -1.7976931348623157E+308 (double min value)

            Console.ReadKey();
        }
    }
}
