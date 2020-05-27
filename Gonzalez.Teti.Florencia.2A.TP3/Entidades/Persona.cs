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

        #region Tipos Anidados
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion

        #region Propiedades
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                if (this.ValidarNombreApellido(value) != "False")
                {
                    this.apellido = value;
                }
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
                if (this.ValidarNombreApellido(value) != "False")
                {
                    this.nombre = value;
                }
            }
        }
        public string StringToDNI
        {
            set
            {
                try
                {
                    int dni = ValidarDni(this.Nacionalidad, value);
                    if (dni != -1)
                    {
                        this.DNI = dni;
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
            }
        }
        #endregion

        #region Metodos
        public Persona() { }
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

            if(nacionalidad == ENacionalidad.Argentino && dato>=1 && dato<=89999999)
            {
                retorno = dato;
            }
            else if(nacionalidad == ENacionalidad.Extranjero && dato>=90000000 && dato<=99999999)
            {
                retorno = dato;
            }

            return retorno;
        }
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int numeroValidado = -1;

            if (int.TryParse(dato, out numeroValidado) == false)
            {
                throw new DniInvalidoException("El DNI solo debe contener numeros");
            }
            else if(ValidarDni(nacionalidad, numeroValidado) == -1)
            {
                throw new NacionalidadInvalidaException();
            }
            else
            {
                numeroValidado = ValidarDni(nacionalidad, numeroValidado);
            }

            return numeroValidado; 
        }
        private string ValidarNombreApellido(string dato)
        {
            bool esValido = true;

            foreach(char letra in dato)
            {
                if(Char.IsLetter(letra) == false)
                {
                    esValido = false;
                    break;
                }
            }

            return esValido.ToString();
        }
        #endregion
    }
}
