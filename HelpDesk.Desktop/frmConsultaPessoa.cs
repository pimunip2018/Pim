using Helpdesk.Infrastructure.Data;
using HelpDesk.BLL;
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
    public partial class frmConsultaPessoa : Form
    {
        public frmConsultaPessoa()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void MostrarDados(string valor)
        {

            DALConexao dal = new DALConexao();
            BLLPessoaPF bll = new BLLPessoaPF(dal);
            dtDados.DataSource = null;
            dtDados.DataSource = bll.Localizar(valor);
            EsconderColuna();
           
        }


        public void EsconderColuna()
        {
            dtDados.Columns["PessoaPFId"].Visible = false;
            dtDados.Columns["Sexo"].Visible = false;
            dtDados.Columns["TelefoneCelular"].Visible = false;
        }
        private void frmCadastroUsuario_Load(object sender, EventArgs e)
        {
            MostrarDados(txtValor.Text);
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            this.MostrarDados(txtValor.Text);
        }

        private void dtDados_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            dtDados.Columns["Nome"].Width = 250;
            dtDados.Columns["CPF"].Width = 100;
            dtDados.Columns["DtNasc"].Width = 100;
            dtDados.Columns["DtNasc"].HeaderText = "Dt.Nascimento";
            dtDados.Columns["Telefone"].Width = 100;
            dtDados.Columns["Email"].Width = 160;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dtDados.SelectedRows.Count > 0)
            {
                frmCadastroPessoa frm = new frmCadastroPessoa();
                frm.txtCodigo.Text = dtDados.CurrentRow.Cells["PessoaPFId"].Value.ToString(); ;
                frm.txtNome.Text = dtDados.CurrentRow.Cells["Nome"].Value.ToString();
                frm.txtCPF.Text = dtDados.CurrentRow.Cells["CPF"].Value.ToString();
                frm.cmbSexo.Text = dtDados.CurrentRow.Cells["Sexo"].Value.ToString();
                frm.txtDtNAsc.Text = dtDados.CurrentRow.Cells["DtNasc"].Value.ToString();
                frm.txtTelefone.Text = dtDados.CurrentRow.Cells["Telefone"].Value.ToString();
                frm.txtCelular.Text = dtDados.CurrentRow.Cells["TelefoneCelular"].Value.ToString();
                frm.txtEmail.Text = dtDados.CurrentRow.Cells["Email"].Value.ToString();
                frm.ShowDialog();
                this.MostrarDados(txtValor.Text);
                
            }
            else
            {
                MessageBox.Show("Por favor, selecione um registro!");
            }
        }
    }
}
