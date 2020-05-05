using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moto : Vehiculo
    {
        public Moto(EMarca marca, string codigo, ConsoleColor color) : base(codigo, marca, color) { }

        /// <summary>
        /// ReadOnly: Las motos son chicas
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }
        /// <summary>
        /// Muestra los valores de los atributos de la Moto
        /// </summary>
        /// <returns>Retorna el string con el valor de los atributos de un vehiculo</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MOTO");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("TAMAÑO: " + this.Tamanio);
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
