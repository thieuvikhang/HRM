using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DAL;
using DevExpress.XtraEditors;

namespace HRM
{
    public partial class UcContract : XtraUserControl
    {
        private int _flag;
        private DateTime _dStart;
        private DateTime _dEnd;

        public UcContract()
        {
            InitializeComponent();
        }

        readonly ContractBus _conTractBus = new ContractBus();
        private readonly HRMModelDataContext _aHrm = new HRMModelDataContext();
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
            btnKiemTraLoi.Enabled = false;
            mmNote.Properties.MaxLength = 100;
            //load data len grid
            gcContract.DataSource = _conTractBus.LoadAll(); 
            Session aSession = new Session();
            if (aSession["userName"] != null)
            {
                lblSession.Text = aSession["userName"].ToString();
            }
            else
            {
                lblSession.Text = @"Không tìm thấy session Username";
            }
            //Load các combobox: Staffs and ContractType
            LoadComboboxContractType();
            LoadComboboxStaffs();
            Loadcbbstatus();
            LoadCbbHinhThucTra();
            LoadCbbLoaiTien();

            grbxThongTin.Enabled = false;
            SetBtn(true);

            //Set cac date 
            dateSign.Properties.MaxValue = DateTime.Now;

            lblThongBao.Text = @"- - - CHÚC BẠN CÓ 1 NGÀY LÀM VIỆC VUI VẺ - - -";
        }
         
        #region load combodox Staffs and ContractType
        // Hàm load Combobox Loai Contract
        public void LoadComboboxStaffs()
        {
            var allStaffs = from st in _aHrm.Staffs
                            select new
                            {
                                ten = st.StaffName,
                                ma = st.StaffID
                            };
            cbbStaffID.DataSource = allStaffs.ToList();
            cbbStaffID.DisplayMember = "ten";
            cbbStaffID.ValueMember = "ma";
        }

        // Hàm load Combobox Loai Contract
        public void LoadComboboxContractType()
        {
            var loaiCt = from loai in _aHrm.ContractTypes
                         select new
                         {
                             tenloai = loai.ContractTypeName,
                             maloai = loai.ContractTypeID
                         };
            cbbContractTypeID.DataSource = loaiCt.ToList();
            cbbContractTypeID.DisplayMember = "tenloai";
            cbbContractTypeID.ValueMember = "maloai";
        }

        private void Loadcbbstatus()
        {
            var employmentStatus = new BindingList<KeyValuePair<bool, string>>
            {
                new KeyValuePair<bool, string>(true, "Còn"),
                new KeyValuePair<bool, string>(false, "Hết")
            };

            cbbStatus.DataSource = employmentStatus;
            cbbStatus.ValueMember = "Key";
            cbbStatus.DisplayMember = "Value";
        }

