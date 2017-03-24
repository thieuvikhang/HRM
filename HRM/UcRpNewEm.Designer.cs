namespace HRM
{
    partial class UcRpNewEm
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.NewEmployeesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.HRMDataSet = new HRM.HRMDataSet();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnSummit = new DevExpress.XtraEditors.SimpleButton();
            this.dateTo = new DevExpress.XtraEditors.DateEdit();
            this.dateFrom = new DevExpress.XtraEditors.DateEdit();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.NewEmployeesTableAdapter = new HRM.HRMDataSetTableAdapters.NewEmployeesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.NewEmployeesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HRMDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // NewEmployeesBindingSource
            // 
            this.NewEmployeesBindingSource.DataMember = "NewEmployees";
            this.NewEmployeesBindingSource.DataSource = this.HRMDataSet;
            // 
            // HRMDataSet
            // 
            this.HRMDataSet.DataSetName = "HRMDataSet";
            this.HRMDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnSummit);
            this.panelControl1.Controls.Add(this.dateTo);
            this.panelControl1.Controls.Add(this.dateFrom);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(725, 86);
            this.panelControl1.TabIndex = 0;
            // 
            // btnSummit
            // 
            this.btnSummit.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSummit.Appearance.Options.UseFont = true;
            this.btnSummit.Location = new System.Drawing.Point(476, 29);
            this.btnSummit.Name = "btnSummit";
            this.btnSummit.Size = new System.Drawing.Size(97, 27);
            this.btnSummit.TabIndex = 2;
            this.btnSummit.Text = "Thống kê";
            this.btnSummit.Click += new System.EventHandler(this.btnSummit_Click);
            // 
            // dateTo
            // 
            this.dateTo.EditValue = null;
            this.dateTo.Location = new System.Drawing.Point(318, 34);
            this.dateTo.Name = "dateTo";
            this.dateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTo.Size = new System.Drawing.Size(143, 20);
            this.dateTo.TabIndex = 1;
            this.dateTo.BeforePopup += new System.EventHandler(this.dateTo_BeforePopup);
            this.dateTo.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.dateTo_ButtonClick);
            this.dateTo.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.dateTo_EditValueChanging);
            this.dateTo.CausesValidationChanged += new System.EventHandler(this.dateTo_CausesValidationChanged);
            this.dateTo.TextChanged += new System.EventHandler(this.dateTo_TextChanged);
            this.dateTo.Click += new System.EventHandler(this.dateTo_Click);
            // 
            // dateFrom
            // 
            this.dateFrom.EditValue = null;
            this.dateFrom.Location = new System.Drawing.Point(159, 34);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFrom.Size = new System.Drawing.Size(143, 20);
            this.dateFrom.TabIndex = 0;
            this.dateFrom.BeforePopup += new System.EventHandler(this.dateFrom_BeforePopup);
            this.dateFrom.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.dateFrom_ButtonClick);
            this.dateFrom.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.dateFrom_EditValueChanging);
            this.dateFrom.CausesValidationChanged += new System.EventHandler(this.dateFrom_CausesValidationChanged);
            this.dateFrom.TabIndexChanged += new System.EventHandler(this.dateFrom_TabIndexChanged);
            this.dateFrom.TextChanged += new System.EventHandler(this.dateFrom_TextChanged);
            this.dateFrom.Click += new System.EventHandler(this.dateFrom_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "DataSet1";
            reportDataSource3.Value = this.NewEmployeesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "HRM.ReportNewEm.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 86);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(725, 263);
            this.reportViewer1.TabIndex = 1;
            // 
            // NewEmployeesTableAdapter
            // 
            this.NewEmployeesTableAdapter.ClearBeforeFill = true;
            // 
            // UcRpNewEm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panelControl1);
            this.Name = "UcRpNewEm";
            this.Size = new System.Drawing.Size(725, 349);
            this.Load += new System.EventHandler(this.UcRpNewEm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NewEmployeesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HRMDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnSummit;
        private DevExpress.XtraEditors.DateEdit dateTo;
        private DevExpress.XtraEditors.DateEdit dateFrom;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource NewEmployeesBindingSource;
        private HRMDataSet HRMDataSet;
        private HRMDataSetTableAdapters.NewEmployeesTableAdapter NewEmployeesTableAdapter;
    }
}
