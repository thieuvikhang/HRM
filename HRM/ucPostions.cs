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
    public partial class ucPostions : DevExpress.XtraEditors.XtraUserControl
    {
        public ucPostions()
        {
            InitializeComponent();
        }
        PostBUS postBUS = new PostBUS();
        private void ucPostions_Load(object sender, EventArgs e)
        {
            gcPostions.DataSource = postBUS.LoadAll();
        }
    }
}
