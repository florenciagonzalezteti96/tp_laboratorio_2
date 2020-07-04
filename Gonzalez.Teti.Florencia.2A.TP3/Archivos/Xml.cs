using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Esta funcion permite guardar un archivo con serializacion xml con datos
        /// </summary>
        /// <param name="archivo">El path del archivo</param>
        /// <param name="datos">Los datos que se guardaran en el archivo con serializacion xml</param>
        /// <returns>Retorna true si logro guardar, caso contrario retorna false</returns>
        public bool Guardar(string archivo, T datos)
        {
            bool sePudoGuardar = false;
            Encoding codificacion = Encoding.UTF8;

            try
            {
                if(archivo != null && datos != null)
                {
                    using (XmlTextWriter writer = new XmlTextWriter(archivo, codificacion))
                    {
                        XmlSerializer ser = new XmlSerializer(typeof(T));
                        ser.Serialize(writer, datos);
                        writer.Close();
                        sePudoGuardar = true;
                    }
                    if (sePudoGuardar == false)
                    {
                        throw new ArchivosException(new Exception("Ha ocurrido un error con la serializacion XML del archivo!"));
                    }
                }
                else
                {
                    throw new ArchivosException(new Exception("Ha ocurrido un error con la serializacion XML del archivo!"));
                }

            }
            catch (ArchivosException ex)
            {
                throw ex;
            }
            return sePudoGuardar;
        }

        /// <summary>
        /// Esta funcion permite leer un archivo con serializacion xml con datos guardados
        /// </summary>
        /// <param name="archivo">El path del archivo</param>
        /// <param name="datos">El objeto en el cual se guardaran los datos leidos del archivo</param>
        /// <returns>Retorna true si logro leer, caso contrario retorna false</returns>
        public bool Leer(string archivo, out T datos)
        {
            bool sePudoLeer = false;

            try
            {
                if(archivo != null)
                {
                    using (XmlTextReader reader = new XmlTextReader(archivo))
                    {
                        XmlSerializer ser = new XmlSerializer(typeof(T));
                        datos = (T)ser.Deserialize(reader);
                        sePudoLeer = true;
                    }
                    if (sePudoLeer == false)
                    {
                        throw new ArchivosException(new Exception("Ha ocurrido un error con la serializacion XML del archivo!"));
                    }
                }
                else
                {
                    throw new ArchivosException(new Exception("Ha ocurrido un error con la serializacion XML del archivo!"));
                }
            }
            catch (ArchivosException ex)
            {
                throw ex;
            }

            return sePudoLeer;
        }
    }
}
