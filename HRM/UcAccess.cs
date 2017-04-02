using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DAL;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace HRM
{
    public partial class UcAccess : DevExpress.XtraEditors.XtraUserControl
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
            //CheckEdit.ReadOnly = true;
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {

        }

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {

        }

        private void gridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            CheckEdit.ReadOnly = true;
            if (e.RowHandle == 0)
                e.RepositoryItem = CheckEdit;
        }
    }
}
