using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        public int legajo;

        #region Metodos
        public Universitario() { }
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1.Equals(pg2) && ((pg1.legajo == pg2.legajo) || (pg1.DNI == pg2.DNI));
        }
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        public override bool Equals(object obj)
        {
            return (obj.GetType() == this.GetType());
        }
        public virtual string MostrarDatos()
        {
            StringBuilder universitario = new StringBuilder();

            universitario.Append(base.ToString());
            universitario.AppendLine("LEGAJO NUMERO: " + this.legajo);

            return universitario.ToString();
        }
        protected abstract string ParticiparEnClase();
        
        #endregion
    }
}
