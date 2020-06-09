using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        private Universidad.EClases clasesQueToma;
        private EEstadoCuenta estadoCuenta;

        #region Metodos
        public Alumno() : base(1, "", "", "1", ENacionalidad.Argentino) { }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesQueToma = clasesQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma, EEstadoCuenta estadoCuenta): this(id, nombre, apellido, dni, nacionalidad, clasesQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        protected override string MostrarDatos()
        {
            StringBuilder alumno = new StringBuilder();

            alumno.AppendLine(base.MostrarDatos());
            switch(this.estadoCuenta)
            {
                case EEstadoCuenta.AlDia:
                    alumno.AppendLine("ESTADO DE CUENTA: Cuota al día");
                    break;
                case EEstadoCuenta.Deudor:
                    alumno.AppendLine("ESTADO DE CUENTA: Deudor");
                    break;
                case EEstadoCuenta.Becado:
                    alumno.AppendLine("ESTADO DE CUENTA: Becado");
                    break;
            }
            alumno.AppendLine(this.ParticiparEnClase());

            return alumno.ToString();
        }

        protected override string ParticiparEnClase()
        {
            return "TOMA CLASES DE: " + this.clasesQueToma;
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #region Sobrecarga de operadores
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return (a.clasesQueToma == clase) && (a.estadoCuenta != EEstadoCuenta.Deudor);
        }

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return a.clasesQueToma != clase;
        }
        #endregion

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
