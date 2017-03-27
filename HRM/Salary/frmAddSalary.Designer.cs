using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using ComboBox = System.Windows.Forms.ComboBox;

namespace HRM.Salary
{
    partial class FrmAddSalary
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        ///
        private void InitializeComponent()
        {
            this.windowsUIButton = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.label3 = new System.Windows.Forms.Label();
            this.gcAddSalary = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcStaffId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbbChonThang = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbChonPB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.txtPhuCap = new System.Windows.Forms.NumericUpDown();
            this.txtChonNV = new DevExpress.XtraEditors.TextEdit();
            this.label14 = new System.Windows.Forms.Label();
            this.txtSoNgayNghi = new DevExpress.XtraEditors.TextEdit();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSoNgayCong = new DevExpress.XtraEditors.TextEdit();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLuongThucLanh = new DevExpress.XtraEditors.TextEdit();
            this.txtLuongHD = new DevExpress.XtraEditors.TextEdit();
            this.txtLuongCoBan = new DevExpress.XtraEditors.TextEdit();
            this.txtBHXH = new DevExpress.XtraEditors.TextEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGhiChu = new DevExpress.XtraEditors.MemoEdit();
            this.txtNgayCongQuyDinh = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPhongBan = new DevExpress.XtraEditors.TextEdit();
            this.label12 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcAddSalary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhuCap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChonNV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoNgayNghi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoNgayCong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLuongThucLanh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLuongHD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLuongCoBan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBHXH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayCongQuyDinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhongBan.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // windowsUIButton
            // 
            this.windowsUIButton.AppearanceButton.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.windowsUIButton.AppearanceButton.Hovered.FontSizeDelta = -1;
            this.windowsUIButton.AppearanceButton.Hovered.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.windowsUIButton.AppearanceButton.Hovered.Options.UseBackColor = true;
            this.windowsUIButton.AppearanceButton.Hovered.Options.UseFont = true;
            this.windowsUIButton.AppearanceButton.Hovered.Options.UseForeColor = true;
            this.windowsUIButton.AppearanceButton.Normal.FontSizeDelta = -1;
            this.windowsUIButton.AppearanceButton.Normal.Options.UseFont = true;
            this.windowsUIButton.AppearanceButton.Pressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
            this.windowsUIButton.AppearanceButton.Pressed.FontSizeDelta = -1;
            this.windowsUIButton.AppearanceButton.Pressed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
            this.windowsUIButton.AppearanceButton.Pressed.Options.UseBackColor = true;
            this.windowsUIButton.AppearanceButton.Pressed.Options.UseFont = true;
            this.windowsUIButton.AppearanceButton.Pressed.Options.UseForeColor = true;
            this.windowsUIButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            this.windowsUIButton.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Lưu", "Save;Size32x32;GrayScaled", DevExpress.XtraBars.Docking2010.ImageLocation.Default, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", true, -1, true, null, true, false, true, null, "tagSave", -1, false, false),
            new DevExpress.XtraBars.Docking2010.WindowsUISeparator(),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Lưu và Thoát", "SaveAndClose;Size32x32;GrayScaled", DevExpress.XtraBars.Docking2010.ImageLocation.Default, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", true, -1, true, null, true, false, true, null, "tagSaveAndClose", -1, false, false),
            new DevExpress.XtraBars.Docking2010.WindowsUISeparator(),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Xóa trắng", "Reset;Size32x32;GrayScaled", DevExpress.XtraBars.Docking2010.ImageLocation.Default, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", true, -1, true, null, true, false, true, null, "tagReset", -1, false, false),
            new DevExpress.XtraBars.Docking2010.WindowsUISeparator(),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Thoát", "Delete", DevExpress.XtraBars.Docking2010.ImageLocation.Default, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", true, -1, true, null, true, false, true, null, "tagThoat", -1, false, false)});
            this.windowsUIButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.windowsUIButton.EnableImageTransparency = true;
            this.windowsUIButton.ForeColor = System.Drawing.Color.White;
            this.windowsUIButton.Location = new System.Drawing.Point(0, 536);
            this.windowsUIButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.windowsUIButton.MaximumSize = new System.Drawing.Size(0, 60);
            this.windowsUIButton.MinimumSize = new System.Drawing.Size(60, 60);
            this.windowsUIButton.Name = "windowsUIButton";
            this.windowsUIButton.Size = new System.Drawing.Size(957, 60);
            this.windowsUIButton.TabIndex = 3;
            this.windowsUIButton.Text = "windowsUIButtonPanelMain";
            this.windowsUIButton.UseButtonBackgroundImages = false;
            this.windowsUIButton.ButtonClick += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(this.windowsUIButton_ButtonClick);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.gcAddSalary);
            this.groupControl1.Controls.Add(this.cbbChonThang);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.cbbChonPB);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(289, 536);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Chọn nhân viên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(54, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 19);
            this.label3.TabIndex = 47;
            this.label3.Text = "Nhân viên chưa tính lương";
            // 
            // gcAddSalary
            // 
            this.gcAddSalary.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gcAddSalary.Location = new System.Drawing.Point(2, 143);
            this.gcAddSalary.MainView = this.gridView1;
            this.gcAddSalary.Name = "gcAddSalary";
            this.gcAddSalary.Size = new System.Drawing.Size(285, 391);
            this.gcAddSalary.TabIndex = 46;
            this.gcAddSalary.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gcAddSalary.Click += new System.EventHandler(this.gcAddSalary_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcStaffId,
            this.gridColumn2,
            this.gridColumn3});
            this.gridView1.GridControl = this.gcAddSalary;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            // 
            // gcStaffId
            // 
            this.gcStaffId.Caption = "Mã nhân viên";
            this.gcStaffId.FieldName = "StaffID";
            this.gcStaffId.Name = "gcStaffId";
            this.gcStaffId.Visible = true;
            this.gcStaffId.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tên nhân viên";
            this.gridColumn2.FieldName = "StaffName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Phòng ban";
            this.gridColumn3.FieldName = "SectionName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // cbbChonThang
            // 
            this.cbbChonThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbChonThang.FormattingEnabled = true;
            this.cbbChonThang.Location = new System.Drawing.Point(85, 70);
            this.cbbChonThang.Name = "cbbChonThang";
            this.cbbChonThang.Size = new System.Drawing.Size(186, 21);
            this.cbbChonThang.TabIndex = 3;
            this.cbbChonThang.TextChanged += new System.EventHandler(this.cbbChonThang_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Chọn tháng:";
            // 
            // cbbChonPB
            // 
            this.cbbChonPB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbChonPB.FormattingEnabled = true;
            this.cbbChonPB.Location = new System.Drawing.Point(85, 34);
            this.cbbChonPB.Name = "cbbChonPB";
            this.cbbChonPB.Size = new System.Drawing.Size(186, 21);
            this.cbbChonPB.TabIndex = 1;
            this.cbbChonPB.TextChanged += new System.EventHandler(this.cbbChonPB_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn PB:";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.txtPhuCap);
            this.groupControl2.Controls.Add(this.txtChonNV);
            this.groupControl2.Controls.Add(this.label14);
            this.groupControl2.Controls.Add(this.txtSoNgayNghi);
            this.groupControl2.Controls.Add(this.label13);
            this.groupControl2.Controls.Add(this.txtSoNgayCong);
            this.groupControl2.Controls.Add(this.label11);
            this.groupControl2.Controls.Add(this.label10);
            this.groupControl2.Controls.Add(this.label9);
            this.groupControl2.Controls.Add(this.label8);
            this.groupControl2.Controls.Add(this.txtLuongThucLanh);
            this.groupControl2.Controls.Add(this.txtLuongHD);
            this.groupControl2.Controls.Add(this.txtLuongCoBan);
            this.groupControl2.Controls.Add(this.txtBHXH);
            this.groupControl2.Controls.Add(this.label7);
            this.groupControl2.Controls.Add(this.label6);
            this.groupControl2.Controls.Add(this.txtGhiChu);
            this.groupControl2.Controls.Add(this.txtNgayCongQuyDinh);
            this.groupControl2.Controls.Add(this.label5);
            this.groupControl2.Controls.Add(this.txtPhongBan);
            this.groupControl2.Controls.Add(this.label12);
            this.groupControl2.Controls.Add(this.label4);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupControl2.Location = new System.Drawing.Point(293, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(664, 536);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "Thêm lương";
            // 
            // txtPhuCap
            // 
            this.txtPhuCap.Location = new System.Drawing.Point(96, 236);
            this.txtPhuCap.Maximum = new decimal(new int[] {
            99000000,
            0,
            0,
            0});
            this.txtPhuCap.Name = "txtPhuCap";
            this.txtPhuCap.Size = new System.Drawing.Size(220, 21);
            this.txtPhuCap.TabIndex = 1;
            this.txtPhuCap.ValueChanged += new System.EventHandler(this.txtPhuCap_ValueChanged);
            this.txtPhuCap.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhuCap_KeyPress);
            // 
            // txtChonNV
            // 
            this.txtChonNV.Enabled = false;
            this.txtChonNV.Location = new System.Drawing.Point(96, 37);
            this.txtChonNV.Name = "txtChonNV";
            this.txtChonNV.Size = new System.Drawing.Size(220, 20);
            this.txtChonNV.TabIndex = 76;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(334, 174);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 13);
            this.label14.TabIndex = 75;
            this.label14.Text = "Số ngày nghĩ:";
            // 
            // txtSoNgayNghi
            // 
            this.txtSoNgayNghi.Enabled = false;
            this.txtSoNgayNghi.Location = new System.Drawing.Point(424, 171);
            this.txtSoNgayNghi.Name = "txtSoNgayNghi";
            this.txtSoNgayNghi.Size = new System.Drawing.Size(220, 20);
            this.txtSoNgayNghi.TabIndex = 74;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 174);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 13);
            this.label13.TabIndex = 73;
            this.label13.Text = "Số ngày công:";
            // 
            // txtSoNgayCong
            // 
            this.txtSoNgayCong.Enabled = false;
            this.txtSoNgayCong.Location = new System.Drawing.Point(96, 171);
            this.txtSoNgayCong.Name = "txtSoNgayCong";
            this.txtSoNgayCong.Size = new System.Drawing.Size(220, 20);
            this.txtSoNgayCong.TabIndex = 72;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 108);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 13);
            this.label11.TabIndex = 71;
            this.label11.Text = "Lương HĐ:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 419);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 13);
            this.label10.TabIndex = 70;
            this.label10.Text = "Lương cơ bản:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(334, 419);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 69;
            this.label9.Text = "BHXH:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(282, 480);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 13);
            this.label8.TabIndex = 68;
            this.label8.Text = "Lương thực lãnh:";
            // 
            // txtLuongThucLanh
            // 
            this.txtLuongThucLanh.Enabled = false;
            this.txtLuongThucLanh.Location = new System.Drawing.Point(424, 477);
            this.txtLuongThucLanh.Name = "txtLuongThucLanh";
            this.txtLuongThucLanh.Size = new System.Drawing.Size(220, 20);
            this.txtLuongThucLanh.TabIndex = 67;
            // 
            // txtLuongHD
            // 
            this.txtLuongHD.Enabled = false;
            this.txtLuongHD.Location = new System.Drawing.Point(96, 105);
            this.txtLuongHD.Name = "txtLuongHD";
            this.txtLuongHD.Size = new System.Drawing.Size(220, 20);
            this.txtLuongHD.TabIndex = 66;
            // 
            // txtLuongCoBan
            // 
            this.txtLuongCoBan.Enabled = false;
            this.txtLuongCoBan.Location = new System.Drawing.Point(96, 416);
            this.txtLuongCoBan.Name = "txtLuongCoBan";
            this.txtLuongCoBan.Size = new System.Drawing.Size(232, 20);
            this.txtLuongCoBan.TabIndex = 65;
            // 
            // txtBHXH
            // 
            this.txtBHXH.Enabled = false;
            this.txtBHXH.Location = new System.Drawing.Point(424, 416);
            this.txtBHXH.Name = "txtBHXH";
            this.txtBHXH.Size = new System.Drawing.Size(220, 20);
            this.txtBHXH.TabIndex = 64;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 238);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 63;
            this.label7.Text = "Phụ cấp:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 326);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 61;
            this.label6.Text = "Ghi chú:";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGhiChu.Location = new System.Drawing.Point(96, 274);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(548, 121);
            this.txtGhiChu.TabIndex = 2;
            this.txtGhiChu.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtGhiChu_EditValueChanging);
            // 
            // txtNgayCongQuyDinh
            // 
            this.txtNgayCongQuyDinh.Enabled = false;
            this.txtNgayCongQuyDinh.Location = new System.Drawing.Point(424, 105);
            this.txtNgayCongQuyDinh.Name = "txtNgayCongQuyDinh";
            this.txtNgayCongQuyDinh.Size = new System.Drawing.Size(220, 20);
            this.txtNgayCongQuyDinh.TabIndex = 59;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(334, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 58;
            this.label5.Text = "Ngày công QĐ:";
            // 
            // txtPhongBan
            // 
            this.txtPhongBan.Enabled = false;
            this.txtPhongBan.Location = new System.Drawing.Point(424, 37);
            this.txtPhongBan.Name = "txtPhongBan";
            this.txtPhongBan.Size = new System.Drawing.Size(220, 20);
            this.txtPhongBan.TabIndex = 57;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(334, 40);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 13);
            this.label12.TabIndex = 56;
            this.label12.Text = "Phòng ban:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 48;
            this.label4.Text = "Chọn NV:";
            // 
            // FrmAddSalary
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(957, 596);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.windowsUIButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddSalary";
            this.Load += new System.EventHandler(this.frmAddSalary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcAddSalary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhuCap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChonNV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoNgayNghi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoNgayCong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLuongThucLanh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLuongHD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLuongCoBan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBHXH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayCongQuyDinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhongBan.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private WindowsUIButtonPanel windowsUIButton;
        private GroupControl groupControl1;
        private ComboBox cbbChonThang;
        private Label label2;
        private ComboBox cbbChonPB;
        private Label label1;
        private GroupControl groupControl2;
        private GridControl gcAddSalary;
        private GridView gridView1;
        private GridColumn gcStaffId;
        private GridColumn gridColumn2;
        private GridColumn gridColumn3;
        private Label label3;
        private Label label12;
        private Label label4;
        private Label label5;
        private TextEdit txtPhongBan;
        private TextEdit txtNgayCongQuyDinh;
        private Label label14;
        private TextEdit txtSoNgayNghi;
        private Label label13;
        private TextEdit txtSoNgayCong;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private TextEdit txtLuongThucLanh;
        private TextEdit txtLuongHD;
        private TextEdit txtLuongCoBan;
        private TextEdit txtBHXH;
        private Label label7;
        private Label label6;
        private MemoEdit txtGhiChu;
        private TextEdit txtChonNV;
        private NumericUpDown txtPhuCap;
    }

}