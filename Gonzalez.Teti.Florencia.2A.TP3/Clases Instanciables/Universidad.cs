using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                return jornada; ///
            }
            set
            {
                this.jornada = value; ///
            }
        }
        #endregion

        #region Metodos
        public bool Guardar(Universidad uni)
        {

        }
        public Universidad Leer()
        {

        }
        public string MostrarDatos(Universidad uni)
        {

        }
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            return !(g == clase);
        }
        public static Universidad operator +(Universidad g, EClases clase)
        {
            return !(g == clase);
        }
        public static Universidad operator +(Universidad u, Alumno a)
        {
            return !(g == clase);
        }
        public static Universidad operator +(Universidad u, Profesor i)
        {
            return !(g == clase);
        }
        public static bool operator ==(Universidad g, Alumno a)
        {

        }
        public static bool operator ==(Universidad g, Profesor i)
        {

        }
        public static Profesor operator ==(Universidad u, EClases clase)
        {

        }
        public override string ToString()
        {
            return base.ToString();
        }
        public Universidad()
        {

        }
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
