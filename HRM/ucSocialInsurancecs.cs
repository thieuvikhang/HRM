﻿using System;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DAL;
using DevExpress.XtraEditors;

namespace HRM
{
    public partial class UcSocialInsurancecs : XtraUserControl
    {
        int _checkActive;
        bool _checkClickGrid;

        public UcSocialInsurancecs()
        {
            InitializeComponent();
        }
        readonly HRMModelDataContext _aHrm = new HRMModelDataContext();
        readonly SocialInsuranceBus _socialInBus = new SocialInsuranceBus();

        private void UcSocialInsurancecs_Load(object sender, EventArgs e)
        {
            
            //LoadLookUpId();
            int countRecordSocial = _aHrm.SocialInsurances.Count();
            int countStaffHasNotSignSocial = _socialInBus.CountAllStaffHasNotsocial();
            grbxStaffHasNotBHXH.Enabled = countStaffHasNotSignSocial != 0;
            grbxListBHXH.Enabled = countRecordSocial != 0;
            txtIDSocialIn.Properties.MaxLength = 10;

            grctListBHXH.DataSource = _socialInBus.LoadAll();
            grctStaffHasNotBHXH.DataSource = _socialInBus.LoadAllInfoOfStaff();

            grbxInfo.Enabled = false;
            grbxActive.Enabled = false;

            lblThongBao1.Text = @"Chào bạn. Công việc hôm nay của bạn là.";
            lblThongBao2.Text = @"1. Click 1 nhân viên ở trên để thêm BHXH cho họ.";
            lblThongBao3.Text = @"2. Click 1 phiếu BHXH để sửa hoặc xóa.";
            lblTrangThai.Text = @". . .";
        }

        private void grctStaffHasNotBHXH_Click(object sender, EventArgs e)
        {
            _checkClickGrid = true;
            //bật group active đóng group in for
            grbxActive.Enabled = true;
            grbxInfo.Enabled = false;

            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
            btnCheck.Enabled = false;
            

            lblThongBao1.Text = @"Bạn nên kiểm tra trước khi lưu.";
            lblTrangThai.Text = @"Đang chọn nhân viên chưa có BHXH.";

            GetInfo();
        }

        private void grctListBHXH_Click(object sender, EventArgs e)
        {
            _checkClickGrid = false;
            //bật group active đóng group in for
            grbxActive.Enabled = true;
            grbxInfo.Enabled = false; 

            btnAdd.Enabled = false;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false; 
            lblThongBao1.Text = @"Bạn nên kiểm tra trước khi lưu.";
            lblTrangThai.Text = @"Đang chọn BHXH để sửa hoặc xóa.";
            GetInfo();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnCheck.Enabled = true;
            txtPayRate.EditValue = 8;
            //Gán CheckActive = 1 cho click vào Add
            _checkActive = 1;
            //Sét ẩn hiện cho các button
            btnAdd.Enabled = false;
            btnSave.Enabled = false;
            //Sét ẩn hiện cho các groupbox
            grbxInfo.Enabled = true;
            grbxListBHXH.Enabled = false;
            grbxStaffHasNotBHXH.Enabled = false;

            //Láy 1 mã mới khác vs những mã khác trong table SocialIn 
 

            lblThongBao1.Text = @"Click vào nút (Kiểm tra) trước khi lưu.";
            lblTrangThai.Text = @"Đang thêm phiếu BHXH có mã " + txtIDSocialIn.Text + @" cho nhân viên " + txtStaffName.Text + @"...";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtIDSocialIn.Text == "")
            {
                lblThongBao1.Text = @"Chọn 1 phiếu BHXH trước khi sửa thông tin.";
            }
            else
            {
                _checkActive = 2;
                lblThongBao1.Text = @"Điền đủ thông tin và kiểm tra trước khi lưu.";
                lblTrangThai.Text = @"Đang sửa phiếu BHXH có mã " + txtIDSocialIn.Text + @" cho nhân viên " + txtStaffName.Text + @"...";
                btnEdit.Enabled = false;
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                grbxInfo.Enabled = true;
                grbxListBHXH.Enabled = false;
                grbxStaffHasNotBHXH.Enabled = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            grbxActive.Enabled = false;
            grbxInfo.Enabled = false;
            grbxStaffHasNotBHXH.Enabled = true;

            int countRecordSocial = _aHrm.SocialInsurances.Count();
            int countStaffHasNotSignSocial = _socialInBus.CountAllStaffHasNotsocial();
            grbxStaffHasNotBHXH.Enabled = countStaffHasNotSignSocial != 0;
            grbxListBHXH.Enabled = countRecordSocial != 0;

            lblThongBao1.Text = @"Công ciệc của bạn ở bên dưới.";
            lblTrangThai.Text = @". . .";
            dxErrorProvider1.ClearErrors();
        }

