using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryGestionClientes
{
    
    public partial class frmGestionLab : Form
    {
        clsArchivoClientes archivo = new clsArchivoClientes();
        public frmGestionLab()
        {
            InitializeComponent();
            archivo.CargarDatosIniciales();
        }

        private void agregarNuevosClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formulario = new frmCargarCliente();
            formulario.ShowDialog();
        }

        private void listadoDeTodosLosClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formulario = new frmListadoClientes();
            formulario.ShowDialog();
        }

        private void listadoDeClientesDeudoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formulario = new frmListaClientes();
            formulario.ShowDialog();
        }

        private void frmGestionLab_Load(object sender, EventArgs e)
        {

        }
    }
}
