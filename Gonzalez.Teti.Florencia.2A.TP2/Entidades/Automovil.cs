using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Automovil : Vehiculo
    {
        private ETipo tipo;

        /// <summary>
        /// Enumerado con los posibles tipos de automoviles
        /// </summary>
        public enum ETipo
        {
            Monovolumen, Sedan
        }

        #region Constructores

        /// <summary>
        /// Por defecto, TIPO será Monovolumen
        /// </summary>
        /// <param name="marca">La marca del Automovil</param>
        /// <param name="chasis">El chasis del Automovil</param>
        /// <param name="color">El color del Automovil</param>
        public Automovil(Vehiculo.EMarca marca, string chasis, ConsoleColor color) : this(marca, chasis, color, ETipo.Monovolumen) { }
        
        /// <summary>
        /// Inicializa los atributos de la clase base Vehiculo y el atributo tipo de cada instancia de Automovil
        /// </summary>
        /// <param name="marca">La marca del Automovil</param>
        /// <param name="chasis">El chasis del Automovil</param>
        /// <param name="color">El color del Automovil</param>
        /// <param name="tipo">El tipo de Automovil</param>
        public Automovil(Vehiculo.EMarca marca, string chasis, ConsoleColor color, ETipo tipo) : base(chasis, marca, color)
        {
            this.tipo = tipo;
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// ReadOnly: Los automoviles son medianos
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return Vehiculo.ETamanio.Mediano;
            }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Publica los valores de los atributos del Automovil
        /// </summary>
        /// <returns>Retorna el string con el valor de los atributos de un Automovil</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("AUTOMOVIL");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("TAMAÑO: " + this.Tamanio);
            sb.AppendLine("TIPO: " + this.tipo);
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion
    }
}