using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace ClasesInstanciables
{
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        #region Propiedades
        /// <summary>
        /// Propiedad de lectura y escritura del atributo alumnos de Universidad
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
        /// Propiedad de lectura y escritura del atributo profesores de Universidad
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo jornada de Universidad
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura que a partir de un indice devuelve un objeto de tipo Jornada de la lista del atributo jornada de Universidad o setea ese mismo objeto en la lista del atributo jornada de Universidad
        /// </summary>
        /// <param name="i">El indice del atributo a devolver o del lugar en donde se insertara el nuevo objeto de tipo Jornada</param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get
            {
                Jornada retorno = null;
                try
                {
                    retorno = this.jornada.ElementAt(i);
                }
                catch (ArgumentNullException exNull)
                {
                    Console.WriteLine(exNull.Message);
                }
                catch (ArgumentOutOfRangeException exOutOfRange)
                {
                    Console.WriteLine(exOutOfRange.Message);
                }
                return retorno;
            }
            set
            {
                this.jornada.Insert(i, value);
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Inicializa los atributos alumnos, jornada y profesores de un objeto de tipo Universidad
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }

        /// <summary>
        /// Muestra los datos contenidos en los atributos de un objeto de tipo Universidad
        /// </summary>
        /// <param name="uni">El objeto de tipo Universidad a mostrar</param>
        /// <returns>Retorna un string con los valores de los atributos del objeto de tipo Universidad</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder universidad = new StringBuilder();

            universidad.AppendLine("JORNADA:");
            foreach (Jornada jornadaEnUniversidad in uni.Jornadas)
            {
                universidad.AppendLine(jornadaEnUniversidad.ToString());
                universidad.AppendLine("<-------------------------------------------------->\n");
            }

            return universidad.ToString();
        }

        /// <summary>
        /// Sobrecarga de ToString(). Muestra los atributos de la instancia actual de Universidad
        /// </summary>
        /// <returns>Retorna un string con los valores de los atributos de la instancia actual de Universidad</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// Guarda el estado de un objeto de tipo Universidad utilizando la serializacion xml, es un archivo xml
        /// </summary>
        /// <param name="uni">El objeto de tipo Universidad que se serializara y guardara</param>
        /// <returns>Retorna true si logro serializar y guardar, caso contrario retorna false</returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> universidadAGuardar = new Xml<Universidad>();
            
            return universidadAGuardar.Guardar("Universidad.xml", uni);
        }

        /// <summary>
        /// Lee de un archivo xml, deserializando con xml y guardando los datos en un objeto de tipo Universidad
        /// </summary>
        /// <returns>Retorna un objeto de tipo Universidad nulo si no pudo realizar la lectura, caso contrario retorna un objeto de tipo Universidad con los datos leidos del archivo xml</returns>
        public static Universidad Leer()
        {
            Xml<Universidad> universidadAGuardar = new Xml<Universidad>();
            Universidad universidad = null;

            if(universidadAGuardar.Leer("Universidad.xml", out universidad) == false)
            {
                universidad = null;
            }

            return universidad;
        }

        #region Sobrecarga de operadores
        /// <summary>
        /// Sobrecarga del operador == que evalua si un objeto de tipo Universidad y otro de tipo Alumno son iguales. 
        /// Seran iguales si el objeto de tipo Alumno existe en la lista del atributo alumnos del objeto de tipo Universidad
        /// </summary>
        /// <param name="g">El objeto de tipo Universidad</param>
        /// <param name="a">El objeto de tipo Alumno</param>
        /// <returns>Retorna true si son iguales, caso contrario retorna false</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool yaExiste = false;
            foreach (Alumno alumnoEnUniversidad in g.alumnos)
            {
                if (alumnoEnUniversidad == a)
                {
                    yaExiste = true;
                    break;
                }
            }

            return yaExiste;
        }

        /// <summary>
        /// Sobrecarga del operador != que evalua si un objeto de tipo Universidad y otro de tipo Alumno son distintos
        /// </summary>
        /// <param name="g">El objeto de tipo Universidad</param>
        /// <param name="a">El objeto de tipo Alumno</param>
        /// <returns>Retorna true si son distintos, caso contrario retorna false</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Sobrecarga del operador == que evalua si un objeto de tipo Universidad y otro de tipo Profesor son iguales. 
        /// Seran iguales si el objeto de tipo Profesor existe en la lista del atributo profesores del objeto de tipo Universidad
        /// </summary>
        /// <param name="g">El objeto de tipo Universidad</param>
        /// <param name="i">El objeto de tipo Profesor</param>
        /// <returns>Retorna true si son iguales, caso contrario retorna false</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool yaExiste = false;
            foreach (Profesor instructorEnUniversidad in g.profesores)
            {
                if (instructorEnUniversidad == i)
                {
                    yaExiste = true;
                    break;
                }
            }

            return yaExiste;
        }

        /// <summary>
        /// Sobrecarga del operador != que evalua si un objeto de tipo Universidad y otro de tipo Profesor son distintos.
        /// </summary>
        /// <param name="g">El objeto de tipo Universidad</param>
        /// <param name="i">El objeto de tipo Profesor</param>
        /// <returns>Retorna true si son distintos, caso contrario retorna false</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Sobrecarga del operador == que evalua si un objeto de tipo Universidad y otro de tipo enumerado Universidad.EClases son iguales. 
        /// Seran iguales si ese tipo enumerado Universidad.EClases existe en la fila del atributo ClasesDelDia de un objeto de tipo Profesor en la lista del atributo profesores del objeto de tipo Universidad
        /// </summary>
        /// <param name="u">El objeto de tipo Universidad</param>
        /// <param name="clase">El objeto de tipo Universidad.EClases</param>
        /// <returns>Retorna un objeto de tipo Profesor nulo, si no son iguales. Caso contrario retorna el profesor que se encontro con ese objeto de tipo Universidad.EClases</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor instructorDisponible = null;
            bool seEncontroProfesor = false;
            int i;

            for (i = 0; i < u.profesores.Count; i++)
            {
                if (u.profesores[i] == clase)
                {
                    seEncontroProfesor = true;
                    break;
                }
            }
            if (seEncontroProfesor)
            {
                instructorDisponible =  u.profesores[i];
            }
            else
            {
                throw new SinProfesorException();
            }
            return instructorDisponible;
        }

        /// <summary>
        /// Sobrecarga del operador != que evalua si un objeto de tipo Universidad y otro de tipo enumerador Universidad.EClases son distintos.
        /// </summary>
        /// <param name="g">El objeto de tipo Universidad</param>
        /// <param name="clase">El objeto de tipo Universidad.EClases</param>
        /// <returns>Retorna el primer objeto de tipo Profesor que se encuentre que es distinto al objeto de tipo enumerado Universidad.EClases</returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            Profesor instructor = null;
            bool instructorNoDisponible = false;
            int i;

            for (i = 0; i < g.profesores.Count; i++)
            {
                if (g.profesores[i] != clase)
                {
                    instructorNoDisponible = true;
                    break;
                }
            }
            if (instructorNoDisponible)
            {
                instructor = g.profesores[i];
            }
            return instructor;
        }

        /// <summary>
        /// Sobrecarga del operador + que agrega un objeto de tipo Jornada a la lista del atributo jornada del objeto de tipo Univeridad.
        /// Se agregara si el existen objetos de tipo Alumno en la lista del atributo alumnos del objeto de tipo Universidad que cuenten con el objeto de tipo enumerado Universidad.EClases
        /// en su atributo claseQueToma. 
        /// </summary>
        /// <param name="g">El objeto de tipo Universidad</param>
        /// <param name="clase">El objeto de tipo enumerado Universidad.EClases</param>
        /// <returns>Retorna un objeto de tipo Universidad</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            List<Alumno> alumnosDisponibles = new List<Alumno>();
            Profesor profesorDisponible = null;

            try
            {
                profesorDisponible = (g == clase);
                if(profesorDisponible != null)
                {
                    Jornada nuevaJornada = new Jornada(clase, g == clase);
                    foreach (Alumno alumnoEnUniversidad in g.alumnos)
                    {
                        if (!(alumnoEnUniversidad != clase))
                        {
                            nuevaJornada.Alumnos.Add(alumnoEnUniversidad);
                        }
                    }
                    g.jornada.Add(nuevaJornada);
                }
            }
            catch (SinProfesorException exSinProfesor)
            {
                Console.WriteLine(exSinProfesor.Message);
            }
            return g;
        }

        /// <summary>
        /// Sobrecarga del operador + que agrega un objeto de tipo alumno a la lista del atributo alumnos del objeto de tipo Universidad, si no existe en la lista 
        /// </summary>
        /// <param name="u">EL objeto de tipo Universidad</param>
        /// <param name="a">El objeto de tipo Alumno</param>
        /// <returns>Retorna un objeto de tipo Universidad</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            try
            {
                if (u != a)
                {
                    u.alumnos.Add(a);
                }
                else
                {
                    throw new AlumnoRepetidoException();
                }
            }
            catch (AlumnoRepetidoException exAlumnoRepetido)
            {
                Console.WriteLine(exAlumnoRepetido.Message);
            }

            return u;
        }

        /// <summary>
        /// Sobrecarga de operador + que agrega un objeto de tipo Profesor a la lista del atributo profesores del objeto de tipo Universidad, si no existe en la lista
        /// </summary>
        /// <param name="u">El objeto de tipo Universidad</param>
        /// <param name="i">El objeto de tipo Profesor</param>
        /// <returns>Retorna un objeto de tipo Universidad</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.profesores.Add(i);
            }
            return u;
        }
        #endregion

        #endregion

        #region Tipos anidados
        /// <summary>
        /// Enumerado con los posibles tipos de valores que puede tener un objeto de tipo enumerado EClases
        /// </summary>
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        #endregion
    }
}
