﻿using System;
using System.Windows.Forms;
using BUS;
using DevExpress.XtraEditors;

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
            gcContract.DataSource = _conTractBus.LoadAll();
            dateSign.DateTime = DateTime.Now;
            dateEnd.DateTime = DateTime.Now;
            dateStart.DateTime = DateTime.Now;
            dateStart.Properties.MaxValue = DateTime.Now;
            cbbCurrency.SelectedItem = "VND";
            cbbPayment.SelectedItem = "Tiền mặt";
        }


        private void dateSign_EditValueChanged(object sender, EventArgs e)
        {
            //Khi Ngày lập thay đổi thì:
            //1. Ngày lớn nhất của ngày thành lập là ngày hiện tại(now)
            dateSign.Properties.MaxValue = DateTime.Now;
            //2. Ngày nhỏ nhất của ngày bắt đầu hịu lực = ngày lập
            dateStart.Properties.MinValue = dateSign.DateTime;
        }

        public void GetInfo()
        {
            //txtSectionID.Text = gridView1.GetFocusedRowCellDisplayText(gCoSectionID);
            //txtName.Text = gridView1.GetFocusedRowCellDisplayText(gCoSectionName);
            //mmDescription.Text = gridView1.GetFocusedRowCellDisplayText(gCoDescription);
            //numStandardWorkdays.Text = gridView1.GetFocusedRowCellDisplayText(gCoStandardWorkdays);
            //txtPhone.Text = gridView1.GetFocusedRowCellDisplayText(gCoPhone);
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

        private bool CheckDateStartVsDateSign()
        {
            //Lấy thông tin ngày tháng năm của dateStart
            var namBatDau = dateStart.DateTime.Year;
            var thangBatDau = dateStart.DateTime.Month;
            var ngayBatDau = dateStart.DateTime.Day;
            DateTime fullNgayBatDau = new DateTime(namBatDau, thangBatDau, ngayBatDau);

            //Lấy thông tin ngày tháng năm của dateSign
            var namlapHd = dateSign.DateTime.Year;
            var thangLapHd = dateSign.DateTime.Month;
            var ngayLapHd = dateSign.DateTime.Day;
            DateTime fullNgayKetThuc = new DateTime(namlapHd, thangLapHd, ngayLapHd);

            //So sánh 2 ngày dateStart vs Datesign
            if (DateTime.Compare(fullNgayBatDau, fullNgayKetThuc) < 0)
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //flag=1 xác nhận click vào button add 
            //reset các button
            //reset các textbox
            //reset datagridview
            Flag = 1;

        }

        private void dateStart_DateTimeChanged(object sender, EventArgs e)
        {
            dateEnd.Properties.MinValue = dateStart.DateTime;
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
            dateSign.Properties.MaxValue = DateTime.Now;
        }

        private void dateStart_EditValueChanged(object sender, EventArgs e)
        {
            //Thay đổi value của ngày bắt đầu thì:
            //1. Min của ngày
            dateStart.Properties.MaxValue = dateEnd.DateTime;
            dateEnd.Properties.MinValue = dateStart.DateTime;
            dateEnd.Properties.MaxValue = DateTime.Now;
        }
    }
}
