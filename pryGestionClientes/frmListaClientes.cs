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
    public partial class frmListaClientes : Form
    {
        public frmListaClientes()
        {
            InitializeComponent();
        }
        clsArchivoClientes archivo = new clsArchivoClientes();

        private void btnListar_Click(object sender, EventArgs e)
        {
            archivo.ListarDeudores(dgvDatos);
            lblTotalDos.Text = archivo.DeudaClientes().ToString();
            lblCantidadDos.Text = archivo.CantidadDeudores().ToString();
            lblPromedioDos.Text = archivo.PromedioDeudores().ToString();
        }
    }
}
