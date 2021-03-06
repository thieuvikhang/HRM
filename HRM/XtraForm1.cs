﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraPivotGrid;

namespace HRM
{
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm1()
        {
            InitializeComponent();
            // This line of code is generated by Data Source Configuration Wizard
            pivotTableAdapter1.Fill(hrmDataSet1.Pivot);
        }
        private void XtraForm1_Load(object sender, EventArgs e)
        {
            
        }

        private void pivotGridControl1_FieldValueDisplayText_1(object sender, PivotFieldDisplayTextEventArgs e)
        {
            if (e.ValueType == PivotGridValueType.GrandTotal)
            {
                if (e.IsColumn)
                {
                    e.DisplayText = "Tổng cộng";
                }
                else
                {
                    e.DisplayText = "Tổng cộng";
                }
            }
        }
    }
}