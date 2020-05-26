using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstractas
{
    public abstract class Universitario : Persona
    {
        int legajo;

        #region Metodos
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        protected string MostrarDatos()
        {
            return "";
        }
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {

        }
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        protected abstract string ParticiparEnClase();
        public Universitario()
        {

        }
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        {

        }
        #endregion
    }
}
