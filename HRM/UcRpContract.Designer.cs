namespace HRM
{
    partial class UcRpContract
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.HRMDataSet = new HRM.HRMDataSet();
            this.ContractRpBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ContractRpTableAdapter = new HRM.HRMDataSetTableAdapters.ContractRpTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.HRMDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContractRpBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.ContractRpBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "HRM.RpContract.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(736, 354);
            this.reportViewer1.TabIndex = 0;           
            // 
            // HRMDataSet
            // 
            this.HRMDataSet.DataSetName = "HRMDataSet";
            this.HRMDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ContractRpBindingSource
            // 
            this.ContractRpBindingSource.DataMember = "ContractRp";
            this.ContractRpBindingSource.DataSource = this.HRMDataSet;
            // 
            // ContractRpTableAdapter
            // 
            this.ContractRpTableAdapter.ClearBeforeFill = true;
            // 
            // UcRpContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.reportViewer1);
            this.Name = "UcRpContract";
            this.Size = new System.Drawing.Size(736, 354);
            this.Load += new System.EventHandler(this.UcRpContract_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HRMDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContractRpBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ContractRpBindingSource;
        private HRMDataSet HRMDataSet;
        private HRMDataSetTableAdapters.ContractRpTableAdapter ContractRpTableAdapter;
    }
}
