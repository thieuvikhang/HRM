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
        public ucContract()
        {
            InitializeComponent();
        }
        contractBUS conTractBUS = new contractBUS();
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textEdit6_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl7_Click(object sender, EventArgs e)
        {

        }

        private void ucContract_Load(object sender, EventArgs e)
        {
            gcContract.DataSource = conTractBUS.loadAllContract();
        }
    }
}
