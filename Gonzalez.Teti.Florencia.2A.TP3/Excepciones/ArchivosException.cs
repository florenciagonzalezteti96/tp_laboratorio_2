using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Inicializa los atributos message e innerException de la clase base Exception
        /// </summary>
        /// <param name="innerException">La instancia de Exception contenida en una instancia de ArchivosException</param>
        public ArchivosException(Exception innerException) : base("No se pudo realizar la accion con el archivo.", innerException) { }
    }
}
