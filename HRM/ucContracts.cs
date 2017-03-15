using System;
using System.Windows.Forms;
using BUS;
using DevExpress.XtraEditors;
using DAL;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;

namespace HRM
{
    public partial class UcContract : XtraUserControl
    {
        int Flag;
        int dateNull;
        DateTime dSign = new DateTime();
        DateTime dStart = new DateTime();
        DateTime dEnd = new DateTime();

        public UcContract()
        {
            InitializeComponent();
        }

        readonly ContractBus _conTractBus = new ContractBus();
        HRMModelDataContext aHRM = new HRMModelDataContext();
        //Ham set các button 
        public void SetButton(bool set)
        {
            //code set
            btnAdd.Enabled = set;
            btnDelete.Enabled = set;
            btnEdit.Enabled = set;
            btnSave.Enabled = !set;
            btnCancel.Enabled = !set;
        }

        private string GetLastIDContract()
        {
            int idcontract = 0;
            string lastID = "";
            

            int countrecords = aHRM.Contracts.Count();
            if (countrecords == 0)
            {
                idcontract = 0;
            }
            else
            {
                idcontract = countrecords + 1;
            }
            lastID = "HD" + idcontract;
            return lastID;
        }

        //ham set cac TextBox
        public void SetText(bool set)
        {
            //code set
            txtBasicPay.Enabled = set;
            txtContractID.Enabled = set;
        }

        private void labelControl7_Click(object sender, EventArgs e)
        {

        }

        private void ucContract_Load(object sender, EventArgs e)
        {
            //load data len grid
            gcContract.DataSource = _conTractBus.LoadAll();

            //Load các combobox: Staffs and ContractType
            LoadComboboxContractType();
            LoadComboboxStaffs();
            loadcbbstatus();
            LoadCbbHinhThucTra();
            LoadCbbLoaiTien();

            grbxThongTin.Enabled = false;
            SetBtn(true);

            //Set cac date 
            dateSign.Properties.MaxValue = DateTime.Now;

            lblThongBao.Text = "- - - CHÚC BẠN CÓ 1 NGÀY LÀM VIỆC VUI VẺ - - -";
        }
         
        #region load combodox Staffs and ContractType
        // Hàm load Combobox Loai Contract
        public void LoadComboboxStaffs()
        {
            var allStaffs = from st in aHRM.Staffs
                            select new
                            {
                                ten = st.StaffName,
                                ma = st.StaffID,
                            };
            cbbStaffID.DataSource = allStaffs.ToList();
            cbbStaffID.DisplayMember = "ten";
            cbbStaffID.ValueMember = "ma";
        }

        // Hàm load Combobox Loai Contract
        public void LoadComboboxContractType()
        {
            var loaiCT = from loai in aHRM.ContractTypes
                         select new
                         {
                             tenloai = loai.ContractTypeName,
                             maloai = loai.ContractTypeID,
                         };
            cbbContractTypeID.DataSource = loaiCT.ToList();
            cbbContractTypeID.DisplayMember = "tenloai";
            cbbContractTypeID.ValueMember = "maloai";
        }

        void loadcbbstatus()
        {
            var employmentStatus = new BindingList<KeyValuePair<bool, string>>();

            employmentStatus.Add(new KeyValuePair<bool, string>(true, "Còn"));
            employmentStatus.Add(new KeyValuePair<bool, string>(false, "Hết"));
            cbbStatus.DataSource = employmentStatus;
            cbbStatus.ValueMember = "Key";
            cbbStatus.DisplayMember = "Value";
        }

        void LoadCbbHinhThucTra()
        {
            var employmentStatus = new BindingList<KeyValuePair<string, string>>();
            employmentStatus.Add(new KeyValuePair<string, string>("Tiền mặt", "Tiền mặt"));
            employmentStatus.Add(new KeyValuePair<string, string>("Thẻ ATM", "Thẻ ATM"));
            cbbPayment.DataSource = employmentStatus;
            cbbPayment.ValueMember = "Key";
            cbbPayment.DisplayMember = "Value";
        }

        void LoadCbbLoaiTien()
        {
            var employmentStatus = new BindingList<KeyValuePair<string, string>>();
            employmentStatus.Add(new KeyValuePair<string, string>("VND", "VND"));
            employmentStatus.Add(new KeyValuePair<string, string>("USD", "USD"));
            cbbCurrency.DataSource = employmentStatus;
            cbbCurrency.ValueMember = "Key";
            cbbCurrency.DisplayMember = "Value";
        }
        #endregion


