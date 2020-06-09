using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        #region Metodos
        public Profesor() : this(1, "Sin nombre", "Sin Apellido", "1", ENacionalidad.Argentino) { }

        public Profesor(int id, string nombre, string apellido, string dni, Persona.ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        static Profesor()
        {
            random = new Random();
        }

        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 4));
            }
        }

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

        protected override string MostrarDatos()
        {
            StringBuilder profesor = new StringBuilder();

            profesor.Append(base.MostrarDatos());
            profesor.AppendLine(this.ParticiparEnClase());

            return profesor.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #region Sobrecargar de operadores
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

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion

        #endregion

    }
}
