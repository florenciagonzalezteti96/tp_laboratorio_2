using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

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
        public static bool Guardar(Jornada jornada)
        {
            Texto jornadaAGuardar = new Texto();
            bool sePudoGuardar;

            if ((sePudoGuardar = jornadaAGuardar.Guardar("Jornada.txt", jornada.ToString())) == false)
            {
                throw new ArchivosException(new Exception());
            }
            return sePudoGuardar;
        }

        public static string Leer()
        {
            Texto jornadaAGuardar = new Texto();

            if(!jornadaAGuardar.Leer("Jornada.txt", out string jornada))
            {
                throw new ArchivosException(new Exception());
            }

            return jornada;
        }

        Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

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

        #region Sobrecarga de operadores
        public static bool operator ==(Jornada j, Alumno a)
        {
            return a == j.Clase;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

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
