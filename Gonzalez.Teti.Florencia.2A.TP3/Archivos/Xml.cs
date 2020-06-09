using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    /*public class Xml<T> : IArchivo<T>
    {
        /*public bool Guardar(string archivo, T datos)
        {
            bool sePudoGuardar = false;
            Encoding codificacion = Encoding.UTF8;

            StringBuilder datosRetorno = new StringBuilder();
            string lineaDeTexto;

            string escritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path = escritorio + @"\" + archivo;

            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(path, codificacion))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    ser.Serialize(writer, T);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool Leer(string archivo, out T datos)
        {

        }
    }*/
}
