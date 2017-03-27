using System;
using System.Windows.Forms;
using BUS;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Localization;

namespace HRM
{
    public partial class UcSection : XtraUserControl
    {
        int _checkAdd;
        public class MyGridLocalizer : GridLocalizer
        {
            public override string GetLocalizedString(GridStringId id)
            {
                switch (id)
                {
                    case GridStringId.FindControlFindButton:
                        return "Tìm kiếm";
                    case GridStringId.FindControlClearButton:
                        return "Hủy";
                    default:
                        return base.GetLocalizedString(id);
                }
            }
        }
        public UcSection()
        {
            InitializeComponent();
            GridLocalizer.Active = new MyGridLocalizer();
        }

        readonly SectionBus _sectionBus = new SectionBus();
       

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }
        private void ResetTextBox()
        {
            txtSectionID.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            mmDescription.Text = "";
        }
        private void ucSection_Load(object sender, EventArgs e)
        {
            gcSection.DataSource = _sectionBus.LoadAll();
            SetTxt(false);
            SetBtn(true);
            txtPhone.Properties.MaxLength = 11;
            txtSectionID.Properties.MaxLength = 6;
            numStandardWorkdays.Minimum = 24;
            numStandardWorkdays.Maximum = 26;      
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
            _sectionBus.CreateASection(txtSectionID.Text, txtName.Text, mmDescription.Text, stardw, txtPhone.Text);
        }
        public void EditSection()
        {
            int stardw = int.Parse(numStandardWorkdays.Text);
            _sectionBus.EditSection(txtSectionID.Text, txtName.Text, mmDescription.Text, stardw, txtPhone.Text);
        }
        public void DelSection()
        {
            _sectionBus.DeleteASection(txtSectionID.Text);
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            SetTxt(true);
            ResetTextBox();
            SetBtn(false);
            _checkAdd = 1;
            gcSection.Enabled = false;
            dxErrorProvider.ClearErrors();
            numStandardWorkdays.Value = 26;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = XtraMessageBox.Show($"Bạn muốn xóa phòng {txtName.Text} này", "Xóa phòng ban", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    DelSection();

                }
            }
            catch
            {
                // ignored
            }
            gcSection.DataSource = _sectionBus.LoadAll();
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
            _checkAdd = 2;
            SetBtn(false);
            txtSectionID.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {            
                //kiem tra them             
                if(_checkAdd == 1)
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
                        ResetTextBox();
                        SetTxt(false);
                        SetBtn(true);
                        gcSection.Enabled = true;
                    }                                             
                }
                //kiem tra xoa
                if(_checkAdd == 2)
                {
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
                        ResetTextBox();
                        SetTxt(false);
                        SetBtn(true);
                        gcSection.Enabled = true;
                    }
                }
                    
            }
            catch
            {
                MessageBox.Show(@"Các trường * không được bỏ trống");
            }
            gcSection.DataSource = _sectionBus.LoadAll();          
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetBtn(true);
            ResetTextBox();
            SetTxt(false);
            _checkAdd = 0;
            dxErrorProvider.ClearErrors();
            gcSection.Enabled = true;
        }
        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            dxErrorProvider.SetError(txtName,null);
        }

        private void txtSectionID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
        }
        private void txtSectionID_TextChanged(object sender, EventArgs e)
        {
            dxErrorProvider.SetError(txtSectionID,
                _sectionBus.FindIdInputIntable(txtSectionID.Text) ? "Mã phòng ban trùng" : null);
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            dxErrorProvider.SetError(txtName,
                _sectionBus.FindNameInputIntable(txtName.Text) ? "Tên phòng ban trùng" : null);
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                dxErrorProvider.SetError(txtPhone, null);
            }
        }

        private void txtPhone_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged_1(object sender, EventArgs e)
        {
            if (_sectionBus.FindPhoneInputIntable(txtPhone.Text) &&(txtPhone.Text != ""))
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
