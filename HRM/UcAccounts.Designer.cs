namespace HRM
{
    partial class UcAccounts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcAccounts));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.gcNhanVien = new DevExpress.XtraGrid.GridControl();
            this.gvNhanVien = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.StaffID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StaffName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SectionName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gcNhomQuyen = new DevExpress.XtraGrid.GridControl();
            this.gvPhongBan = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GroupAccessID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GroupAccessName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Description = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtThongBaoNLMK = new System.Windows.Forms.Label();
            this.txtThongBaoMK = new System.Windows.Forms.Label();
            this.txtThongBao = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtTaiKhoang = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtNhapLaiMatKhau = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtMatKhau = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.gcTaiKhoan = new DevExpress.XtraGrid.GridControl();
            this.gvTaiKhoan = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.AccID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StaffName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AccountStatusOnline = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GroupAccessName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Edit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.Delete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNhanVien)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcNhomQuyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPhongBan)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaiKhoang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNhapLaiMatKhau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatKhau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTaiKhoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTaiKhoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btDelete)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.groupBox4);
            this.panelControl1.Controls.Add(this.groupBox2);
            this.panelControl1.Controls.Add(this.groupBox1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1169, 285);
            this.panelControl1.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.gcNhanVien);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox4.Location = new System.Drawing.Point(17, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(315, 275);
            this.groupBox4.TabIndex = 61;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Chọn Nhân Viên";
            // 
            // gcNhanVien
            // 
            this.gcNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcNhanVien.Location = new System.Drawing.Point(3, 17);
            this.gcNhanVien.MainView = this.gvNhanVien;
            this.gcNhanVien.Name = "gcNhanVien";
            this.gcNhanVien.Size = new System.Drawing.Size(309, 255);
            this.gcNhanVien.TabIndex = 0;
            this.gcNhanVien.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvNhanVien});
            // 
            // gvNhanVien
            // 
            this.gvNhanVien.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.StaffID,
            this.StaffName,
            this.SectionName});
            this.gvNhanVien.GridControl = this.gcNhanVien;
            this.gvNhanVien.Name = "gvNhanVien";
            this.gvNhanVien.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gvNhanVien.OptionsSelection.InvertSelection = true;
            this.gvNhanVien.OptionsSelection.MultiSelect = true;
            this.gvNhanVien.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gvNhanVien.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.False;
            this.gvNhanVien.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            this.gvNhanVien.OptionsView.ShowGroupPanel = false;
            this.gvNhanVien.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gvNhanVien_RowClick);
            this.gvNhanVien.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gvNhanVien_SelectionChanged);
            // 
            // StaffID
            // 
            this.StaffID.Caption = "ID";
            this.StaffID.FieldName = "StaffID";
            this.StaffID.Name = "StaffID";
            this.StaffID.OptionsColumn.AllowEdit = false;
            this.StaffID.Visible = true;
            this.StaffID.VisibleIndex = 1;
            this.StaffID.Width = 205;
            // 
            // StaffName
            // 
            this.StaffName.Caption = "Tên Nhân Viên";
            this.StaffName.FieldName = "StaffName";
            this.StaffName.Name = "StaffName";
            this.StaffName.OptionsColumn.AllowEdit = false;
            this.StaffName.Visible = true;
            this.StaffName.VisibleIndex = 2;
            this.StaffName.Width = 397;
            // 
            // SectionName
            // 
            this.SectionName.Caption = "Phòng Ban";
            this.SectionName.FieldName = "SectionName";
            this.SectionName.Name = "SectionName";
            this.SectionName.OptionsColumn.AllowEdit = false;
            this.SectionName.Visible = true;
            this.SectionName.VisibleIndex = 3;
            this.SectionName.Width = 420;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gcNhomQuyen);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox2.Location = new System.Drawing.Point(357, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(315, 275);
            this.groupBox2.TabIndex = 60;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chọn Nhóm Quyền";
            // 
            // gcNhomQuyen
            // 
            this.gcNhomQuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcNhomQuyen.Location = new System.Drawing.Point(3, 17);
            this.gcNhomQuyen.MainView = this.gvPhongBan;
            this.gcNhomQuyen.Name = "gcNhomQuyen";
            this.gcNhomQuyen.Size = new System.Drawing.Size(309, 255);
            this.gcNhomQuyen.TabIndex = 0;
            this.gcNhomQuyen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPhongBan});
            // 
            // gvPhongBan
            // 
            this.gvPhongBan.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.GroupAccessID,
            this.GroupAccessName,
            this.Description});
            this.gvPhongBan.GridControl = this.gcNhomQuyen;
            this.gvPhongBan.Name = "gvPhongBan";
            this.gvPhongBan.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gvPhongBan.OptionsSelection.MultiSelect = true;
            this.gvPhongBan.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gvPhongBan.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.False;
            this.gvPhongBan.OptionsSelection.UseIndicatorForSelection = false;
            this.gvPhongBan.OptionsView.ShowGroupPanel = false;
            this.gvPhongBan.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gvPhongBan_RowClick);
            this.gvPhongBan.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gvPhongBan_SelectionChanged);
            // 
            // GroupAccessID
            // 
            this.GroupAccessID.Caption = "ID";
            this.GroupAccessID.FieldName = "GroupAccessID";
            this.GroupAccessID.Name = "GroupAccessID";
            this.GroupAccessID.OptionsColumn.AllowEdit = false;
            this.GroupAccessID.Visible = true;
            this.GroupAccessID.VisibleIndex = 1;
            this.GroupAccessID.Width = 140;
            // 
            // GroupAccessName
            // 
            this.GroupAccessName.Caption = "Tên Nhóm Quyền";
            this.GroupAccessName.FieldName = "GroupAccessName";
            this.GroupAccessName.Name = "GroupAccessName";
            this.GroupAccessName.OptionsColumn.AllowEdit = false;
            this.GroupAccessName.Visible = true;
            this.GroupAccessName.VisibleIndex = 2;
            this.GroupAccessName.Width = 432;
            // 
            // Description
            // 
            this.Description.Caption = "Mô Tả";
            this.Description.FieldName = "Description";
            this.Description.Name = "Description";
            this.Description.OptionsColumn.AllowEdit = false;
            this.Description.Visible = true;
            this.Description.VisibleIndex = 3;
            this.Description.Width = 448;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtThongBaoNLMK);
            this.groupBox1.Controls.Add(this.txtThongBaoMK);
            this.groupBox1.Controls.Add(this.txtThongBao);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.txtTaiKhoang);
            this.groupBox1.Controls.Add(this.labelControl1);
            this.groupBox1.Controls.Add(this.txtNhapLaiMatKhau);
            this.groupBox1.Controls.Add(this.labelControl2);
            this.groupBox1.Controls.Add(this.txtMatKhau);
            this.groupBox1.Controls.Add(this.labelControl3);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.Location = new System.Drawing.Point(708, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(447, 268);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Tài Khoản";
            // 
            // txtThongBaoNLMK
            // 
            this.txtThongBaoNLMK.AutoSize = true;
            this.txtThongBaoNLMK.Location = new System.Drawing.Point(173, 131);
            this.txtThongBaoNLMK.Name = "txtThongBaoNLMK";
            this.txtThongBaoNLMK.Size = new System.Drawing.Size(0, 13);
            this.txtThongBaoNLMK.TabIndex = 71;
            // 
            // txtThongBaoMK
            // 
            this.txtThongBaoMK.AutoSize = true;
            this.txtThongBaoMK.Location = new System.Drawing.Point(173, 82);
            this.txtThongBaoMK.Name = "txtThongBaoMK";
            this.txtThongBaoMK.Size = new System.Drawing.Size(0, 13);
            this.txtThongBaoMK.TabIndex = 70;
            // 
            // txtThongBao
            // 
            this.txtThongBao.AutoSize = true;
            this.txtThongBao.Location = new System.Drawing.Point(173, 27);
            this.txtThongBao.Name = "txtThongBao";
            this.txtThongBao.Size = new System.Drawing.Size(0, 13);
            this.txtThongBao.TabIndex = 69;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnCancel);
            this.groupBox3.Controls.Add(this.btnAdd);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Location = new System.Drawing.Point(27, 173);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(398, 76);
            this.groupBox3.TabIndex = 68;
            this.groupBox3.TabStop = false;
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
            // txtTaiKhoang
            // 
            this.txtTaiKhoang.Location = new System.Drawing.Point(173, 43);
            this.txtTaiKhoang.Name = "txtTaiKhoang";
            this.txtTaiKhoang.Size = new System.Drawing.Size(252, 20);
            this.txtTaiKhoang.TabIndex = 0;
            this.txtTaiKhoang.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtTaiKhoang_EditValueChanging);
            this.txtTaiKhoang.TextChanged += new System.EventHandler(this.txtTaiKhoang_TextChanged);
            this.txtTaiKhoang.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTaiKhoang_KeyPress);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl1.Location = new System.Drawing.Point(52, 44);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(83, 16);
            this.labelControl1.TabIndex = 15;
            this.labelControl1.Text = "Tên tài khoản:";
            // 
            // txtNhapLaiMatKhau
            // 
            this.txtNhapLaiMatKhau.EditValue = "**********";
            this.txtNhapLaiMatKhau.Location = new System.Drawing.Point(173, 147);
            this.txtNhapLaiMatKhau.Name = "txtNhapLaiMatKhau";
            this.txtNhapLaiMatKhau.Properties.PasswordChar = '*';
            this.txtNhapLaiMatKhau.Size = new System.Drawing.Size(252, 20);
            this.txtNhapLaiMatKhau.TabIndex = 2;
            this.txtNhapLaiMatKhau.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtNhapLaiMatKhau_EditValueChanging);
            this.txtNhapLaiMatKhau.TextChanged += new System.EventHandler(this.txtNhapLaiMatKhau_TextChanged);
            this.txtNhapLaiMatKhau.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNhapLaiMatKhau_KeyPress);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl2.Location = new System.Drawing.Point(78, 99);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(57, 16);
            this.labelControl2.TabIndex = 52;
            this.labelControl2.Text = "Mật khẩu:";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.EditValue = "**********";
            this.txtMatKhau.Location = new System.Drawing.Point(173, 101);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Properties.PasswordChar = '*';
            this.txtMatKhau.Size = new System.Drawing.Size(252, 20);
            this.txtMatKhau.TabIndex = 1;
            this.txtMatKhau.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtMatKhau_EditValueChanging);
            this.txtMatKhau.TextChanged += new System.EventHandler(this.txtMatKhau_TextChanged);
            this.txtMatKhau.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMatKhau_KeyPress);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl3.Location = new System.Drawing.Point(27, 148);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(108, 16);
            this.labelControl3.TabIndex = 53;
            this.labelControl3.Text = "Nhập lại mật khẩu:";
            // 
            // gcTaiKhoan
            // 
            this.gcTaiKhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTaiKhoan.Location = new System.Drawing.Point(0, 285);
            this.gcTaiKhoan.MainView = this.gvTaiKhoan;
            this.gcTaiKhoan.Name = "gcTaiKhoan";
            this.gcTaiKhoan.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btEdit,
            this.btDelete});
            this.gcTaiKhoan.Size = new System.Drawing.Size(1169, 265);
            this.gcTaiKhoan.TabIndex = 2;
            this.gcTaiKhoan.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTaiKhoan});
            this.gcTaiKhoan.Click += new System.EventHandler(this.gcTaiKhoan_Click);
            // 
            // gvTaiKhoan
            // 
            this.gvTaiKhoan.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.AccID,
            this.UserName,
            this.StaffName1,
            this.AccountStatusOnline,
            this.GroupAccessName1,
            this.Edit,
            this.Delete});
            this.gvTaiKhoan.GridControl = this.gcTaiKhoan;
            this.gvTaiKhoan.Name = "gvTaiKhoan";
            this.gvTaiKhoan.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gvTaiKhoan.OptionsView.ShowGroupPanel = false;
            this.gvTaiKhoan.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gvTaiKhoan_CustomRowCellEdit);
            // 
            // AccID
            // 
            this.AccID.Caption = "Mã Tải Khoản";
            this.AccID.FieldName = "AccID";
            this.AccID.Name = "AccID";
            this.AccID.OptionsColumn.AllowEdit = false;
            this.AccID.Visible = true;
            this.AccID.VisibleIndex = 0;
            // 
            // UserName
            // 
            this.UserName.Caption = "Tên Tài Khoản";
            this.UserName.FieldName = "UserName";
            this.UserName.Name = "UserName";
            this.UserName.OptionsColumn.AllowEdit = false;
            this.UserName.Visible = true;
            this.UserName.VisibleIndex = 1;
            // 
            // StaffName1
            // 
            this.StaffName1.Caption = "Tên Nhân Viên";
            this.StaffName1.FieldName = "StaffName1";
            this.StaffName1.Name = "StaffName1";
            this.StaffName1.OptionsColumn.AllowEdit = false;
            this.StaffName1.Visible = true;
            this.StaffName1.VisibleIndex = 2;
            // 
            // AccountStatusOnline
            // 
            this.AccountStatusOnline.Caption = "Tình Trạng";
            this.AccountStatusOnline.FieldName = "AccountStatusOnline";
            this.AccountStatusOnline.Name = "AccountStatusOnline";
            this.AccountStatusOnline.OptionsColumn.AllowEdit = false;
            this.AccountStatusOnline.Visible = true;
            this.AccountStatusOnline.VisibleIndex = 4;
            // 
            // GroupAccessName1
            // 
            this.GroupAccessName1.Caption = "Tên Nhóm Quyền";
            this.GroupAccessName1.FieldName = "GroupAccessName1";
            this.GroupAccessName1.Name = "GroupAccessName1";
            this.GroupAccessName1.OptionsColumn.AllowEdit = false;
            this.GroupAccessName1.Visible = true;
            this.GroupAccessName1.VisibleIndex = 3;
            // 
            // Edit
            // 
            this.Edit.Caption = "Sửa ";
            this.Edit.ColumnEdit = this.btEdit;
            this.Edit.FieldName = "Edit";
            this.Edit.Name = "Edit";
            this.Edit.Visible = true;
            this.Edit.VisibleIndex = 5;
            // 
            // btEdit
            // 
            this.btEdit.AutoHeight = false;
            this.btEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.BottomCenter, ((System.Drawing.Image)(resources.GetObject("btEdit.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "", null, null, true)});
            this.btEdit.Name = "btEdit";
            this.btEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btEdit_ButtonClick);
            // 
            // Delete
            // 
            this.Delete.Caption = "Xóa";
            this.Delete.ColumnEdit = this.btDelete;
            this.Delete.FieldName = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.Visible = true;
            this.Delete.VisibleIndex = 6;
            // 
            // btDelete
            // 
            this.btDelete.AutoHeight = false;
            this.btDelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.BottomCenter, ((System.Drawing.Image)(resources.GetObject("btDelete.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6, "", null, null, true)});
            this.btDelete.Name = "btDelete";
            this.btDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btDelete.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btDelete_ButtonClick);
            // 
            // UcAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcTaiKhoan);
            this.Controls.Add(this.panelControl1);
            this.Name = "UcAccounts";
            this.Size = new System.Drawing.Size(1169, 550);
            this.Load += new System.EventHandler(this.UcAccounts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNhanVien)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcNhomQuyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPhongBan)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTaiKhoang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNhapLaiMatKhau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatKhau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTaiKhoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTaiKhoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btDelete)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtNhapLaiMatKhau;
        private DevExpress.XtraEditors.TextEdit txtMatKhau;
        private DevExpress.XtraEditors.TextEdit txtTaiKhoang;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.GridControl gcTaiKhoan;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTaiKhoan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraGrid.GridControl gcNhomQuyen;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPhongBan;
        private DevExpress.XtraGrid.Columns.GridColumn GroupAccessID;
        private DevExpress.XtraGrid.Columns.GridColumn GroupAccessName;
        private DevExpress.XtraGrid.Columns.GridColumn Description;
        private DevExpress.XtraGrid.Columns.GridColumn AccID;
        private DevExpress.XtraGrid.Columns.GridColumn UserName;
        private DevExpress.XtraGrid.Columns.GridColumn StaffName1;
        private DevExpress.XtraGrid.Columns.GridColumn GroupAccessName1;
        private DevExpress.XtraGrid.Columns.GridColumn Edit;
        private DevExpress.XtraGrid.Columns.GridColumn Delete;
        private System.Windows.Forms.GroupBox groupBox3;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.GroupBox groupBox4;
        private DevExpress.XtraGrid.GridControl gcNhanVien;
        private DevExpress.XtraGrid.Views.Grid.GridView gvNhanVien;
        private DevExpress.XtraGrid.Columns.GridColumn StaffID;
        private DevExpress.XtraGrid.Columns.GridColumn StaffName;
        private DevExpress.XtraGrid.Columns.GridColumn SectionName;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btDelete;
        private System.Windows.Forms.Label txtThongBao;
        private System.Windows.Forms.Label txtThongBaoNLMK;
        private System.Windows.Forms.Label txtThongBaoMK;
        private DevExpress.XtraGrid.Columns.GridColumn AccountStatusOnline;
    }
}