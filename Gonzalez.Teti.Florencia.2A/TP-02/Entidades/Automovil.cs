using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Automovil : Vehiculo
    {
        public enum ETipo
        {
            Monovolumen, Sedan
        }

        private ETipo tipo;

        /// <summary>
        /// Por defecto, TIPO será Monovolumen
        /// </summary>
        /// <param name="marca">El valor del atributo marca de la clase base Vehiculo</param>
        /// <param name="chasis">El valor del atributo chasis de la clase base Vehiculo</param>
        /// <param name="color">El valor del atributo color de la clase base Vehiculo</param>
        public Automovil(Vehiculo.EMarca marca, string chasis, ConsoleColor color) : this(marca, chasis, color, ETipo.Monovolumen) { }
        public Automovil(Vehiculo.EMarca marca, string chasis, ConsoleColor color, ETipo tipo) : base(chasis, marca, color)
        {
            this.tipo = tipo;
        }
        /// <summary>
        /// Los automoviles son medianos
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return Vehiculo.ETamanio.Mediano;
            }
        }
        /// <summary>
        /// Publica los valores de los atributos del Automovil
        /// </summary>
        /// <returns>Retorna el string con el valor de los atributos de un vehiculo</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("AUTOMOVIL");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("TAMAÑO: " + this.Tamanio);
            sb.AppendLine("TIPO: " + this.tipo);
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}