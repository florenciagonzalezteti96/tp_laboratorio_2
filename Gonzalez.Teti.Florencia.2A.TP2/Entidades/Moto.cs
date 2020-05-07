using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moto : Vehiculo
    {
        #region Constructores

        /// <summary>
        /// Inicializa los atributos de la clase base Vehiculo para cada instancia de Moto
        /// </summary>
        /// <param name="marca">La marca de la moto</param>
        /// <param name="codigo">El codigo de la moto</param>
        /// <param name="color">El color de la moto</param>
        public Moto(EMarca marca, string codigo, ConsoleColor color) : base(codigo, marca, color) { }

        #endregion

        #region Propiedades

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

        #endregion

        #region Metodos

        /// <summary>
        /// Muestra los valores de los atributos de la Moto
        /// </summary>
        /// <returns>Retorna el string con el valor de los atributos de una Moto</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MOTO");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("TAMAÑO: " + this.Tamanio);
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion
    }
}
