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
            int countRecordSocial = _aHrm.SocialInsurances.Count();
            int countStaffHasNotSignSocial = socialInBus.countAllStaffHasNotsocial();
            if (countStaffHasNotSignSocial == 0)
            {
                grbxStaffHasNotBHXH.Enabled = false;
            }
            else
            {
                grbxStaffHasNotBHXH.Enabled = true;
            }
            if (countRecordSocial == 0)
            {
                grbxListBHXH.Enabled = false;
            }
            else
            {
                grbxListBHXH.Enabled = true;
            }


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

            lblThongBao1.Text = "Click vào nút (Kiểm tra) trước khi lưu.";
            lblTrangThai.Text = "Đang thêm phiếu BHXH có mã " + txtIDSocialIn.Text + " cho nhân viên " + txtStaffName.Text + "...";
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
                lblTrangThai.Text = "Đang sửa phiếu BHXH có mã " + txtIDSocialIn.Text + " cho nhân viên " + txtStaffName.Text + "...";
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
            int countStaffHasNotSignSocial = socialInBus.countAllStaffHasNotsocial();
            if (countStaffHasNotSignSocial == 0)
            {
                grbxStaffHasNotBHXH.Enabled = false;
            }
            else
            {
                grbxStaffHasNotBHXH.Enabled = true;
            }
            if (countRecordSocial == 0)
            {
                grbxListBHXH.Enabled = false;
            }
            else
            {
                grbxListBHXH.Enabled = true;
            }

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
                Contract cont = _aHrm.Contracts.Where(con => con.StaffID == idStaff).OrderByDescending(co => co.Date).FirstOrDefault();

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
                lblIDStaff.Text = staf.StaffID;
            }
            else
            {
                idSocialIn = gridView1.GetFocusedRowCellDisplayText(grcoIDSocial);
                SocialInsurance social = _aHrm.SocialInsurances.SingleOrDefault(so => so.InsuranceID == idSocialIn);
                Staff sta = _aHrm.Staffs.SingleOrDefault(st => st.StaffID == social.StaffID);
                Contract cont = _aHrm.Contracts.Where(con => con.StaffID == sta.StaffID).OrderByDescending(co => co.Date).FirstOrDefault();
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
                lblIDStaff.Text = sta.StaffID;
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

        private void txtPayRate_TextChanged(object sender, EventArgs e)
        {
            double basicpay = 0;
            int payrate = 0;
            double price = 0;

            if(txtPayRate.Text == "")
            {
                payrate = 0;
                price = 0;
            }
            else
            {
                payrate = int.Parse(txtPayRate.Text);
                basicpay = double.Parse(txtBasicPay.Text);
            }
            price = (basicpay * payrate) / 100;
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
            if (checkActive == 1)
            {
                lblTrangThai.Text = "Đang kiểm tra cho chức năng thêm BHXH.";
                CheckError();
            }
            if (checkActive == 2)
            {
                lblTrangThai.Text = "Đang kiểm tra cho chức năng sửa BHXH.";
                CheckError();
            }
            if (dxErrorProvider1.HasErrors)
            {
                lblThongBao1.Text = "[Lỗi] Click vào dấu(X) để xem lỗi";
                btnSave.Enabled = false;
            }
            else
            {
                DialogResult dialog = MessageBox.Show("Đã hết lỗi. Bạn có muốn sửa đổi j thêm nữa không?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dialog == DialogResult.No)
                {
                    grbxInfo.Enabled = false;
                    lblThongBao1.Text = "Đã không còn lỗi bạn có thể lưu lại.";
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
            int payRateInput = 0;
            payRateInput = int.Parse(payrate);
            string price = txtPrice.Text;
            decimal priceInput = 0;
            priceInput = decimal.Parse(price);
            string staffIdInput = lblIDStaff.Text;
            socialInBus.CreateASocialInsurances(idInput, monthInput, payRateInput, priceInput, staffIdInput);
        }

        void EditSocial()
        {
            string idInput = txtIDSocialIn.Text;
            DateTime monthInput = dateDateStart.DateTime;
            string payrate = txtPayRate.Text;
            int payRateInput = 0;
            payRateInput = int.Parse(payrate);
            string price = txtPrice.Text;
            decimal priceInput = 0;
            priceInput = decimal.Parse(price);
            string staffIdInput = lblIDStaff.Text;
            socialInBus.EditASocialInsurances(idInput, monthInput, payRateInput, priceInput, staffIdInput);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(checkActive == 1)
                {
                    DialogResult dialog = MessageBox.Show($"Bạn có chắc muốn thêm BHXH có mã {txtIDSocialIn.Text} cho nhân viên {txtStaffName.Text}?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(dialog == DialogResult.Yes)
                    {
                        CreateSocial();
                        grbxListBHXH.Enabled = true;
                        grbxActive.Enabled = false;
                        grbxInfo.Enabled = false;
                        lblTrangThai.Text = "Vừa thêm BHXH có mã " + txtIDSocialIn.Text + " cho nhân viên " + txtStaffName.Text + ".";
                    }
                    else
                    {
                        lblTrangThai.Text = "Không thêm BHXH có mã " + txtIDSocialIn.Text + " cho nhân viên " + txtStaffName.Text+ ".";
                    }
                }
                if(checkActive == 2)
                {
                    DialogResult dialog = MessageBox.Show($"Bạn có chắc muốn sửa BHXH có mã {txtIDSocialIn.Text} cho nhân viên {txtStaffName.Text}?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        EditSocial();
                        grbxListBHXH.Enabled = true;
                        grbxActive.Enabled = false;
                        grbxInfo.Enabled = false;
                        lblTrangThai.Text = "Vừa sửa BHXH có mã " + txtIDSocialIn.Text + " cho nhân viên " + txtStaffName.Text + ".";
                    }
                    else
                    {
                        lblTrangThai.Text = "Không sửa BHXH có mã " + txtIDSocialIn.Text + " cho nhân viên " + txtStaffName.Text + ".";
                    }
                }
                grctListBHXH.DataSource = socialInBus.LoadAll();
                grctStaffHasNotBHXH.DataSource = socialInBus.loadAllInfoOfStaff();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            string idSocial = txtIDSocialIn.Text;
            DialogResult dialog = MessageBox.Show($"bạn thật sự muốn xóa Phiếu BHXH có mã {txtIDSocialIn.Text} của nhân viên {txtStaffName.Text} không?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(idSocial != "")
            {
                lblThongBao1.Text = "";
                if (dialog == DialogResult.Yes)
                {
                    lblTrangThai.Text = "Đã xóa phiếu BHXH có mã " + txtIDSocialIn.Text + " của nhân viên " + txtStaffName.Text + ".";
                    socialInBus.DeleteASociallnsurance(idSocial);
                    grctListBHXH.DataSource = socialInBus.LoadAll();
                    grctStaffHasNotBHXH.DataSource = socialInBus.loadAllInfoOfStaff();
                    grbxListBHXH.Enabled = true;
                    grbxStaffHasNotBHXH.Enabled = true;
                    grbxActive.Enabled = false;
                    grbxInfo.Enabled = false;
                }
                else
                {
                    lblTrangThai.Text = "Không xóa phiếu BHXH có mã " + txtIDSocialIn.Text + " của nhân viên " + txtStaffName.Text + ".";
                }
            }
            else
            {
                lblThongBao1.Text = "bạn chưa chọn 1 phiếu BHXH nào.";
            }
        }
    }
}
