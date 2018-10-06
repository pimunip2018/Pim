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

        public void MostrarDados()
        {
            DALConexao dal = new DALConexao();
            BLLTipoPessoa bll = new BLLTipoPessoa(dal);

            dtDados.DataSource = bll.Localizar(txtValor.Text);
        }

        public void LimpaTela()
        {
            txtCodigo.Clear();
            txtDescricao.Clear();
        }
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            this.MostrarDados();
        }

        private void frmConsultaTipoPessoa_Load(object sender, EventArgs e)
        {
            this.MostrarDados();
        }

        private void dtDados_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                TipoPessoa modelo = new TipoPessoa();
                modelo.Nome = txtDescricao.Text;
                DALConexao dal = new DALConexao();
                BLLTipoPessoa bll = new BLLTipoPessoa(dal);

                if (txtCodigo.Text == "")
                {
                    bll.Incluir(modelo);
                    MessageBox.Show("Tipo de Pessoa cadastrado com sucesso!");

                }
                else
                {
                    modelo.TipoPessoaId = Convert.ToInt32(txtCodigo.Text);
                    bll.Alterar(modelo);
                    MessageBox.Show("Tipo de Pessoa atualizado com sucesso!");
                }
                LimpaTela();
                MostrarDados();
            }
            catch (Exception erro)
            {

                MessageBox.Show(erro.Message);
            }

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
                frmCadastroTipoUsuario frm = new frmCadastroTipoUsuario(id, descricao);
                frm.Show();
                txtCodigo.Text = id;
                txtDescricao.Text = descricao;
            }
            else
            {
                MessageBox.Show("Por favor, selecione um registro!");
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimpaTela();
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
                        this.LimpaTela();
                        MostrarDados();
                      
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
                MostrarDados();
            }
        }
    }
}
