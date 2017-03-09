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
            numStandardWorkdays.Text = "";

            //txtTTSanPham.Text = "";
        }
        private void ucSection_Load(object sender, EventArgs e)
        {
            gcSection.DataSource = sectionBUS.loadAll();
            SetTxt(false);
            SetBtn(true);
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
        void setHinhErrorTextBoxRong()
        {
            if (txtSectionID.Text == "")
            {
                dxErrorProvider.SetError(txtSectionID, "Chưa nhập mã phòng ban....");
            }
            if (txtName.Text == "")
            {
                dxErrorProvider.SetError(txtName, "Chưa nhập mã phòng ban....");
            }
            if (sectionBUS.findNameInputIntable(txtName.Text) == true)
            {
                dxErrorProvider.SetError(txtName, "Mã phòng ban trùng....");
            }

        }
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            SetTxt(true);
            resetTextBox();
            SetBtn(false);
            checkAdd = 1;
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
                    setHinhErrorTextBoxRong();
                    AddSection();
                    resetTextBox();
                    SetTxt(false);
                    SetBtn(true);
                    
                }
                //kiem tra xoa
                if(checkAdd == 2)
                {
                    setHinhErrorTextBoxRong();
                    EditSection();
                    resetTextBox();
                    SetTxt(false);
                    SetBtn(true);

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
        }
    }
}
