using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HRM
{
    partial class FormLogin
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
        private void InitializeComponent()
        {
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.lblThongBaoNhapMatKhau = new System.Windows.Forms.Label();
            this.lblThongBaoNhapTaiKhoan = new System.Windows.Forms.Label();
            this.labelForgot = new DevExpress.XtraEditors.LabelControl();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.txtPass = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtAcc = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAcc.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.pictureEdit1);
            this.panelControl1.Controls.Add(this.lblThongBaoNhapMatKhau);
            this.panelControl1.Controls.Add(this.lblThongBaoNhapTaiKhoan);
            this.panelControl1.Controls.Add(this.labelForgot);
            this.panelControl1.Controls.Add(this.btnLogin);
            this.panelControl1.Controls.Add(this.txtPass);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.txtAcc);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(377, 190);
            this.panelControl1.TabIndex = 0;
            this.panelControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControl1_Paint);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureEdit1.EditValue = global::HRM.Properties.Resources.admin;
            this.pictureEdit1.Location = new System.Drawing.Point(13, 13);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Properties.ZoomAccelerationFactor = 1D;
            this.pictureEdit1.Size = new System.Drawing.Size(98, 134);
            this.pictureEdit1.TabIndex = 8;
            // 
            // lblThongBaoNhapMatKhau
            // 
            this.lblThongBaoNhapMatKhau.AutoSize = true;
            this.lblThongBaoNhapMatKhau.Location = new System.Drawing.Point(121, 137);
            this.lblThongBaoNhapMatKhau.Name = "lblThongBaoNhapMatKhau";
            this.lblThongBaoNhapMatKhau.Size = new System.Drawing.Size(25, 13);
            this.lblThongBaoNhapMatKhau.TabIndex = 7;
            this.lblThongBaoNhapMatKhau.Text = "      ";
            // 
            // lblThongBaoNhapTaiKhoan
            // 
            this.lblThongBaoNhapTaiKhoan.AutoSize = true;
            this.lblThongBaoNhapTaiKhoan.Location = new System.Drawing.Point(124, 67);
            this.lblThongBaoNhapTaiKhoan.Name = "lblThongBaoNhapTaiKhoan";
            this.lblThongBaoNhapTaiKhoan.Size = new System.Drawing.Size(22, 13);
            this.lblThongBaoNhapTaiKhoan.TabIndex = 7;
            this.lblThongBaoNhapTaiKhoan.Text = "     ";
            // 
            // labelForgot
            // 
            this.labelForgot.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelForgot.Appearance.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelForgot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelForgot.Location = new System.Drawing.Point(117, 159);
            this.labelForgot.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelForgot.Name = "labelForgot";
            this.labelForgot.Size = new System.Drawing.Size(109, 18);
            this.labelForgot.TabIndex = 5;
            this.labelForgot.Text = "Quên mật khẩu?";
            this.labelForgot.Click += new System.EventHandler(this.labelForgot_Click);
            this.labelForgot.MouseLeave += new System.EventHandler(this.labelForgot_MouseLeave);
            this.labelForgot.MouseHover += new System.EventHandler(this.labelControl3_MouseHover);
            // 
            // btnLogin
            // 
            this.btnLogin.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLogin.Appearance.Options.UseFont = true;
            this.btnLogin.Location = new System.Drawing.Point(246, 143);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(110, 42);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPass
            // 
            this.txtPass.EditValue = "";
            this.txtPass.Location = new System.Drawing.Point(121, 109);
            this.txtPass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPass.Name = "txtPass";
            this.txtPass.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtPass.Properties.Appearance.Options.UseFont = true;
            this.txtPass.Properties.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(239, 24);
            this.txtPass.TabIndex = 3;
            this.txtPass.TextChanged += new System.EventHandler(this.txtPass_TextChanged);
            this.txtPass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPass_KeyPress);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl2.Location = new System.Drawing.Point(121, 83);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(61, 18);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Mật khẩu";
            // 
            // txtAcc
            // 
            this.txtAcc.Location = new System.Drawing.Point(117, 39);
            this.txtAcc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAcc.Name = "txtAcc";
            this.txtAcc.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtAcc.Properties.Appearance.Options.UseFont = true;
            this.txtAcc.Size = new System.Drawing.Size(239, 24);
            this.txtAcc.TabIndex = 1;
            this.txtAcc.TextChanged += new System.EventHandler(this.txtAcc_TextChanged);
            this.txtAcc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAcc_KeyPress_1);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl1.Location = new System.Drawing.Point(121, 13);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(64, 18);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Tài khoản";
            // 
            // FormLogin
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 190);
            this.Controls.Add(this.panelControl1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormLogin_FormClosed);
            this.Load += new System.EventHandler(this.FormLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAcc.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PanelControl panelControl1;
        private TextEdit txtPass;
        private LabelControl labelControl2;
        private TextEdit txtAcc;
        private LabelControl labelControl1;
        private SimpleButton btnLogin;
        private LabelControl labelForgot;
        private Label lblThongBaoNhapMatKhau;
        private Label lblThongBaoNhapTaiKhoan;
        private PictureEdit pictureEdit1;
    }
}