        private void LoadCbbHinhThucTra()
        {
            var employmentStatus = new BindingList<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Tiền mặt", "Tiền mặt"),
                new KeyValuePair<string, string>("Thẻ ATM", "Thẻ ATM")
            };
            cbbPayment.DataSource = employmentStatus;
            cbbPayment.ValueMember = "Key";
            cbbPayment.DisplayMember = "Value";
        }

        private void LoadCbbLoaiTien()
        {
            var employmentStatus = new BindingList<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("VND", "VND"),
                new KeyValuePair<string, string>("USD", "USD")
            };
            cbbCurrency.DataSource = employmentStatus;
            cbbCurrency.ValueMember = "Key";
            cbbCurrency.DisplayMember = "Value";
        }
        #endregion

        public void GetInfo()
        {
            txtContractID.Text = gridView1.GetFocusedRowCellDisplayText(gcoContractID);
            var ctByid = _conTractBus.LoadContractbyId(txtContractID.Text);
            string basicpay = ctByid.BasicPay.ToString();
            txtBasicPay.Text = basicpay;
            mmNote.Text = ctByid.Note; 
            if (ctByid.Date == null)
            {
                dxErrorProvider1.SetError(dateSign, "Chưa có ngày lập.");
                lblThongBao.Text += @"Hợp đồng này vẫn chưa có lập.";
            }
            else
            {
                dateSign.DateTime = DateTime.Parse(ctByid.Date.ToString());
                lblThongBao.Text = "";
            } 
            if (ctByid.StartDate == null)
            {
                dateStart.DateTime = DateTime.Now;
                lblThongBao.Text += @"Hợp đồng này vẫn chưa có ngày bắt đầu."; 
            }
            else
            {
                dateStart.DateTime = DateTime.Parse(ctByid.StartDate.ToString());
                lblThongBao.Text = "";
            } 
            if(ctByid.EndDate == null)
            {
                dateEnd.DateTime = DateTime.Now;
                lblThongBao.Text += @"Hợp đồng này vẫn chưa có ngày kết thúc.";
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

        private static bool CheckTwoDate(DateTime dateStart, DateTime dateEnd)
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
            //Ngay bat dau nho hon ngay ket thuc
            return true;
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
            btnKiemTraLoi.Enabled = true;

            SetTxt(true);
            grbxThongTin.Enabled = true;
            txtContractID.Enabled = false;
            ResetTextBox(); 
            
            gcContract.Enabled = false;
            _flag = 1;


            var idInsert = GetNewId();
            txtContractID.Text = idInsert;
            lblThongBao.Text = @"Bạn nên ""kiểm tra"" trước khi click vào nút ""lưu"".";
            lblThongBao1.Text = "";
            lblThongBao1.Text = "";
            lblThucHienCN.Text = @"đang thực hiện thêm.";
        }

        private string GetNewId()
        {
            var generator = new Random();
            string idNew;
            bool checkId;
            do
            {
                var getrandom = generator.Next(1000, 10000);
                idNew = "HD" + getrandom;
                var act = _aHrm.Contracts.SingleOrDefault(ct => ct.ContractID == idNew);
                checkId = act == null;
            } while (checkId == false);
            return idNew;
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        #region Thêm, sửa, xóa
        void AddContract()
        {
            try {
                DateTime? start = null, end = null;
                var yearStartOfTheWord = 1;
                var yearOfDateStart = dateStart.DateTime.Year;
                var yearOfDateEnd = dateEnd.DateTime.Year;
                //Default date sign != null 
                DateTime? sign = dateSign.DateTime;
                if (yearOfDateStart == yearStartOfTheWord)
                {
                }
                else { start = dateStart.DateTime; }
                if(yearOfDateEnd == yearStartOfTheWord) {
                }
                else {
                    end = dateEnd.DateTime;
                }
                
                var currencyInput = cbbCurrency.SelectedValue.ToString();
                var statusInput = bool.Parse(cbbStatus.SelectedValue.ToString());
                var basicPayInput = decimal.Parse(txtBasicPay.Text);
                var paymentInput = cbbPayment.SelectedValue.ToString();
                var noteInput = mmNote.Text;
                var staffIdInput = cbbStaffID.SelectedValue.ToString();
                var contractTypeIdInput = cbbContractTypeID.SelectedValue.ToString();
                _conTractBus.CreateAContract(txtContractID.Text, sign, currencyInput, start, end, statusInput, basicPayInput, paymentInput, noteInput, staffIdInput, contractTypeIdInput);
                MessageBox.Show(@"Chúc mừng bạn thêm hợp đồng thành công.", @"thông báo");
                
            } catch(Exception)
            {
                MessageBox.Show(@"Chúc mừng bạn thêm hợp đồng thành công.", @"thông báo");
            }
            
        }

        public void EditContract()
        {
            DateTime? start, end;
            const int yearStartOfTheWord = 1;
            var yearOfDateStart = dateStart.DateTime.Year;
            var yearOfDateEnd = dateEnd.DateTime.Year;
            //Default date sign != null 
            DateTime? sign = dateSign.DateTime;
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

            var currencyInput = cbbCurrency.SelectedValue.ToString();
            var statusInput = bool.Parse(cbbStatus.SelectedValue.ToString());
            var basicPayInput = decimal.Parse(txtBasicPay.Text);
            var paymentInput = cbbPayment.SelectedValue.ToString();
            var noteInput = mmNote.Text;
            var staffIdInput = cbbStaffID.SelectedValue.ToString();
            var contractTypeIdInput = cbbContractTypeID.SelectedValue.ToString(); 
            _conTractBus.EditContract(txtContractID.Text, sign, currencyInput, start, end, statusInput, basicPayInput, paymentInput, noteInput, staffIdInput, contractTypeIdInput);
            MessageBox.Show(@"Chúc mừng bạn thêm hợp đồng thành công.", @"thông báo");
        }
        #endregion

        #region set button, textbox

        private void SetTxt(bool val)
        {
            txtBasicPay.Enabled = val;
            txtContractID.Enabled = val;
            mmNote.Enabled = val;
        }

        private void SetBtn(bool val)
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
                btnKiemTraLoi.Enabled = true;
                SetTxt(true);
                _flag = 2; 
                txtContractID.Enabled = false;
                gcContract.Enabled = false;
                grbxThongTin.Enabled = true;
                lblThongBao.Text = @"Bạn nên ""kiểm tra"" trước khi click vào nút ""lưu"".";
                lblThongBao1.Text = "";
                lblThongBao2.Text = "";
                
            }
            else
            { 
                lblThongBao.Text = @"Bạn chưa chọn hợp đồng để sửa.";
                lblThongBao1.Text = "";
                lblThongBao2.Text = "";
            }
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
                if (_flag == 1)
                { 
                    if (!dxErrorProvider1.HasErrors)
                    {
                        AddContract();
                        ResetTextBox();
                        SetTxt(false);
                        SetBtn(true);
                        gcContract.Enabled = true;
                        btnKiemTraLoi.Enabled = false;
                    }
                    else
                    {
                        lblThongBao.Text = @"Vẫn còn lỗi. Không thể thêm.";
                    }
                }
                if(_flag == 2)
                {
                    if(!dxErrorProvider1.HasErrors)
                    {
                        EditContract();
                        ResetTextBox();
                        SetTxt(false);
                        SetBtn(true);
                        gcContract.Enabled = true;
                        btnKiemTraLoi.Enabled = false;
                    }
                }
                grbxThongTin.Enabled = false;
                gcContract.DataSource = _conTractBus.LoadAll();
            }
            catch (Exception)
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
            btnKiemTraLoi.Enabled = false;
            ResetTextBox();
            SetTxt(false);
            _flag = 0;
            dxErrorProvider1.ClearErrors();
            gcContract.Enabled = true;
            grbxThongTin.Enabled = false;
            lblThongBao.Text = @"- - -CHÚC BẠN CÓ 1 NGÀY LÀM VIỆC VUI VẺ - - -"; 
            lblThongBao1.Text = "";
            lblThongBao2.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(txtContractID.Text == "")
            {
                MessageBox.Show(@"Chúc mừng bạn thêm hợp đồng thành công.", @"thông báo");
            }
            else
            {
                var dia = MessageBox.Show($@"Bạn muốn xóa hợp đồng có mã {txtContractID.Text} này?", @"THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(dia == DialogResult.Yes)
                {
                    _conTractBus.DeleteAContract(txtContractID.Text);
                }
                else
                {
                    grbxThongTin.Enabled = false;
                    gcContract.Enabled = true;
                    lblThongBao.Text = @"--Chúc bạn có một ngày làm việc vui vẻ.";
                }
                txtContractID.Text = "";
                gcContract.DataSource = _conTractBus.LoadAll();
            }
        }

        private void cbbStaffID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            lblThongBao.Text = @"Không thể nhập thông tin ở đây.";
        }

        private void cbbContractTypeID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            lblThongBao.Text = @"Không thể nhập thông tin ở đây.";
        }

        private void dateSign_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            lblThongBao.Text = @"Không thể nhập thông tin ở đây.";
        }

        private void cbbStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            lblThongBao.Text = @"Không thể nhập thông tin ở đây.";
        }

        private void dateStart_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            lblThongBao.Text = @"Không thể nhập thông tin ở đây.";
        }

        private void dateEnd_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            lblThongBao.Text = @"Không thể nhập thông tin ở đây.";
        }

        private void cbbPayment_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            lblThongBao.Text = @"Không thể nhập thông tin ở đây.";
        }

        private void cbbCurrency_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            lblThongBao.Text = @"Không thể nhập thông tin ở đây.";
        }

        private void txtBasicPay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                lblThongBao.Text = @"bạn không thể nhập ký tự vào ô này.";
            }
            else
            {
                if (txtBasicPay.Text.Length == 10)
                {
                    e.Handled = true;
                    lblThongBao.Text = @"Chúng tôi không thể đáp ứng mức lương cơ bản trên 10 chữ số.";
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
                txtBasicPay.Text = $@"{double.Parse(txtBasicPay.Text):n0}";  
            }
            lblThongBao.Text = "";
        }

        private void btnKiemTraLoi_Click(object sender, EventArgs e)
        {
            _dStart = dateStart.DateTime;
            _dEnd = dateEnd.DateTime;

            const int yearStartOfTheWord = 1;
            var yearOfDateSign = dateSign.DateTime.Year;
            var yearOfDateStart = dateStart.DateTime.Year;
            var yearOfDateEnd = dateEnd.DateTime.Year;


            dxErrorProvider1.SetError(txtBasicPay, txtBasicPay.Text == "" ? "Lương cơ bản hiện vẫn còn trống" : null);

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
                        lblThongBao2.Text = @"[Dữ liệu trống] Chưa có ngày kết thúc.";
                    }
                    else
                    {
                        //When value of date start != nul and date end != null
                        //Check validate 3 date 
                        if (CheckTwoDate(_dStart, _dEnd) == false)
                        { 
                            lblThongBao2.Text = @"[Cảnh báo] Ngày kết thúc nhỏ hơn ngày bắt đầu.";
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
                lblThongBao.Text = @"[LỖI] click vào biểu tượng (X) để xem lỗi.";
            }
            else
            {
                lblThongBao.Text = @"Đã hết lỗi, hãy nhấn vào nút lưu để hoàn tất thủ tục";
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

        private void dateSign_Click(object sender, EventArgs e)
        {
            
        }

        private void dateStart_Click(object sender, EventArgs e)
        {
            
        }

        private void dateEnd_Click(object sender, EventArgs e)
        {
            
        }

        private void txtBasicPay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                txtBasicPay.Text = "";
            }
        }

        private void dateSign_QueryCloseUp(object sender, CancelEventArgs e)
        {

        }

        private void dateSign_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void dateSign_TextChanged(object sender, EventArgs e)
        {
            var yearStartOftheWord = 1;
            var yearOfdateStart = dateStart.DateTime.Year;
            var yearOfDateEnd = dateEnd.DateTime.Year;
            dateSign.Properties.MaxValue = DateTime.Now;
            if (yearOfdateStart != yearStartOftheWord)
            {
                dateSign.Properties.MaxValue = dateStart.DateTime;
            }
            else
            {
                dateSign.Properties.MaxValue = yearOfDateEnd != yearStartOftheWord ? dateEnd.DateTime : DateTime.Now;
            }
        }

        private void dateStart_TextChanged(object sender, EventArgs e)
        {
            const int yearStartOftheWord = 1;
            var yearOfDateSign = dateSign.DateTime.Year;
            var yearOfDateEnd = dateEnd.DateTime.Year;
            if (yearOfDateSign != yearStartOftheWord)
            {
                dateStart.Properties.MinValue = dateSign.DateTime;
                dxErrorProvider1.SetError(dateSign, null);
            }
            else
            {
                dxErrorProvider1.SetError(dateSign, "Phải thiết lập ngày lập hợp đồng.");
            }
            if (yearOfDateEnd != yearStartOftheWord)
            {
                dateStart.Properties.MaxValue = dateEnd.DateTime;
                lblThongBao2.Text = "";
            }
            else
            {
                lblThongBao2.Text = @"[Dữ liệu trống] Chưa có ngày kết thúc.";
            }
        }

        private void dateEnd_TextChanged(object sender, EventArgs e)
        {
            const int yearStartOftheWord = 1;
            var yearOfDateSign = dateSign.DateTime.Year;
            var yearOfdateStart = dateStart.DateTime.Year;

            if (yearOfdateStart != yearStartOftheWord)
            {
                dateEnd.Properties.MinValue = dateStart.DateTime;
            }
            else
            {
                dateEnd.Properties.MinValue = dateSign.DateTime;
                if (yearOfDateSign != yearStartOftheWord)
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
    }
}
