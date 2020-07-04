using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TrackingIdRepetidoException : Exception
    {
        #region Constructores

        /// <summary>
        /// Inicializa una instancia de un objeto tipo TrackingIdRepetidoException, seteando el valor de la propiedad Message de la excepcion
        /// </summary>
        /// <param name="mensaje">El mensaje de la excepcion</param>
        public TrackingIdRepetidoException(string mensaje) : base(mensaje) { }

        /// <summary>
        /// Inicializa una instancia de un objeto tipo TrackingIdRepetidoException, seteando el valor de la propiedad Message de la excepcion y la InnerException
        /// </summary>
        /// <param name="mensaje">El mensaje de la excepcion</param>
        /// <param name="inner">La excepcion que produce el error</param>
        public TrackingIdRepetidoException(string mensaje, Exception inner) : base(mensaje, inner) { }

        #endregion
    }
}
