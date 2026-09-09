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
    public partial class frmCargarCliente : Form
    {
        public frmCargarCliente()
        {
            InitializeComponent();
        }

        clsArchivoClientes archivo = new clsArchivoClientes();

        private void btnCargar_Click(object sender, EventArgs e)
        {
            archivo.Grabar(txtCodigo.Text, txtNombre.Text, txtLimite.Text, txtDeuda.Text);
            
            txtCodigo.Clear();
            txtNombre.Clear();
            txtLimite.Clear();
            txtDeuda.Clear();

        }

        private void frmCargarCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