        private void dateSign_EditValueChanged(object sender, EventArgs e)
        {
            dSign = dateSign.DateTime;
            dStart = dateStart.DateTime;
            dEnd = dateEnd.DateTime;

            int yearStartOfTheWord = 1;
            int yearOfDateStart = dateStart.DateTime.Year;
            int yearOfDateEnd = dateEnd.DateTime.Year;
            if (yearOfDateStart == yearStartOfTheWord) {
                lblThongBao1.Text = "[Dữ liệu trống] Chưa có ngày bắt đầu.";
                if (yearOfDateEnd == yearStartOfTheWord) {
                    lblThongBao2.Text = "[Dữ liệu trống] Chưa có ngày kết thúc.";
                }
                else {
                    lblThongBao2.Text = "[Cảnh báo] Ngày bắt đầu trống => ";
                }
            }

            if(CheckTwoDate(dSign, dStart) == false) 
            { 
                lblThongBao1.Text = "[Cảnh báo] Ngày bắt đầu nhỏ hơn ngày lập.";
            }
            else if(CheckTwoDate(dSign, dEnd) == false)
            {  
                lblThongBao2.Text = "[Cảnh báo] Ngày kết thúc nhỏ hơn ngày lập.";
            }
            else
            {
                lblThongBao1.Text = "";
                lblThongBao2.Text = "";
            }
        }

        public void GetInfo()
        {
            txtContractID.Text = gridView1.GetFocusedRowCellDisplayText(gcoContractID);
            Contract ctByid = _conTractBus.LoadContractbyId(txtContractID.Text);
            string basicpay = ctByid.BasicPay.ToString();
            txtBasicPay.Text = basicpay;
            mmNote.Text = ctByid.Note; 
            if (ctByid.Date == null)
            {
                dxErrorProvider1.SetError(dateSign, "Chưa có ngày lập.");
                lblThongBao.Text += "Hợp đồng này vẫn chưa có lập.";
            }
            else
            {
                dateSign.DateTime = DateTime.Parse(ctByid.Date.ToString());
                lblThongBao.Text = "";
            } 
            if (ctByid.StartDate == null)
            {
                dateStart.DateTime = DateTime.Now;
                lblThongBao.Text += "Hợp đồng này vẫn chưa có ngày bắt đầu."; 
            }
            else
            {
                dateStart.DateTime = DateTime.Parse(ctByid.StartDate.ToString());
                lblThongBao.Text = "";
            } 
            if(ctByid.EndDate == null)
            {
                dateEnd.DateTime = DateTime.Now;
                lblThongBao.Text += "Hợp đồng này vẫn chưa có ngày kết thúc.";
            }
            else
            {
                dateEnd.DateTime = DateTime.Parse(ctByid.EndDate.ToString());
                lblThongBao.Text = "";
            }
            
            cbbContractTypeID.SelectedValue = ctByid.ContractTypeID;
            cbbCurrency.SelectedValue = ctByid.Currency;
            cbbPayment.SelectedValue = ctByid.Payment;
            cbbStaffID.SelectedValue = ctByid.StaffID;
            cbbStatus.SelectedValue = ctByid.Status;
        } 

        private bool CheckTwoDate(DateTime dateStart, DateTime dateEnd)
        {

            //Lấy thông tin ngày tháng năm của dateStart
            var yearStart = dateStart.Year;
            var monthStart = dateStart.Month;
            var dayStart = dateStart.Day;
            DateTime fullDateStart = new DateTime(yearStart, monthStart, dayStart);

            //Lấy thông tin ngày tháng năm của dateSign
            var yearEnd = dateEnd.Year;
            var monthEnd = dateEnd.Month;
            var dayEnd = dateEnd.Day;
            DateTime fullDateEnd = new DateTime(yearEnd, monthEnd, dayEnd); 

            //So sánh 2 ngày dateStart vs Datesign
            if (DateTime.Compare(fullDateStart, fullDateEnd) > 0)
            {
                //Ngay bat dau lon hon ngay ket thuc
                return false;
            }
            else
            { 
                //Ngay bat dau nho hon ngay ket thuc
                return true;
            }
        }


        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled = true;
            btnSave.Enabled = false;
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            dateSign.EditValue = null;
            dateStart.EditValue = null;
            dateEnd.EditValue = null;


