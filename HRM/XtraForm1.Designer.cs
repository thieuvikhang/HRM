﻿namespace HRM
{
    partial class XtraForm1
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
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.hrmDataSet1 = new HRM.HRMDataSet();
            this.fieldStaffName1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldBasicPay1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldSalaryMonth1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldWorkdays1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldAllowance1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldRealPay1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldSectionName1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotTableAdapter1 = new HRM.HRMDataSetTableAdapters.PivotTableAdapter();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hrmDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            this.SuspendLayout();
            // 
            // pivotGridControl1
            // 
            this.pivotGridControl1.DataMember = "Pivot";
            this.pivotGridControl1.DataSource = this.hrmDataSet1;
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
            this.pivotGridControl1.Size = new System.Drawing.Size(986, 268);
            this.pivotGridControl1.TabIndex = 0;
            this.pivotGridControl1.FieldValueDisplayText += new DevExpress.XtraPivotGrid.PivotFieldDisplayTextEventHandler(this.pivotGridControl1_FieldValueDisplayText_1);
            // 
            // hrmDataSet1
            // 
            this.hrmDataSet1.DataSetName = "HRMDataSet";
            this.hrmDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fieldStaffName1
            // 
            this.fieldStaffName1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldStaffName1.AreaIndex = 0;
            this.fieldStaffName1.Caption = "Tên NV";
            this.fieldStaffName1.FieldName = "StaffName";
            this.fieldStaffName1.Name = "fieldStaffName1";
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
            // pivotTableAdapter1
            // 
            this.pivotTableAdapter1.ClearBeforeFill = true;
            // 
            // chartControl1
            // 
            this.chartControl1.DataSource = this.pivotGridControl1;
            xyDiagram1.AxisX.Title.Text = "Tên NV Bộ phận";
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
            this.chartControl1.Size = new System.Drawing.Size(986, 73);
            this.chartControl1.TabIndex = 1;
            // 
            // XtraForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 341);
            this.Controls.Add(this.chartControl1);
            this.Controls.Add(this.pivotGridControl1);
            this.Name = "XtraForm1";
            this.Text = "XtraForm1";
            this.Load += new System.EventHandler(this.XtraForm1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hrmDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl1;
        private HRMDataSet hrmDataSet1;
        private HRMDataSetTableAdapters.PivotTableAdapter pivotTableAdapter1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldStaffName1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldBasicPay1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldSalaryMonth1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldWorkdays1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldAllowance1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldRealPay1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldSectionName1;
        private DevExpress.XtraCharts.ChartControl chartControl1;
    }
}