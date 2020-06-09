using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public bool Guardar(string archivo, string datos)
        {
            bool sePudoGuardar = false;
            Encoding codificacion = Encoding.UTF8;

            string escritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path = escritorio + @"\" + archivo;

            try
            {
                if (Directory.Exists(escritorio))
                {
                    using (StreamWriter swTexto = new StreamWriter(path, true, codificacion))
                    {
                        swTexto.WriteLine(datos);
                        Console.WriteLine("Se guardo el archivo");
                        sePudoGuardar = true;
                    }
                }
                else
                {
                    throw new DirectoryNotFoundException();
                }
            }
            catch (DirectoryNotFoundException exNoExisteDirectorio)
            {
                Console.WriteLine(exNoExisteDirectorio.Message);
            }
            catch (ArgumentNullException exPathEsNulo)
            {
                Console.WriteLine(exPathEsNulo.Message + exPathEsNulo.ParamName);
            }
            catch (ArgumentException exPathNoExiste)
            {
                Console.WriteLine(exPathNoExiste.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Se ha producido un error al intentar guardar en el archivo.");
            }

            return sePudoGuardar;
        }

        public bool Leer(string archivo, out string datos)
        {
            bool sePudoLeer = false;
            Encoding codificacion = Encoding.UTF8;

            StringBuilder datosRetorno = new StringBuilder();
            string lineaDeTexto;

            string escritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path = escritorio + @"\" + archivo;

            try
            {
                datosRetorno.Append("No se pudo leer el archivo");
                if (Directory.Exists(escritorio))
                {
                    if (File.Exists(path))
                    {
                        using (StreamReader srTexto = new StreamReader(path, codificacion, true))
                        {
                            datosRetorno.Clear();
                            while ((lineaDeTexto = srTexto.ReadLine()) != null)
                            {
                                datosRetorno.AppendLine(lineaDeTexto);
                            }
                            sePudoLeer = true;

                        }
                    }
                    else
                    {
                        throw new FileNotFoundException();
                    }
                }
                else
                {
                    throw new DirectoryNotFoundException();
                }
            }
            catch (DirectoryNotFoundException exNoExisteDirectorio)
            {
                Console.WriteLine(exNoExisteDirectorio.Message);
            }
            catch (FileNotFoundException exNoExisteArchivo)
            {
                Console.WriteLine(exNoExisteArchivo.Message);
            }
            catch (ArgumentNullException exPathEsNulo)
            {
                Console.WriteLine(exPathEsNulo.Message + exPathEsNulo.ParamName);
            }
            catch (ArgumentException exPathNoExiste)
            {
                Console.WriteLine(exPathNoExiste.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Se ha producido un error al intentar leer el archivo.");
            }

            datos = datosRetorno.ToString();

            return sePudoLeer;
        }
    }
}