            SetTxt(true);
            grbxThongTin.Enabled = true;
            txtContractID.Enabled = false;
            ResetTextBox(); 
            
            gcContract.Enabled = false;
            Flag = 1;

             
            string idInsert = "";
            idInsert = GetNewID();
            txtContractID.Text = idInsert;
            lblThongBao.Text = "Bạn nên \"kiểm tra\" trước khi click vào nút \"lưu\".";
            lblThongBao1.Text = "";
            lblThongBao1.Text = "";
            lblThucHienCN.Text = "đang thực hiện thêm.";
        }

        private string GetNewID()
        {
            Random generator = new Random();
            int getrandom = 0;
            string idNew = "";
            bool checkID = false;
            Contract act = new Contract();
            do
            {
                getrandom = generator.Next(1000, 10000);
                idNew = "HD" + getrandom.ToString();
                act = aHRM.Contracts.SingleOrDefault(ct => ct.ContractID == idNew);
                if (act != null)
                {
                    checkID = false;
                }
                else
                {
                    checkID = true;
                }
            } while (checkID == false);
            return idNew;
        }

        private void dateStart_DateTimeChanged(object sender, EventArgs e)
        {
            dateEnd.Properties.MinValue = dateStart.DateTime;
            dateSign.Properties.MaxValue = dateStart.DateTime;
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateEnd_DateTimeChanged(object sender, EventArgs e)
        {
            dateStart.Properties.MaxValue = dateEnd.DateTime;
        }

        private void dateSign_DateTimeChanged(object sender, EventArgs e)
        {
            dateSign.Properties.MaxValue = DateTime.Now;
            dateStart.Properties.MinValue = dateSign.DateTime;
        }

        
        private void dateStart_EditValueChanged(object sender, EventArgs e)
        {
            dSign = dateSign.DateTime;
            dStart = dateStart.DateTime;
            dEnd = dateEnd.DateTime;

            if(CheckTwoDate(dSign, dStart)== false)
            {
                lblThongBao1.Text = "[Cảnh báo] Ngày bắt đầu nhỏ hơn ngày lập.";
            }
            else if (CheckTwoDate(dStart, dEnd) == false)
            { 
                lblThongBao2.Text = "[Cảnh báo] Ngày kết thúc nhỏ hơn ngày bắt đầu.";
            }
            else
            {
                lblThongBao1.Text = "";
                lblThongBao2.Text = "";
            }
        }

        private void cbbContractTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateEnd_EditValueChanged(object sender, EventArgs e)
        {
            //sf
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           //fsf
        }
        

        private void dateStart_FormatEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            dateStart.Properties.MinValue = dateSign.DateTime;
        }

