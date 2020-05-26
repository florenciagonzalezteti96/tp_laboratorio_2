using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        private Universidad.EClases clasesQueToma;
        private EEstadoCuenta estadoCuenta;

        #region Metodos
        public Alumno()
        {

        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma)
        {

        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma, EEstadoCuenta estadoCuenta)
        {

        }
        protected string MostrarDatos()
        {

        }
        public string bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a == clase);
        }
        public string bool operator ==(Alumno a, Universidad.EClases clase)
        {
            
        }
        protected override string ParticiparEnClase()
        {

        }
        public override string ToString()
        {
            return base.ToString();
        }
        #endregion

        #region Tipos anidados
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        #endregion
    }
}
