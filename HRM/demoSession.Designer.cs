using System.ComponentModel;
using System.Windows.Forms;

namespace HRM
{
    partial class demoSession
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblUserNameAcc = new System.Windows.Forms.Label();
            this.lblAccessName = new System.Windows.Forms.Label();
            this.lblListAccess = new System.Windows.Forms.Label();
            this.lblStaffName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên nhân viên(Staff name)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên đăng nhập";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "label1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Group access name";
            this.label4.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblUserNameAcc
            // 
            this.lblUserNameAcc.AutoSize = true;
            this.lblUserNameAcc.Location = new System.Drawing.Point(253, 68);
            this.lblUserNameAcc.Name = "lblUserNameAcc";
            this.lblUserNameAcc.Size = new System.Drawing.Size(35, 13);
            this.lblUserNameAcc.TabIndex = 0;
            this.lblUserNameAcc.Text = "label1";
            this.lblUserNameAcc.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblAccessName
            // 
            this.lblAccessName.AutoSize = true;
            this.lblAccessName.Location = new System.Drawing.Point(253, 108);
            this.lblAccessName.Name = "lblAccessName";
            this.lblAccessName.Size = new System.Drawing.Size(35, 13);
            this.lblAccessName.TabIndex = 0;
            this.lblAccessName.Text = "label1";
            this.lblAccessName.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblListAccess
            // 
            this.lblListAccess.AutoSize = true;
            this.lblListAccess.Location = new System.Drawing.Point(253, 149);
            this.lblListAccess.Name = "lblListAccess";
            this.lblListAccess.Size = new System.Drawing.Size(29, 13);
            this.lblListAccess.TabIndex = 0;
            this.lblListAccess.Text = "zfsdf";
            // 
            // lblStaffName
            // 
            this.lblStaffName.AutoSize = true;
            this.lblStaffName.Location = new System.Drawing.Point(253, 30);
            this.lblStaffName.Name = "lblStaffName";
            this.lblStaffName.Size = new System.Drawing.Size(35, 13);
            this.lblStaffName.TabIndex = 0;
            this.lblStaffName.Text = "label1";
            this.lblStaffName.Click += new System.EventHandler(this.label2_Click);
            // 
            // demoSession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 261);
            this.Controls.Add(this.lblListAccess);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblAccessName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblStaffName);
            this.Controls.Add(this.lblUserNameAcc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "demoSession";
            this.Text = "demoSession";
            this.Load += new System.EventHandler(this.demoSession_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label lblUserNameAcc;
        private Label lblAccessName;
        private Label lblListAccess;
        private Label lblStaffName;
    }
}