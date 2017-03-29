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
    partial class UcContract
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcContract));
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnKiemTraLoi = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.dateSign = new DevExpress.XtraEditors.DateEdit();
            this.dateStart = new DevExpress.XtraEditors.DateEdit();
            this.dateEnd = new DevExpress.XtraEditors.DateEdit();
            this.cbbStatus = new System.Windows.Forms.ComboBox();
            this.cbbCurrency = new System.Windows.Forms.ComboBox();
            this.cbbPayment = new System.Windows.Forms.ComboBox();
            this.cbbContractTypeID = new System.Windows.Forms.ComboBox();
            this.cbbStaffID = new System.Windows.Forms.ComboBox();
            this.mmNote = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.txtBasicPay = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtContractID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.grbxThongTin = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblThongBao2 = new System.Windows.Forms.Label();
            this.lblThongBao1 = new System.Windows.Forms.Label();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.lblThucHienCN = new DevExpress.XtraEditors.LabelControl();
            this.gcContract = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcoContractID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcoDateSign = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcoDateStart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcoDateEnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.gridCoName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateSign.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateSign.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBasicPay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContractID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.grbxThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcContract)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnCancel);
            this.groupControl2.Controls.Add(this.btnEdit);
            this.groupControl2.Controls.Add(this.btnSave);
            this.groupControl2.Controls.Add(this.btnKiemTraLoi);
            this.groupControl2.Controls.Add(this.btnDelete);
            this.groupControl2.Controls.Add(this.btnAdd);
            this.groupControl2.Location = new System.Drawing.Point(5, 167);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(582, 63);
            this.groupControl2.TabIndex = 46;
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(490, 23);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 34);
            this.btnCancel.TabIndex = 53;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
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
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(399, 23);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 34);
            this.btnSave.TabIndex = 52;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // btnKiemTraLoi
            // 
            this.btnKiemTraLoi.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnKiemTraLoi.Appearance.Options.UseFont = true;
            this.btnKiemTraLoi.Image = ((System.Drawing.Image)(resources.GetObject("btnKiemTraLoi.Image")));
            this.btnKiemTraLoi.Location = new System.Drawing.Point(278, 24);
            this.btnKiemTraLoi.Name = "btnKiemTraLoi";
            this.btnKiemTraLoi.Size = new System.Drawing.Size(115, 34);
            this.btnKiemTraLoi.TabIndex = 1;
            this.btnKiemTraLoi.Text = "Kiểm tra";
            this.btnKiemTraLoi.Click += new System.EventHandler(this.btnKiemTraLoi_Click);
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
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dateSign
            // 
            this.dateSign.EditValue = new System.DateTime(((long)(0)));
            this.dateSign.Location = new System.Drawing.Point(100, 98);
            this.dateSign.Name = "dateSign";
            this.dateSign.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateSign.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateSign.Size = new System.Drawing.Size(163, 20);
            this.dateSign.TabIndex = 39;
            // 
            // dateStart
            // 
            this.dateStart.EditValue = new System.DateTime(((long)(0)));
            this.dateStart.Location = new System.Drawing.Point(384, 20);
            this.dateStart.Name = "dateStart";
            this.dateStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateStart.Size = new System.Drawing.Size(163, 20);
            this.dateStart.TabIndex = 38;
            this.dateStart.TextChanged += new System.EventHandler(this.dateStart_TextChanged);
            // 
            // dateEnd
            // 
            this.dateEnd.EditValue = new System.DateTime(((long)(0)));
            this.dateEnd.Location = new System.Drawing.Point(384, 46);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEnd.Size = new System.Drawing.Size(163, 20);
            this.dateEnd.TabIndex = 37;
            // 
            // cbbStatus
            // 
            this.cbbStatus.FormattingEnabled = true;
            this.cbbStatus.Items.AddRange(new object[] {
            "còn",
            "hết"});
            this.cbbStatus.Location = new System.Drawing.Point(100, 124);
            this.cbbStatus.Name = "cbbStatus";
            this.cbbStatus.Size = new System.Drawing.Size(163, 21);
            this.cbbStatus.TabIndex = 35;
            this.cbbStatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbStatus_KeyPress);
            this.cbbStatus.Leave += new System.EventHandler(this.cbbStatus_Leave);
            // 
            // cbbCurrency
            // 
            this.cbbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCurrency.FormattingEnabled = true;
            this.cbbCurrency.Items.AddRange(new object[] {
            "VND",
            "USD"});
            this.cbbCurrency.Location = new System.Drawing.Point(384, 124);
            this.cbbCurrency.Name = "cbbCurrency";
            this.cbbCurrency.Size = new System.Drawing.Size(163, 21);
            this.cbbCurrency.TabIndex = 34;
            this.cbbCurrency.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbCurrency_KeyPress);
            this.cbbCurrency.Leave += new System.EventHandler(this.cbbCurrency_Leave);
            // 
            // cbbPayment
            // 
            this.cbbPayment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbPayment.FormattingEnabled = true;
            this.cbbPayment.Items.AddRange(new object[] {
            "Tiền mặt",
            "Qua ATM"});
            this.cbbPayment.Location = new System.Drawing.Point(384, 71);
            this.cbbPayment.Name = "cbbPayment";
            this.cbbPayment.Size = new System.Drawing.Size(163, 21);
            this.cbbPayment.TabIndex = 33;
            this.cbbPayment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbPayment_KeyPress);
            this.cbbPayment.Leave += new System.EventHandler(this.cbbPayment_Leave);
            // 
            // cbbContractTypeID
            // 
            this.cbbContractTypeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbContractTypeID.FormattingEnabled = true;
            this.cbbContractTypeID.Location = new System.Drawing.Point(100, 71);
            this.cbbContractTypeID.Name = "cbbContractTypeID";
            this.cbbContractTypeID.Size = new System.Drawing.Size(163, 21);
            this.cbbContractTypeID.TabIndex = 32;
            this.cbbContractTypeID.SelectionChangeCommitted += new System.EventHandler(this.cbbContractTypeID_SelectionChangeCommitted);
            // 
            // cbbStaffID
            // 
            this.cbbStaffID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbStaffID.FormattingEnabled = true;
            this.cbbStaffID.Location = new System.Drawing.Point(100, 45);
            this.cbbStaffID.Name = "cbbStaffID";
            this.cbbStaffID.Size = new System.Drawing.Size(163, 21);
            this.cbbStaffID.TabIndex = 31;
            this.cbbStaffID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbStaffID_KeyPress);
            this.cbbStaffID.Leave += new System.EventHandler(this.cbbStaffID_Leave);
            // 
            // mmNote
            // 
            this.mmNote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mmNote.Location = new System.Drawing.Point(601, 24);
            this.mmNote.Name = "mmNote";
            this.mmNote.Size = new System.Drawing.Size(200, 117);
            this.mmNote.TabIndex = 30;
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl10.Location = new System.Drawing.Point(329, 125);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(48, 16);
            this.labelControl10.TabIndex = 28;
            this.labelControl10.Text = "Loại tiền";
            // 
            // txtBasicPay
            // 
            this.txtBasicPay.Location = new System.Drawing.Point(384, 98);
            this.txtBasicPay.Name = "txtBasicPay";
            this.txtBasicPay.Size = new System.Drawing.Size(163, 20);
            this.txtBasicPay.TabIndex = 27;
            this.txtBasicPay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBasicPay_KeyDown);
            this.txtBasicPay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBasicPay_KeyPress);
            this.txtBasicPay.Leave += new System.EventHandler(this.txtBasicPay_Leave);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl1.Location = new System.Drawing.Point(300, 99);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(77, 16);
            this.labelControl1.TabIndex = 26;
            this.labelControl1.Text = "Lương cơ bản";
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl11.Location = new System.Drawing.Point(33, 125);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(59, 16);
            this.labelControl11.TabIndex = 24;
            this.labelControl11.Text = "Tình trạng";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl6.Location = new System.Drawing.Point(553, 24);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(42, 16);
            this.labelControl6.TabIndex = 19;
            this.labelControl6.Text = "Ghi chú";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl7.Location = new System.Drawing.Point(303, 73);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(74, 16);
            this.labelControl7.TabIndex = 18;
            this.labelControl7.Text = "Hình thức trả";
            this.labelControl7.Click += new System.EventHandler(this.labelControl7_Click);
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl8.Location = new System.Drawing.Point(12, 73);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(80, 16);
            this.labelControl8.TabIndex = 15;
            this.labelControl8.Text = "Loại hợp đồng";
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl9.Location = new System.Drawing.Point(11, 47);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(81, 16);
            this.labelControl9.TabIndex = 14;
            this.labelControl9.Text = "Tên nhân viên";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl4.Location = new System.Drawing.Point(300, 47);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(77, 16);
            this.labelControl4.TabIndex = 11;
            this.labelControl4.Text = "Ngày kết thúc";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl5.Location = new System.Drawing.Point(302, 21);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(75, 16);
            this.labelControl5.TabIndex = 10;
            this.labelControl5.Text = "Ngày bắt đầu";
            // 
            // txtContractID
            // 
            this.txtContractID.Location = new System.Drawing.Point(100, 20);
            this.txtContractID.Name = "txtContractID";
            this.txtContractID.Size = new System.Drawing.Size(163, 20);
            this.txtContractID.TabIndex = 8;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl2.Location = new System.Drawing.Point(43, 99);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(49, 16);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Ngày lập";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl3.Location = new System.Drawing.Point(18, 21);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(74, 16);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Mã hợp đồng";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.grbxThongTin);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.lblThongBao2);
            this.panelControl1.Controls.Add(this.lblThongBao1);
            this.panelControl1.Controls.Add(this.lblThongBao);
            this.panelControl1.Controls.Add(this.groupControl2);
            this.panelControl1.Controls.Add(this.lblThucHienCN);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(835, 262);
            this.panelControl1.TabIndex = 47;
            this.panelControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControl1_Paint);
            // 
            // grbxThongTin
            // 
            this.grbxThongTin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbxThongTin.Controls.Add(this.txtContractID);
            this.grbxThongTin.Controls.Add(this.labelControl4);
            this.grbxThongTin.Controls.Add(this.dateStart);
            this.grbxThongTin.Controls.Add(this.cbbContractTypeID);
            this.grbxThongTin.Controls.Add(this.cbbPayment);
            this.grbxThongTin.Controls.Add(this.labelControl1);
            this.grbxThongTin.Controls.Add(this.labelControl9);
            this.grbxThongTin.Controls.Add(this.dateSign);
            this.grbxThongTin.Controls.Add(this.labelControl5);
            this.grbxThongTin.Controls.Add(this.labelControl11);
            this.grbxThongTin.Controls.Add(this.cbbStaffID);
            this.grbxThongTin.Controls.Add(this.txtBasicPay);
            this.grbxThongTin.Controls.Add(this.cbbCurrency);
            this.grbxThongTin.Controls.Add(this.labelControl3);
            this.grbxThongTin.Controls.Add(this.labelControl8);
            this.grbxThongTin.Controls.Add(this.labelControl6);
            this.grbxThongTin.Controls.Add(this.mmNote);
            this.grbxThongTin.Controls.Add(this.dateEnd);
            this.grbxThongTin.Controls.Add(this.cbbStatus);
            this.grbxThongTin.Controls.Add(this.labelControl10);
            this.grbxThongTin.Controls.Add(this.labelControl7);
            this.grbxThongTin.Controls.Add(this.labelControl2);
            this.grbxThongTin.Location = new System.Drawing.Point(5, 5);
            this.grbxThongTin.Name = "grbxThongTin";
            this.grbxThongTin.Size = new System.Drawing.Size(825, 156);
            this.grbxThongTin.TabIndex = 55;
            this.grbxThongTin.TabStop = false;
            this.grbxThongTin.Text = "Thông tin";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(593, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 23);
            this.label1.TabIndex = 54;
            this.label1.Text = "THÔNG BÁO:";
            // 
            // lblThongBao2
            // 
            this.lblThongBao2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblThongBao2.AutoSize = true;
            this.lblThongBao2.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongBao2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblThongBao2.Location = new System.Drawing.Point(706, 234);
            this.lblThongBao2.Name = "lblThongBao2";
            this.lblThongBao2.Size = new System.Drawing.Size(17, 26);
            this.lblThongBao2.TabIndex = 54;
            this.lblThongBao2.Text = " ";
            // 
            // lblThongBao1
            // 
            this.lblThongBao1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblThongBao1.AutoSize = true;
            this.lblThongBao1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongBao1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblThongBao1.Location = new System.Drawing.Point(706, 199);
            this.lblThongBao1.Name = "lblThongBao1";
            this.lblThongBao1.Size = new System.Drawing.Size(17, 26);
            this.lblThongBao1.TabIndex = 54;
            this.lblThongBao1.Text = " ";
            // 
            // lblThongBao
            // 
            this.lblThongBao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblThongBao.AutoSize = true;
            this.lblThongBao.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblThongBao.Location = new System.Drawing.Point(706, 167);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(17, 26);
            this.lblThongBao.TabIndex = 54;
            this.lblThongBao.Text = " ";
            // 
            // lblThucHienCN
            // 
            this.lblThucHienCN.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblThucHienCN.Location = new System.Drawing.Point(5, 233);
            this.lblThucHienCN.Name = "lblThucHienCN";
            this.lblThucHienCN.Size = new System.Drawing.Size(36, 23);
            this.lblThucHienCN.TabIndex = 24;
            this.lblThucHienCN.Text = "      ";
            // 
            // gcContract
            // 
            this.gcContract.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcContract.Location = new System.Drawing.Point(0, 262);
            this.gcContract.MainView = this.gridView1;
            this.gcContract.Name = "gcContract";
            this.gcContract.Size = new System.Drawing.Size(835, 260);
            this.gcContract.TabIndex = 48;
            this.gcContract.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gcContract.Click += new System.EventHandler(this.gcContract_Click_1);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcoContractID,
            this.gcoDateSign,
            this.gcoDateStart,
            this.gcoDateEnd,
            this.gridCoName});
            this.gridView1.GridControl = this.gcContract;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowDetailButtons = false;
            // 
            // gcoContractID
            // 
            this.gcoContractID.Caption = "Mã hợp đồng";
            this.gcoContractID.FieldName = "ContractID";
            this.gcoContractID.Name = "gcoContractID";
            this.gcoContractID.Visible = true;
            this.gcoContractID.VisibleIndex = 0;
            // 
            // gcoDateSign
            // 
            this.gcoDateSign.Caption = "Ngày lập";
            this.gcoDateSign.FieldName = "Date";
            this.gcoDateSign.Name = "gcoDateSign";
            this.gcoDateSign.Visible = true;
            this.gcoDateSign.VisibleIndex = 2;
            // 
            // gcoDateStart
            // 
            this.gcoDateStart.Caption = "Ngày bắt đầu";
            this.gcoDateStart.FieldName = "StartDate";
            this.gcoDateStart.Name = "gcoDateStart";
            this.gcoDateStart.Visible = true;
            this.gcoDateStart.VisibleIndex = 3;
            // 
            // gcoDateEnd
            // 
            this.gcoDateEnd.Caption = "Ngày kết thúc";
            this.gcoDateEnd.FieldName = "EndDate";
            this.gcoDateEnd.Name = "gcoDateEnd";
            this.gcoDateEnd.Visible = true;
            this.gcoDateEnd.VisibleIndex = 4;
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // gridCoName
            // 
            this.gridCoName.Caption = "Tên NV";
            this.gridCoName.Name = "gridCoName";
            this.gridCoName.Visible = true;
            this.gridCoName.VisibleIndex = 1;
            // 
            // UcContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcContract);
            this.Controls.Add(this.panelControl1);
            this.Name = "UcContract";
            this.Size = new System.Drawing.Size(835, 522);
            this.Load += new System.EventHandler(this.ucContract_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateSign.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateSign.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBasicPay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContractID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.grbxThongTin.ResumeLayout(false);
            this.grbxThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcContract)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private LabelControl labelControl11;
        private LabelControl labelControl6;
        private LabelControl labelControl7;
        private LabelControl labelControl8;
        private LabelControl labelControl9;
        private LabelControl labelControl4;
        private LabelControl labelControl5;
        private TextEdit txtContractID;
        private LabelControl labelControl2;
        private LabelControl labelControl3;
        private DateEdit dateSign;
        private DateEdit dateStart;
        private DateEdit dateEnd;
        private ComboBox cbbStatus;
        private ComboBox cbbCurrency;
        private ComboBox cbbPayment;
        private ComboBox cbbContractTypeID;
        private ComboBox cbbStaffID;
        private MemoEdit mmNote;
        private LabelControl labelControl10;
        private TextEdit txtBasicPay;
        private LabelControl labelControl1;
        private GroupControl groupControl2;
        private SimpleButton btnEdit;
        private SimpleButton btnDelete;
        private SimpleButton btnAdd;
        private PanelControl panelControl1;
        private GridControl gcContract;
        private GridView gridView1;
        private SimpleButton btnCancel;
        private SimpleButton btnSave;
        private DXErrorProvider dxErrorProvider1;
        private Label lblThongBao;
        private GridColumn gcoContractID;
        private GridColumn gcoDateSign;
        private GridColumn gcoDateStart;
        private GridColumn gcoDateEnd;
        private GroupBox grbxThongTin;
        private Label label1;
        private SimpleButton btnKiemTraLoi;
        private Label lblThongBao2;
        private Label lblThongBao1;
        private LabelControl lblThucHienCN;
        private GridColumn gridCoName;
    }
}
