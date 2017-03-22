using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRM
{
    public partial class demoSession : Form
    {

        public Session getsession = new Session();
        public demoSession()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void demoSession_Load(object sender, EventArgs e)
        {
            lblUserNameAcc.Text = getsession["userName"].ToString();
            lblStaffName.Text = getsession["staffName"].ToString();
            lblAccessName.Text = getsession["groupAccessName"].ToString();
        }
    }
}
