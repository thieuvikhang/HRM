using System;
using System.Collections.Generic;
using BUS;
using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace HRM
{
    public partial class UcAccess : XtraUserControl
    {
        private readonly AccessBus _accessBus = new AccessBus();
        // Create an empty list.
        public readonly List<int> Rows = new List<int>();
        public UcAccess()
        {
            InitializeComponent();
        }

        private void UcAccess_Load(object sender, EventArgs e)
        {
            gridAccess.DataSource = _accessBus.LoadAll();
            gridControl2.DataSource = _accessBus.GetAllGroupAccess();
        }

        private void gridView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Rows.Clear();
            foreach (var i in gridView1.GetSelectedRows())
            {
                var d = (int)gridView1.GetRowCellValue(Convert.ToInt32(i), "AccessID");
                Rows.Add(d);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var ten = txtTenNhom.Text;
            var mota = txtTenNhom.Text;
            if (!_accessBus.AddAccesses(ten, mota, Rows))
            {
                XtraMessageBox.Show("Lỗi thêm!");
            }
            UcAccess_Load(sender, e);
        }

        private void btnEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {

        }

        private void btnDelete_ButtonClick(object sender, ButtonPressedEventArgs e)
        {

        }
    }
}
