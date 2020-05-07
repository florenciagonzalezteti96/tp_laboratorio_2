using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Camioneta : Vehiculo
    {
        #region Constructores

        /// <summary>
        /// Inicializa todos los atributos de la clase base Vehiculo para cada instancia de Camioneta
        /// </summary>
        /// <param name="marca">La marca de la camioneta</param>
        /// <param name="codigo">El codigo de la camioneta</param>
        /// <param name="color">El color de la camioneta</param>
        public Camioneta(EMarca marca, string codigo, ConsoleColor color) : base(codigo, marca, color) { }

        #endregion

        #region Propiedades

        /// <summary>
        /// Las camionetas son grandes
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Muestra los valores de los atributos del Camion
        /// </summary>
        /// <returns>Retorna el string con el valor de los atributos de una Camioneta</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CAMIONETA");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("TAMAÑO: " + this.Tamanio);
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion
    }
}
