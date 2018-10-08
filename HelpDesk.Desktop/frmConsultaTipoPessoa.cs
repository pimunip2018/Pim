using Helpdesk.Infrastructure.Data;
using HelpDesk.BLL;
using HelpDesk.Domain.Modelo;
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
    public partial class frmConsultaTipoPessoa : Form
    {

        public frmConsultaTipoPessoa()
        {
            InitializeComponent();
        }

        public void MostrarDados( string valor)
        {
            DALConexao dal = new DALConexao();
            BLLTipoPessoa bll = new BLLTipoPessoa(dal);
            dtDados.DataSource = null;
            dtDados.DataSource = bll.Localizar(valor);
           
            dtDados.Refresh();
            dtDados.Update();
        }
        
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            this.MostrarDados(txtValor.Text);
        }

        private void frmConsultaTipoPessoa_Load(object sender, EventArgs e)
        {
            this.MostrarDados(txtValor.Text);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dtDados.SelectedRows.Count > 0)
            {
                string id = dtDados.CurrentRow.Cells["TipoUsuarioId"].Value.ToString();
                string descricao= dtDados.CurrentRow.Cells["Nome"].Value.ToString();
                frmCadastroTipoUsuario frm = new frmCadastroTipoUsuario();
                frm.txtCodigo.Text = id;
                frm.txtDescricao.Text = descricao;
                frm.ShowDialog();
                this.MostrarDados(txtValor.Text);
            }
            else
            {
                MessageBox.Show("Por favor, selecione um registro!");
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmCadastroTipoUsuario frm = new frmCadastroTipoUsuario();
            frm.ShowDialog();
            this.MostrarDados(txtValor.Text);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtDados.SelectedRows.Count > 0)
                {


                    DialogResult d = MessageBox.Show("Deseja excluir o registro?", "Aviso", MessageBoxButtons.YesNo);
                    if (d.ToString() == "Yes")
                    {
                        DALConexao dal = new DALConexao();
                        BLLTipoPessoa bll = new BLLTipoPessoa(dal);

                        bll.Excluir(Convert.ToInt32(dtDados.CurrentRow.Cells["TipoUsuarioId"].Value.ToString()));
                        MostrarDados(txtValor.Text);
                      
                    }
                }

                else
                {
                    MessageBox.Show("Por favor, selecione um registro!");
                }
            }
            catch
            {

                MessageBox.Show("Impossível excluir o registro. \n O registro está sendo utilizado em outra operação");
                MostrarDados(txtValor.Text);
            }
        }

        private void dtDados_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dtDados.Columns["TipoUsuarioId"].Width = 100;
            dtDados.Columns["TipoUsuarioId"].HeaderText = "Codigo";
            dtDados.Columns["Nome"].Width = 477;
        }
    }
}
