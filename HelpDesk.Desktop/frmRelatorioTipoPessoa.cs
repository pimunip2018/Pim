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
    public partial class frmRelatorioTipoPessoa : Form
    {
        public frmRelatorioTipoPessoa()
        {
            InitializeComponent();
        }

        private void frmRelatorioTipoPessoa_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'help_deskDataSet.TipoPessoa' table. You can move, or remove it, as needed.
            this.TipoPessoaTableAdapter.Fill(this.help_deskDataSet.TipoPessoa);

            this.reportViewer2.RefreshReport();
        }
    }
}
