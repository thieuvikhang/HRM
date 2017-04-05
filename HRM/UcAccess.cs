using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using BUS;
using DAL;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace HRM
{
    public partial class UcAccess : XtraUserControl
    {
        readonly AccessBus _accessBus = new AccessBus();
        readonly HRMModelDataContext _aHrm = new HRMModelDataContext();
        public UcAccess()
        {
            InitializeComponent();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            //LogInternal_RowItem  selectedLogItem = (LogInternal_RowItem)GridControl_ListLogItem.SelectedItem);
        }

        private void UcAccess_Load(object sender, EventArgs e)
        {
            gridAccess.DataSource = _accessBus.LoadAll();
            CheckEdit.ReadOnly = true;
        }

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {

        }

        private void gridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            // Create an empty list.
            var rows = new ArrayList();
            // Add the selected rows to the list.
            for (var i = 0; i < gridView1.SelectedRowsCount; i++)
            {
                if (gridView1.GetSelectedRows()[i] >= 0)
                    rows.Add(gridView1.GetDataRow(gridView1.GetSelectedRows()[i]));
            }
            try
            {
                gridView1.BeginUpdate();
                foreach (var t in rows)
                {
                    //var row = t as DataRow;
                    // Change the field value.
/*                    if (row != null)
                        row["Discontinued"] = true;*/
                    if (t != null)
                        XtraMessageBox.Show(t.ToString());
                }
            }
            finally
            {
                gridView1.EndUpdate();
            }
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
        }
    }
}
