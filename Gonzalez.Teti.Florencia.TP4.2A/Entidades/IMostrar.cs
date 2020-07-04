using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IMostrar<T>
    {
        #region Metodos

        /// <summary>
        /// Metodo de interfaz que mostrara los datos de un objeto en su implementacion
        /// </summary>
        /// <param name="elemento">El objeto con los datos a ser mostrados</param>
        /// <returns>Retorna un string con los datos del objeto</returns>
        string MostrarDatos(IMostrar<T> elemento);

        #endregion
    }
}
