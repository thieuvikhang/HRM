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
    public partial class ucSection : DevExpress.XtraEditors.XtraUserControl
    {
        public ucSection()
        {
            InitializeComponent();
        }
        sectionBUS sectionBUS = new sectionBUS();

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void ucSection_Load(object sender, EventArgs e)
        {
            sectionGrid.DataSource = sectionBUS.loadAllSection();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
