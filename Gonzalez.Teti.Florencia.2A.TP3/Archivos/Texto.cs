using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Esta funcion permite guardar un archivo de texto con datos
        /// </summary>
        /// <param name="archivo">El path del archivo</param>
        /// <param name="datos">Los datos que se guardaran en el archivo de texto</param>
        /// <returns>Retorna true si logro guardar, caso contrario retorna false</returns>
        public bool Guardar(string archivo, string datos)
        {
            bool sePudoGuardar = false;
            Encoding codificacion = Encoding.UTF8;

            try
            {
                using (StreamWriter swTexto = new StreamWriter(archivo, true, codificacion))
                {
                    swTexto.WriteLine(datos);
                    sePudoGuardar = true;
                }
                if (sePudoGuardar == false)
                {
                    throw new ArchivosException(new Exception("Ha ocurrido un error con el guardado del archivo de texto!"));
                }
            }
            catch (ArchivosException ex)
            {
                throw ex;
            }

            return sePudoGuardar;
        }

        /// <summary>
        /// Esta funcion permite leer un archivo de texto con datos guardados
        /// </summary>
        /// <param name="archivo">El path del archivo</param>
        /// <param name="datos">El objeto en el cual se guardaran los datos leidos del archivo de texto</param>
        /// <returns>Retorna true si logro leer, caso contrario retorna false</returns>
        public bool Leer(string archivo, out string datos)
        {
            bool sePudoLeer = false;
            Encoding codificacion = Encoding.UTF8;

            StringBuilder datosRetorno = new StringBuilder();
            string lineaDeTexto;

            try
            {
                datosRetorno.Append("No se pudo leer el archivo");

                if (File.Exists(archivo))
                {
                    using (StreamReader srTexto = new StreamReader(archivo, codificacion, true))
                    {
                        datosRetorno.Clear();
                        while ((lineaDeTexto = srTexto.ReadLine()) != null)
                        {
                            datosRetorno.AppendLine(lineaDeTexto);
                        }
                        sePudoLeer = true;
                    }
                }
                if (!sePudoLeer == false)
                {
                    throw new ArchivosException(new Exception("Ha ocurrido un error con la lectura del archivo de texto!"));
                }
            }
            catch (ArchivosException ex)
            {
                throw ex;
            }

            datos = datosRetorno.ToString();

            return sePudoLeer;
        }
    }
}
