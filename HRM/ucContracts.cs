﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DAL;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System.Data;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;

namespace HRM
{
    public partial class UcContract : XtraUserControl
    {
        private int _flag;
        public Session Session = new Session();

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
            var access = int.Parse(Session["Access"].ToString());
            if (access != 1)
            {
                groupControl2.Visible = false;
                btnAdd.Visible = false;
                btnSave.Visible = false;
                btnCancel.Visible = false;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                btnKiemTraLoi.Visible = false;
            }
            dateSign.Enabled = false;
            dateEnd.Enabled = false;
            btnKiemTraLoi.Enabled = false;
            mmNote.Properties.MaxLength = 100;
            //load data len grid
            gcContract.DataSource = _conTractBus.LoadAll(); 
            
            //Load các combobox: Staffs and ContractType
            LoadComboboxContractType();
            LoadComboboxStaffs();
            Loadcbbstatus();
            LoadCbbHinhThucTra();
            LoadCbbLoaiTien();
            cbbStatus.Enabled = false;
            grbxThongTin.Enabled = false;
            SetBtn(true);

            //Set cac date 
            dateSign.Properties.MaxValue = DateTime.Now;

            lblThongBao.Text = @"- - - CHÚC BẠN CÓ 1 NGÀY LÀM VIỆC VUI VẺ - - -";

            //việt hóa messagebox
            Localizer.Active = new showMessageBox("&hủy bỏ", "&Hủy", "&Chấp nhận", "&Không", "&Được", "&Thử lại", "&Đồng ý");
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
            Dictionary<string, string> filterItems = new Dictionary<string, string>
            {
                {"Hợp đồng 3 tháng", "3"},
                {"Hợp đồng 6 tháng", "6"},
                {"Hợp đồng 12 tháng", "12"},
                {"Hợp đồng vô thời hạn", "0"}
            };
            cbbContractTypeID.DataSource = new BindingSource(filterItems, null);
            cbbContractTypeID.DisplayMember = "Key";
            cbbContractTypeID.ValueMember = "Value";

            cbbContractTypeID.SelectedIndex = 0;
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
            dateSign.EditValue = gridView1.GetFocusedRowCellDisplayText(gcoDateSign);
            if (ctByid.StartDate == null)
            {
                dateStart.EditValue = null;
                lblThongBao.Text = @"Hợp đồng này vẫn chưa có ngày bắt đầu."; 
            }
            else
            {
                dateStart.EditValue = DateTime.Parse(ctByid.StartDate.ToString());
                lblThongBao.Text = "";
            } 
            if(ctByid.EndDate == null)
            {
                dateEnd.EditValue = null;
                lblThongBao1.Text = @"Hợp đồng này vẫn chưa có ngày kết thúc.";
            }
            else
            {
                dateEnd.EditValue = DateTime.Parse(ctByid.EndDate.ToString());
                lblThongBao1.Text = "";
            }
            if (ctByid.ContractTypeID == 6)
            {
                cbbContractTypeID.SelectedIndex = 1;
            }
            else if (ctByid.ContractTypeID == 3)
            {
                cbbContractTypeID.SelectedIndex = 0;
            }
            else if (ctByid.ContractTypeID == 12)
            {
                cbbContractTypeID.SelectedIndex = 2;
            }
            else if (ctByid.ContractTypeID == 0)
            {
                cbbContractTypeID.SelectedIndex = 3;
            }
            cbbCurrency.SelectedValue = ctByid.Currency;
            cbbPayment.SelectedValue = ctByid.Payment;
            cbbStaffID.SelectedValue = ctByid.StaffID;
            cbbStatus.SelectedValue = ctByid.Status;
        }

        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            btnCancel.Enabled = true;
            btnSave.Enabled = false;
            this.btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
   
