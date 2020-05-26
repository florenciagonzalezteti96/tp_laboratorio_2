using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace ClasesAbstractas
{
    public abstract class Persona
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
                string dato = this.ValidarNombreApellido(value);
                if(dato != "No es valido")
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
                try
                { 
                    this.StringToDNI = value.ToString();
                }
                catch(DniInvalidoException e)
                {
                    Console.WriteLine(e.Message);
                }
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
                if (this.ValidarNombreApellido(value) != "No es valido")
                {
                    this.apellido = value;
                }
            }
        }
        public string StringToDNI
        {
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value); //ingresa string y paso a int
            }
        }
        #endregion

        #region Metodos
        public Persona() { }
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, dni.ToString(), nacionalidad) { }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        public override string ToString()
        {
            StringBuilder persona = new StringBuilder();

            persona.AppendLine("NOMBRE COMPLETO: " + this.Apellido + ", " + this.Nombre);
            persona.AppendLine("NACIONALIDAD: " + this.Nacionalidad);

            return this.ToString(); 
        }
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            bool esValido = false;
            int retorno = -1;

            if(nacionalidad == ENacionalidad.Argentino && dato>1 && dato<89999999)
            {
                esValido = true;
            }
            else if(nacionalidad == ENacionalidad.Extranjero && dato > 90000000 && dato < 99999999)
            {
                esValido = true;
            }

            if(esValido == true)
            {
                retorno = dato;
            }

            return retorno;
        }
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            if (int.TryParse(dato, out int numeroValidado) == false)
            {
                numeroValidado = -1;
            }
            else
            {
                numeroValidado = ValidarDni(nacionalidad, numeroValidado);
            }
            
            if(numeroValidado == -1)
            {
                throw new DniInvalidoException("El DNI solo debe contener numeros");//agregar excepcion EN OTRO PROYECTO !!!
            }

            return numeroValidado;
        }
        private string ValidarNombreApellido(string dato)
        {
            bool esValido = true;
            string retorno = "No es valido";

            foreach(char letra in dato)
            {
                if(Char.IsLetter(letra) == false)
                {
                    esValido = false;
                    break;
                }
            }
            if(esValido == true)
            {
                retorno = dato;
            }
            return retorno;
        }
        #endregion
    }
}
