using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace HelpDesk.Desktop
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void tipoPessoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroTipoPessoa f = new frmCadastroTipoPessoa("");
            f.ShowDialog();
            f.Dispose();
        }

        private void tipoPessoaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmConsultaTipoPessoa f = new frmConsultaTipoPessoa();
            f.ShowDialog();
            f.Dispose();
        }

        private void toolStripCliente_Click(object sender, EventArgs e)
        {
            frmConsultaTipoPessoa f = new frmConsultaTipoPessoa();
            f.MdiParent = this;
            f.Show();
        }

        private void btnSlide_Click(object sender, EventArgs e)
        {
            if(MenuVertical.Width==290)
            {
                MenuVertical.Width = 100;
            }
            else
            {
                MenuVertical.Width = 290;
            }
        }

        private void iconeSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconeMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            iconeRestaurar.Visible = true;
            iconeMaximizar.Visible = false;
        }

        private void iconeRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            iconeRestaurar.Visible = false;
            iconeMaximizar.Visible = true;
        }

        private void iconeMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
         
        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        private void AbrirFormInPanel(object Formhijo)
        {
            if(this.panelContenedor.Controls.Count > 0)
            {
                this.panelContenedor.Controls.RemoveAt(0);
            }

            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }
        private void btnProduto_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Produtos());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmConsultaPessoa());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmRelatorioTipoPessoa());
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
