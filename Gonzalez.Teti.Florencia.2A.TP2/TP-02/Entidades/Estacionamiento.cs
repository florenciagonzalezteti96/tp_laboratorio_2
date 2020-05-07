using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Estacionamiento
    {
        private List<Vehiculo> vehiculos;
        private int espacioDisponible;

        /// <summary>
        /// Enumerado con los posibles tipos de vehiculos en el estacionamiento
        /// </summary>
        public enum ETipo
        {
            Moto, Automovil, Camioneta, Todos
        }

        #region "Constructores"

        /// <summary>
        /// Inicializa el atributo de tipo List para una instancia de Estacionamiento. No recibe parametros.
        /// </summary>
        private Estacionamiento()
        {
            this.vehiculos = new List<Vehiculo>();
        }

        /// <summary>
        /// Inicializa el atributo de espacio disponible para una instancia de Estacionamiento
        /// </summary>
        /// <param name="espacioDisponible">El numero de espacios disponibles en el estacionamiento</param>
        public Estacionamiento(int espacioDisponible) : this()
        {
            this.espacioDisponible = espacioDisponible;
        }

        #endregion

        #region "Sobrecargas"

        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos
        /// </summary>
        /// <returns>Retorna un string con todos los datos del estacionamiento y los vehiculos que en el existen (si los hay)</returns>
        public override string ToString()
        {
            return Estacionamiento.Mostrar(this, ETipo.Todos);
        }

        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns>Retorna un string con los datos el elemento Estacionamiento y su lista, filtrando por tipo de Vehiculo</returns>
        public static string Mostrar(Estacionamiento c, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles\n", c.vehiculos.Count, c.espacioDisponible);
            foreach (Vehiculo item in c.vehiculos)
            {
                switch (tipo)
                {
                    case ETipo.Moto:
                        if (item is Moto)
                        {
                            sb.AppendLine(item.Mostrar());
                        }
                        break;
                    case ETipo.Automovil:
                        if (item is Automovil)
                        {
                            sb.AppendLine(item.Mostrar());
                        }
                        break;
                    case ETipo.Camioneta:
                        if(item is Camioneta)
                        {
                            sb.AppendLine(item.Mostrar());
                        }
                        break;
                    default:
                        sb.AppendLine(item.Mostrar());
                        break;
                }
            }
            return sb.ToString();
        }

        #endregion

        #region "Operadores"

        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="c">Objeto que contiene la lista donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns>Retorna el objeto Estacionamiento con el objeto vehiculo, si logro agregarlo</returns>
        public static Estacionamiento operator +(Estacionamiento c, Vehiculo p)
        {
            bool yaExiste = false;
            if (c.vehiculos.Count < c.espacioDisponible)
            {
                foreach (Vehiculo vehiculo in c.vehiculos)
                {
                    if (vehiculo == p)
                    {
                        yaExiste = true;
                        break;
                    }
                }
                if (yaExiste == false)
                {
                    c.vehiculos.Add(p);
                }
            }
            return c;
        }

        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns>Retorna el objeto Estacionamiento sin el objeto vehiculo, si logro quitarlo</returns>
        public static Estacionamiento operator -(Estacionamiento c, Vehiculo p)
        {
            int indice = 0;
            foreach (Vehiculo v in c.vehiculos)
            {
                if (v == p)
                {
                    c.vehiculos.RemoveAt(indice);
                    break;
                }
                indice++;
            }
            return c;
        }

        #endregion
    }
}