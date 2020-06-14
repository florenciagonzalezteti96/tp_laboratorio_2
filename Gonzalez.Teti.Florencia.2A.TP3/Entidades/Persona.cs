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
        /// <summary>
        /// Propiedad de lectura y escritura para el atributo apellido de Persona
        /// </summary>
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

        /// <summary>
        /// Propiedad de lectura y escritura para el atributo dni de Persona
        /// </summary>
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

        /// <summary>
        /// Propiedad de lectura y escritura para el atributo nacionalidad de Persona
        /// </summary>
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

        /// <summary>
        /// Propiedad de lectura y escritura para el atributo nombre de Persona
        /// </summary>
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

        /// <summary>
        /// Propiedad de solo escritura para el atributo dni de Persona
        /// </summary>
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

        /// <summary>
        /// Inicializa los atributos de un objeto de tipo Persona
        /// </summary>
        public Persona()
        {
            this.Apellido = "";
            this.DNI = 1;
            this.Nacionalidad = ENacionalidad.Argentino;
            this.nombre = "";
        }

        /// <summary>
        /// Inicializa los atributos nombre, apellido y nacionalidad de un objeto de tipo Persona
        /// </summary>
        /// <param name="nombre">el valor del atributo nombre del objeto de tipo Persona</param>
        /// <param name="apellido">el valor del atributo apellido del objeto de tipo Persona</param>
        /// <param name="nacionalidad">el valor del atributo nacionalidad del objeto de tipo Persona</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Inicializa los atributos nombre, apellido, dni y nacionalidad de un objeto de tipo Persona
        /// </summary>
        /// <param name="nombre">el valor del atributo nombre del objeto de tipo Persona</param>
        /// <param name="apellido">el valor del atributo apellido del objeto de tipo Persona</param>
        /// <param name="dni">el valor del atributo dni del objeto de tipo Persona</param>
        /// <param name="nacionalidad">el valor del atributo nacionalidad del objeto de tipo Persona</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        /// <summary>
        /// Inicializa los atributos nombre, apellido, dni y nacionalidad de un objeto de tipo Persona
        /// </summary>
        /// <param name="nombre">el valor del atributo nombre del objeto de tipo Persona</param>
        /// <param name="apellido">el valor del atributo apellido del objeto de tipo Persona</param>
        /// <param name="dni">el valor del atributo dni del objeto de tipo Persona</param>
        /// <param name="nacionalidad">el valor del atributo nacionalidad del objeto de tipo Persona</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, dni.ToString(), nacionalidad) { }

        /// <summary>
        /// Muestra el valor de los atributos apellido, nombre y nacionalidad de la instancia actual de tipo Persona
        /// </summary>
        /// <returns>Retorna un string con los valores de los atributos</returns>
        public override string ToString()
        {
            StringBuilder persona = new StringBuilder();

            persona.AppendLine("NOMBRE COMPLETO: " + this.Apellido + ", " + this.Nombre);
            persona.AppendLine("NACIONALIDAD: " + this.Nacionalidad);

            return persona.ToString();
        }

        /// <summary>
        /// Valida que el valor ingresado para el atributo dni un objeto de tipo Persona sea valido de acuerdo a los rangos permitidos para cada nacionalidad
        /// </summary>
        /// <param name="nacionalidad">El valor del atributo nacionalidad del objeto de tipo Persona</param>
        /// <param name="dato">El dato a validar para el atributo dni del objeto de tipo Persona</param>
        /// <returns>Retorna -1 si el valor del dato no se condice con la nacionalidad del objeto, caso contrario retorna el dato</returns>
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

        /// <summary>
        /// Valida que el valor ingresado para el atributo dni un objeto de tipo Persona sea valido de acuerdo a los rangos permitidos para cada nacionalidad, que no tenga mas que 8 caracteres y que todos sean numeros
        /// </summary>
        /// <param name="nacionalidad">El valor del atributo nacionalidad del objeto de tipo Persona</param>
        /// <param name="dato">El dato a validar para el atributo dni del objeto de tipo Persona</param>
        /// <returns>Retorna -1 si el dato tiene mas de 8 caracteres o si el valor no es valido de acuerdo a la nacionalidad, 0 si no logro convertir del string a un entero, caso contrario retorna el dato</returns>
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
                throw exDni;
            }
            catch (NacionalidadInvalidaException exNacionalidad)
            {
                throw exNacionalidad;
            }
            catch (OverflowException exOverflow)
            {
                Console.WriteLine(exOverflow.Message);
            }

            return numeroValidado;
        }

        /// <summary>
        /// Valida que un dato de tipo string solo tenga letras
        /// </summary>
        /// <param name="dato">El string a validar</param>
        /// <returns>Retorna un string vacio si el dato contiene un caracter que no es letra, caso contrario retorna el string</returns>
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
        /// <summary>
        /// Enumerado con los posibles tipos de valores que puede tener un objeto de tipo enumerado ENacionalidad
        /// </summary>
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion

    }
}
