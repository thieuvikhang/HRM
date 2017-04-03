using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace HRM
{
    partial class UcAbsent
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcAbsent));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbKhongLuong = new System.Windows.Forms.RadioButton();
            this.rbCoLuong = new System.Windows.Forms.RadioButton();
            this.dateChonBD = new DevExpress.XtraEditors.DateEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtGhiChu = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtSoNgayNghi = new DevExpress.XtraEditors.TextEdit();
            this.luChonNV = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dateChonKT = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.gcAbsent = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.StaffID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StaffName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AbsentDay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FromDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ToDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Note = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AbsentType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AbsentID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Sua = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.Xoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.delete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateChonBD.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateChonBD.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoNgayNghi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luChonNV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateChonKT.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateChonKT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAbsent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delete)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.groupBox2);
            this.panelControl1.Controls.Add(this.dateChonBD);
            this.panelControl1.Controls.Add(this.groupBox1);
            this.panelControl1.Controls.Add(this.txtGhiChu);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.txtSoNgayNghi);
            this.panelControl1.Controls.Add(this.luChonNV);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.dateChonKT);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl13);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(975, 208);
            this.panelControl1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbKhongLuong);
            this.groupBox2.Controls.Add(this.rbCoLuong);
            this.groupBox2.Location = new System.Drawing.Point(146, 159);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(277, 44);
            this.groupBox2.TabIndex = 68;
            this.groupBox2.TabStop = false;
            // 
            // rbKhongLuong
            // 
            this.rbKhongLuong.AutoSize = true;
            this.rbKhongLuong.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rbKhongLuong.Location = new System.Drawing.Point(138, 18);
            this.rbKhongLuong.Name = "rbKhongLuong";
            this.rbKhongLuong.Size = new System.Drawing.Size(97, 20);
            this.rbKhongLuong.TabIndex = 5;
            this.rbKhongLuong.Text = "Không lương";
            this.rbKhongLuong.UseVisualStyleBackColor = true;
            // 
            // rbCoLuong
            // 
            this.rbCoLuong.AutoSize = true;
            this.rbCoLuong.Checked = true;
            this.rbCoLuong.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rbCoLuong.Location = new System.Drawing.Point(26, 18);
            this.rbCoLuong.Name = "rbCoLuong";
            this.rbCoLuong.Size = new System.Drawing.Size(77, 20);
            this.rbCoLuong.TabIndex = 4;
            this.rbCoLuong.TabStop = true;
            this.rbCoLuong.Text = "Có lương";
            this.rbCoLuong.UseVisualStyleBackColor = true;
            // 
            // dateChonBD
            // 
            this.dateChonBD.EditValue = null;
            this.dateChonBD.Location = new System.Drawing.Point(146, 57);
            this.dateChonBD.Name = "dateChonBD";
            this.dateChonBD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateChonBD.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateChonBD.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista;
            this.dateChonBD.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dateChonBD.Properties.VistaCalendarViewStyle = ((DevExpress.XtraEditors.VistaCalendarViewStyle)(((((DevExpress.XtraEditors.VistaCalendarViewStyle.MonthView | DevExpress.XtraEditors.VistaCalendarViewStyle.YearView)
            | DevExpress.XtraEditors.VistaCalendarViewStyle.QuarterView)
            | DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView)
            | DevExpress.XtraEditors.VistaCalendarViewStyle.CenturyView)));
            this.dateChonBD.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.dateChonBD.Size = new System.Drawing.Size(277, 20);
            this.dateChonBD.TabIndex = 1;
            this.dateChonBD.DrawItem += new DevExpress.XtraEditors.Calendar.CustomDrawDayNumberCellEventHandler(this.dateChonBD_DrawItem);
            this.dateChonBD.DateTimeChanged += new System.EventHandler(this.dateChonBD_DateTimeChanged);
            this.dateChonBD.QueryCloseUp += new System.ComponentModel.CancelEventHandler(this.dateChonBD_QueryCloseUp);
            this.dateChonBD.TextChanged += new System.EventHandler(this.dateChonBD_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Location = new System.Drawing.Point(526, 132);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(423, 76);
            this.groupBox1.TabIndex = 66;
            this.groupBox1.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(289, 27);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 34);
            this.btnCancel.TabIndex = 9;
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
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGhiChu.Location = new System.Drawing.Point(526, 23);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(423, 103);
            this.txtGhiChu.TabIndex = 6;
            this.txtGhiChu.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtGhiChu_EditValueChanging);
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl5.Location = new System.Drawing.Point(451, 56);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(47, 16);
            this.labelControl5.TabIndex = 64;
            this.labelControl5.Text = "Ghi chú:";
            // 
            // txtSoNgayNghi
            // 
            this.txtSoNgayNghi.Enabled = false;
            this.txtSoNgayNghi.Location = new System.Drawing.Point(146, 133);
            this.txtSoNgayNghi.Name = "txtSoNgayNghi";
            this.txtSoNgayNghi.Size = new System.Drawing.Size(277, 20);
            this.txtSoNgayNghi.TabIndex = 3;
            // 
            // luChonNV
            // 
            this.luChonNV.Location = new System.Drawing.Point(146, 20);
            this.luChonNV.Name = "luChonNV";
            this.luChonNV.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luChonNV.Properties.NullText = "Vui lòng chọn nhân viên";
            this.luChonNV.Size = new System.Drawing.Size(277, 20);
            this.luChonNV.TabIndex = 0;
            this.luChonNV.TextChanged += new System.EventHandler(this.luChonNV_TextChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl4.Location = new System.Drawing.Point(25, 23);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(81, 16);
            this.labelControl4.TabIndex = 39;
            this.labelControl4.Text = "Tên nhân viên";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl3.Location = new System.Drawing.Point(25, 172);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(83, 16);
            this.labelControl3.TabIndex = 37;
            this.labelControl3.Text = "Loại nghỉ phép";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl1.Location = new System.Drawing.Point(25, 134);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(74, 16);
            this.labelControl1.TabIndex = 35;
            this.labelControl1.Text = "Số ngày nghỉ";
            // 
            // dateChonKT
            // 
            this.dateChonKT.EditValue = null;
            this.dateChonKT.Location = new System.Drawing.Point(146, 93);
            this.dateChonKT.Name = "dateChonKT";
            this.dateChonKT.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateChonKT.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateChonKT.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista;
            this.dateChonKT.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dateChonKT.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.dateChonKT.Size = new System.Drawing.Size(277, 20);
            this.dateChonKT.TabIndex = 2;
            this.dateChonKT.DrawItem += new DevExpress.XtraEditors.Calendar.CustomDrawDayNumberCellEventHandler(this.dateChonKT_DrawItem);
            this.dateChonKT.DateTimeChanged += new System.EventHandler(this.dateChonKT_DateTimeChanged);
            this.dateChonKT.QueryCloseUp += new System.ComponentModel.CancelEventHandler(this.dateChonKT_QueryCloseUp);
            this.dateChonKT.TextChanged += new System.EventHandler(this.dateChonKT_TextChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl2.Location = new System.Drawing.Point(25, 96);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(54, 16);
            this.labelControl2.TabIndex = 31;
            this.labelControl2.Text = "Đến ngày";
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl13.Location = new System.Drawing.Point(25, 58);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(47, 16);
            this.labelControl13.TabIndex = 29;
            this.labelControl13.Text = "Từ ngày";
            // 
            // gcAbsent
            // 
            this.gcAbsent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcAbsent.Location = new System.Drawing.Point(0, 208);
            this.gcAbsent.MainView = this.gridView1;
            this.gcAbsent.Name = "gcAbsent";
            this.gcAbsent.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.edit,
            this.delete});
            this.gcAbsent.Size = new System.Drawing.Size(975, 344);
            this.gcAbsent.TabIndex = 1;
            this.gcAbsent.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gcAbsent.Click += new System.EventHandler(this.gcAbsent_Click);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.ColumnFilterButton.Options.UseImage = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.StaffID,
            this.StaffName,
            this.AbsentDay,
            this.FromDate,
            this.ToDate,
            this.Note,
            this.AbsentType,
            this.AbsentID,
            this.Sua,
            this.Xoa});
            this.gridView1.GridControl = this.gcAbsent;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.FromDate, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // StaffID
            // 
            this.StaffID.Caption = "Mã nhân viên";
            this.StaffID.FieldName = "StaffID";
            this.StaffID.Name = "StaffID";
            this.StaffID.OptionsColumn.AllowEdit = false;
            this.StaffID.Visible = true;
            this.StaffID.VisibleIndex = 0;
            // 
            // StaffName
            // 
            this.StaffName.Caption = "Tên nhân viên";
            this.StaffName.FieldName = "StaffName";
            this.StaffName.Name = "StaffName";
            this.StaffName.OptionsColumn.AllowEdit = false;
            this.StaffName.Visible = true;
            this.StaffName.VisibleIndex = 1;
            // 
            // AbsentDay
            // 
            this.AbsentDay.Caption = "Số ngày nghỉ";
            this.AbsentDay.FieldName = "AbsentDay";
            this.AbsentDay.Name = "AbsentDay";
            this.AbsentDay.OptionsColumn.AllowEdit = false;
            this.AbsentDay.Visible = true;
            this.AbsentDay.VisibleIndex = 2;
            // 
            // FromDate
            // 
            this.FromDate.Caption = "Ngày bắt đầu";
            this.FromDate.FieldName = "FromDate";
            this.FromDate.Name = "FromDate";
            this.FromDate.OptionsColumn.AllowEdit = false;
            this.FromDate.Visible = true;
            this.FromDate.VisibleIndex = 3;
            // 
            // ToDate
            // 
            this.ToDate.Caption = "Ngày làm lại";
            this.ToDate.FieldName = "ToDate";
            this.ToDate.Name = "ToDate";
            this.ToDate.OptionsColumn.AllowEdit = false;
            this.ToDate.Visible = true;
            this.ToDate.VisibleIndex = 4;
            // 
            // Note
            // 
            this.Note.Caption = "Ghi chú";
            this.Note.FieldName = "Note";
            this.Note.Name = "Note";
            this.Note.OptionsColumn.AllowEdit = false;
            this.Note.Visible = true;
            this.Note.VisibleIndex = 5;
            // 
            // AbsentType
            // 
            this.AbsentType.Caption = "Loại nghĩ phép";
            this.AbsentType.FieldName = "AbsentType";
            this.AbsentType.Name = "AbsentType";
            this.AbsentType.OptionsColumn.AllowEdit = false;
            this.AbsentType.Visible = true;
            this.AbsentType.VisibleIndex = 6;
            // 
            // AbsentID
            // 
            this.AbsentID.Caption = "Mã nghĩ phép";
            this.AbsentID.FieldName = "AbsentID";
            this.AbsentID.Name = "AbsentID";
            this.AbsentID.OptionsColumn.AllowEdit = false;
            this.AbsentID.Visible = true;
            this.AbsentID.VisibleIndex = 7;
            // 
            // Sua
            // 
            this.Sua.Caption = "Sửa";
            this.Sua.ColumnEdit = this.edit;
            this.Sua.FieldName = "btSua";
            this.Sua.Name = "Sua";
            this.Sua.Tag = "tagSua";
            this.Sua.Visible = true;
            this.Sua.VisibleIndex = 8;
            // 
            // edit
            // 
            this.edit.AutoHeight = false;
            this.edit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("edit.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.edit.Name = "edit";
            this.edit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.edit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.edit_ButtonClick);
            // 
            // Xoa
            // 
            this.Xoa.Caption = "Xóa";
            this.Xoa.ColumnEdit = this.delete;
            this.Xoa.FieldName = "btXoa";
            this.Xoa.Name = "Xoa";
            this.Xoa.Tag = "tagXoa";
            this.Xoa.Visible = true;
            this.Xoa.VisibleIndex = 9;
            // 
            // delete
            // 
            this.delete.AutoHeight = false;
            this.delete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("delete.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.delete.Name = "delete";
            this.delete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.delete.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.delete_ButtonClick);
            // 
            // UcAbsent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcAbsent);
            this.Controls.Add(this.panelControl1);
            this.Name = "UcAbsent";
            this.Size = new System.Drawing.Size(975, 552);
            this.Load += new System.EventHandler(this.ucAbsent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateChonBD.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateChonBD.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoNgayNghi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luChonNV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateChonKT.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateChonKT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAbsent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delete)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PanelControl panelControl1;
        private LabelControl labelControl13;
        private LookUpEdit luChonNV;
        private LabelControl labelControl4;
        private LabelControl labelControl3;
        private LabelControl labelControl1;
        private DateEdit dateChonKT;
        private LabelControl labelControl2;
        private GridControl gcAbsent;
        private GridView gridView1;
        private GridColumn StaffID;
        private GridColumn StaffName;
        private GridColumn AbsentDay;
        private GridColumn FromDate;
        private GridColumn ToDate;
        private GridColumn Note;
        private GridColumn AbsentType;
        private GridColumn AbsentID;
        private RadioButton rbKhongLuong;
        private RadioButton rbCoLuong;
        private TextEdit txtSoNgayNghi;
        private LabelControl labelControl5;
        private MemoEdit txtGhiChu;
        private GroupBox groupBox1;
        private SimpleButton btnCancel;
        private SimpleButton btnAdd;
        private SimpleButton btnSave;
        private GridColumn Sua;
        private GridColumn Xoa;
        private RepositoryItemButtonEdit edit;
        private RepositoryItemButtonEdit delete;
        private DateEdit dateChonBD;
        private GroupBox groupBox2;
    }
}