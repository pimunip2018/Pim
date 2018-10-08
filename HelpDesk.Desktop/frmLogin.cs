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
using Helpdesk.Infrastructure.Data;
using System.Data.SqlClient;
using HelpDesk.BLL;

namespace HelpDesk.Desktop
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtCpf.Text == "USUARIO")
            {
                txtCpf.Text = "";
                txtCpf.ForeColor = Color.LightGray;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtCpf.Text == "")
            {
                txtCpf.Text = "USUARIO";
                txtCpf.ForeColor = Color.DimGray;
            }
        }

        private void txtSenha_Enter(object sender, EventArgs e)
        {
            if (txtSenha.Text == "SENHA")
            {
                txtSenha.Text = "";
                txtSenha.ForeColor = Color.LightGray;
            }
        }

        private void txtSenha_Leave(object sender, EventArgs e)
        {
            if (txtSenha.Text == "")
            {
                txtSenha.Text = "SENHA";
                txtSenha.ForeColor = Color.DimGray;
            }
        }

        private void iconeSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblErroSenha.Visible = false;
            lblErroUsuario.Visible = false;
            lblErroLogin.Visible = false;
            DALConexao dal = new DALConexao();
            BLLUSuario user = new BLLUSuario(dal);
            SqlDataReader Logar;
            user.usuario = txtCpf.Text;
            user.senha = txtSenha.Text;
           

            if (txtCpf.Text!="CPF")
            {
                if (txtSenha.Text != "SENHA")
                {
                    Logar = user.IniciaSessao();

                    if (Logar.Read() == true)
                    {
                        this.Hide();
                        frmPrincipal frm = new frmPrincipal();
                        frm.Show();
                    }
                    else
                    {
                        lblErroLogin.Text = "Usuário/Senha inválido!";
                        lblErroLogin.Visible = true;
                        txtSenha.Text = "";
                        txtSenha_Leave(null, e);
                        txtCpf.Focus();
                    }

                }
                else
                {
                    lblErroSenha.Text = "Favor preencher o Usuário";
                    lblErroSenha.Visible = true;
                }

            }
            else
            {
                lblErroUsuario.Text = "Favor preencher a Senha";
                lblErroUsuario.Visible = true;
            }

        }
    }
}
