using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivo<T>
    {
        /// <summary>
        /// Esta funcion permite guardar un archivo con datos
        /// </summary>
        /// <param name="archivo">El path del archivo</param>
        /// <param name="datos">Los datos que se guardaran en el archivo</param>
        /// <returns>Retorna true si logro guardar, caso contrario retorna false</returns>
        bool Guardar(string archivo, T datos);

        /// <summary>
        /// Esta funcion permite leer un archivo con datos guardados
        /// </summary>
        /// <param name="archivo">El path del archivo</param>
        /// <param name="datos">El objeto en el cual se guardaran los datos leidos del archivo</param>
        /// <returns>Retorna true si logro leer, caso contrario retorna false</returns>
        bool Leer(string archivo, out T datos);
    }
}
