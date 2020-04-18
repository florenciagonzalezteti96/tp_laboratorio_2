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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {

        }
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult respuesta = new DialogResult();

            respuesta = MessageBox.Show("Esta seguro que desea salir?","Aviso!", MessageBoxButtons.YesNo);

            if(respuesta == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Limpiar()
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.cmbOperador.ResetText();
            this.lblResultado.Text = String.Empty;
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);

            return Calculadora.Operar(num1, num2, operador);
        }
        private void btnOperar_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = FormCalculadora.Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text).ToString();
        }
        private void btnDecimalABinario_Click(object sender, EventArgs e)
        {
            if(!(String.IsNullOrWhiteSpace(this.lblResultado.Text)))
            {
                string resultadoExiste = this.lblResultado.Text;
                this.lblResultado.Text = Numero.DecimalBinario(resultadoExiste);
            }
        }
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (!(String.IsNullOrWhiteSpace(this.lblResultado.Text)))
            {
                string resultadoExiste = this.lblResultado.Text;
                this.lblResultado.Text = Numero.BinarioDecimal(resultadoExiste);
            }
        }
    }
}
