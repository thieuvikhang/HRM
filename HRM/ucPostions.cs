using System;
using System.Windows.Forms;
using BUS;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Localization;

namespace HRM
{
    public partial class UcPostions : XtraUserControl
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
        public UcPostions()
        {
            InitializeComponent();
            GridLocalizer.Active = new MyGridLocalizer();
        }

        private readonly PostBus _postBus = new PostBus();
        private void ResetTextBox()
        {
            txtPostID.Text = "";
            txtPostName.Text = "";
            mmDescription.Text = "";
        }
        void SetTxt(bool val)
        {
            txtPostID.Enabled = val;
            txtPostName.Enabled = val;
            mmDescription.Enabled = val;
        }
        void SetBtn(bool val)
        {
            btnAdd.Enabled = val;
            btnDelete.Enabled = val;
            btnEdit.Enabled = val;
            btnSave.Enabled = !val;
            btnCancel.Enabled = !val;
        }
        private void ucPostions_Load(object sender, EventArgs e)
        {
            gcPostions.DataSource = _postBus.LoadAll();
            SetTxt(false);
            SetBtn(true);
            txtPostName.Properties.MaxLength = 50;
            txtPostID.Properties.MaxLength = 6;
            mmDescription.Properties.MaxLength = 50;
        }
        public void GetInfo()
        {
            txtPostID.Text = gridView1.GetFocusedRowCellDisplayText(gcoPostID);
            txtPostName.Text = gridView1.GetFocusedRowCellDisplayText(gcoPostName);
            mmDescription.Text = gridView1.GetFocusedRowCellDisplayText(gcoDescription);
        }
        public void AddPost()
        {
            _postBus.CreateAPost(txtPostID.Text, txtPostName.Text, mmDescription.Text);
        }
        public void EditPost()
        {
            _postBus.EditPost(txtPostID.Text, txtPostName.Text, mmDescription.Text);
        }
        public void DelPost()
        {
            _postBus.DeleteAPost(txtPostID.Text);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetTxt(true);
            ResetTextBox();
            SetBtn(false);
            _checkAdd = 1;
            gcPostions.Enabled = false;
            dxErrorProvider.ClearErrors();
        }

        private void gcPostions_Click(object sender, EventArgs e)
        {
            GetInfo();
            dxErrorProvider.ClearErrors();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = XtraMessageBox.Show($"Bạn muốn xóa chức vụ {txtPostName.Text} này", "Xóa chức vụ", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    DelPost();

                }
            }
            catch
            {
                // ignored
            }
            gcPostions.DataSource = _postBus.LoadAll();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SetTxt(true);
            _checkAdd = 2;
            SetBtn(false);
            txtPostID.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //kiem tra them             
                if (_checkAdd == 1)
                {
                    if (string.IsNullOrEmpty(txtPostID.Text))
                    {
                        dxErrorProvider.SetError(txtPostID, "Mã chức vụ không được trống");
                    }
                    if (string.IsNullOrEmpty(txtPostName.Text))
                    {
                        dxErrorProvider.SetError(txtPostName, "Tên chức vụ không được trống");
                    }
                    if (!dxErrorProvider.HasErrors)
                    {
                        AddPost();
                        ResetTextBox();
                        SetTxt(false);
                        SetBtn(true);
                        gcPostions.Enabled = true;
                    }
                }
                //kiem tra xoa
                if (_checkAdd == 2)
                {
                    if (string.IsNullOrEmpty(txtPostName.Text))
                    {
                        dxErrorProvider.SetError(txtPostName, "Tên chức vụ không được trống");
                    }
                    if (!dxErrorProvider.HasErrors)
                    {
                        EditPost();
                        ResetTextBox();
                        SetTxt(false);
                        SetBtn(true);
                        gcPostions.Enabled = true;
                    }
                }

            }
            catch
            {
                MessageBox.Show(@"Các trường * không được bỏ trống");
            }
            gcPostions.DataSource = _postBus.LoadAll();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetBtn(true);
            ResetTextBox();
            SetTxt(false);
            _checkAdd = 0;
            dxErrorProvider.ClearErrors();
            gcPostions.Enabled = true;
        }

        private void txtPostName_KeyPress(object sender, KeyPressEventArgs e)
        {
            dxErrorProvider.SetError(txtPostName, null);
        }

        private void txtPostID_TextChanged(object sender, EventArgs e)
        {
            if (_postBus.FindIdInputIntable(txtPostID.Text))
            {
                dxErrorProvider.SetError(txtPostID, "Mã chức vụ trùng");
            }
            else
            {
                dxErrorProvider.SetError(txtPostID, null);
            }
        }

        private void txtPostName_TextChanged(object sender, EventArgs e)
        {
            dxErrorProvider.SetError(txtPostName,
                _postBus.FindNameInputIntable(txtPostName.Text) ? "Tên chức vụ trùng" : null);
        }

        private void txtPostID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
        }
    }
}
