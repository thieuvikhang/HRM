namespace HRM
{
    partial class UcSalaryAl
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
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.pivotTableAdapter = new HRM.HRMDataSetTableAdapters.PivotTableAdapter();
            this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.pivotBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hRMDataSet = new HRM.HRMDataSet();
            this.fieldStaffName1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldBasicPay1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldSalaryMonth1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldWorkdays1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldAllowance1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldRealPay1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldSectionName1 = new DevExpress.XtraPivotGrid.PivotGridField();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hRMDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // chartControl1
            // 
            this.chartControl1.DataAdapter = this.pivotTableAdapter;
            this.chartControl1.DataSource = this.pivotGridControl1;
            xyDiagram1.AxisX.Title.Text = "Tên Nhân viên Bộ phận";
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.Label.TextPattern = "{V:c}";
            xyDiagram1.AxisY.Title.Text = "Lương cơ bản Phụ cấp Ngày công Lương thực lãnh";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.chartControl1.Diagram = xyDiagram1;
            this.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl1.Legend.MaxHorizontalPercentage = 30D;
            this.chartControl1.Legend.Name = "Default Legend";
            this.chartControl1.Location = new System.Drawing.Point(0, 268);
            this.chartControl1.Name = "chartControl1";
            this.chartControl1.SeriesDataMember = "Series";
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartControl1.SeriesTemplate.ArgumentDataMember = "Arguments";
            this.chartControl1.SeriesTemplate.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;
            this.chartControl1.SeriesTemplate.ValueDataMembersSerializable = "Values";
            this.chartControl1.Size = new System.Drawing.Size(690, 90);
            this.chartControl1.TabIndex = 3;
            // 
            // pivotTableAdapter
            // 
            this.pivotTableAdapter.ClearBeforeFill = true;
            // 
            // pivotGridControl1
            // 
            this.pivotGridControl1.DataSource = this.pivotBindingSource;
            this.pivotGridControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.fieldStaffName1,
            this.fieldBasicPay1,
            this.fieldSalaryMonth1,
            this.fieldWorkdays1,
            this.fieldAllowance1,
            this.fieldRealPay1,
            this.fieldSectionName1});
            this.pivotGridControl1.Location = new System.Drawing.Point(0, 0);
            this.pivotGridControl1.Name = "pivotGridControl1";
            this.pivotGridControl1.OptionsView.ShowColumnGrandTotalHeader = false;
            this.pivotGridControl1.OptionsView.ShowFilterHeaders = false;
            this.pivotGridControl1.Size = new System.Drawing.Size(690, 268);
            this.pivotGridControl1.TabIndex = 2;
            this.pivotGridControl1.FieldValueDisplayText += new DevExpress.XtraPivotGrid.PivotFieldDisplayTextEventHandler(this.pivotGridControl1_FieldValueDisplayText);
            // 
            // pivotBindingSource
            // 
            this.pivotBindingSource.DataMember = "Pivot";
            this.pivotBindingSource.DataSource = this.hRMDataSet;
            // 
            // hRMDataSet
            // 
            this.hRMDataSet.DataSetName = "HRMDataSet";
            this.hRMDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fieldStaffName1
            // 
            this.fieldStaffName1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldStaffName1.AreaIndex = 0;
            this.fieldStaffName1.Caption = "Tên Nhân viên";
            this.fieldStaffName1.FieldName = "StaffName";
            this.fieldStaffName1.Name = "fieldStaffName1";
            this.fieldStaffName1.Options.ShowInCustomizationForm = false;
            this.fieldStaffName1.Width = 253;
            // 
            // fieldBasicPay1
            // 
            this.fieldBasicPay1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldBasicPay1.AreaIndex = 0;
            this.fieldBasicPay1.Caption = "Lương cơ bản";
            this.fieldBasicPay1.FieldName = "BasicPay";
            this.fieldBasicPay1.Name = "fieldBasicPay1";
            // 
            // fieldSalaryMonth1
            // 
            this.fieldSalaryMonth1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldSalaryMonth1.AreaIndex = 0;
            this.fieldSalaryMonth1.Caption = "Tháng";
            this.fieldSalaryMonth1.FieldName = "SalaryMonth";
            this.fieldSalaryMonth1.Name = "fieldSalaryMonth1";
            this.fieldSalaryMonth1.ValueFormat.FormatString = "Y";
            this.fieldSalaryMonth1.ValueFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            // 
            // fieldWorkdays1
            // 
            this.fieldWorkdays1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldWorkdays1.AreaIndex = 2;
            this.fieldWorkdays1.Caption = "Ngày công";
            this.fieldWorkdays1.FieldName = "Workdays";
            this.fieldWorkdays1.Name = "fieldWorkdays1";
            // 
            // fieldAllowance1
            // 
            this.fieldAllowance1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldAllowance1.AreaIndex = 1;
            this.fieldAllowance1.Caption = "Phụ cấp";
            this.fieldAllowance1.FieldName = "Allowance";
            this.fieldAllowance1.Name = "fieldAllowance1";
            // 
            // fieldRealPay1
            // 
            this.fieldRealPay1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldRealPay1.AreaIndex = 3;
            this.fieldRealPay1.Caption = "Lương thực lãnh";
            this.fieldRealPay1.FieldName = "RealPay";
            this.fieldRealPay1.Name = "fieldRealPay1";
            // 
            // fieldSectionName1
            // 
            this.fieldSectionName1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldSectionName1.AreaIndex = 1;
            this.fieldSectionName1.Caption = "Bộ phận";
            this.fieldSectionName1.FieldName = "SectionName";
            this.fieldSectionName1.Name = "fieldSectionName1";
            // 
            // UcSalaryAl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chartControl1);
            this.Controls.Add(this.pivotGridControl1);
            this.Name = "UcSalaryAl";
            this.Size = new System.Drawing.Size(690, 358);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hRMDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraCharts.ChartControl chartControl1;
        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldStaffName1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldBasicPay1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldSalaryMonth1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldWorkdays1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldAllowance1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldRealPay1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldSectionName1;
        private HRMDataSetTableAdapters.PivotTableAdapter pivotTableAdapter;
        private System.Windows.Forms.BindingSource pivotBindingSource;
        private HRMDataSet hRMDataSet;
    }
}
