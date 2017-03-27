namespace HRM
{
    partial class XtraForm2
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.HRMDataSet = new HRM.HRMDataSet();
            this.NewEmployeesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.NewEmployeesTableAdapter = new HRM.HRMDataSetTableAdapters.NewEmployeesTableAdapter();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.HRMDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewEmployeesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.NewEmployeesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "HRM.RpBirthDay.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 40);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(582, 246);
            this.reportViewer1.TabIndex = 0;
            // 
            // HRMDataSet
            // 
            this.HRMDataSet.DataSetName = "HRMDataSet";
            this.HRMDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // NewEmployeesBindingSource
            // 
            this.NewEmployeesBindingSource.DataMember = "NewEmployees";
            this.NewEmployeesBindingSource.DataSource = this.HRMDataSet;
            // 
            // NewEmployeesTableAdapter
            // 
            this.NewEmployeesTableAdapter.ClearBeforeFill = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Tháng 1",
            "Tháng 10",
            "Tháng 7"});
            this.comboBox1.Location = new System.Drawing.Point(184, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // XtraForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 280);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "XtraForm2";
            this.Text = "XtraForm2";
            this.Load += new System.EventHandler(this.XtraForm2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HRMDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewEmployeesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource NewEmployeesBindingSource;
        private HRMDataSet HRMDataSet;
        private HRMDataSetTableAdapters.NewEmployeesTableAdapter NewEmployeesTableAdapter;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}