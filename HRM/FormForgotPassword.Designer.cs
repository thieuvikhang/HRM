﻿namespace HRM
{
    partial class FormForgotPassword
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.btnForgotPassword = new DevExpress.XtraEditors.SimpleButton();
            this.txtEmailStaff = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtAccName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtPhoneStaff = new DevExpress.XtraEditors.TextEdit();
            this.lblthongbao = new System.Windows.Forms.Label();
            this.lblThongBao2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmailStaff.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhoneStaff.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblThongBao2);
            this.panelControl1.Controls.Add(this.lblthongbao);
            this.panelControl1.Controls.Add(this.pictureEdit1);
            this.panelControl1.Controls.Add(this.btnForgotPassword);
            this.panelControl1.Controls.Add(this.txtPhoneStaff);
            this.panelControl1.Controls.Add(this.txtEmailStaff);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.txtAccName);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(373, 261);
            this.panelControl1.TabIndex = 1;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureEdit1.EditValue = global::HRM.Properties.Resources.admin;
            this.pictureEdit1.Location = new System.Drawing.Point(12, 12);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Properties.ZoomAccelerationFactor = 1D;
            this.pictureEdit1.Size = new System.Drawing.Size(98, 134);
            this.pictureEdit1.TabIndex = 8;
            // 
            // btnForgotPassword
            // 
            this.btnForgotPassword.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnForgotPassword.Appearance.Options.UseFont = true;
            this.btnForgotPassword.Location = new System.Drawing.Point(245, 185);
            this.btnForgotPassword.Name = "btnForgotPassword";
            this.btnForgotPassword.Size = new System.Drawing.Size(110, 42);
            this.btnForgotPassword.TabIndex = 4;
            this.btnForgotPassword.Text = "Lấy mật khẩu";
            this.btnForgotPassword.Click += new System.EventHandler(this.btnForgotPassword_Click);
            // 
            // txtEmailStaff
            // 
            this.txtEmailStaff.EditValue = "";
            this.txtEmailStaff.Location = new System.Drawing.Point(116, 154);
            this.txtEmailStaff.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEmailStaff.Name = "txtEmailStaff";
            this.txtEmailStaff.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtEmailStaff.Properties.Appearance.Options.UseFont = true;
            this.txtEmailStaff.Properties.PasswordChar = '*';
            this.txtEmailStaff.Size = new System.Drawing.Size(239, 24);
            this.txtEmailStaff.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl2.Location = new System.Drawing.Point(120, 128);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(38, 18);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Email:";
            // 
            // txtAccName
            // 
            this.txtAccName.Location = new System.Drawing.Point(116, 38);
            this.txtAccName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAccName.Name = "txtAccName";
            this.txtAccName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtAccName.Properties.Appearance.Options.UseFont = true;
            this.txtAccName.Size = new System.Drawing.Size(239, 24);
            this.txtAccName.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl1.Location = new System.Drawing.Point(120, 12);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(64, 18);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Tài khoản";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl3.Location = new System.Drawing.Point(120, 70);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(89, 18);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Số điện thoại:";
            // 
            // txtPhoneStaff
            // 
            this.txtPhoneStaff.EditValue = "";
            this.txtPhoneStaff.Location = new System.Drawing.Point(116, 96);
            this.txtPhoneStaff.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPhoneStaff.Name = "txtPhoneStaff";
            this.txtPhoneStaff.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtPhoneStaff.Properties.Appearance.Options.UseFont = true;
            this.txtPhoneStaff.Properties.PasswordChar = '*';
            this.txtPhoneStaff.Size = new System.Drawing.Size(239, 24);
            this.txtPhoneStaff.TabIndex = 3;
            // 
            // lblthongbao
            // 
            this.lblthongbao.AutoSize = true;
            this.lblthongbao.Location = new System.Drawing.Point(12, 214);
            this.lblthongbao.Name = "lblthongbao";
            this.lblthongbao.Size = new System.Drawing.Size(62, 13);
            this.lblthongbao.TabIndex = 9;
            this.lblthongbao.Text = "Thông báo:";
            // 
            // lblThongBao2
            // 
            this.lblThongBao2.AutoSize = true;
            this.lblThongBao2.Location = new System.Drawing.Point(12, 239);
            this.lblThongBao2.Name = "lblThongBao2";
            this.lblThongBao2.Size = new System.Drawing.Size(62, 13);
            this.lblThongBao2.TabIndex = 9;
            this.lblThongBao2.Text = "Thông báo:";
            // 
            // FormForgotPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 261);
            this.Controls.Add(this.panelControl1);
            this.Name = "FormForgotPassword";
            this.Text = "FormForgotPassword";
            this.Load += new System.EventHandler(this.FormForgotPassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmailStaff.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhoneStaff.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.SimpleButton btnForgotPassword;
        private DevExpress.XtraEditors.TextEdit txtEmailStaff;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtAccName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtPhoneStaff;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.Label lblthongbao;
        private System.Windows.Forms.Label lblThongBao2;
    }
}