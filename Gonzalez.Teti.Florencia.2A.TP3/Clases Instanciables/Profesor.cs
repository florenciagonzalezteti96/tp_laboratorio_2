using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        #region Metodos
        /// <summary>
        /// Inicializa los atributos de la clase base Universitario
        /// </summary>
        public Profesor() : this(1, "Sin nombre", "Sin Apellido", "1", ENacionalidad.Argentino) { }

        /// <summary>
        /// Inicializa los atributos de laclase base y tambien la lista del atributo clasesDelDia del objeto de tipo Profesor
        /// </summary>
        /// <param name="id">El valor del atributo legajo de la clase base Universitario</param>
        /// <param name="nombre">El valor del atributo nombre de la clase base Universitario</param>
        /// <param name="apellido">El valor del atributo apellido de la clase base Universitario</param>
        /// <param name="dni">El valor del atributo dni de la clase base Universitario</param>
        /// <param name="nacionalidad">El valor del atributo nacionalidad de la clase base Universitario</param>
        public Profesor(int id, string nombre, string apellido, string dni, Persona.ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        /// <summary>
        /// Inicializa el atributo estatico random de la clase Profesor
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Utiliza el metodo Random.Next() para asignar objetos de tipo enumerado Universidad.EClases a la lista de objetos de tipo enumerado Universidad.EClases del atributo clasesDeDia de un objeto de tipo Profesor
        /// </summary>
        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 4));
            }
        }

        /// <summary>
        /// Sobrecarga de ParticiparEnClase() de la clase base Universitario. Muestra la lista del atributo clasesDelDia de una instancia actual de tipo Profesor
        /// </summary>
        /// <returns>Retorna un string con el valor del atributo</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder clasesDelDia = new StringBuilder();

            clasesDelDia.AppendLine("CLASES DEL DIA:");
            foreach (Universidad.EClases item in this.clasesDelDia)
            {
                clasesDelDia.AppendLine(Enum.GetName(typeof(Universidad.EClases), item));
            }

            return clasesDelDia.ToString();
        }

        /// <summary>
        /// Sobrecarga de MostrarDatos() de la clase base Universitario. Muestra el valor de los atributos apellido, nombre, nacionalidad, legajo y el atributo clasesDelDia de la instancia actual de tipo Profesor
        /// </summary>
        /// <returns>Retorna un string con los valores de los atributos</returns>
        protected override string MostrarDatos()
        {
            StringBuilder profesor = new StringBuilder();

            profesor.Append(base.MostrarDatos());
            profesor.AppendLine(this.ParticiparEnClase());

            return profesor.ToString();
        }

        /// <summary>
        /// Sobrecarga de ToString(). Muestra los valores de los atributos de una instancia de tipo Profesor
        /// </summary>
        /// <returns>Retorna un string con los valores de los atributos</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #region Sobrecarga de operadores
        /// <summary>
        /// Sobrecarga del operador == que evalua si un objeto de tipo Profesor es igual a uno de tipo enumerado Universidad.EClases. Seran iguales si el valor del tipo enumerado existe en la lista del atributo clasesDelDia del objeto de tipo Profesor.
        /// </summary>
        /// <param name="i">El objeto de tipo Profesor</param>
        /// <param name="clase">El objeto de tipo enumerado Universidad.EClases</param>
        /// <returns>Retorna true si son iguales, caso contrario retorna false</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool sonIguales = false;
            foreach(Universidad.EClases claseDelDia in i.clasesDelDia)
            {
                if(claseDelDia == clase)
                {
                    sonIguales = true;
                    break;
                }
            }
            return sonIguales;
        }

        /// <summary>
        /// Sobrecarga del operador != que evalua si un objeto de tipo Profesor y uno de tipo enumerado Universidad.EClases son distintos
        /// </summary>
        /// <param name="i">El objeto de tipo Profesor</param>
        /// <param name="clase">El objeto de tipo enumerado Universidad.EClases</param>
        /// <returns>Retorna true si son distintos, caso contrario retorna false</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion

        #endregion

    }
}
