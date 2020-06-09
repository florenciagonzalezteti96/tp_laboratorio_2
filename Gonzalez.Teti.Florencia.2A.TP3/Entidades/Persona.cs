using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public class Persona
    {
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        #region Propiedades
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = this.ValidarNombreApellido(value);
            }
        }
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = value;
            }
        }
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = this.ValidarNombreApellido(value);
            }
        }
        public string StringToDNI
        {
            set
            {

                int dni = ValidarDni(this.Nacionalidad, value);
                if (dni != -1)
                {
                    this.DNI = dni;
                }
                else
                {
                    this.DNI = 1;
                }

            }
        }
        #endregion

        #region Metodos
        public Persona()
        {
            this.Apellido = "";
            this.DNI = 1;
            this.Nacionalidad = ENacionalidad.Argentino;
            this.nombre = "";
        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, dni.ToString(), nacionalidad) { }

        public override string ToString()
        {
            StringBuilder persona = new StringBuilder();

            persona.AppendLine("NOMBRE COMPLETO: " + this.Apellido + ", " + this.Nombre);
            persona.AppendLine("NACIONALIDAD: " + this.Nacionalidad);

            return persona.ToString();
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int retorno = -1;

            if (nacionalidad == ENacionalidad.Argentino && dato >= 1 && dato <= 89999999)
            {
                retorno = dato;
            }
            else if (nacionalidad == ENacionalidad.Extranjero && dato >= 90000000 && dato <= 99999999)
            {
                retorno = dato;
            }

            return retorno;
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int numeroValidado = -1;

            try
            {
                if (dato.Length > 8)
                {
                    throw new DniInvalidoException("El dni ingresado tiene mas caracteres de los permitidos");
                }
                if (int.TryParse(dato, out numeroValidado) == false)
                {
                    throw new DniInvalidoException();
                }
                else if (ValidarDni(nacionalidad, numeroValidado) == -1)
                {
                    throw new NacionalidadInvalidaException();
                }
                else
                {
                    numeroValidado = ValidarDni(nacionalidad, numeroValidado);
                }
            }
            catch (DniInvalidoException exDni)
            {
                Console.WriteLine(exDni.Message);
            }
            catch (NacionalidadInvalidaException exNacionalidad)
            {
                Console.WriteLine(exNacionalidad.Message);
            }
            catch (OverflowException exOverflow)
            {
                Console.WriteLine(exOverflow.Message);
            }

            return numeroValidado;
        }

        private string ValidarNombreApellido(string dato)
        {
            foreach (char letra in dato)
            {
                if (Char.IsLetter(letra) == false)
                {
                    dato = "";
                    break;
                }
            }

            return dato;
        }
        #endregion

        #region Tipos Anidados
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion

    }
}
