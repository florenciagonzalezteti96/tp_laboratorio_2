using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {

        #region Metodos
        /// <summary>
        /// Metodo de extension para un objeto de tipo string.
        /// Crea un archivo de texto en el escritorio conteniendo los datos del objeto de tipo string que utiliza el metodo
        /// </summary>
        /// <param name="texto">Un objeto de tipo string cuyos datos se guardan en el archivo</param>
        /// <param name="archivo">El nombre del archivo</param>
        /// <returns></returns>
        public static bool Guardar(this string texto, string archivo)
        {
            bool sePudoGuardar = false;

            try
            {
                using (StreamWriter swTexto = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"" + archivo, true, Encoding.UTF8))
                {
                    swTexto.WriteLine(texto);
                    sePudoGuardar = true;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ha ocurrido un error al guardar el archivo de texto.");
            }

            return sePudoGuardar;
        }
        #endregion

    }
}
