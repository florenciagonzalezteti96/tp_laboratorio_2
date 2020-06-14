using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        #region Propiedades
        /// <summary>
        /// Propiedad de lectura y escritura del atributo alumnos de Jornada
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo clase de Jornada
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo instructor de Jornada
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Inicializa la lista del atributo alumnos de una instancia de Jornada
        /// </summary>
        Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Inicializa los atributos clase e instructor de una instancia de Jornada
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        /// <summary>
        /// Muestra el valor de los atributos clase, instructor y alumnos de una instancia actual de tipo Jornada
        /// </summary>
        /// <returns>Retorna un string con el valor de los atributos</returns>
        public override string ToString()
        {
            StringBuilder jornada = new StringBuilder();

            jornada.AppendLine("CLASE DE: " + this.Clase + " POR " + this.Instructor.ToString());
            jornada.AppendLine("ALUMNOS:");
            foreach (Alumno alumnoEnJornada in this.Alumnos)
            {
                jornada.AppendLine(alumnoEnJornada.ToString());
            }

            return jornada.ToString();
        }

        /// <summary>
        /// Guarda en un archivo de texto los datos contenidos en un objeto de tipo Jornada
        /// </summary>
        /// <param name="jornada">El objeto de tipo Jornada cuyos datos se guardaran en el archivo de texto</param>
        /// <returns>Retorna true si logro guardar el objeto de tipo Jornada, caso contrario retorna false</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto jornadaAGuardar = new Texto();

            return jornadaAGuardar.Guardar("Jornada.txt", jornada.ToString());
        }

        /// <summary>
        /// Lee de un archivo de texto los datos contenidos y los devuelve
        /// </summary>
        /// <returns>Retorna un string con los datos contenidos en el archivo de texto</returns>
        public static string Leer()
        {
            Texto jornadaAGuardar = new Texto();

            if (!jornadaAGuardar.Leer("Jornada.txt", out string jornada))
            {
                throw new ArchivosException(new Exception());
            }

            return jornada;
        }

        #region Sobrecarga de operadores
        /// <summary>
        /// Sobrecarga de operador == que evalua si un objeto de tipo Jornada y otro de tipo Alumno son iguales. 
        /// Seran iguales si el atributo de clasesQueToma del objeto de tipo Alumno es igual al de clase del objeto de tipo Jornada
        /// </summary>
        /// <param name="j">El objeto de tipo Jornada</param>
        /// <param name="a">El objeto de tipo Alumno</param>
        /// <returns>Retorna true si son iguales, caso contrario retorna false</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            return (!(a != j.Clase));
        }

        /// <summary>
        /// Sobrecarga de operador != que evalua si un objeto de tipo Jornada y otro de tipo Alumno son distintos
        /// </summary>
        /// <param name="j">El objeto de tipo Jornada</param>
        /// <param name="a">El objeto de tipo Alumno</param>
        /// <returns>Retorna true si son distintos, caso contrario retorna false</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Sobrecarga del operador + que agrega un objeto de tipo Alumno a la lista del atributo alumnos de un objeto de tipo Jornada. 
        /// El alumno solo se agregara si no existe en la lista
        /// </summary>
        /// <param name="j">El objeto de tipo Jornada</param>
        /// <param name="a">El objeto de tipo Alumno</param>
        /// <returns>Retorna un objeto de tipo Jornada</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            bool yaExiste = false;
            foreach(Alumno alumnoEnJornada in j.Alumnos)
            {
                if(alumnoEnJornada == a)
                {
                    yaExiste = true;
                    break;
                }
            }
            if(yaExiste == false)
            {
                j.Alumnos.Add(a);
            }
            return j;
        }
        #endregion
        
        #endregion
    }
}
