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
        public ucContract()
        {
            InitializeComponent();
        }
        contractBUS conTractBUS = new contractBUS();
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        //Ham set các button 
        public void SetButton(bool set)
        {
            //code set
            
        }

        //ham set cac TextBox
        public void SetText(bool set)
        {
            //code set
        }

        private void textEdit6_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl7_Click(object sender, EventArgs e)
        {

        }

        private void ucContract_Load(object sender, EventArgs e)
        {
            gcContract.DataSource = conTractBUS.loadAll();
        }

        private void dateSign_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //flag=1 xác nhận click vào button add 
            //reset các button
            //reset các textbox
            //reset datagridview
            flag = 1;

        }


    }
}
