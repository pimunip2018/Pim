using Correios.Net;
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
    public partial class frmCadastroPessoa : Form
    {
        public frmCadastroPessoa()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            limpartela();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpartela();
            this.Close();

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

        private void LocalizarCEP()
        {
            if (!string.IsNullOrWhiteSpace(txtCEP.Text))
            {
                Address endereco = SearchZip.GetAddress(txtCEP.Text);
                if (endereco.Zip != null)
                {
                    txtEstado.Text = endereco.State;
                    txtCidade.Text = endereco.City;
                    txtBairro.Text = endereco.District;
                    txtEndereco.Text = endereco.Street;

                }
                else
                {
                    MessageBox.Show("Cep não localizado...");
                }
            }
            else
            {
                MessageBox.Show("Informe um CEP válido");
            }
        }

        private void txtCEP_Leave(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml("http://cep.republicavirtual.com.br/web_cep.php?cep=" + txtCEP.Text.Replace("-", "").Trim() + "&formato=xml");

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtEstado.Text = ds.Tables[0].Rows[0]["uf"].ToString().Trim();
                        txtCidade.Text = ds.Tables[0].Rows[0]["cidade"].ToString().Trim();
                        txtBairro.Text = ds.Tables[0].Rows[0]["bairro"].ToString().Trim();
                        txtEndereco.Text = ds.Tables[0].Rows[0]["tipo_logradouro"].ToString().Trim() + ds.Tables[0].Rows[0]["logradouro"].ToString().Trim();

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void rdbFisica_CheckedChanged(object sender, EventArgs e)
        {
            pessoaFisica();
        }

        private void rdbJuridica_CheckedChanged(object sender, EventArgs e)
        {
            pessoaJuridica();
        }


        public void pessoaFisica()
        {
            if (rdbFisica.Checked == true)
            {
                rdbJuridica.Checked = false;
                lblNome.Text = "Nome";
                lblDataNascimento.Text = "Data de Nascimento";
                cmbSexo.Enabled = true;
                lblCPF.Text = "CPF";
                txtCPF.Mask = "000,000,000-00";
            }
        }

        public void pessoaJuridica()
        {
            if (rdbJuridica.Checked == true)
            {
                rdbFisica.Checked = false;
                lblNome.Text = "Razão Social";
                lblDataNascimento.Text = "Data de Fundação";
                cmbSexo.Enabled = false;
                lblCPF.Text = "CNPJ";
                txtCPF.Mask = "00,000,000/0000-00";
            }
        }

        public void CarregarSexo()
        {
            DALConexao dal = new DALConexao();
            BLLSexo bll = new BLLSexo(dal);
            cmbSexo.DataSource = bll.Localizar();
            cmbSexo.DisplayMember = "Descricao";
            cmbSexo.ValueMember = "SexoId";

        }

        private void frmCadastroPessoa_Load(object sender, EventArgs e)
        {
            frmConsultaPessoa frm = new frmConsultaPessoa();
            if(frm.operacao=="editar")
            {
                desabilitarCampo();
            }
            else
            {
                limpartela();
                habilitarCampo();
            }

            if (cmbSexo.SelectedValue == null)
            {
                CarregarSexo();
            }
            
        }

        public void habilitarCampo()
        {
            txtCPF.Enabled = true;
            txtDtNAsc.Enabled = true;
        }

        public void desabilitarCampo()
        {
            txtCPF.Enabled = false;
            txtDtNAsc.Enabled = false;
        }
    }
}
