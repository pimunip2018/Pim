using Helpdesk.Infrastructure.Data;
using HelpDesk.BLL;
using HelpDesk.Domain.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace HelpDesk.Desktop
{
    public partial class frmCadastroTipoPessoa : HelpDesk.Desktop.frmModeloDeCadastro
    {
        private TextBox textBox1;

        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pnDados.SuspendLayout();
            this.pnBotoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnDados
            // 
            this.pnDados.Controls.Add(this.textBox1);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(65, 70);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // frmCadastroTipoPessoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Name = "frmCadastroTipoPessoa";
            this.pnDados.ResumeLayout(false);
            this.pnDados.PerformLayout();
            this.pnBotoes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        public frmCadastroTipoPessoa(string valor)
        {
            InitializeComponent();
                textBox1.Text = valor.ToString();
            
        }
        private void btnAlterar_Click(object sender, EventArgs e)
        {
        }
        //public frmCadastroTipoPessoa()
        //{
        //    InitializeComponent();
        //}

        //public void LimpaTela()
        //{
        //    txtCodigo.Clear();
        //    txtNome.Clear();
        //}
        //private void frmCadastroTipoPessoa_Load(object sender, EventArgs e)
        //{
        //    this.AlteraBotoes(1);
        //}

        //private void btnInserir_Click(object sender, EventArgs e)
        //{
        //    this.operacao = "inserir";
        //    this.AlteraBotoes(2);
        //}

        //private void btnCancelar_Click(object sender, EventArgs e)
        //{
        //    this.LimpaTela();
        //    this.AlteraBotoes(1);
        //}



        //private void btnSalvar_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        TipoPessoa modelo = new TipoPessoa();
        //        modelo.Nome = txtNome.Text;
        //        DALConexao dal = new DALConexao(DadosDaConexao.stringDeConexao);
        //        BLLTipoPessoa bll = new BLLTipoPessoa(dal);

        //        if (this.operacao == "inserir")
        //        {
        //            bll.Incluir(modelo);
        //            MessageBox.Show("Tipo de Pessoa cadastrado com sucesso!");
        //        }
        //        else
        //        {
        //            modelo.TipoPessoaId = Convert.ToInt32(txtCodigo.Text);
        //            bll.Alterar(modelo);
        //            MessageBox.Show("Tipo de Pessoa atualizado com sucesso!");
        //        }
        //        this.LimpaTela();
        //        this.AlteraBotoes(1);
        //    }
        //    catch (Exception erro)
        //    {

        //        MessageBox.Show(erro.Message);
        //    }

        //}

        //private void btnExcluir_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        DialogResult d = MessageBox.Show("Deseja excluir o registro?", "Aviso", MessageBoxButtons.YesNo);
        //        if (d.ToString() == "Yes")
        //        {
        //            DALConexao dal = new DALConexao(DadosDaConexao.stringDeConexao);
        //            BLLTipoPessoa bll = new BLLTipoPessoa(dal);

        //            bll.Excluir(Convert.ToInt32(txtCodigo.Text));
        //            this.LimpaTela();
        //            this.AlteraBotoes(1);
        //        }
        //    }
        //    catch 
        //    {

        //        MessageBox.Show("Impossível excluir o registro. \n O registro está sendo utilizado em outra operação");
        //        this.AlteraBotoes(3);
        //    }
        //}
    }
}
