namespace HRM
{
    partial class UcAccess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcAccess));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gridAccessView = new DevExpress.XtraGrid.GridControl();
            this.gridViewView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.AccessIDView = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FormView = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DescriptionAccessView = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.lbThongBao = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtMoTa = new DevExpress.XtraEditors.MemoEdit();
            this.txtTenNhom = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridAccessEdit = new DevExpress.XtraGrid.GridControl();
            this.gridViewEdit = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.AccessID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Form = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DescriptionAccess = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GroupAccessID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GroupAccessName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Description = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EEdit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.Delete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.Count = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CountEdit = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAccessView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoTa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenNhom.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAccessEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.groupBox3);
            this.panelControl1.Controls.Add(this.lbThongBao);
            this.panelControl1.Controls.Add(this.groupBox2);
            this.panelControl1.Controls.Add(this.txtMoTa);
            this.panelControl1.Controls.Add(this.txtTenNhom);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.groupBox1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1222, 361);
            this.panelControl1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.gridAccessView);
            this.groupBox3.Location = new System.Drawing.Point(367, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(340, 351);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "CÁC QUYỀN XEM";
            // 
            // gridAccessView
            // 
            this.gridAccessView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAccessView.Location = new System.Drawing.Point(3, 17);
            this.gridAccessView.MainView = this.gridViewView;
            this.gridAccessView.Name = "gridAccessView";
            this.gridAccessView.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridAccessView.Size = new System.Drawing.Size(334, 331);
            this.gridAccessView.TabIndex = 3;
            this.gridAccessView.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewView});
            // 
            // gridViewView
            // 
            this.gridViewView.ActiveFilterEnabled = false;
            this.gridViewView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.AccessIDView,
            this.FormView,
            this.DescriptionAccessView});
            this.gridViewView.GridControl = this.gridAccessView;
            this.gridViewView.Name = "gridViewView";
            this.gridViewView.OptionsBehavior.Editable = false;
            this.gridViewView.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridViewView.OptionsSelection.MultiSelect = true;
            this.gridViewView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridViewView.OptionsView.ShowGroupPanel = false;
            this.gridViewView.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridViewView_SelectionChanged);
            // 
            // AccessIDView
            // 
            this.AccessIDView.Caption = "ID";
            this.AccessIDView.FieldName = "AccessID";
            this.AccessIDView.MinWidth = 10;
            this.AccessIDView.Name = "AccessIDView";
            this.AccessIDView.OptionsColumn.AllowEdit = false;
            this.AccessIDView.Visible = true;
            this.AccessIDView.VisibleIndex = 1;
            this.AccessIDView.Width = 96;
            // 
            // FormView
            // 
            this.FormView.Caption = "Tên Form";
            this.FormView.FieldName = "Form";
            this.FormView.Name = "FormView";
            this.FormView.OptionsColumn.AllowEdit = false;
            this.FormView.Visible = true;
            this.FormView.VisibleIndex = 2;
            this.FormView.Width = 278;
            // 
            // DescriptionAccessView
            // 
            this.DescriptionAccessView.Caption = "Mô tả";
            this.DescriptionAccessView.FieldName = "DescriptionAccess";
            this.DescriptionAccessView.Name = "DescriptionAccessView";
            this.DescriptionAccessView.OptionsColumn.AllowEdit = false;
            this.DescriptionAccessView.Visible = true;
            this.DescriptionAccessView.VisibleIndex = 3;
            this.DescriptionAccessView.Width = 291;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // lbThongBao
            // 
            this.lbThongBao.AutoSize = true;
            this.lbThongBao.Location = new System.Drawing.Point(771, 33);
            this.lbThongBao.Name = "lbThongBao";
            this.lbThongBao.Size = new System.Drawing.Size(0, 13);
            this.lbThongBao.TabIndex = 68;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Location = new System.Drawing.Point(818, 234);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(386, 76);
            this.groupBox2.TabIndex = 67;
            this.groupBox2.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(289, 27);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 34);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(29, 27);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 34);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(155, 27);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 34);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtMoTa
            // 
            this.txtMoTa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMoTa.Location = new System.Drawing.Point(815, 78);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(389, 150);
            this.txtMoTa.TabIndex = 1;
            this.txtMoTa.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtMoTa_EditValueChanging);
            // 
            // txtTenNhom
            // 
            this.txtTenNhom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenNhom.Location = new System.Drawing.Point(815, 52);
            this.txtTenNhom.Name = "txtTenNhom";
            this.txtTenNhom.Size = new System.Drawing.Size(389, 20);
            this.txtTenNhom.TabIndex = 0;
            this.txtTenNhom.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtTenNhom_EditValueChanging);
            this.txtTenNhom.TextChanged += new System.EventHandler(this.txtTenNhom_TextChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl2.Location = new System.Drawing.Point(777, 78);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(32, 16);
            this.labelControl2.TabIndex = 28;
            this.labelControl2.Text = "Mô tả";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl1.Location = new System.Drawing.Point(713, 53);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(96, 16);
            this.labelControl1.TabIndex = 27;
            this.labelControl1.Text = "Tên nhóm quyền";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.gridAccessEdit);
            this.groupBox1.Location = new System.Drawing.Point(5, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 351);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CÁC QUYỀN SỬA";
            // 
            // gridAccessEdit
            // 
            this.gridAccessEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAccessEdit.Location = new System.Drawing.Point(3, 17);
            this.gridAccessEdit.MainView = this.gridViewEdit;
            this.gridAccessEdit.Name = "gridAccessEdit";
            this.gridAccessEdit.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.CheckEdit});
            this.gridAccessEdit.Size = new System.Drawing.Size(334, 331);
            this.gridAccessEdit.TabIndex = 3;
            this.gridAccessEdit.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewEdit});
            // 
            // gridViewEdit
            // 
            this.gridViewEdit.ActiveFilterEnabled = false;
            this.gridViewEdit.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.AccessID,
            this.Form,
            this.DescriptionAccess});
            this.gridViewEdit.GridControl = this.gridAccessEdit;
            this.gridViewEdit.Name = "gridViewEdit";
            this.gridViewEdit.OptionsBehavior.Editable = false;
            this.gridViewEdit.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridViewEdit.OptionsSelection.MultiSelect = true;
            this.gridViewEdit.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridViewEdit.OptionsView.ShowGroupPanel = false;
            this.gridViewEdit.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridView1_SelectionChanged);
            // 
            // AccessID
            // 
            this.AccessID.Caption = "ID";
            this.AccessID.FieldName = "AccessID";
            this.AccessID.Name = "AccessID";
            this.AccessID.OptionsColumn.AllowEdit = false;
            this.AccessID.Visible = true;
            this.AccessID.VisibleIndex = 1;
            this.AccessID.Width = 114;
            // 
            // Form
            // 
            this.Form.Caption = "Tên form";
            this.Form.FieldName = "Form";
            this.Form.Name = "Form";
            this.Form.OptionsColumn.AllowEdit = false;
            this.Form.Visible = true;
            this.Form.VisibleIndex = 2;
            this.Form.Width = 272;
            // 
            // DescriptionAccess
            // 
            this.DescriptionAccess.Caption = "Mô tả";
            this.DescriptionAccess.FieldName = "DescriptionAccess";
            this.DescriptionAccess.Name = "DescriptionAccess";
            this.DescriptionAccess.OptionsColumn.AllowEdit = false;
            this.DescriptionAccess.Visible = true;
            this.DescriptionAccess.VisibleIndex = 3;
            this.DescriptionAccess.Width = 284;
            // 
            // CheckEdit
            // 
            this.CheckEdit.Name = "CheckEdit";
            this.CheckEdit.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(0, 361);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnEdit,
            this.btnDelete});
            this.gridControl2.Size = new System.Drawing.Size(1222, 197);
            this.gridControl2.TabIndex = 1;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.GroupAccessID,
            this.GroupAccessName,
            this.Description,
            this.EEdit,
            this.Delete,
            this.Count,
            this.CountEdit});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.ReadOnly = true;
            this.gridView2.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridView2_CustomRowCellEdit);
            this.gridView2.Click += new System.EventHandler(this.gridView2_Click);
            // 
            // GroupAccessID
            // 
            this.GroupAccessID.Caption = "Mã nhóm quyền";
            this.GroupAccessID.FieldName = "GroupAccessID";
            this.GroupAccessID.Name = "GroupAccessID";
            this.GroupAccessID.OptionsColumn.AllowEdit = false;
            this.GroupAccessID.Visible = true;
            this.GroupAccessID.VisibleIndex = 0;
            // 
            // GroupAccessName
            // 
            this.GroupAccessName.Caption = "Tên nhóm quyền";
            this.GroupAccessName.FieldName = "GroupAccessName";
            this.GroupAccessName.Name = "GroupAccessName";
            this.GroupAccessName.OptionsColumn.AllowEdit = false;
            this.GroupAccessName.Visible = true;
            this.GroupAccessName.VisibleIndex = 1;
            // 
            // Description
            // 
            this.Description.Caption = "Mô tả";
            this.Description.FieldName = "Description";
            this.Description.Name = "Description";
            this.Description.OptionsColumn.AllowEdit = false;
            this.Description.Visible = true;
            this.Description.VisibleIndex = 2;
            // 
            // EEdit
            // 
            this.EEdit.Caption = "Sửa";
            this.EEdit.ColumnEdit = this.btnEdit;
            this.EEdit.FieldName = "Edit";
            this.EEdit.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.EEdit.Name = "EEdit";
            this.EEdit.Visible = true;
            this.EEdit.VisibleIndex = 5;
            // 
            // btnEdit
            // 
            this.btnEdit.AutoHeight = false;
            this.btnEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("btnEdit.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnEdit_ButtonClick);
            // 
            // Delete
            // 
            this.Delete.Caption = "Xóa";
            this.Delete.ColumnEdit = this.btnDelete;
            this.Delete.FieldName = "Delete";
            this.Delete.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.Delete.Name = "Delete";
            this.Delete.Visible = true;
            this.Delete.VisibleIndex = 6;
            // 
            // btnDelete
            // 
            this.btnDelete.AutoHeight = false;
            this.btnDelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("btnDelete.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnDelete.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnDelete_ButtonClick);
            // 
            // Count
            // 
            this.Count.Caption = "Số Form tác động";
            this.Count.FieldName = "Count";
            this.Count.Name = "Count";
            this.Count.OptionsColumn.AllowEdit = false;
            this.Count.Visible = true;
            this.Count.VisibleIndex = 3;
            // 
            // CountEdit
            // 
            this.CountEdit.Caption = "Số Form sửa";
            this.CountEdit.FieldName = "CountEdit";
            this.CountEdit.Name = "CountEdit";
            this.CountEdit.OptionsColumn.AllowEdit = false;
            this.CountEdit.Visible = true;
            this.CountEdit.VisibleIndex = 4;
            // 
            // UcAccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "UcAccess";
            this.Size = new System.Drawing.Size(1222, 558);
            this.Load += new System.EventHandler(this.UcAccess_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAccessView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtMoTa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenNhom.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAccessEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn GroupAccessID;
        private DevExpress.XtraGrid.Columns.GridColumn GroupAccessName;
        private DevExpress.XtraGrid.Columns.GridColumn Description;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraGrid.GridControl gridAccessEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewEdit;
        private DevExpress.XtraGrid.Columns.GridColumn AccessID;
        private DevExpress.XtraGrid.Columns.GridColumn Form;
        private DevExpress.XtraGrid.Columns.GridColumn DescriptionAccess;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit CheckEdit;
        private DevExpress.XtraEditors.MemoEdit txtMoTa;
        private DevExpress.XtraEditors.TextEdit txtTenNhom;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraGrid.Columns.GridColumn EEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnEdit;
        private DevExpress.XtraGrid.Columns.GridColumn Delete;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnDelete;
        private System.Windows.Forms.Label lbThongBao;
        private DevExpress.XtraGrid.Columns.GridColumn Count;
        private DevExpress.XtraGrid.Columns.GridColumn CountEdit;
        private System.Windows.Forms.GroupBox groupBox3;
        private DevExpress.XtraGrid.GridControl gridAccessView;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewView;
        private DevExpress.XtraGrid.Columns.GridColumn AccessIDView;
        private DevExpress.XtraGrid.Columns.GridColumn FormView;
        private DevExpress.XtraGrid.Columns.GridColumn DescriptionAccessView;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
    }
}