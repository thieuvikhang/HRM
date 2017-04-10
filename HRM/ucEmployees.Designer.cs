using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using ComboBox = System.Windows.Forms.ComboBox;

namespace HRM
{
    partial class UcEmployees
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcEmployees));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lkupManID = new DevExpress.XtraEditors.LookUpEdit();
            this.txtMail = new DevExpress.XtraEditors.TextEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.cbbPost = new System.Windows.Forms.ComboBox();
            this.cbbSection = new System.Windows.Forms.ComboBox();
            this.cbbEducation = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbNu = new System.Windows.Forms.RadioButton();
            this.rbNam = new System.Windows.Forms.RadioButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.dateEnd = new DevExpress.XtraEditors.DateEdit();
            this.dateStart = new DevExpress.XtraEditors.DateEdit();
            this.dateBirth = new DevExpress.XtraEditors.DateEdit();
            this.picImageStaff = new System.Windows.Forms.PictureBox();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.txtAddress = new DevExpress.XtraEditors.TextEdit();
            this.txtPhone = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtOnlineStatus = new DevExpress.XtraEditors.TextEdit();
            this.txtCardID = new DevExpress.XtraEditors.TextEdit();
            this.lblTitleOnlineStatus = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.txtStaffID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gcEmployees = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcStaffID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcStaffName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcoGender = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcBirthDay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCardID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEducation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPosition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSection = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDateStart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcManagerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkupManID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBirth.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBirth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImageStaff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOnlineStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCardID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStaffID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lkupManID);
            this.panelControl1.Controls.Add(this.txtMail);
            this.panelControl1.Controls.Add(this.groupControl2);
            this.panelControl1.Controls.Add(this.cbbPost);
            this.panelControl1.Controls.Add(this.cbbSection);
            this.panelControl1.Controls.Add(this.cbbEducation);
            this.panelControl1.Controls.Add(this.groupBox1);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.dateEnd);
            this.panelControl1.Controls.Add(this.dateStart);
            this.panelControl1.Controls.Add(this.dateBirth);
            this.panelControl1.Controls.Add(this.picImageStaff);
            this.panelControl1.Controls.Add(this.labelControl14);
            this.panelControl1.Controls.Add(this.labelControl15);
            this.panelControl1.Controls.Add(this.labelControl13);
            this.panelControl1.Controls.Add(this.labelControl8);
            this.panelControl1.Controls.Add(this.labelControl9);
            this.panelControl1.Controls.Add(this.labelControl10);
            this.panelControl1.Controls.Add(this.labelControl11);
            this.panelControl1.Controls.Add(this.txtAddress);
            this.panelControl1.Controls.Add(this.txtPhone);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl7);
            this.panelControl1.Controls.Add(this.txtOnlineStatus);
            this.panelControl1.Controls.Add(this.txtCardID);
            this.panelControl1.Controls.Add(this.lblTitleOnlineStatus);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.labelControl6);
            this.panelControl1.Controls.Add(this.txtName);
            this.panelControl1.Controls.Add(this.txtStaffID);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1090, 250);
            this.panelControl1.TabIndex = 0;
            // 
            // lkupManID
            // 
            this.lkupManID.EditValue = "Chọn Nhân viên quản lý";
            this.lkupManID.Location = new System.Drawing.Point(699, 128);
            this.lkupManID.Name = "lkupManID";
            this.lkupManID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkupManID.Size = new System.Drawing.Size(144, 20);
            this.lkupManID.TabIndex = 53;
            // 
            // txtMail
            // 
            this.dxErrorProvider.SetIconAlignment(this.txtMail, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.txtMail.Location = new System.Drawing.Point(383, 75);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(170, 20);
            this.txtMail.TabIndex = 7;
            this.txtMail.TextChanged += new System.EventHandler(this.txtMail_TextChanged);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnDelete);
            this.groupControl2.Controls.Add(this.btnCancel);
            this.groupControl2.Controls.Add(this.btnEdit);
            this.groupControl2.Controls.Add(this.btnAdd);
            this.groupControl2.Controls.Add(this.btnSave);
            this.groupControl2.Location = new System.Drawing.Point(5, 154);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(458, 67);
            this.groupControl2.TabIndex = 52;
            this.groupControl2.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl2_Paint);
            // 
            // btnDelete
            // 
            this.btnDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(369, 23);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 34);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(278, 23);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 34);
            this.btnCancel.TabIndex = 51;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
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
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(187, 23);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 34);
            this.btnSave.TabIndex = 50;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbbPost
            // 
            this.cbbPost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbPost.FormattingEnabled = true;
            this.cbbPost.Location = new System.Drawing.Point(699, 75);
            this.cbbPost.Name = "cbbPost";
            this.cbbPost.Size = new System.Drawing.Size(144, 21);
            this.cbbPost.TabIndex = 12;
            // 
            // cbbSection
            // 
            this.cbbSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSection.FormattingEnabled = true;
            this.cbbSection.Location = new System.Drawing.Point(699, 102);
            this.cbbSection.Name = "cbbSection";
            this.cbbSection.Size = new System.Drawing.Size(144, 21);
            this.cbbSection.TabIndex = 13;
            this.cbbSection.SelectedIndexChanged += new System.EventHandler(this.cbbSection_SelectedIndexChanged);
            // 
            // cbbEducation
            // 
            this.cbbEducation.FormattingEnabled = true;
            this.cbbEducation.Items.AddRange(new object[] {
            "Đại học",
            "Cao Đẳng"});
            this.cbbEducation.Location = new System.Drawing.Point(699, 49);
            this.cbbEducation.Name = "cbbEducation";
            this.cbbEducation.Size = new System.Drawing.Size(144, 21);
            this.cbbEducation.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbNu);
            this.groupBox1.Controls.Add(this.rbNam);
            this.groupBox1.Location = new System.Drawing.Point(119, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(163, 43);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            // 
            // rbNu
            // 
            this.rbNu.AutoSize = true;
            this.rbNu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rbNu.Location = new System.Drawing.Point(64, 17);
            this.rbNu.Name = "rbNu";
            this.rbNu.Size = new System.Drawing.Size(42, 20);
            this.rbNu.TabIndex = 3;
            this.rbNu.TabStop = true;
            this.rbNu.Text = "Nữ";
            this.rbNu.UseVisualStyleBackColor = true;
            // 
            // rbNam
            // 
            this.rbNam.AutoSize = true;
            this.rbNam.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rbNam.Location = new System.Drawing.Point(6, 17);
            this.rbNam.Name = "rbNam";
            this.rbNam.Size = new System.Drawing.Size(52, 20);
            this.rbNam.TabIndex = 2;
            this.rbNam.TabStop = true;
            this.rbNam.Text = "Nam";
            this.rbNam.UseVisualStyleBackColor = true;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl4.Location = new System.Drawing.Point(67, 95);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(46, 16);
            this.labelControl4.TabIndex = 42;
            this.labelControl4.Text = "Giới tính";
            // 
            // dateEnd
            // 
            this.dateEnd.EditValue = null;
            this.dateEnd.Location = new System.Drawing.Point(382, 128);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEnd.Size = new System.Drawing.Size(171, 20);
            this.dateEnd.TabIndex = 9;
            this.dateEnd.DateTimeChanged += new System.EventHandler(this.dateEnd_DateTimeChanged);
            this.dateEnd.BeforePopup += new System.EventHandler(this.dateEnd_BeforePopup);
            this.dateEnd.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.dateEnd_ButtonClick);
            this.dateEnd.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.dateEnd_EditValueChanging);
            // 
            // dateStart
            // 
            this.dateStart.EditValue = null;
            this.dateStart.Location = new System.Drawing.Point(382, 102);
            this.dateStart.Name = "dateStart";
            this.dateStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateStart.Size = new System.Drawing.Size(171, 20);
            this.dateStart.TabIndex = 8;
            this.dateStart.DateTimeChanged += new System.EventHandler(this.dateStart_DateTimeChanged);
            // 
            // dateBirth
            // 
            this.dateBirth.EditValue = null;
            this.dateBirth.Location = new System.Drawing.Point(119, 125);
            this.dateBirth.Name = "dateBirth";
            this.dateBirth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBirth.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBirth.Size = new System.Drawing.Size(163, 20);
            this.dateBirth.TabIndex = 4;
            this.dateBirth.Click += new System.EventHandler(this.dateBirth_Click);
            this.dateBirth.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dateBirth_MouseClick);
            // 
            // picImageStaff
            // 
            this.picImageStaff.Image = global::HRM.Properties.Resources.thumb_14400082930User;
            this.picImageStaff.InitialImage = global::HRM.Properties.Resources.admin;
            this.picImageStaff.Location = new System.Drawing.Point(936, 5);
            this.picImageStaff.Name = "picImageStaff";
            this.picImageStaff.Size = new System.Drawing.Size(149, 204);
            this.picImageStaff.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImageStaff.TabIndex = 36;
            this.picImageStaff.TabStop = false;
            // 
            // labelControl14
            // 
            this.labelControl14.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl14.Location = new System.Drawing.Point(633, 103);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(60, 16);
            this.labelControl14.TabIndex = 32;
            this.labelControl14.Text = "Phòng ban";
            // 
            // labelControl15
            // 
            this.labelControl15.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl15.Location = new System.Drawing.Point(647, 77);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(46, 16);
            this.labelControl15.TabIndex = 31;
            this.labelControl15.Text = "Chức vụ";
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl13.Location = new System.Drawing.Point(345, 77);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(31, 16);
            this.labelControl13.TabIndex = 27;
            this.labelControl13.Text = "Email";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl8.Location = new System.Drawing.Point(567, 129);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(126, 16);
            this.labelControl8.TabIndex = 24;
            this.labelControl8.Text = "Tên nhân viên quản lý";
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl9.Location = new System.Drawing.Point(299, 129);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(77, 16);
            this.labelControl9.TabIndex = 23;
            this.labelControl9.Text = "Ngày kết thúc";
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl10.Location = new System.Drawing.Point(301, 103);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(75, 16);
            this.labelControl10.TabIndex = 20;
            this.labelControl10.Text = "Ngày bắt đầu";
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl11.Location = new System.Drawing.Point(597, 51);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(96, 16);
            this.labelControl11.TabIndex = 19;
            this.labelControl11.Text = "Trình độ học vấn";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(382, 24);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(171, 20);
            this.txtAddress.TabIndex = 5;
            // 
            // txtPhone
            // 
            this.dxErrorProvider.SetIconAlignment(this.txtPhone, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.txtPhone.Location = new System.Drawing.Point(382, 50);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(171, 20);
            this.txtPhone.TabIndex = 6;
            this.txtPhone.EditValueChanged += new System.EventHandler(this.textEdit4_EditValueChanged);
            this.txtPhone.TextChanged += new System.EventHandler(this.txtPhone_TextChanged);
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl3.Location = new System.Drawing.Point(337, 25);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(39, 16);
            this.labelControl3.TabIndex = 16;
            this.labelControl3.Text = "Địa chỉ";
            this.labelControl3.Click += new System.EventHandler(this.labelControl3_Click);
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl7.Location = new System.Drawing.Point(318, 51);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(58, 16);
            this.labelControl7.TabIndex = 15;
            this.labelControl7.Text = "Điện thoại";
            this.labelControl7.Click += new System.EventHandler(this.labelControl7_Click);
            // 
            // txtOnlineStatus
            // 
            this.txtOnlineStatus.Enabled = false;
            this.txtOnlineStatus.Location = new System.Drawing.Point(699, 154);
            this.txtOnlineStatus.Name = "txtOnlineStatus";
            this.txtOnlineStatus.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOnlineStatus.Properties.Appearance.Options.UseFont = true;
            this.txtOnlineStatus.Size = new System.Drawing.Size(144, 22);
            this.txtOnlineStatus.TabIndex = 10;
            this.txtOnlineStatus.TextChanged += new System.EventHandler(this.txtCardID_TextChanged);
            this.txtOnlineStatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCardID_KeyPress);
            // 
            // txtCardID
            // 
            this.dxErrorProvider.SetIconAlignment(this.txtCardID, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.txtCardID.Location = new System.Drawing.Point(699, 24);
            this.txtCardID.Name = "txtCardID";
            this.txtCardID.Size = new System.Drawing.Size(144, 20);
            this.txtCardID.TabIndex = 10;
            this.txtCardID.TextChanged += new System.EventHandler(this.txtCardID_TextChanged);
            this.txtCardID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCardID_KeyPress);
            // 
            // lblTitleOnlineStatus
            // 
            this.lblTitleOnlineStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTitleOnlineStatus.Location = new System.Drawing.Point(589, 154);
            this.lblTitleOnlineStatus.Name = "lblTitleOnlineStatus";
            this.lblTitleOnlineStatus.Size = new System.Drawing.Size(104, 16);
            this.lblTitleOnlineStatus.TabIndex = 11;
            this.lblTitleOnlineStatus.Text = "Trạng thái Online:";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl5.Location = new System.Drawing.Point(640, 25);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(53, 16);
            this.labelControl5.TabIndex = 11;
            this.labelControl5.Text = "Số CMND";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl6.Location = new System.Drawing.Point(58, 126);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(55, 16);
            this.labelControl6.TabIndex = 10;
            this.labelControl6.Text = "Ngày sinh";
            // 
            // txtName
            // 
            this.dxErrorProvider.SetIconAlignment(this.txtName, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.txtName.Location = new System.Drawing.Point(119, 50);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(163, 20);
            this.txtName.TabIndex = 1;
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
            // 
            // txtStaffID
            // 
            this.dxErrorProvider.SetIconAlignment(this.txtStaffID, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.txtStaffID.Location = new System.Drawing.Point(119, 24);
            this.txtStaffID.Name = "txtStaffID";
            this.txtStaffID.Size = new System.Drawing.Size(163, 20);
            this.txtStaffID.TabIndex = 0;
            this.txtStaffID.TextChanged += new System.EventHandler(this.txtStaffID_TextChanged);
            this.txtStaffID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStaffID_KeyPress);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl2.Location = new System.Drawing.Point(10, 51);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(103, 16);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Tên nhân viên (*)";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl1.Location = new System.Drawing.Point(15, 25);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(98, 16);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Mã nhân viên (*)";
            // 
            // gcEmployees
            // 
            this.gcEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcEmployees.Location = new System.Drawing.Point(0, 250);
            this.gcEmployees.MainView = this.gridView1;
            this.gcEmployees.Name = "gcEmployees";
            this.gcEmployees.Size = new System.Drawing.Size(1090, 328);
            this.gcEmployees.TabIndex = 1;
            this.gcEmployees.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gcEmployees.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcStaffID,
            this.gcStaffName,
            this.gcoGender,
            this.gcBirthDay,
            this.gcCardID,
            this.gcPhone,
            this.gcAddress,
            this.gcEducation,
            this.gcEmail,
            this.gcPosition,
            this.gcSection,
            this.gcDateStart,
            this.gcEndDate,
            this.gcManagerID});
            this.gridView1.GridControl = this.gcEmployees;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            // 
            // gcStaffID
            // 
            this.gcStaffID.Caption = "Mã nhân viên";
            this.gcStaffID.FieldName = "StaffID";
            this.gcStaffID.Name = "gcStaffID";
            this.gcStaffID.Visible = true;
            this.gcStaffID.VisibleIndex = 0;
            // 
            // gcStaffName
            // 
            this.gcStaffName.Caption = "Tên nhân viên";
            this.gcStaffName.FieldName = "StaffName";
            this.gcStaffName.Name = "gcStaffName";
            this.gcStaffName.Visible = true;
            this.gcStaffName.VisibleIndex = 1;
            // 
            // gcoGender
            // 
            this.gcoGender.Caption = "Giới tính";
            this.gcoGender.FieldName = "Gender";
            this.gcoGender.Name = "gcoGender";
            this.gcoGender.Visible = true;
            this.gcoGender.VisibleIndex = 2;
            // 
            // gcBirthDay
            // 
            this.gcBirthDay.Caption = "Ngày sinh";
            this.gcBirthDay.FieldName = "BirthDay";
            this.gcBirthDay.Name = "gcBirthDay";
            this.gcBirthDay.Visible = true;
            this.gcBirthDay.VisibleIndex = 3;
            // 
            // gcCardID
            // 
            this.gcCardID.Caption = "CMND";
            this.gcCardID.FieldName = "CardID";
            this.gcCardID.Name = "gcCardID";
            this.gcCardID.Visible = true;
            this.gcCardID.VisibleIndex = 4;
            // 
            // gcPhone
            // 
            this.gcPhone.Caption = "Điện thoại";
            this.gcPhone.FieldName = "Phone";
            this.gcPhone.Name = "gcPhone";
            this.gcPhone.Visible = true;
            this.gcPhone.VisibleIndex = 5;
            // 
            // gcAddress
            // 
            this.gcAddress.Caption = "Địa chỉ";
            this.gcAddress.FieldName = "Address";
            this.gcAddress.Name = "gcAddress";
            this.gcAddress.Visible = true;
            this.gcAddress.VisibleIndex = 6;
            // 
            // gcEducation
            // 
            this.gcEducation.Caption = "Trình độ học vấn";
            this.gcEducation.FieldName = "Education";
            this.gcEducation.Name = "gcEducation";
            this.gcEducation.Visible = true;
            this.gcEducation.VisibleIndex = 7;
            // 
            // gcEmail
            // 
            this.gcEmail.Caption = "Email";
            this.gcEmail.FieldName = "Email";
            this.gcEmail.Name = "gcEmail";
            this.gcEmail.Visible = true;
            this.gcEmail.VisibleIndex = 8;
            // 
            // gcPosition
            // 
            this.gcPosition.Caption = "Chức vụ";
            this.gcPosition.FieldName = "PostName";
            this.gcPosition.Name = "gcPosition";
            this.gcPosition.Visible = true;
            this.gcPosition.VisibleIndex = 9;
            // 
            // gcSection
            // 
            this.gcSection.Caption = "Phòng ban";
            this.gcSection.FieldName = "SectionName";
            this.gcSection.Name = "gcSection";
            this.gcSection.Visible = true;
            this.gcSection.VisibleIndex = 10;
            // 
            // gcDateStart
            // 
            this.gcDateStart.Caption = "Ngày bắt đầu";
            this.gcDateStart.FieldName = "StartDate";
            this.gcDateStart.Name = "gcDateStart";
            // 
            // gcEndDate
            // 
            this.gcEndDate.Caption = "Ngày kết thúc";
            this.gcEndDate.FieldName = "EndDate";
            this.gcEndDate.Name = "gcEndDate";
            // 
            // gcManagerID
            // 
            this.gcManagerID.Caption = "Tên nhân viên quản lý";
            this.gcManagerID.FieldName = "ManagerID";
            this.gcManagerID.Name = "gcManagerID";
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // UcEmployees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcEmployees);
            this.Controls.Add(this.panelControl1);
            this.Name = "UcEmployees";
            this.Size = new System.Drawing.Size(1090, 578);
            this.Load += new System.EventHandler(this.ucEmployees_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkupManID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBirth.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBirth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImageStaff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOnlineStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCardID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStaffID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PanelControl panelControl1;
        private TextEdit txtCardID;
        private LabelControl labelControl5;
        private TextEdit txtName;
        private TextEdit txtStaffID;
        private LabelControl labelControl2;
        private LabelControl labelControl1;
        private RadioButton rbNu;
        private RadioButton rbNam;
        private TextEdit txtAddress;
        private TextEdit txtPhone;
        private LabelControl labelControl3;
        private LabelControl labelControl7;
        private PictureBox picImageStaff;
        private LabelControl labelControl14;
        private LabelControl labelControl15;
        private LabelControl labelControl13;
        private LabelControl labelControl8;
        private LabelControl labelControl9;
        private LabelControl labelControl10;
        private LabelControl labelControl11;
        private DateEdit dateEnd;
        private DateEdit dateStart;
        private DateEdit dateBirth;
        private LabelControl labelControl6;
        private GridControl gcEmployees;
        private GridView gridView1;
        private GroupBox groupBox1;
        private LabelControl labelControl4;
        private ComboBox cbbPost;
        private ComboBox cbbSection;
        private ComboBox cbbEducation;
        private GridColumn gcoGender;
        private GridColumn gcStaffID;
        private GridColumn gcStaffName;
        private GridColumn gcBirthDay;
        private GridColumn gcCardID;
        private GridColumn gcPhone;
        private GridColumn gcAddress;
        private GridColumn gcEducation;
        private GridColumn gcEmail;
        private GridColumn gcPosition;
        private GridColumn gcSection;
        private GroupControl groupControl2;
        private SimpleButton btnDelete;
        private SimpleButton btnCancel;
        private SimpleButton btnEdit;
        private SimpleButton btnAdd;
        private SimpleButton btnSave;
        private GridColumn gcDateStart;
        private GridColumn gcEndDate;
        private GridColumn gcManagerID;
        private DXErrorProvider dxErrorProvider;
        private TextEdit txtMail;
        private LookUpEdit lkupManID;
        private TextEdit txtOnlineStatus;
        private LabelControl lblTitleOnlineStatus;
    }
}
