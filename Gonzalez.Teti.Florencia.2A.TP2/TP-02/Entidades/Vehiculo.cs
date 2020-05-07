using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        private EMarca marca;
        private string chasis;
        private ConsoleColor color;

        /// <summary>
        /// Enumerado con las posibles marcas para un Vehiculo
        /// </summary>
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda
        }
        /// <summary>
        /// Enumerado con los posibles tamaños para un Vehiculo
        /// </summary>
        public enum ETamanio
        {
            Chico, Mediano, Grande
        }

        #region Constructores

        /// <summary>
        /// Inicializa los atributos de un tipo de Vehiculo
        /// </summary>
        /// <param name="chasis">El chasis del vehiculo</param>
        /// <param name="marca">La marca del vehiculo</param>
        /// <param name="color">El color del Vehiculo</param>
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.marca = marca;
            this.chasis = chasis;
            this.color = color;
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        ///
        protected abstract ETamanio Tamanio
        {
            get;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Muestra los valores de los atributos del Vehiculo
        /// </summary>
        /// <returns>Retorna el string con el valor de los atributos de un vehiculo</returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Crea un string con los datos del Vehiculo
        /// </summary>
        /// <param name="p">El vehiculo con los datos a cargar en el string</param>
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CHASIS: " + p.chasis);
            sb.AppendLine("MARCA : " + p.marca.ToString());
            sb.AppendLine("COLOR : " + p.color.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1">El primer vehiculo a comparar</param>
        /// <param name="v2">El segundo vehiculo a comparar</param>
        /// <returns>Retorna true si los atributos chasis de cada vehiculo son de igual valor, caso contrario retorna false</returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            bool retorno = false;
            if (String.Compare(v1.chasis, v2.chasis) == 0)
            {
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1">El primer vehiculo a comparar</param>
        /// <param name="v2">El segundo vehiculo a comparar</param>
        /// <returns>Retorna true si los atributos chasis de cada vehiculo son de diferente valor, caso contrario retorna false</returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }

        #endregion
    }
}