            dateStart.EditValue = null;
            dateEnd.EditValue = null;
            btnKiemTraLoi.Enabled = true;
            dateSign.EditValue = DateTime.Now;
            dateStart.Properties.MinValue = dateSign.DateTime;
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
                var contractTypeIdInput = Int32.Parse(cbbContractTypeID.SelectedValue.ToString());
                _conTractBus.CreateAContract(txtContractID.Text, sign, currencyInput, start, end, statusInput, basicPayInput, paymentInput, noteInput, staffIdInput, contractTypeIdInput);
                XtraMessageBox.Show(@"Chúc mừng bạn thêm hợp đồng thành công.", @"thông báo");
                
            } catch(Exception)
            {
                XtraMessageBox.Show(@"Chúc mừng bạn thêm hợp đồng thành công.", @"thông báo");
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
            var contractTypeIdInput = Int32.Parse(cbbContractTypeID.SelectedValue.ToString()); 
            _conTractBus.EditContract(txtContractID.Text, sign, currencyInput, start, end, statusInput, basicPayInput, paymentInput, noteInput, staffIdInput, contractTypeIdInput);
            XtraMessageBox.Show(@"Chúc mừng bạn sửa hợp đồng thành công.", @"thông báo");
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
                XtraMessageBox.Show(@"Các trường * không được bỏ trống");
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
                XtraMessageBox.Show(@"Bạn chưa chọn nhân viên", @"thông báo");
            }
            else
            {
                var dia = XtraMessageBox.Show($@"Bạn muốn xóa hợp đồng có mã {txtContractID.Text} này?", @"THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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


        private void cbbStatus_KeyPress(object sender, KeyPressEventArgs e)
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
            dxErrorProvider1.SetError(txtBasicPay, txtBasicPay.Text == "" ? "Lương cơ bản hiện vẫn còn trống" : null);
            //lblThongBao1.Text = _conTractBus.CheckIdInputInTable(cbbStaffID.SelectedValue.ToString()) ? @"Nhân viên chưa hết hạn hợp đồng" : ""; 
            if(dxErrorProvider1.HasErrors)
            {
                btnSave.Enabled = false;
                lblThongBao.Text = @"[LỖI] click vào biểu tượng (X) để xem lỗi.";
            }
            else if(lblThongBao1.Text != "")
            {
                btnSave.Enabled = false;
            }
            else
            {   
                if(_flag == 1)
                {
                    if(lblStatusLastContract.Text == "Còn thời hạn.")
                    {
                        XtraMessageBox.Show($@"Hợp đồng trước của nhân viên {cbbStaffID.Text} vẫn còn thời hạn. thông thể thêm mới hợp đồng.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                        btnSave.Enabled = false;
                    } 
                    else
                    {
                        XtraMessageBox.Show("Đã hết lỗi, hãy nhấn vào nút lưu để hoàn tất thủ tục.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnSave.Enabled = true;
                    }
                }
                else
                {
                    lblThongBao.Text = @"Đã hết lỗi, hãy nhấn vào nút lưu để hoàn tất thủ tục";
                    btnSave.Enabled = true;
                } 
            }
        } 

        private void cbbStaffID_Leave(object sender, EventArgs e)
        {
            lblThongBao.Text = "";
        }
     
        private void cbbStatus_Leave(object sender, EventArgs e)
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

        private void txtBasicPay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                txtBasicPay.Text = "";
            }
        }


        private void dateStart_TextChanged(object sender, EventArgs e)
        {
            dateStart.Properties.MinValue = dateSign.DateTime;

            int x = int.Parse(cbbContractTypeID.SelectedValue.ToString());
            if (x != 0)
            {
                dateEnd.DateTime = dateStart.DateTime.AddMonths(x);
            }
            else
            {
                dateEnd.EditValue = null;
            }
        }

        private void cbbContractTypeID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int x = int.Parse(cbbContractTypeID.SelectedValue.ToString());
            if (x != 0 && dateStart.EditValue != null)
            {
                dateEnd.DateTime = dateStart.DateTime.AddMonths(x);
            }
            else
            {
                dateEnd.EditValue = null;
            }
        }

        private void cbbStaffID_SelectedValueChanged(object sender, EventArgs e)
        { 
            string idStaff = "";
            idStaff = cbbStaffID.SelectedValue.ToString();
            bool finfcontractByIdStaff = false;
            finfcontractByIdStaff = _conTractBus.FindContractByIDStaff(idStaff);
            if (finfcontractByIdStaff)
            {
                grbxLastContract.Enabled = true;
                Contract lastContract = _conTractBus.LoadLastDateContract(idStaff);
                txtMaHDTruoc.Text = lastContract.ContractID; 
                dateBuilOfLastContract.DateTime = DateTime.Parse(lastContract.Date.ToString()); 
                dateStartOfLastContract.DateTime = DateTime.Parse(lastContract.StartDate.ToString());
                if(lastContract.EndDate == null)
                {
                    dateEndOfLastContract.EditValue = null;
                }
                else
                {
                    dateEndOfLastContract.DateTime = DateTime.Parse(lastContract.EndDate.ToString());
                } 
                if(lastContract.Status == true)
                { 
                    lblStatusLastContract.Text = "Còn thời hạn.";
                    lblThongBao.Text = "Hợp đồng trước của nhân viên: " + cbbStaffID.Text + " Còn thời hạn.";
                }
                else
                { 
                    lblStatusLastContract.Text = "Hết hạn hợp đồng.";
                    lblThongBao.Text = "Thêm hợp đồng cho nhân viên: " + cbbStaffID.Text + ".";
                } 
            }
            else
            {
                lblThongBao.Text = "Nhân viên: " + cbbStaffID.Text + " vẫn chưa có hợp đồng.";
                txtMaHDTruoc.Text = "";
                dateBuilOfLastContract.EditValue = null;
                dateStartOfLastContract.EditValue = null;
                dateEndOfLastContract.EditValue = null; 
                lblStatusLastContract.Text = "";
                grbxLastContract.Enabled = false; 
            }
        }
    }
}
