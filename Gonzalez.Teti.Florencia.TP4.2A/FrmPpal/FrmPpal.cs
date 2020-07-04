using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace FrmPpal
{
    public partial class FrmPpal : Form
    {
        private Correo correo;

        /// <summary>
        /// Inicializa una instancia de FrmPpal y el atributo de tipo Correo del FrmPpal
        /// </summary>
        public FrmPpal()
        {
            InitializeComponent();
            this.correo = new Correo();
        }

        /// <summary>
        /// Actualiza las listas del FrmPpal y los items de tipo Paquete que se muestran en ellas
        /// </summary>
        private void ActualizarEstados() 
        {
            this.lstEstadoIngresado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoEntregado.Items.Clear();

            foreach(Paquete paquete in this.correo.Paquetes)
            {
                if (paquete.Estado == Paquete.EEstado.Ingresado)
                {
                    this.lstEstadoIngresado.Items.Add(paquete);
                }
                else if (paquete.Estado == Paquete.EEstado.EnViaje)
                {
                    this.lstEstadoEnViaje.Items.Add(paquete);
                }
                else
                {
                    this.lstEstadoEntregado.Items.Add(paquete);
                }
            }
        }

        /// <summary>
        /// Al cliquear el boton Agregar se creara un nuevo paquete
        /// y se mostrara el ciclo de vida del mismo, pasando por los diferentes estados de Ingresado, En Viaje y Entregado
        /// </summary>
        /// <param name="sender">el objeto emisor del evento</param>
        /// <param name="e">el objeto de tipo EvenArgs</param>
        private void btnAgregar_Click(object sender, EventArgs e) 
        {
            try
            {
                Paquete paquete = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text);
                paquete.InformaEstado += new Paquete.DelegadoEstado(paq_InformaEstado);
                this.correo += paquete;
                this.ActualizarEstados();
            }
            catch (TrackingIdRepetidoException exTrackingId)
            {
                MessageBox.Show(exTrackingId.Message);
            }
        }

        /// <summary>
        /// Se mostrara en el richTextBox del FrmPpal la informacion 
        /// de todos los paquetes que contiene el atributo tipo Correo del formulario
        /// </summary>
        /// <param name="sender">el objeto emisor del evento</param>
        /// <param name="e">el objeto de tipo EvenArgs</param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// Mostrara un mensaje de aviso en caso de que se quiera cerrar el formulario
        /// </summary>
        /// <param name="sender">el objeto emisor del evento</param>
        /// <param name="e">el objeto de tipo EvenArgs</param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e) 
        {
            DialogResult respuesta = new DialogResult();

            respuesta = MessageBox.Show("Esta seguro que desea salir?", "Aviso!", MessageBoxButtons.YesNo);

            if (respuesta == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                this.correo.FinEntregas();
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Mostrara la informacion contenida en un objeto de tipo IMostrar<T>
        /// y luego guardara el mismo en un archivo de texto
        /// </summary>
        /// <typeparam name="T">El tipo del objeto que se va a mostrar y guardar</typeparam>
        /// <param name="elemento">El objeto que se va a mostrar y guardar</param>
        private void MostrarInformacion<T>(IMostrar<T> elemento) 
        { 
            if(elemento != null)
            {
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
                this.rtbMostrar.Text.Guardar("salida.txt");
            }
        }

        /// <summary>
        /// Realiza la invocacion del metodo ActualizarEstados() si ya fue agregada para ser invocada, 
        /// de otra manera lo agrega a la lista y realiza la invocacion
        /// </summary>
        /// <param name="sender">el objeto emisor del evento</param>
        /// <param name="e">el objeto de tipo EvenArgs</param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);

                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        /// <summary>
        /// Muestra todos los datos del item tipo Paquete seleccionado en la lista de Entregado
        /// </summary>
        /// <param name="sender">el objeto emisor del evento</param>
        /// <param name="e">el objeto de tipo EvenArgs</param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }
    }
}
