using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        #region Propiedades
        /// <summary>
        /// Propiedad de lectura-escritura que retorna o setea 
        /// el valor del atributo paquetes de una instancia tipo Correo
        /// </summary>
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Inicializa los valores de los atributos de una instancia tipo Correo.
        /// </summary>
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }

        /// <summary>
        /// Finaliza todos los hilos de la lista mockPaquetes de una instancia de tipo Correo
        /// que esten activos al momento de ejecutarse el metodo
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread entregas in this.mockPaquetes)
            {
                if (entregas != null && entregas.ThreadState == ThreadState.Running)
                {
                    entregas.Abort();
                }
            }
        }

        /// <summary>
        /// Muestra los datos de una lista de elementos de tipo Paquetes
        /// </summary>
        /// <param name="elementos">El atributo de tipo IMostrar que contiene la lista a mostrar</param>
        /// <returns>Retorna un string con todos los elementos</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            string paquetes = "";
            List<Paquete> correo = ((Correo)elementos).Paquetes;

            foreach (Paquete p in correo)
            {
                paquetes += string.Format("{0} para {1} ({2})", p.TrackingID, p.DireccionEntrega, p.Estado.ToString());
                paquetes += "\n";
            }

            return paquetes.ToString();
        }

        #region Sobrecarga de operadores
        /// <summary>
        /// Agrega un paquete a la lista de tipo Paquetes contenida en una instancia de tipo Correo
        /// Si no existe el paquete en la lista, lo agrega. Caso contrario, lanzara una excepcion de tipo TrackingIdRepetidoException
        /// </summary>
        /// <param name="c">el objeto de tipo correo al cual se quiere agregar el paquete</param>
        /// <param name="p">El paquete a agregar</param>
        /// <returns>Retonar el objeto de tipo correo</returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            bool yaExiste = false;
            foreach (Paquete paqueteEnLista in c.Paquetes)
            {
                if (paqueteEnLista == p)
                {
                    yaExiste = true;
                    throw new TrackingIdRepetidoException("Paquete Repetido");
                }
            }
            if (!yaExiste)
            {
                c.Paquetes.Add(p);
                Thread hilo = new Thread(p.MockCicloDeVida);
                c.mockPaquetes.Add(hilo);
                hilo.Start();
            }
            return c;
        }

        #endregion

        #endregion

    }
}
