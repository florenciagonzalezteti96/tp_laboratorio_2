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
            Calculadora.TestearCalculadora();

            Console.WriteLine(Numero.BinarioDecimal("asasas"));

            Console.WriteLine(Numero.BinarioDecimal("1000"));

            Console.ReadKey();
        }
    }
}
