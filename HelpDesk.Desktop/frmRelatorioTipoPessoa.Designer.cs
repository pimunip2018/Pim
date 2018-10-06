namespace HelpDesk.Desktop
{
    partial class frmRelatorioTipoPessoa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.help_deskDataSet = new HelpDesk.Desktop.help_deskDataSet();
            this.TipoPessoaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TipoPessoaTableAdapter = new HelpDesk.Desktop.help_deskDataSetTableAdapters.TipoPessoaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.help_deskDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TipoPessoaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "ReportViewer";
            this.reportViewer1.Size = new System.Drawing.Size(396, 246);
            this.reportViewer1.TabIndex = 0;
            // 
            // reportViewer2
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.TipoPessoaBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "HelpDesk.Desktop.rptTipoUsuario.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(14, 25);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(982, 550);
            this.reportViewer2.TabIndex = 0;
            // 
            // help_deskDataSet
            // 
            this.help_deskDataSet.DataSetName = "help_deskDataSet";
            this.help_deskDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // TipoPessoaBindingSource
            // 
            this.TipoPessoaBindingSource.DataMember = "TipoPessoa";
            this.TipoPessoaBindingSource.DataSource = this.help_deskDataSet;
            // 
            // TipoPessoaTableAdapter
            // 
            this.TipoPessoaTableAdapter.ClearBeforeFill = true;
            // 
            // frmRelatorioTipoPessoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.reportViewer2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRelatorioTipoPessoa";
            this.Text = "frmRelatorioTipoPessoa";
            this.Load += new System.EventHandler(this.frmRelatorioTipoPessoa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.help_deskDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TipoPessoaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.BindingSource TipoPessoaBindingSource;
        private help_deskDataSet help_deskDataSet;
        private help_deskDataSetTableAdapters.TipoPessoaTableAdapter TipoPessoaTableAdapter;
    }
}