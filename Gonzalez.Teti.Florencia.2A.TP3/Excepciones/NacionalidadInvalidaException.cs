using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// Inicializa el atributo message clase base Exception
        /// </summary>
        public NacionalidadInvalidaException() : this("La nacionalidad no se condice con el numero de DNI") { }

        /// <summary>
        /// Inicializa el atributo message clase base Exception
        /// </summary>
        /// <param name="mensaje"></param>
        public NacionalidadInvalidaException(string mensaje) : base(mensaje) { } 

    }
}
