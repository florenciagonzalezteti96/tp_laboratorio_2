using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        #region Propiedades

        /// <summary>
        /// Propiedad de lectura-escritura que retorna o setea 
        /// el valor del atributo direccionEntrega de una instancia tipo Paquete
        /// </summary>
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura-escritura que retorna o setea 
        /// el valor del atributo estado de una instancia tipo Paquete
        /// </summary>
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura-escritura que retorna o setea 
        /// el valor del atributo trackingID de una instancia tipo Paquete
        /// </summary>
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Inicializa los valores de los atributos de una instancia tipo Paquete.
        /// El atributo estado se inicializa en EEstado.Ingresado
        /// </summary>
        /// <param name="direccionEntrega">el valor tipo string del atributo direccionEntrega</param>
        /// <param name="trackingID">el valor tipo string del atributo trackingID</param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
            this.Estado = EEstado.Ingresado;
        }

        /// <summary>
        /// Metodo que simula el ciclo de vida de un objeto de tipo Paquete
        /// recorriendo los posibles valores del atributo estado hasta llegar a EEstado.Entregado
        /// </summary>
        public void MockCicloDeVida() 
        {
            while(this.Estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);
                this.Estado += 1;

                this.InformaEstado(this, new EventArgs());

                try
                {
                    PaqueteDAO.Insertar(this);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Metodo que retorna el valor de los atributos de 
        /// trackingID y direccionEntrega de un objeto tipo Paquete
        /// </summary>
        /// <param name="elemento">objeto de tipo interfaz IMostrar<Paquete> </param>
        /// <returns>retorna el string con el valor de los atributos</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento) 
        {
            Paquete p = (Paquete)elemento;
            return string.Format("{0} para {1}", p.trackingID, p.direccionEntrega);  
        }

        /// <summary>
        /// Metodo que llama a MostrarDatos() de Paquete y muestra los valores de los atributos
        /// trackingID y direccionEntrega de la instancia actual de Paquete
        /// </summary>
        /// <returns>retorna el string con el valor de los atributos</returns>
        public override string ToString()
        {
            IMostrar<Paquete> paquete = this;

            return MostrarDatos(paquete);
        }

        #region Sobrecarga de operadores

        /// <summary>
        /// Sobrecarga de operador == que evalua si dos objetos de tipo Paquete son iguales.
        /// Seran iguales siempre y cuando los valores del atributo trackingID de cada uno sean iguales
        /// </summary>
        /// <param name="p1">un objeto de tipo Paquete</param>
        /// <param name="p2">un objeto de tipo Paquete</param>
        /// <returns>retorna true si son iguales, caso contrario retorna false</returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return p1.TrackingID == p2.TrackingID;
        }

        /// <summary>
        /// Sobrecarga de operador == que evalua si dos objetos de tipo Paquete son distintos.
        /// Seran distintos siempre y cuando los valores del atributo trackingID de cada uno sean distintos
        /// </summary>
        /// <param name="p1">un objeto de tipo Paquete</param>
        /// <param name="p2">un objeto de tipo Paquete</param>
        /// <returns>retorna true si son distintos, caso contrario retorna false</returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        #endregion

        #endregion

        #region Eventos

        /// <summary>
        /// Evento que informa el estado de un paquete
        /// </summary>
        public event DelegadoEstado InformaEstado;

        #endregion

        #region Tipos Anidados

        /// <summary>
        /// Delegado que informa el estado de un paquete
        /// </summary>
        /// <param name="emisor">un objeto emisor</param>
        /// <param name="evento">un objeto de tipo EventArgs</param>
        public delegate void DelegadoEstado(object emisor, EventArgs evento);

        /// <summary>
        /// Enumerado que contiene los posibles valores para el atributo estado
        /// de un objeto tipo Paquete
        /// </summary>
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }

        #endregion

    }
}
