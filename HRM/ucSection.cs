using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DAL;
using BUS;

namespace HRM
{
    public partial class ucSection : DevExpress.XtraEditors.XtraUserControl
    {
        int checkAdd = 0;
        public ucSection()
        {
            InitializeComponent();
        }
        sectionBUS sectionBUS = new sectionBUS();
        

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }
        private void resetTextBox()
        {
            txtSectionID.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            mmDescription.Text = "";

            //txtTTSanPham.Text = "";
        }
        private void ucSection_Load(object sender, EventArgs e)
        {
            gcSection.DataSource = sectionBUS.loadAll();
            SetTxt(false);
            SetBtn(true);
            numStandardWorkdays.Minimum = 24;
            numStandardWorkdays.Maximum = 26;      
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }
        public void GetInfo()
        {
            txtSectionID.Text = gridView1.GetFocusedRowCellDisplayText(gCoSectionID);
            txtName.Text = gridView1.GetFocusedRowCellDisplayText(gCoSectionName);
            mmDescription.Text = gridView1.GetFocusedRowCellDisplayText(gCoDescription);
            numStandardWorkdays.Text = gridView1.GetFocusedRowCellDisplayText(gCoStandardWorkdays);
            txtPhone.Text = gridView1.GetFocusedRowCellDisplayText(gCoPhone);
        }
        private void gcSection_Click(object sender, EventArgs e)
        {
            GetInfo();
            dxErrorProvider.ClearErrors();
        }
        public void AddSection()
        {
            int stardw = int.Parse(numStandardWorkdays.Text);
            sectionBUS.createASection(txtSectionID.Text, txtName.Text, mmDescription.Text, stardw, txtPhone.Text);
        }
        public void EditSection()
        {
            int stardw = int.Parse(numStandardWorkdays.Text);
            sectionBUS.editSection(txtSectionID.Text, txtName.Text, mmDescription.Text, stardw, txtPhone.Text);
        }
        public void DelSection()
        {
            sectionBUS.deleteASection(txtSectionID.Text);
        }
        private void gridView1_Click(object sender, EventArgs e)
        {
            GetInfo();
        }
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            SetTxt(true);
            resetTextBox();
            SetBtn(false);
            checkAdd = 1;
            gcSection.Enabled = false;
            dxErrorProvider.ClearErrors();
            numStandardWorkdays.Value = 26;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = XtraMessageBox.Show(string.Format("Bạn muốn xóa phòng {0} này", txtName.Text), "Xóa phòng ban", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    DelSection();

                }
                else
                {

                }
                
            }
            catch
            {

            }
            gcSection.DataSource = sectionBUS.loadAll();
        }
        void SetTxt(bool val)
        {
            txtSectionID.Enabled = val;
            txtName.Enabled = val;
            txtPhone.Enabled = val;
            mmDescription.Enabled = val;
            numStandardWorkdays.Enabled = val;
        }
        void SetBtn(bool val)
        {
            btnAdd.Enabled = val;
            btnDelete.Enabled = val;
            btnEdit.Enabled = val;
            btnSave.Enabled = !val;
            btnCancel.Enabled = !val;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SetTxt(true);
            checkAdd = 2;
            SetBtn(false);
            txtSectionID.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {            
                //kiem tra them             
                if(checkAdd == 1)
                {
                    if (string.IsNullOrEmpty(txtSectionID.Text))
                    {
                        dxErrorProvider.SetError(txtSectionID, "Mã phòng ban ko dc trống");
                    }
                    if(string.IsNullOrEmpty(txtName.Text))
                    {
                        dxErrorProvider.SetError(txtName, "Tên phòng ko dc trống");
                    }
                    if (string.IsNullOrEmpty(numStandardWorkdays.Text))
                    {
                        dxErrorProvider.SetError(numStandardWorkdays, "Số ngày qui định ko dc trống");
                    }
                    if (!dxErrorProvider.HasErrors)
                    {
                        AddSection();                       
                        resetTextBox();
                        SetTxt(false);
                        SetBtn(true);
                        gcSection.Enabled = true;
                    }                                             
                }
                //kiem tra xoa
                if(checkAdd == 2)
                {
                    if (string.IsNullOrEmpty(txtSectionID.Text))
                    {
                        dxErrorProvider.SetError(txtSectionID, "Mã phòng ban ko dc trống");
                    }
                    if (string.IsNullOrEmpty(txtName.Text))
                    {
                        dxErrorProvider.SetError(txtName, "Tên phòng ko dc trống");
                    }
                    if (string.IsNullOrEmpty(numStandardWorkdays.Text))
                    {
                        dxErrorProvider.SetError(numStandardWorkdays, "Số ngày qui định ko dc trống");
                    }
                    if (!dxErrorProvider.HasErrors)
                    {
                        EditSection();
                        resetTextBox();
                        SetTxt(false);
                        SetBtn(true);
                        gcSection.Enabled = true;
                    }
                }
                    
            }
            catch
            {
                MessageBox.Show("Các trường * không được bỏ trống");
            }
            gcSection.DataSource = sectionBUS.loadAll();          
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetBtn(true);
            SetTxt(false);
            checkAdd = 0;
            dxErrorProvider.ClearErrors();
            gcSection.Enabled = true;
        }
        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            dxErrorProvider.SetError(txtName,null);
        }

        private void txtSectionID_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void txtSectionID_TextChanged(object sender, EventArgs e)
        {
            if(sectionBUS.findIDInputIntable(txtSectionID.Text) == true)
            {
                dxErrorProvider.SetError(txtSectionID, "Mã phòng ban trùng");
            }
            else if (string.IsNullOrEmpty(txtSectionID.Text))
            {
                dxErrorProvider.SetError(txtSectionID, "Mã phòng ban ko dc để trống");
            }
            //else if (txtSectionID.Text.Length > 6)
            //{
            //    dxErrorProvider.SetError(txtSectionID, "Mã phòng ban ko dc vượt quá 6 ký tự");
            //}
            else
            {
                dxErrorProvider.SetError(txtSectionID, null);
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (sectionBUS.findNameInputIntable(txtName.Text) == true)
            {
                dxErrorProvider.SetError(txtName, "Tên phòng ban trùng");
            }
            else if(string.IsNullOrEmpty(txtName.Text))
            {
                dxErrorProvider.SetError(txtName, "Tên phòng ban ko dc để trống");
            }
            //else if(txtName.Text.Length > 20)
            //{
            //    dxErrorProvider.SetError(txtName, "Tên phòng ban ko dc vượt quá 20 ký tự");
            //}
            else
            {
                dxErrorProvider.SetError(txtName, null);
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPhone_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged_1(object sender, EventArgs e)
        {
            if (txtPhone.Text.Length > 11 || txtPhone.Text.Length <3)
            {
                dxErrorProvider.SetError(txtPhone, "Số điện thoại quá dài hoặc quá ngắn");
            }
            else if (sectionBUS.findPhoneInputIntable(txtPhone.Text) == true)
            {
                dxErrorProvider.SetError(txtPhone, "Số điện thoại trùng");
            }
            else
            {
                dxErrorProvider.SetError(txtPhone, null);
            }
        }

        private void numStandardWorkdays_ValueChanged(object sender, EventArgs e)
        {
            if(numStandardWorkdays.Value > 30 || numStandardWorkdays.Value < 23)
            {
                dxErrorProvider.SetError(numStandardWorkdays, "Số ngày công qui định ko đúng");
            }
        }
    }
}