        void GetInfo()
        { 
            string basicPays;
            string idStaff;
            string staffName;
            string positionName;
            string sectionName;
            string idSocialIn;
            string payRate;
            string price;
            if(_checkClickGrid)
            {
                txtIDSocialIn.Text = "";
                txtPayRate.Text = "";
                txtPrice.Text = "";
                dateDateStart.EditValue = null;

                //Lấy idStaff từ cột name của grodview2
                idStaff = gridView2.GetFocusedRowCellDisplayText(grcoIDStaff);
                staffName = gridView2.GetFocusedRowCellDisplayText(grcoStafName);
                //Lấy 1 Staff có idStaff vừa tìm duoc
                Staff staf = _aHrm.Staffs.SingleOrDefault(sta => sta.StaffID == idStaff);
                //Lấy 1 contract last của staffID vừa tìm dc
                Contract cont = _aHrm.Contracts.Where(con => con.StaffID == idStaff).OrderByDescending(co => co.Date).FirstOrDefault();

                //Lấy các thông tin basicPays, positionName, sectionName
                if (cont != null)
                {
                    basicPays = cont.BasicPay.ToString();
                    positionName = _aHrm.Positions.SingleOrDefault(po => po.PostID == staf.PostID).PostName;
                    sectionName = _aHrm.Sections.SingleOrDefault(se => se.SectionID == staf.SectionID).SectionName;
                    //Đưa các giá trị tìm được lên các ô textbox
                    txtStaffName.Text = staffName;
                    txtPositionName.Text = positionName;
                    txtSectionName.Text = sectionName;
                    txtBasicPay.Text = basicPays;
                    lblNgoaiTe1.Text = cont.Currency;
                    lblNgoaiTe2.Text = cont.Currency;
                }
                if (staf != null) lblIDStaff.Text = staf.StaffID;
            }
            else
            {
                idSocialIn = gridView1.GetFocusedRowCellDisplayText(grcoIDSocial);
                SocialInsurance social = _aHrm.SocialInsurances.SingleOrDefault(so => so.InsuranceID == idSocialIn);
                Staff sta = _aHrm.Staffs.SingleOrDefault(st => st.StaffID == social.StaffID);
                Contract cont = _aHrm.Contracts.Where(con => con.StaffID == sta.StaffID).OrderByDescending(co => co.Date).FirstOrDefault();
                //Lấy các thông tin basicPays, positionName, sectionName
                if (sta != null)
                {
                    staffName = sta.StaffName;
                    if (cont != null)
                    {
                        basicPays = cont.BasicPay.ToString();
                        positionName = _aHrm.Positions.SingleOrDefault(po => po.PostID == sta.PostID).PostName;
                        sectionName = _aHrm.Sections.SingleOrDefault(se => se.SectionID == sta.SectionID).SectionName;
                        payRate = social.PayRate.ToString();
                        price = social.Price.ToString();
                        //Đưa các giá trị tìm được lên các ô textbox
                        txtIDSocialIn.Text = idSocialIn; 
                        txtStaffName.Text = staffName;
                        txtPositionName.Text = positionName;
                        txtSectionName.Text = sectionName;
                        txtBasicPay.Text = basicPays;
                        txtPayRate.Text = payRate;
                        txtPrice.Text = price;
                        lblNgoaiTe1.Text = cont.Currency;
                        lblNgoaiTe2.Text = cont.Currency;
                    }
                    lblIDStaff.Text = sta.StaffID;
                }
                if (social != null && social.SIStartDate == null)
                {
                    dateDateStart.EditValue = null;
                }
                else
                {
                    if (social != null) dateDateStart.DateTime = DateTime.Parse(social.SIStartDate.ToString());
                }
            }
        }

