using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DAL;
namespace HRM
{
    public partial class UcSocialInsurancecs : XtraUserControl
    {
        int checkActive = 0;
        bool checkClickGrid = false;

        public UcSocialInsurancecs()
        {
            InitializeComponent();
        }
        readonly HRMModelDataContext _aHrm = new HRMModelDataContext();
        SocialInsuranceBus socialInBus = new SocialInsuranceBus();

        //public void LoadLookUpId()
        //{
        //    var mana = from ma in _aHrm.Staffs
        //               select new
        //               {
        //                   ID = ma.StaffID,
        //                   Name = ma.StaffName,                          
        //               };
        //    lkStaffID.Properties.DataSource = mana.ToList();
        //    lkStaffID.Properties.ValueMember = "ID";
        //    lkStaffID.Properties.DisplayMember = "Name";           
        //}
        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBoxEdit3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl6_Click(object sender, EventArgs e)
        {

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void labelControl5_Click(object sender, EventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void labelControl4_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void UcSocialInsurancecs_Load(object sender, EventArgs e)
        {
            //LoadLookUpId();

            grctListBHXH.DataSource = socialInBus.LoadAll();
            grctStaffHasNotBHXH.DataSource = socialInBus.loadAllInfoOfStaff();

            grbxInfo.Enabled = false;
            grbxActive.Enabled = false;

            lblThongBao1.Text = "Chào bạn. Công việc hôm nay của bạn là.";
            lblThongBao2.Text = "1. Click 1 nhân viên ở trên để thêm BHXH cho họ.";
            lblThongBao3.Text = "2. Click 1 phiếu BHXH để sửa hoặc xóa.";
            lblTrangThai.Text = ". . .";
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {

        }

        private void grctStaffHasNotBHXH_Click(object sender, EventArgs e)
        {
            checkClickGrid = true;
            //bật group active đóng group in for
            grbxActive.Enabled = true;
            grbxInfo.Enabled = false;

            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = false;

            

            lblThongBao1.Text = "Bạn nên kiểm tra trước khi lưu.";
            lblTrangThai.Text = "Đang chọn nhân viên chưa có BHXH.";

            GetInfo();
        }

        private void grctListBHXH_Click(object sender, EventArgs e)
        {
            checkClickGrid = false;
            //bật group active đóng group in for
            grbxActive.Enabled = true;
            grbxInfo.Enabled = false; 

            btnAdd.Enabled = false;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false; 
            lblThongBao1.Text = "Bạn nên kiểm tra trước khi lưu.";
            lblTrangThai.Text = "Đang chọn BHXH để sửa hoặc xóa.";
            GetInfo();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Gán CheckActive = 1 cho click vào Add
            checkActive = 1;
            //Sét ẩn hiện cho các button
            btnAdd.Enabled = false;
            btnSave.Enabled = false;
            //Sét ẩn hiện cho các groupbox
            grbxInfo.Enabled = true;
            grbxListBHXH.Enabled = false;
            grbxStaffHasNotBHXH.Enabled = false;

            //Láy 1 mã mới khác vs những mã khác trong table SocialIn 
            string newIDSocial = GetNewId();
            txtIDSocialIn.Text = newIDSocial;

            lblThongBao1.Text = "Điền đủ thông tin thông tin trước khi lưu.";
            lblTrangThai.Text = "Bạn đã click vào chức năng thêm.";
        }

        private string GetNewId()
        {
            var generator = new Random();
            string idNew = "";
            bool checkId = false;
            do
            {
                var getrandom = generator.Next(1000, 10000);
                idNew = "BH" + getrandom.ToString();
                var act = _aHrm.SocialInsurances.SingleOrDefault(social => social.InsuranceID == idNew);
                if(act == null)
                {
                    checkId = true;
                }
                else
                {
                    checkId = false;
                }
            } while (checkId == false);
            return idNew;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtIDSocialIn.Text == "")
            {
                lblThongBao1.Text = "Chọn 1 phiếu BHXH trước khi sửa thông tin.";
            }
            else
            {
                checkActive = 2;
                lblThongBao1.Text = "Điền đủ thông tin và kiểm tra trước khi lưu.";
                lblTrangThai.Text = "Bạn đã click vào chức năng sửa.";
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
            grbxListBHXH.Enabled = true;
            grbxStaffHasNotBHXH.Enabled = true;

            lblThongBao1.Text = "Công ciệc của bạn ở bên dưới.";
            lblTrangThai.Text = ". . .";
        }

        void GetInfo()
        { 
            string basicPays = "";
            string idStaff = "";
            string staffName = "";
            string positionName = "";
            string sectionName = "";
            string idSocialIn = "";
            string payRate = "";
            string price = "";
            if(checkClickGrid == true)
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
                Contract cont = _aHrm.Contracts.Where(con => con.StaffID == idStaff).OrderByDescending(co => co.Date).SingleOrDefault();

                //Lấy các thông tin basicPays, positionName, sectionName
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
            else
            {
                idSocialIn = gridView1.GetFocusedRowCellDisplayText(grcoIDSocial);
                SocialInsurance social = _aHrm.SocialInsurances.SingleOrDefault(so => so.InsuranceID == idSocialIn);
                Staff sta = _aHrm.Staffs.SingleOrDefault(st => st.StaffID == social.StaffID);
                Contract cont = _aHrm.Contracts.Where(con => con.StaffID == sta.StaffID).OrderByDescending(co => co.Date).SingleOrDefault();
                //Lấy các thông tin basicPays, positionName, sectionName
                staffName = sta.StaffName;
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
                if (social.SIStartDate == null)
                {
                    dateDateStart.EditValue = null;
                }
                else
                {
                    dateDateStart.DateTime = DateTime.Parse(social.SIStartDate.ToString());
                }
            }
        }

        private void txtPayRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(txtPayRate.Text.Length >= 2)
            {
                e.Handled = true;
                lblThongBao1.Text = "[Cảnh báo] Tỉ lệ đóng BHXH không để đạt 100%";
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
                Decimal dTmp = Convert.ToDecimal(this.Text);
                this.Text = dTmp.ToString("C");
            }
            catch { }
        }
    }
}
