using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            }
            set
            {

            }
        }
        public Universidad.EClases Clase
        {
            get
            {

            }
            set
            {

            }
        }
        public Profesor Instructor
        {
            get
            {

            }
            set
            {

            }
        }
        #endregion

        #region Metodos
        public bool Guardar(Jornada jornada)
        {
            
        }
        private Jornada()
        {

        }
        public Jornada(Universidad.EClases clase, Profesor instructor)
        {

        }
        public string Leer()
        {

        }
        public static bool operator !=(Jornada j, Alumno a)
        {

        }
        public static Jornada operator +(Jornada j, Alumno a)
        {

        }
        public static bool operator ==(Jornada j, Alumno a)
        {

        }
        public override string ToString()
        {
            return base.ToString();
        }
        #endregion
    }
}
