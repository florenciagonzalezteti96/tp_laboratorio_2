using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace ClasesInstanciables
{
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        #region Propiedades
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
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }

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

        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /*public bool Guardar(Universidad uni)
        {

        }

        public bool Universidad Leer()
        {

        }*/

        #region Sobrecarga de operadores
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

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

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

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        public static Profesor operator ==(Universidad u, EClases clase)
        {
            bool instructorDisponible = false;
            int i;

            for (i = 0; i < u.profesores.Count; i++)
            {
                if (u.profesores[i] == clase)
                {
                    instructorDisponible = true;
                    break;
                }
            }
            if (instructorDisponible)
            {
                return u.profesores[i];
            }
            else
            {
                throw new SinProfesorException();
            }
        }

        public static Profesor operator !=(Universidad g, EClases clase)
        {
            bool instructorNoDisponible = false;
            Profesor instructor = null;
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

        public static Universidad operator +(Universidad g, EClases clase)
        {
            List<Alumno> alumnosDisponibles = new List<Alumno>();
            try
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
            catch (SinProfesorException exSinProfesor)
            {
                Console.WriteLine(exSinProfesor.Message);
            }
            return g;
        }

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