        private void txtPayRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(txtPayRate.Text.Length >= 2)
            {
                e.Handled = true;
                lblThongBao1.Text = @"[Cảnh báo] Tỉ lệ đóng BHXH không để đạt 100%";
            } 
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                lblThongBao1.Text = @"Bạn không thể nhập ký tự vào ô này.";
            }
            
        }

        private void txtBasicPay_Validated(object sender, EventArgs e)
        {
            try
            {
                // format the value as currency
                Decimal dTmp = Convert.ToDecimal(Text);
                Text = dTmp.ToString("C");
            }
            catch
            {
                // ignored
            }
        }

        private void txtPayRate_TextChanged(object sender, EventArgs e)
        {
            double basicpay = 0;
            int payrate;

            if(txtPayRate.Text == "")
            {
                payrate = 0;
            }
            else
            {
                payrate = int.Parse(txtPayRate.Text);
                basicpay = double.Parse(txtBasicPay.Text);
            }
            var price = (basicpay * payrate) / 100;
            txtPrice.Text = price.ToString();
        }

        private void txtPayRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                txtPayRate.Text = "";
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (_checkActive == 1)
            {
                lblTrangThai.Text = @"Đang kiểm tra cho chức năng thêm BHXH.";
                CheckError();
            }
            if (_checkActive == 2)
            {
                lblTrangThai.Text = @"Đang kiểm tra cho chức năng sửa BHXH.";
                CheckError();
            }
            if (dxErrorProvider1.HasErrors)
            {
                lblThongBao1.Text = @"[Lỗi] Click vào dấu(X) để xem lỗi";
                btnSave.Enabled = false;
            }
            else
            {
                DialogResult dialog = XtraMessageBox.Show(@"Đã hết lỗi. Bạn có muốn sửa đổi thêm nữa không?", @"THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dialog == DialogResult.No)
                {
                    grbxInfo.Enabled = false;
                    lblThongBao1.Text = @"Đã không còn lỗi bạn có thể lưu lại.";
                    btnSave.Enabled = true;
                }
                else
                {
                    btnSave.Enabled = false;
                }
            }
        }

        protected virtual void CheckError()
        {
            if (_socialInBus.FindIdInputInTable(txtIDSocialIn.Text))
            {
                dxErrorProvider1.SetError(txtIDSocialIn, "Số BHXH trùng");
            }
            else if (txtIDSocialIn.Text == "")
            {
                dxErrorProvider1.SetError(txtIDSocialIn, "Chưa nhập số BHXH");
            }
            else
            {
                dxErrorProvider1.SetError(txtIDSocialIn,null);
            }
            //DateTime? start = null;
            var yearStartOfTheWord = 1;
            var yearOfDateStart = dateDateStart.DateTime.Year;
            //Default date sign != null 
            dxErrorProvider1.SetError(dateDateStart,
                yearOfDateStart == yearStartOfTheWord ? "Chưa chọn ngày bắt đầu." : null);

            dxErrorProvider1.SetError(txtPayRate, txtPayRate.Text == "" ? "Chưa nhập tỷ lệ đóng BHXH." : null);
        }

        protected virtual void CreateSocial()
        {
            string idInput = txtIDSocialIn.Text;
            DateTime monthInput = dateDateStart.DateTime;
            string payrate = txtPayRate.Text;
            var payRateInput = int.Parse(payrate);
            string price = txtPrice.Text;
            var priceInput = decimal.Parse(price);
            string staffIdInput = lblIDStaff.Text;
            _socialInBus.CreateASocialInsurances(idInput, monthInput, payRateInput, priceInput, staffIdInput);
        }

        void EditSocial()
        {
            btnCheck.Enabled = true;
            string idInput = txtIDSocialIn.Text;
            DateTime monthInput = dateDateStart.DateTime;
            string payrate = txtPayRate.Text;
            var payRateInput = int.Parse(payrate);
            string price = txtPrice.Text;
            var priceInput = decimal.Parse(price);
            string staffIdInput = lblIDStaff.Text;
            _socialInBus.EditASocialInsurances(idInput, monthInput, payRateInput, priceInput, staffIdInput);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(_checkActive == 1)
            {
                DialogResult dialog = XtraMessageBox.Show($@"Bạn có chắc muốn thêm BHXH có mã {txtIDSocialIn.Text} cho nhân viên {txtStaffName.Text}?", @"THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dialog == DialogResult.Yes)
                {
                    CreateSocial();
                    grbxListBHXH.Enabled = true;
                    grbxActive.Enabled = false;
                    grbxInfo.Enabled = false;
                    btnCheck.Enabled = false;
                    lblTrangThai.Text = @"Vừa thêm BHXH có mã " + txtIDSocialIn.Text + @" cho nhân viên " + txtStaffName.Text + @".";
                }
                else
                {
                    lblTrangThai.Text = @"Không thêm BHXH có mã " + txtIDSocialIn.Text + @" cho nhân viên " + txtStaffName.Text+ @".";
                }
            }
            if(_checkActive == 2)
            {
                DialogResult dialog = XtraMessageBox.Show($@"Bạn có chắc muốn sửa BHXH có mã {txtIDSocialIn.Text} cho nhân viên {txtStaffName.Text}?", @"THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    EditSocial();
                    grbxListBHXH.Enabled = true;
                    grbxActive.Enabled = false;
                    grbxInfo.Enabled = false;
                    btnCheck.Enabled = false;
                    lblTrangThai.Text = @"Vừa sửa BHXH có mã " + txtIDSocialIn.Text + @" cho nhân viên " + txtStaffName.Text + @".";
                }
                else
                {
                    lblTrangThai.Text = @"Không sửa BHXH có mã " + txtIDSocialIn.Text + @" cho nhân viên " + txtStaffName.Text + @".";
                }
            }
            grctListBHXH.DataSource = _socialInBus.LoadAll();
            grctStaffHasNotBHXH.DataSource = _socialInBus.LoadAllInfoOfStaff();
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            string idSocial = txtIDSocialIn.Text;
            DialogResult dialog = XtraMessageBox.Show($@"bạn thật sự muốn xóa Phiếu BHXH có mã {txtIDSocialIn.Text} của nhân viên {txtStaffName.Text} không?", @"THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(idSocial != "")
            {
                lblThongBao1.Text = "";
                if (dialog == DialogResult.Yes)
                {
                    lblTrangThai.Text = @"Đã xóa phiếu BHXH có mã " + txtIDSocialIn.Text + @" của nhân viên " + txtStaffName.Text + @".";
                    _socialInBus.DeleteASociallnsurance(idSocial);
                    grctListBHXH.DataSource = _socialInBus.LoadAll();
                    grctStaffHasNotBHXH.DataSource = _socialInBus.LoadAllInfoOfStaff();
                    grbxListBHXH.Enabled = true;
                    grbxStaffHasNotBHXH.Enabled = true;
                    grbxActive.Enabled = false;
                    grbxInfo.Enabled = false;
                }
                else
                {
                    lblTrangThai.Text = @"Không xóa phiếu BHXH có mã " + txtIDSocialIn.Text + @" của nhân viên " + txtStaffName.Text + @".";
                }
            }
            else
            {
                lblThongBao1.Text = @"bạn chưa chọn 1 phiếu BHXH nào.";
            }
        }

        private void txtIDSocialIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
