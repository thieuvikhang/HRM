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
        public int Flag;
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
            if (CheckDateSignVsDateStart() == false)
            {
                //Ngay lap lon hon ngay bat dau
                lblThongBao.Text += "Lỗi: Ngày lập lớn hơn ngày bắt đầu.";
                dxErrorProvider1.SetError(dateSign, "Ngày lập lớn hơn ngày bắt đầu.");
                dxErrorProvider1.SetError(dateStart, "Ngày lập lớn hơn ngày bắt đầu.");
            }
            else
            {
                lblThongBao.Text = "";
                dxErrorProvider1.SetError(dateSign, null);
                dxErrorProvider1.SetError(dateStart, null);
            }
            if (CheckDateSignVsDateEnd() == false)
            {
                lblThongBao.Text += "Lỗi: Ngày Lập lớn hơn ngày kết thúc.";
                dxErrorProvider1.SetError(dateSign, "Ngày Lập lớn hơn ngày kết thúc.");
                dxErrorProvider1.SetError(dateEnd, "Ngày Lập lớn hơn ngày kết thúc.");
            }
            else
            {
                lblThongBao.Text = "";
                dxErrorProvider1.SetError(dateSign, null);
                dxErrorProvider1.SetError(dateEnd, null);
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

        private bool CheckDateStartVsDateEnd()
        {
            //Lấy thông tin ngày tháng năm của dateStart
            var namBatDau = dateStart.DateTime.Year;
            var thangBatDau = dateStart.DateTime.Month;
            var ngayBatDau = dateStart.DateTime.Day;
            DateTime fullNgayBatDau = new DateTime(namBatDau, thangBatDau, ngayBatDau);

            //Lấy thông tin ngày tháng năm của dateEnd
            var namKetThuc = dateEnd.DateTime.Year;
            var thangKetThuc = dateEnd.DateTime.Month;
            var ngayKetThuc = dateEnd.DateTime.Day;
            DateTime fullNgayKetThuc = new DateTime(namKetThuc, thangKetThuc, ngayKetThuc);

            //So sánh 2 ngày dateStart vs DateEnd
            if (DateTime.Compare(fullNgayBatDau, fullNgayKetThuc) > 0)
            {
                //Ngày bắt đầu lớn hơn ngày kết thúc
                return false;
            }
            else
            {
                //Ngày bắt đầu nhỏ hơn ngày kết thúc
                return true;
            }
        }

        private bool CheckDateSignVsDateEnd()
        {
            //Lấy thông tin ngày tháng năm của dateSign
            var namlapHd = dateSign.DateTime.Year;
            var thangLapHd = dateSign.DateTime.Month;
            var ngayLapHd = dateSign.DateTime.Day;
            DateTime fullNgayLap = new DateTime(namlapHd, thangLapHd, ngayLapHd);

            //Lấy thông tin ngày tháng năm của dateEnd
            var namKetThuc = dateEnd.DateTime.Year;
            var thangKetThuc = dateEnd.DateTime.Month;
            var ngayKetThuc = dateEnd.DateTime.Day;
            DateTime fullNgayKetThuc = new DateTime(namKetThuc, thangKetThuc, ngayKetThuc);

            //So sánh 2 ngày dateStart vs Datesign
            if (DateTime.Compare(fullNgayLap, fullNgayKetThuc) > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool CheckDateSignVsDateStart()
        {
            //Lấy thông tin ngày tháng năm của dateSign
            var namlapHd = dateSign.DateTime.Year;
            var thangLapHd = dateSign.DateTime.Month;
            var ngayLapHd = dateSign.DateTime.Day;
            DateTime fullNgayLap = new DateTime(namlapHd, thangLapHd, ngayLapHd);

            //Lấy thông tin ngày tháng năm của dateStart
            var namBatDau = dateStart.DateTime.Year;
            var thangBatDau = dateStart.DateTime.Month;
            var ngayBatDau = dateStart.DateTime.Day;
            DateTime fullNgayBatDau = new DateTime(namBatDau, thangBatDau, ngayBatDau);

            //So sánh 2 ngày dateStart vs Datesign
            if (DateTime.Compare(fullNgayLap, fullNgayBatDau) > 0)
            {
                //Ngày bắt đầu nho hơn ngày lập Hợp đồng
                return false;
            }
            else
            {
                //Ngày bắt đầu lớn hơn hoặc trùng ngày lập hợp đồng
                return true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetTxt(true);
            grbxThongTin.Enabled = true;
            txtContractID.Enabled = false;
            ResetTextBox();
            SetBtn(false);
            gcContract.Enabled = false;
            Flag = 1;
            string idInsert = "";
            idInsert = GetLastIDContract();
            txtContractID.Text = idInsert; 
        }

        private string GetNewID()
        {
            Random generator = new Random();
            int getrandom = generator.Next(1000, 10000);
            string idnew = getrandom.ToString();
            return idnew;
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
            if (CheckDateSignVsDateStart() == false)
            {
                //Ngay lap lon hon ngay bat dau
                lblThongBao.Text += "Lỗi: Ngày lập lớn hơn ngày bắt đầu.";
                dxErrorProvider1.SetError(dateSign, "Ngày lập lớn hơn ngày bắt đầu.");
                dxErrorProvider1.SetError(dateStart, "Ngày lập lớn hơn ngày bắt đầu.");
            }
            else
            {
                lblThongBao.Text = "";
                dxErrorProvider1.SetError(dateSign, null);
                dxErrorProvider1.SetError(dateStart, null);
            }
            if (CheckDateStartVsDateEnd() == false)
            {
                lblThongBao.Text += "Lỗi: Ngày bắt đầu lớn hơn ngày kết thúc.";
                dxErrorProvider1.SetError(dateEnd, "Ngày bắt đầu lớn hơn ngày kết thúc.");
                dxErrorProvider1.SetError(dateStart, "Ngày bắt đầu lớn hơn ngày kết thúc.");
            }
            else
            {
                lblThongBao.Text = "";
                dxErrorProvider1.SetError(dateEnd, null);
                dxErrorProvider1.SetError(dateStart, null);
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
                if (dateSign.DateTime != null)
                {
                    sign = dateSign.DateTime;
                }
                if (dateStart.DateTime != null)
                {
                    start = dateStart.DateTime;
                }
                if (dateEnd.DateTime != null)
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
                if (sign == null)
                {
                    MessageBox.Show("Chưa chọn ngày lập không thể sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    _conTractBus.CreateAContract(txtContractID.Text, sign, currencyInput, start, end, statusInput, basicPayInput, paymentInput, noteInput, staffIdInput, contractTypeIdInput);
                    MessageBox.Show("Chúc mừng bạn thêm hợp đồng thành công.", "thông báo");
                }
            } catch(Exception ex)
            {
                MessageBox.Show("Thêm hợp đồng thất bại", "thông báo");
            }
            
        }

        public void EditContract()
        {
            DateTime? sign = null, start = null, end = null;
            if (dateSign.DateTime != null)
            {
                sign = dateSign.DateTime;
            }
            if (dateStart.DateTime != null)
            {
                start = dateStart.DateTime;

            }
            if (dateEnd.DateTime != null)
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
            if(sign == null)
            {
                MessageBox.Show("Chưa chọn ngày lập không thể sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                _conTractBus.EditContract(txtContractID.Text, sign, currencyInput, start, end, statusInput, basicPayInput, paymentInput, noteInput, staffIdInput, contractTypeIdInput);
                MessageBox.Show("Chúc mừng bạn đã sửa hợp đồng thành công.", "thông báo");
            }
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
                SetTxt(true);
                Flag = 2;
                SetBtn(false);
                txtContractID.Enabled = false;
                gcContract.Enabled = false;
                grbxThongTin.Enabled = true;
            }
            else
            {
                DialogResult dia = MessageBox.Show("Bạn chưa chọn hợp đồng đẻ sửa.", "Thông báo");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //sf
        }

        private void gcContract_Click_1(object sender, EventArgs e)
        {
            GetInfo();
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
            SetBtn(true);
            ResetTextBox();
            SetTxt(false);
            Flag = 0;
            dxErrorProvider1.ClearErrors();
            gcContract.Enabled = true;
            grbxThongTin.Enabled = false;
            lblThongBao.Text = "--Chúc bạn có một ngày làm việc vui vẻ.";
        }

        private void dateEnd_EditValueChanged_1(object sender, EventArgs e)
        {
            if (CheckDateStartVsDateEnd() == false)
            {
                lblThongBao.Text += "Lỗi: Ngày bắt đầu lớn hơn ngày kết thúc.";
                dxErrorProvider1.SetError(dateEnd, "Ngày bắt đầu lớn hơn ngày kết thúc.");
                dxErrorProvider1.SetError(dateStart, "Ngày bắt đầu lớn hơn ngày kết thúc.");
            }
            else
            {
                lblThongBao.Text = "";
                dxErrorProvider1.SetError(dateEnd, null);
                dxErrorProvider1.SetError(dateStart, null);
            }
            if (CheckDateSignVsDateEnd() == false)
            {
                lblThongBao.Text += "Lỗi: Ngày Lập lớn hơn ngày kết thúc.";
                dxErrorProvider1.SetError(dateSign, "Ngày Lập lớn hơn ngày kết thúc.");
                dxErrorProvider1.SetError(dateEnd, "Ngày Lập lớn hơn ngày kết thúc.");
            }
            else
            {
                lblThongBao.Text = "";
                dxErrorProvider1.SetError(dateSign, null);
                dxErrorProvider1.SetError(dateEnd, null);
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
                if (txtBasicPay.Text.Length > 10)
                {
                    e.Handled = true;
                    lblThongBao.Text = "Chúng tôi không thể đáp ứng mức lương cơ bản trên 10 chữ số.";
                }
                else
                {
                    e.Handled = false;
                }
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
        }

        private void btnKiemTraLoi_Click(object sender, EventArgs e)
        {
            if (CheckDateSignVsDateStart() == false)
            {
                dxErrorProvider1.SetError(dateStart, "Ngày bắt đầu nhỏ hơn ngày lập.");
                lblThongBao.Text = "Ngày bắt đầu nhỏ hơn ngày lập.";
            }
            else
            {
                dxErrorProvider1.SetError(dateStart, null);
                lblThongBao.Text = "";
            }
            if (CheckDateSignVsDateEnd() == false)
            {
                dxErrorProvider1.SetError(dateSign, "Ngày lập nhỏ hơn ngày bắt đầu.");
                lblThongBao1.Text = "Ngày lập nhỏ hơn ngày bắt đầu.";
            }
            else
            {
                dxErrorProvider1.SetError(dateSign, null);
                lblThongBao1.Text = "";
            }
            if (CheckDateStartVsDateEnd() == false)
            {
                dxErrorProvider1.SetError(dateEnd, "Ngày kết thúc nhỏ hơn ngày bắt đầu.");
                lblThongBao2.Text = "Ngày kết thúc nhỏ hơn ngày bắt đầu.";
            }
            else
            {
                dxErrorProvider1.SetError(dateEnd, null);
                lblThongBao2.Text = "";
            }

            if(!dxErrorProvider1.HasErrors)
            {
                SetButton(false);
                string ThuTuc = "";
                switch (Flag)
                {
                    case 1:
                        {
                            ThuTuc = "Thêm hóa đơn.";
                            break;
                        }
                    case 2:
                        {
                            ThuTuc = "Sửa hóa đơn.";
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                lblThongBao.Text = "Đã không còn lỗi. nhấn vào nút lưu đễ hoàn tất thủ tục " + ThuTuc;
            }
        }
    }
}