        private void dateSign_FormatEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            dateSign.Properties.MaxValue = DateTime.Now;
        }

        #region Thêm, sửa, xóa
        void AddContract()
        {
            try {
                DateTime? sign = null, start = null, end = null;
                int yearStartOfTheWord = 1;
                int yearOfDateStart = dateStart.DateTime.Year;
                int yearOfDateEnd = dateEnd.DateTime.Year;
                //Default date sign != null 
                sign = dateSign.DateTime;
                if (yearOfDateStart == yearStartOfTheWord)
                { start = null; }
                else { start = dateStart.DateTime; }
                if(yearOfDateEnd == yearStartOfTheWord) {
                    end = null;
                }
                else {
                    end = dateEnd.DateTime;
                }
                
                string currencyInput = cbbCurrency.SelectedValue.ToString();
                bool statusInput = bool.Parse(cbbStatus.SelectedValue.ToString());
                decimal basicPayInput = decimal.Parse(txtBasicPay.Text);
                string paymentInput = cbbPayment.SelectedValue.ToString();
                string noteInput = mmNote.Text;
                string staffIdInput = cbbStaffID.SelectedValue.ToString();
                string contractTypeIdInput = cbbContractTypeID.SelectedValue.ToString();
                _conTractBus.CreateAContract(txtContractID.Text, sign, currencyInput, start, end, statusInput, basicPayInput, paymentInput, noteInput, staffIdInput, contractTypeIdInput);
                MessageBox.Show("Chúc mừng bạn thêm hợp đồng thành công.", "thông báo");
                
            } catch(Exception ex)
            {
                MessageBox.Show("Thêm hợp đồng thất bại", "thông báo");
            }
            
        }

        public void EditContract()
        {
            DateTime? sign = null, start = null, end = null;
            int yearStartOfTheWord = 1;
            int yearOfDateStart = dateStart.DateTime.Year;
            int yearOfDateEnd = dateEnd.DateTime.Year;
            //Default date sign != null 
            sign = dateSign.DateTime;
            if (yearOfDateStart == yearStartOfTheWord)
            { start = null; }
            else { start = dateStart.DateTime; }
            if (yearOfDateEnd == yearStartOfTheWord)
            {
                end = null;
            }
            else
            {
                end = dateEnd.DateTime;
            }

            string currencyInput = cbbCurrency.SelectedValue.ToString();
            bool statusInput = bool.Parse(cbbStatus.SelectedValue.ToString());
            decimal basicPayInput = decimal.Parse(txtBasicPay.Text);
            string paymentInput = cbbPayment.SelectedValue.ToString();
            string noteInput = mmNote.Text;
            string staffIdInput = cbbStaffID.SelectedValue.ToString();
            string contractTypeIdInput = cbbContractTypeID.SelectedValue.ToString(); 
            _conTractBus.EditContract(txtContractID.Text, sign, currencyInput, start, end, statusInput, basicPayInput, paymentInput, noteInput, staffIdInput, contractTypeIdInput);
            MessageBox.Show("Chúc mừng bạn đã sửa hợp đồng thành công.", "thông báo");
        }
        #endregion

        #region set button, textbox
        void SetTxt(bool val)
        {
            txtBasicPay.Enabled = val;
            txtContractID.Enabled = val;
            mmNote.Enabled = val;
        }
        void SetBtn(bool val)
        {
            btnAdd.Enabled = val;
            btnDelete.Enabled = val;
            btnEdit.Enabled = val;
            btnSave.Enabled = !val;
            btnCancel.Enabled = !val;
        }
        private void ResetTextBox()
        {
            txtContractID.Text = "";
            txtBasicPay.Text = "";
            mmNote.Text = "";

            //txtTTSanPham.Text = "";
        }
        #endregion

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(txtContractID.Text != "")
            {
                //set button
                btnCancel.Enabled = true;
                btnSave.Enabled = false;
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;

                SetTxt(true);
                Flag = 2; 
                txtContractID.Enabled = false;
                gcContract.Enabled = false;
                grbxThongTin.Enabled = true;
                lblThongBao.Text = "Bạn nên \"kiểm tra\" trước khi click vào nút \"lưu\".";
                lblThongBao1.Text = "";
                lblThongBao2.Text = "";
                
            }
            else
            { 
                lblThongBao.Text = "Bạn chưa chọn hợp đồng để sửa.";
                lblThongBao1.Text = "";
                lblThongBao2.Text = "";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //sf
        }

        private void gcContract_Click_1(object sender, EventArgs e)
        {
            GetInfo();
            lblThongBao.Text = "";
            lblThongBao1.Text = "";
            lblThongBao2.Text = "";
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (Flag == 1)
                { 
                    if (!dxErrorProvider1.HasErrors)
                    {
                        AddContract();
                        ResetTextBox();
                        SetTxt(false);
                        SetBtn(true);
                        gcContract.Enabled = true;
                    }
                    else
                    {
                        lblThongBao.Text = "Vẫn còn lỗi. Không thể thêm.";
                    }
                }
                if(Flag == 2)
                {
                    if(!dxErrorProvider1.HasErrors)
                    {
                        EditContract();
                        ResetTextBox();
                        SetTxt(false);
                        SetBtn(true);
                        gcContract.Enabled = true;
                    }
                }
                grbxThongTin.Enabled = false;
                gcContract.DataSource = _conTractBus.LoadAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Các trường * không được bỏ trống");
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            //set button
            btnCancel.Enabled = false;
            btnSave.Enabled = false;
            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;

            ResetTextBox();
            SetTxt(false);
            Flag = 0;
            dxErrorProvider1.ClearErrors();
            gcContract.Enabled = true;
            grbxThongTin.Enabled = false;
            lblThongBao.Text = "- - -CHÚC BẠN CÓ 1 NGÀY LÀM VIỆC VUI VẺ - - -"; 
            lblThongBao1.Text = "";
            lblThongBao2.Text = "";
        }

        private void dateEnd_EditValueChanged_1(object sender, EventArgs e)
        {
            dSign = dateSign.DateTime;
            dStart = dateStart.DateTime;
            dEnd = dateEnd.DateTime;
            if (CheckTwoDate(dStart, dEnd) == false)
            {
                lblThongBao2.Text = "[Cảnh báo] Ngày kết thúc nhỏ hơn ngày bắt đầu.";
            }
            else if (CheckTwoDate(dSign, dEnd) == false)
            {
                lblThongBao2.Text = "[Cảnh báo] Ngày kết thúc nhỏ hơn ngày lập.";
            }
            else
            {
                lblThongBao1.Text = "";
                lblThongBao2.Text = "";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(txtContractID.Text == "")
            {
                MessageBox.Show("Chưa chọn hợp đồng nào nên ko thể xóa.", "Thông báo");
            }
            else
            {
                DialogResult dia = MessageBox.Show($"Bạn muốn xóa hợp đồng có mã {txtContractID.Text} này?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(dia == DialogResult.Yes)
                {
                    _conTractBus.DeleteAContract(txtContractID.Text);
                }
                else
                {
                    grbxThongTin.Enabled = false;
                    gcContract.Enabled = true;
                    lblThongBao.Text = "--Chúc bạn có một ngày làm việc vui vẻ.";
                }
                txtContractID.Text = "";
                gcContract.DataSource = _conTractBus.LoadAll();
            }
        }

        private void cbbStaffID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            lblThongBao.Text = "Không thể nhập thông tin ở đây.";
        }

        private void cbbContractTypeID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            lblThongBao.Text = "Không thể nhập thông tin ở đây.";
        }

        private void dateSign_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            lblThongBao.Text = "Không thể nhập thông tin ở đây.";
        }

        private void cbbStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            lblThongBao.Text = "Không thể nhập thông tin ở đây.";
        }

        private void dateStart_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            lblThongBao.Text = "Không thể nhập thông tin ở đây.";
        }

        private void dateEnd_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            lblThongBao.Text = "Không thể nhập thông tin ở đây.";
        }

        private void cbbPayment_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            lblThongBao.Text = "Không thể nhập thông tin ở đây.";
        }

        private void cbbCurrency_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            lblThongBao.Text = "Không thể nhập thông tin ở đây.";
        }

        private void txtBasicPay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                lblThongBao.Text = "bạn không thể nhập ký tự vào ô này.";
            }
            else
            {
                if (txtBasicPay.Text.Length == 10)
                {
                    e.Handled = true;
                    lblThongBao.Text = "Chúng tôi không thể đáp ứng mức lương cơ bản trên 10 chữ số.";
                }
                else
                {
                    e.Handled = false;
                }
                dxErrorProvider1.SetError(txtBasicPay, null);
            } 
        }

        private void txtBasicPay_Leave(object sender, EventArgs e)
        {
            //Double value;
            //if (Double.TryParse(txtBasicPay.Text, out value))
            //    txtBasicPay.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", value);
            //else
            //    txtBasicPay.Text = String.Empty;
            if(txtBasicPay.Text != "")
            {
                txtBasicPay.Text = string.Format("{0:n0}", double.Parse(txtBasicPay.Text));  
            }
            lblThongBao.Text = "";
        }

        private void btnKiemTraLoi_Click(object sender, EventArgs e)
        {
            dSign = dateSign.DateTime;
            dStart = dateStart.DateTime;
            dEnd = dateEnd.DateTime;

            DateTime? sign = null, start = null, end = null;
            int yearStartOfTheWord = 1;
            int yearOfDateSign = dateSign.DateTime.Year;
            int yearOfDateStart = dateStart.DateTime.Year;
            int yearOfDateEnd = dateEnd.DateTime.Year;


            if (txtBasicPay.Text == "") {
                dxErrorProvider1.SetError(txtBasicPay, "Lương cơ bản hiện vẫn còn trống");
            }
            else { dxErrorProvider1.SetError(txtBasicPay, null); }

            //Kiem tra date sign = null(chua co gia tri)
            if (yearOfDateSign == yearStartOfTheWord) {
                btnSave.Enabled = false;
                dxErrorProvider1.SetError(dateSign, "Phải thiết lập ngày lập hợp đồng.");
            }
            else {
                dxErrorProvider1.SetError(dateSign, null);

                //check value of date start  == null 
                if (yearOfDateStart == yearStartOfTheWord)
                {
                    
                    dateEnd.EditValue = null;
                }
                else
                {
                    //When value of date start != null
                    //check value of date end = null
                    if(yearOfDateEnd == yearStartOfTheWord)
                    {
                        lblThongBao2.Text = "[Dữ liệu trống] Chưa có ngày kết thúc.";
                    }
                    else
                    {
                        //When value of date start != nul and date end != null
                        //Check validate 3 date 
                        if (CheckTwoDate(dStart, dEnd) == false)
                        { 
                            lblThongBao2.Text = "[Cảnh báo] Ngày kết thúc nhỏ hơn ngày bắt đầu.";
                        }
                        else
                        {
                            dxErrorProvider1.SetError(dateEnd, null);
                            lblThongBao2.Text = "";
                        }
                    }
                }
            }
            if(dxErrorProvider1.HasErrors)
            {
                btnSave.Enabled = false;
                lblThongBao.Text = "[LỖI] click vào biểu tượng (X) để xem lỗi.";
            }
            else
            {
                lblThongBao.Text = "Đã hết lỗi, hãy nhấn vào nút lưu để hoàn tất thủ tục";
                btnSave.Enabled = true;
            }
        }


        /*
         * 
                // Kiểm tra tính hợp lệ của 3 ô
                if (CheckValidDate(dSign, dStart, dEnd) == true) {
                // Thông tin hợp lệ
            }
            else {
                //lỗi giữa các ô  Ngày tháng
            }
         * 
         //Kiểm tra ngày bắt đầu null
                if(dStart == null) {
                    //date start = null => gan datenull = 1
                    dateNull = 1;
                }
                else {
                    if (dateEnd == null) {
                        //date start != null vs date end = null => gan datenull = 2
                        dateNull = 2;
                    }
                    else {
                        //date start != null vs date end != null => gan datenull = 2
                        dateNull = 0;
                    }
                }
             */

        private void cbbStaffID_Leave(object sender, EventArgs e)
        {
            lblThongBao.Text = "";
        }

        private void cbbContractTypeID_Leave(object sender, EventArgs e)
        {
            lblThongBao.Text = "";
        }

        private void dateSign_Leave(object sender, EventArgs e)
        {
            lblThongBao.Text = "";
        }

        private void cbbStatus_Leave(object sender, EventArgs e)
        {
            lblThongBao.Text = "";
        }

        private void dateStart_Leave(object sender, EventArgs e)
        {
            lblThongBao.Text = "";
        }

        private void dateEnd_Leave(object sender, EventArgs e)
        {
            lblThongBao.Text = "";
        }

        private void cbbPayment_Leave(object sender, EventArgs e)
        {
            lblThongBao.Text = "";
        }

        private void cbbCurrency_Leave(object sender, EventArgs e)
        {
            lblThongBao.Text = "";
        }

        //Ham kiem tra tinh hop ly cua 3 ngay.
        void GetValidDate(DateTime dStart, DateTime dBetween, DateTime dEnd)
        {
            //Lưu Ý: Ở trong này quy định
            //  dStart = dateSign.DateTime;
            //  dBetween = dateStart.DateTime;
            //  dEnd = dateEnd.DateTime;
              
            // khi date sign da co thi xet 2 date: between vs End
            //Khi date betwen != null vs date end == null
            if (dBetween != null && dEnd == null)
            {
                //Kiem tra date start vs date between
                //Khi date start > date between
                if (CheckTwoDate(dStart, dBetween) == false)
                {
                    dxErrorProvider1.SetError(dateStart, "Ngày bắt đầu nhỏ hơn ngày lập hợp đồng.");
                    lblThongBao1.Text = "Ngày bắt đầu nhỏ hơn ngày lập hợp đồng.";
                }
                //khi date start < date between
                else
                {
                    dxErrorProvider1.SetError(dateStart, null);
                    lblThongBao1.Text = "";
                }
            }
            //Khi date between == null vs date End != null
            else if (dBetween == null && dEnd != null)
            {
                dxErrorProvider1.SetError(dateEnd, "Chưa có ngày bắt đàu.");
                lblThongBao2.Text = "Chưa có ngày bắt đàu.";
            }
            //Khi date between != null vs date end != null => 3 date deu co gia tri
            else if (dBetween != null && dEnd != null)
            {
                //kiem tra tinh hop le cua 3 date
                //1. Kiem tra date start vs date between
                if (CheckTwoDate(dStart, dBetween) == false)
                {
                    //date start > date between
                    dxErrorProvider1.SetError(dateStart, "Ngày bắt đầu nhỏ hơn ngày lập.");
                    lblThongBao1.Text = "Ngày bắt đầu nhỏ hơn ngày lập.";
                }
                //2. Kiem tra date between vs date end
                else if (CheckTwoDate(dBetween, dEnd) == false)
                {
                    //date between > date end
                    dxErrorProvider1.SetError(dateEnd, "Ngày kết thúc nhỏ hơn ngày bắt đầu.");
                    lblThongBao2.Text = "Ngày kết thúc nhỏ hơn ngày bắt đầu.";
                }
                else
                {
                    dxErrorProvider1.SetError(dateEnd, null);
                    dxErrorProvider1.SetError(dateStart, null);
                    lblThongBao2.Text = "";
                    lblThongBao1.Text = "";
                }
            }
            else
            {
                dxErrorProvider1.SetError(dateStart, null);
                dxErrorProvider1.SetError(dateEnd, null);
                lblThongBao.Text = "";
                lblThongBao1.Text = "";
                lblThongBao2.Text = "";
            } 
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            dateEnd.EditValue = null;
        }

        private void dateSign_Click(object sender, EventArgs e)
        {
            int yearStartOftheWord = 1;
            int YearOfdateStart = dateStart.DateTime.Year;
            int yearOfDateEnd = dateEnd.DateTime.Year;
            dateSign.Properties.MaxValue = DateTime.Now;
            if(YearOfdateStart != yearStartOftheWord)
            {
                dateSign.Properties.MaxValue = dateStart.DateTime;
            }
            else
            {
                if(yearOfDateEnd != yearStartOftheWord)
                {
                    dateSign.Properties.MaxValue = dateEnd.DateTime;
                }
                else
                {
                    dateSign.Properties.MaxValue = DateTime.Now;
                }
            }
        }

        private void dateStart_Click(object sender, EventArgs e)
        {
            int yearStartOftheWord = 1;
            int yearOfDateSign = dateSign.DateTime.Year;
            int YearOfdateStart = dateStart.DateTime.Year;
            int yearOfDateEnd = dateEnd.DateTime.Year;
            if(yearOfDateSign != yearStartOftheWord)
            {
                dateStart.Properties.MinValue = dateSign.DateTime;
                dxErrorProvider1.SetError(dateSign, null);
            }
            else
            {
                dxErrorProvider1.SetError(dateSign, "Phải thiết lập ngày lập hợp đồng.");
            }
            if(yearOfDateEnd != yearStartOftheWord)
            {
                dateStart.Properties.MaxValue = dateEnd.DateTime;
                lblThongBao2.Text = "";
            }
            else
            {
                lblThongBao2.Text = "[Dữ liệu trống] Chưa có ngày kết thúc.";
            }
        }

        private void dateEnd_Click(object sender, EventArgs e)
        {
            int yearStartOftheWord = 1;
            int yearOfDateSign = dateSign.DateTime.Year;
            int YearOfdateStart = dateStart.DateTime.Year;
            int yearOfDateEnd = dateEnd.DateTime.Year;
            
            if(YearOfdateStart != yearStartOftheWord)
            {
                dateEnd.Properties.MinValue = dateStart.DateTime;
            }
            else
            {
                dateEnd.Properties.MinValue = dateSign.DateTime;
                if(yearOfDateSign != yearStartOftheWord)
                {
                    dateEnd.Properties.MinValue = dateSign.DateTime;
                    dxErrorProvider1.SetError(dateSign, null);
                }
                else
                {
                    dxErrorProvider1.SetError(dateSign, "Phải thiết lập ngày lập hợp đồng.");
                }
            }
        }

        private void txtBasicPay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                txtBasicPay.Text = "";
            }
        }
    }
}
