using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        /// <summary>
        /// Inicializa el atributo message clase base Exception
        /// </summary>
        public SinProfesorException() : base("No hay profesor para la clase.") { }

    }
}
