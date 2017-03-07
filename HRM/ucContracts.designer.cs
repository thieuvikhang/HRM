namespace HRM
{
    partial class ucContract
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucContract));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
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
            this.Contractgrid = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel1.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.Contractgrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.panel1.Controls.Add(this.groupControl2);
            this.panel1.Controls.Add(this.dateSign);
            this.panel1.Controls.Add(this.dateStart);
            this.panel1.Controls.Add(this.dateEnd);
            this.panel1.Controls.Add(this.cbbStatus);
            this.panel1.Controls.Add(this.cbbCurrency);
            this.panel1.Controls.Add(this.cbbPayment);
            this.panel1.Controls.Add(this.cbbContractTypeID);
            this.panel1.Controls.Add(this.cbbStaffID);
            this.panel1.Controls.Add(this.mmNote);
            this.panel1.Controls.Add(this.labelControl10);
            this.panel1.Controls.Add(this.txtBasicPay);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Controls.Add(this.labelControl11);
            this.panel1.Controls.Add(this.labelControl6);
            this.panel1.Controls.Add(this.labelControl7);
            this.panel1.Controls.Add(this.labelControl8);
            this.panel1.Controls.Add(this.labelControl9);
            this.panel1.Controls.Add(this.labelControl4);
            this.panel1.Controls.Add(this.labelControl5);
            this.panel1.Controls.Add(this.txtContractID);
            this.panel1.Controls.Add(this.labelControl2);
            this.panel1.Controls.Add(this.labelControl3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(821, 238);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnEdit);
            this.groupControl2.Controls.Add(this.btnDelete);
            this.groupControl2.Controls.Add(this.btnAdd);
            this.groupControl2.Location = new System.Drawing.Point(301, 165);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(277, 63);
            this.groupControl2.TabIndex = 46;
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
            // 
            // dateSign
            // 
            this.dateSign.EditValue = null;
            this.dateSign.Location = new System.Drawing.Point(131, 103);
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
            this.dateStart.EditValue = null;
            this.dateStart.Location = new System.Drawing.Point(415, 25);
            this.dateStart.Name = "dateStart";
            this.dateStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateStart.Size = new System.Drawing.Size(163, 20);
            this.dateStart.TabIndex = 38;
            // 
            // dateEnd
            // 
            this.dateEnd.EditValue = null;
            this.dateEnd.Location = new System.Drawing.Point(415, 51);
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
            this.cbbStatus.Location = new System.Drawing.Point(131, 129);
            this.cbbStatus.Name = "cbbStatus";
            this.cbbStatus.Size = new System.Drawing.Size(163, 21);
            this.cbbStatus.TabIndex = 35;
            // 
            // cbbCurrency
            // 
            this.cbbCurrency.FormattingEnabled = true;
            this.cbbCurrency.Location = new System.Drawing.Point(415, 129);
            this.cbbCurrency.Name = "cbbCurrency";
            this.cbbCurrency.Size = new System.Drawing.Size(163, 21);
            this.cbbCurrency.TabIndex = 34;
            // 
            // cbbPayment
            // 
            this.cbbPayment.FormattingEnabled = true;
            this.cbbPayment.Location = new System.Drawing.Point(415, 76);
            this.cbbPayment.Name = "cbbPayment";
            this.cbbPayment.Size = new System.Drawing.Size(163, 21);
            this.cbbPayment.TabIndex = 33;
            // 
            // cbbContractTypeID
            // 
            this.cbbContractTypeID.FormattingEnabled = true;
            this.cbbContractTypeID.Location = new System.Drawing.Point(131, 76);
            this.cbbContractTypeID.Name = "cbbContractTypeID";
            this.cbbContractTypeID.Size = new System.Drawing.Size(163, 21);
            this.cbbContractTypeID.TabIndex = 32;
            // 
            // cbbStaffID
            // 
            this.cbbStaffID.FormattingEnabled = true;
            this.cbbStaffID.Location = new System.Drawing.Point(131, 50);
            this.cbbStaffID.Name = "cbbStaffID";
            this.cbbStaffID.Size = new System.Drawing.Size(163, 21);
            this.cbbStaffID.TabIndex = 31;
            // 
            // mmNote
            // 
            this.mmNote.Location = new System.Drawing.Point(632, 29);
            this.mmNote.Name = "mmNote";
            this.mmNote.Size = new System.Drawing.Size(167, 121);
            this.mmNote.TabIndex = 30;
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl10.Location = new System.Drawing.Point(360, 130);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(48, 16);
            this.labelControl10.TabIndex = 28;
            this.labelControl10.Text = "Loại tiền";
            // 
            // txtBasicPay
            // 
            this.txtBasicPay.Location = new System.Drawing.Point(415, 103);
            this.txtBasicPay.Name = "txtBasicPay";
            this.txtBasicPay.Size = new System.Drawing.Size(163, 20);
            this.txtBasicPay.TabIndex = 27;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl1.Location = new System.Drawing.Point(331, 104);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(77, 16);
            this.labelControl1.TabIndex = 26;
            this.labelControl1.Text = "Lương cơ bản";
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl11.Location = new System.Drawing.Point(64, 130);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(59, 16);
            this.labelControl11.TabIndex = 24;
            this.labelControl11.Text = "Tình trạng";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl6.Location = new System.Drawing.Point(584, 29);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(42, 16);
            this.labelControl6.TabIndex = 19;
            this.labelControl6.Text = "Ghi chú";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl7.Location = new System.Drawing.Point(334, 78);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(74, 16);
            this.labelControl7.TabIndex = 18;
            this.labelControl7.Text = "Hình thức trả";
            this.labelControl7.Click += new System.EventHandler(this.labelControl7_Click);
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl8.Location = new System.Drawing.Point(43, 78);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(80, 16);
            this.labelControl8.TabIndex = 15;
            this.labelControl8.Text = "Loại hợp đồng";
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl9.Location = new System.Drawing.Point(42, 52);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(81, 16);
            this.labelControl9.TabIndex = 14;
            this.labelControl9.Text = "Tên nhân viên";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl4.Location = new System.Drawing.Point(331, 52);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(77, 16);
            this.labelControl4.TabIndex = 11;
            this.labelControl4.Text = "Ngày kết thúc";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl5.Location = new System.Drawing.Point(333, 26);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(75, 16);
            this.labelControl5.TabIndex = 10;
            this.labelControl5.Text = "Ngày bắt đầu";
            // 
            // txtContractID
            // 
            this.txtContractID.Location = new System.Drawing.Point(131, 25);
            this.txtContractID.Name = "txtContractID";
            this.txtContractID.Size = new System.Drawing.Size(163, 20);
            this.txtContractID.TabIndex = 8;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl2.Location = new System.Drawing.Point(74, 104);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(49, 16);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Ngày lập";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl3.Location = new System.Drawing.Point(49, 26);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(74, 16);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Mã hợp đồng";
            // 
            // Contractgrid
            // 
            this.Contractgrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Contractgrid.Location = new System.Drawing.Point(0, 238);
            this.Contractgrid.MainView = this.gridView1;
            this.Contractgrid.Name = "Contractgrid";
            this.Contractgrid.Size = new System.Drawing.Size(821, 168);
            this.Contractgrid.TabIndex = 1;
            this.Contractgrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.Contractgrid;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            // 
            // ucContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Contractgrid);
            this.Controls.Add(this.panel1);
            this.Name = "ucContract";
            this.Size = new System.Drawing.Size(821, 406);
            this.Load += new System.EventHandler(this.ucContract_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.Contractgrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl Contractgrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtContractID;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit dateSign;
        private DevExpress.XtraEditors.DateEdit dateStart;
        private DevExpress.XtraEditors.DateEdit dateEnd;
        private System.Windows.Forms.ComboBox cbbStatus;
        private System.Windows.Forms.ComboBox cbbCurrency;
        private System.Windows.Forms.ComboBox cbbPayment;
        private System.Windows.Forms.ComboBox cbbContractTypeID;
        private System.Windows.Forms.ComboBox cbbStaffID;
        private DevExpress.XtraEditors.MemoEdit mmNote;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.TextEdit txtBasicPay;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
    }
}
