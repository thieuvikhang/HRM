﻿namespace HRM
{
    partial class ucSection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSection));
            this.numStandardWorkdays = new System.Windows.Forms.NumericUpDown();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.mmDescription = new DevExpress.XtraEditors.MemoEdit();
            this.txtPhone = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtSectionID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.gcSection = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gCoSectionID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCoSectionName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCoDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCoStandardWorkdays = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCoPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.numStandardWorkdays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSectionID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // numStandardWorkdays
            // 
            this.numStandardWorkdays.Location = new System.Drawing.Point(139, 106);
            this.numStandardWorkdays.Name = "numStandardWorkdays";
            this.numStandardWorkdays.Size = new System.Drawing.Size(171, 21);
            this.numStandardWorkdays.TabIndex = 48;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl5.Location = new System.Drawing.Point(22, 106);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(111, 16);
            this.labelControl5.TabIndex = 46;
            this.labelControl5.Text = "Ngày công quy định";
            // 
            // mmDescription
            // 
            this.mmDescription.Location = new System.Drawing.Point(400, 27);
            this.mmDescription.Name = "mmDescription";
            this.mmDescription.Size = new System.Drawing.Size(207, 63);
            this.mmDescription.TabIndex = 44;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(139, 79);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(171, 20);
            this.txtPhone.TabIndex = 8;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl4.Location = new System.Drawing.Point(58, 80);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(75, 16);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "Số điện thoại";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl3.Location = new System.Drawing.Point(362, 28);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(32, 16);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Mô tả";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(139, 53);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(171, 20);
            this.txtName.TabIndex = 4;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl2.Location = new System.Drawing.Point(47, 54);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(86, 16);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Tên phòng ban";
            // 
            // txtSectionID
            // 
            this.txtSectionID.Location = new System.Drawing.Point(139, 27);
            this.txtSectionID.Name = "txtSectionID";
            this.txtSectionID.Size = new System.Drawing.Size(171, 20);
            this.txtSectionID.TabIndex = 1;
            this.txtSectionID.EditValueChanged += new System.EventHandler(this.textEdit1_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl1.Location = new System.Drawing.Point(52, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(81, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Mã phòng ban";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.groupControl2);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.numStandardWorkdays);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.txtName);
            this.panelControl1.Controls.Add(this.mmDescription);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.txtPhone);
            this.panelControl1.Controls.Add(this.txtSectionID);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(647, 250);
            this.panelControl1.TabIndex = 49;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnEdit);
            this.groupControl2.Controls.Add(this.btnDelete);
            this.groupControl2.Controls.Add(this.btnAdd);
            this.groupControl2.Location = new System.Drawing.Point(330, 96);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(277, 63);
            this.groupControl2.TabIndex = 49;
            // 
            // btnEdit
            // 
            this.btnEdit.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnEdit.Appearance.Options.UseFont = true;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(96, 23);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(85, 34);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Sửa";
            // 
            // btnDelete
            // 
            this.btnDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(187, 23);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 34);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(5, 23);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 34);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_1);
            // 
            // gcSection
            // 
            this.gcSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSection.Location = new System.Drawing.Point(0, 250);
            this.gcSection.MainView = this.gridView1;
            this.gcSection.Name = "gcSection";
            this.gcSection.Size = new System.Drawing.Size(647, 118);
            this.gcSection.TabIndex = 50;
            this.gcSection.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gcSection.Click += new System.EventHandler(this.gcSection_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gCoSectionID,
            this.gCoSectionName,
            this.gCoDescription,
            this.gCoStandardWorkdays,
            this.gCoPhone});
            this.gridView1.GridControl = this.gcSection;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            // 
            // gCoSectionID
            // 
            this.gCoSectionID.Caption = "Mã phòng ban";
            this.gCoSectionID.FieldName = "SectionID";
            this.gCoSectionID.Name = "gCoSectionID";
            this.gCoSectionID.Visible = true;
            this.gCoSectionID.VisibleIndex = 0;
            // 
            // gCoSectionName
            // 
            this.gCoSectionName.Caption = "Tên phòng ban";
            this.gCoSectionName.FieldName = "Name";
            this.gCoSectionName.Name = "gCoSectionName";
            this.gCoSectionName.Visible = true;
            this.gCoSectionName.VisibleIndex = 1;
            // 
            // gCoDescription
            // 
            this.gCoDescription.Caption = "Mô tả";
            this.gCoDescription.FieldName = "Description";
            this.gCoDescription.Name = "gCoDescription";
            this.gCoDescription.Visible = true;
            this.gCoDescription.VisibleIndex = 2;
            // 
            // gCoStandardWorkdays
            // 
            this.gCoStandardWorkdays.Caption = "Ngày công quy định";
            this.gCoStandardWorkdays.FieldName = "StandardWorkdays";
            this.gCoStandardWorkdays.Name = "gCoStandardWorkdays";
            this.gCoStandardWorkdays.Visible = true;
            this.gCoStandardWorkdays.VisibleIndex = 3;
            // 
            // gCoPhone
            // 
            this.gCoPhone.Caption = "Số điện thoại";
            this.gCoPhone.FieldName = "Phone";
            this.gCoPhone.Name = "gCoPhone";
            this.gCoPhone.Visible = true;
            this.gCoPhone.VisibleIndex = 4;
            // 
            // ucSection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcSection);
            this.Controls.Add(this.panelControl1);
            this.Name = "ucSection";
            this.Size = new System.Drawing.Size(647, 368);
            this.Load += new System.EventHandler(this.ucSection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numStandardWorkdays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSectionID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcSection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.TextEdit txtPhone;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtSectionID;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit mmDescription;
        private System.Windows.Forms.NumericUpDown numStandardWorkdays;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gcSection;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraGrid.Columns.GridColumn gCoSectionID;
        private DevExpress.XtraGrid.Columns.GridColumn gCoSectionName;
        private DevExpress.XtraGrid.Columns.GridColumn gCoDescription;
        private DevExpress.XtraGrid.Columns.GridColumn gCoStandardWorkdays;
        private DevExpress.XtraGrid.Columns.GridColumn gCoPhone;
    }
}
