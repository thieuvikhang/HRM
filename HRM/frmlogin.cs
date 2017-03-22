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
    public partial class frmlogin : Form
    {
        public Session getsession = new Session();

        public frmlogin()
        {
            InitializeComponent();
        }

        private void frmlogin_Load(object sender, EventArgs e)
        { 
            label1.Text = getsession["userName"].ToString();
            label2.Text = getsession["staffName"].ToString();
            label3.Text = getsession["groupAccessName"].ToString();
        }
    }
}
