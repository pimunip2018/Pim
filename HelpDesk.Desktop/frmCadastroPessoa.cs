using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelpDesk.Desktop
{
    public partial class frmCadastroPessoa : Form
    {
        public frmCadastroPessoa()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
           
            limpartela();
        
        }

        private void limpartela()
        {
            txtCodigo.Clear();
            txtNome.Clear();
            txtCPF.Clear();
            txtDtNAsc.Clear();
            txtTelefone.Clear();
            txtCelular.Clear();
            txtEmail.Clear();
        }
    }
}
