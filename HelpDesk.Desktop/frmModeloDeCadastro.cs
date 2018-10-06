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
    public partial class frmModeloDeCadastro : Form
    {
        public string operacao;
        public frmModeloDeCadastro()
        {
            InitializeComponent();
        }

        public void AlteraBotoes(int op)
        {
            //op= operações que serão feitas com os botões
            //1 = Preparar os botões para inserir e localizar
            //2 = Preparar os botões para inserir/ alterar um registro
            //3 = Preparar a tela para excluir ou alterar

            pnDados.Enabled = false;
            btnInserir.Enabled = false;
            btnAlterar.Enabled = false;
            btnLocalizar.Enabled = false;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = false;

            if (op == 1)
            {
                btnInserir.Enabled = true;
                btnLocalizar.Enabled = true;
            }

            if (op == 2)
            {
                pnDados.Enabled = true;
                btnSalvar.Enabled = true;
            }

            if (op == 3)
            {
                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;
            }
        }

        private void frmModeloDeCadastro_Load(object sender, EventArgs e)
        {
            AlteraBotoes(1);
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {

        }
    }
}
