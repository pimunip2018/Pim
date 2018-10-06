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
    public partial class frmCadastroTipoUsuario : Form
    {
        public frmCadastroTipoUsuario()
        {
            InitializeComponent();
        }

        public frmCadastroTipoUsuario(string codigo, string descricao)
        {
            InitializeComponent();
            txtCodigo.Text = codigo.ToString();
            txtDescricao.Text = descricao.ToString();

        }
        
        public void LimpaTela()
        {
            txtCodigo.Clear();
            txtDescricao.Clear();
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
                
            }
            catch (Exception erro)
            {

                MessageBox.Show(erro.Message);
            }
        }
    }
}
