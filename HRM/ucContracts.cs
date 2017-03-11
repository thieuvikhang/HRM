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
    public partial class ucContract : DevExpress.XtraEditors.XtraUserControl
    {

        int flag = 0;
        HRMModelDataContext aHRM = new HRMModelDataContext();
        public ucContract()
        {
            InitializeComponent();
        }
        contractBUS ctBUS = new contractBUS();
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void AddSection()
        {
            try
            {
                decimal basicPay = decimal.Parse(txtBasicPay.Text);
                string contractID = txtContractID.Text;
                string contractTypeID = cbbContractTypeID.SelectedValue.ToString();
                string currency = cbbCurrency.SelectedValue.ToString();
                string payment = cbbPayment.SelectedValue.ToString();
                string staffID = cbbStaffID.SelectedValue.ToString();
                bool status = bool.Parse(cbbStatus.SelectedValue.ToString());
                string note = mmNote.Text;
                DateTime datesign = dateSign.DateTime;
                DateTime datestard = dateStart.DateTime;
                DateTime dateend = dateEnd.DateTime;
                ctBUS.CreateAContract(contractID, datesign, currency, datestard, dateend, status, basicPay, payment, note, staffID, contractTypeID); 
            } catch
            {

            }
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

        #region set botton and textbox
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
        #endregion

        private void textEdit6_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl7_Click(object sender, EventArgs e)
        {

        }

        private void ucContract_Load(object sender, EventArgs e)
        {
            
            //load data len grid
            gcContract.DataSource = ctBUS.loadAll();

            //Load các combobox: Staffs and ContractType
            LoadComboboxContractType();
            LoadComboboxStaffs();
            loadcbbstatus();

            //Set cac date
            dateEnd.Properties.MaxValue = DateTime.Now;
            dateStart.Properties.MaxValue = DateTime.Now;
            dateSign.Properties.MaxValue = DateTime.Now;
            
        }



        private void dateSign_EditValueChanged(object sender, EventArgs e)
        {
            
            //Kiem tra o dateStart 
            if (dateSign.EditValue != null)
            {
                //Neu ko co Gia tri => max dateSign = date now
                if(dateStart.EditValue != null)
                {
                    dateEnd.Properties.MinValue = dateStart.DateTime;
                }
                else
                {
                    dateEnd.Properties.MinValue = dateSign.DateTime;
                }

                if(dateEnd.EditValue != null)
                {
                    dateStart.Properties.MaxValue = dateEnd.DateTime;
                }
                else
                {
                    dateStart.Properties.MaxValue = DateTime.Now;
                    dateStart.Properties.MinValue = dateSign.DateTime;
                }
            }
            else
            {
                if(dateStart.EditValue != null)
                {
                    dateEnd.Properties.MinValue = dateStart.DateTime;
                }
                else
                {
                    dateEnd.Properties.MinValue = dateSign.DateTime;
                }
                dateStart.Properties.MinValue = dateSign.DateTime;
            }
        }

        //public void GetInfo()
        //{
        //    //txtSectionID.Text = gridView1.GetFocusedRowCellDisplayText(gCoSectionID);
        //    //txtName.Text = gridView1.GetFocusedRowCellDisplayText(gCoSectionName);
        //    //mmDescription.Text = gridView1.GetFocusedRowCellDisplayText(gCoDescription);
        //    //numStandardWorkdays.Text = gridView1.GetFocusedRowCellDisplayText(gCoStandardWorkdays);
        //    //txtPhone.Text = gridView1.GetFocusedRowCellDisplayText(gCoPhone);

        //    //Kiem tra ngayLap va ngaybatdau hiu luc
        //    if(!CheckDateStartVSDateSign())
        //    {
        //        dxErrorProvider1.SetError(dateSign, "Ngày lập lớn hơn ngày bắt đầu hịu lực.");
        //        dxErrorProvider1.SetError(dateStart, "Ngày bắt đầu hịu lực nhỏ hơn ngày lập.");
        //    }
        //    else
        //    {
        //        dxErrorProvider1.SetError(dateSign, null);
        //        dxErrorProvider1.SetError(dateStart, null);
        //    }
        //    //Kiem tra ngaybatdau hiu luc va ngay ket thuc hiu luc
        //    if (!CheckDateStartVSDateEnd())
        //    {
        //        dxErrorProvider1.SetError(dateEnd, "Ngày Kết Khúc phải lớn hơn ngày bắt đầu.");
        //        dxErrorProvider1.SetError(dateStart, "Ngày bắt đầu phải nhỏ hơn ngày kết thúc.");
        //    }
        //    else
        //    {
        //        dxErrorProvider1.SetError(dateEnd, null);
        //        dxErrorProvider1.SetError(dateStart, null);
        //    }
        //}

        

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
        #endregion

        #region Check, Get Error ngày lập, ngày bắt đầu hịu lực, ngày kết thúc hịu lực của hợp đồng
        //Check ngày bắt đầu và ngày kết thúc hợp đồng
        private bool CheckDateStartVSDateEnd()
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

        public void GetErrorDateStartVSDateEnd()
        {
            //Kiem tra ngaybatdau hiu luc va ngay ket thuc hiu luc
            if (!CheckDateStartVSDateEnd())
            {
                dxErrorProvider1.SetError(dateEnd, "Ngày Kết Khúc phải lớn hơn ngày bắt đầu.");
                dxErrorProvider1.SetError(dateStart, "Ngày bắt đầu phải nhỏ hơn ngày kết thúc.");
            }
            else
            {
                dxErrorProvider1.SetError(dateEnd, null);
                dxErrorProvider1.SetError(dateStart, null);
            }
        }

        //check ngày lập và ngày bắt đầu
        private bool CheckDateStartVSDateSign()
        {
            //Lấy thông tin ngày tháng năm của dateStart
            var namBatDau = dateStart.DateTime.Year;
            var thangBatDau = dateStart.DateTime.Month;
            var ngayBatDau = dateStart.DateTime.Day;
            DateTime fullNgayBatDau = new DateTime(namBatDau, thangBatDau, ngayBatDau);

            //Lấy thông tin ngày tháng năm của dateSign
            var namlapHD = dateSign.DateTime.Year;
            var thangLapHD = dateSign.DateTime.Month;
            var ngayLapHD = dateSign.DateTime.Day;
            DateTime fullNgayLap = new DateTime(namlapHD, thangLapHD, ngayLapHD);

            //So sánh 2 ngày dateStart vs Datesign
            if (DateTime.Compare(fullNgayLap, fullNgayBatDau) > 0)
            {
                //Ngày bắt đầu nhỏ hơn ngày lập Hợp đồng
                return false;
            }
            else
            {
                //Ngày bắt đầu lớn hơn hoặc trùng ngày lập hợp đồng
                return true;
            }
        }

        public void GetErrorDateStartVSDateSign()
        {
            //Kiem tra ngayLap va ngaybatdau hiu luc
            if (!CheckDateStartVSDateSign())
            {
                dxErrorProvider1.SetError(dateSign, "Ngày lập lớn hơn ngày bắt đầu hịu lực.");
                dxErrorProvider1.SetError(dateStart, "Ngày bắt đầu hịu lực nhỏ hơn ngày lập.");
            }
            else
            {
                dxErrorProvider1.SetError(dateSign, null);
                dxErrorProvider1.SetError(dateStart, null);
            }
        }
        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //flag=1 xác nhận click vào button add 
            //reset các button
            //reset các textbox
            //reset datagridview
            flag = 1;

        }

        private void dateStart_DateTimeChanged(object sender, EventArgs e)
        {
            
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateEnd_DateTimeChanged(object sender, EventArgs e)
        {
            //dateStart.Properties.MaxValue = dateEnd.DateTime;
        }

        private void dateSign_DateTimeChanged(object sender, EventArgs e)
        {
            
        }


        private void dateStart_EditValueChanged(object sender, EventArgs e)
        {
            //Kiem tra o dateStart 
            if (dateStart.EditValue == null)
            {
                if(dateEnd.EditValue != null)
                {
                    dateSign.Properties.MaxValue = dateEnd.DateTime;
                }
                else
                {
                    dateSign.Properties.MaxValue = DateTime.Now;
                }
                if(dateSign.EditValue != null)
                {
                    dateEnd.Properties.MinValue = dateSign.DateTime;
                }
                else
                {
                    dateEnd.Properties.MinValue = dateSign.DateTime;
                }
            }
            else
            {
                //Neu co gia tri => max dateSign = dateStart
                dateSign.Properties.MaxValue = dateStart.DateTime;
                dateEnd.Properties.MinValue = dateStart.DateTime;
                dateEnd.Properties.MaxValue = DateTime.Now;
            }

        }

        private void dateEnd_EditValueChanged(object sender, EventArgs e)
        {
            if(dateEnd.EditValue != null)
            {
                //value cua ngay ket thuc khac null
                //check toi ngay bat dau
                if(dateStart.EditValue != null)
                {
                    //value cua ngay bat dau khac null
                    //lay date max cua ngay lap = ngay bat dau
                    dateSign.Properties.MaxValue = dateStart.DateTime;
                }
                else
                {
                    //value cua ngay bat dau = null
                    //lay max date cua ngay lap = ngay ket thuc
                    dateSign.Properties.MaxValue = dateEnd.DateTime;
                }

                //check toi ngay lap
                if(dateSign.EditValue != null)
                {
                    //value cua ngay lap khac null
                    //lay date min cua ngay bat dau = ngay lap
                    dateStart.Properties.MinValue = dateSign.DateTime;
                    dateStart.Properties.MaxValue = dateEnd.DateTime;
                }
                else
                {
                    //value cua ngay bat dau khac null
                    dateStart.Properties.MinValue = dateSign.DateTime;
                    
                }
            }
            else
            {
                if(dateSign.EditValue != null)
                {
                    dateStart.Properties.MaxValue = DateTime.Now;
                    dateStart.Properties.MinValue = dateSign.DateTime;
                }
                else
                {
                    dateStart.Properties.MaxValue = DateTime.Now;
                    dateStart.Properties.MinValue = dateSign.DateTime;
                }
                if(dateStart.EditValue != null)
                {
                    dateSign.Properties.MaxValue = dateStart.DateTime;
                }
                else
                {
                    dateSign.Properties.MaxValue = DateTime.Now;
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {//sf
        }

        private void cbbStaffID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
