using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSVData;

namespace CSVXtremeViewer
{
    public partial class csvColumns : Form
    {
        private Metadata metadata;

        public csvColumns(Metadata metadata)
        {
            InitializeComponent();
            this.metadata = metadata;
            updateColumns();
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void bHideAll_Click(object sender, EventArgs e)
        {
            for ( int i=0 ; i < metadata.ColumnsCount ; i++ )
                metadata.visible[i] = false;
            updateColumns();
        }
        
        private void bShowAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < metadata.ColumnsCount; i++)
                metadata.visible[i] = true;
            updateColumns();
        }

        private void updateColumns()
        {
            lbShowColumns.Items.Clear();
            lbHideColumns.Items.Clear();
            for (int i = 0; i < metadata.ColumnsCount; i++)
            {
                if (metadata.visible[i])
                    lbShowColumns.Items.Add(metadata.columnNames[i]);
                else
                    lbHideColumns.Items.Add(metadata.columnNames[i]);
            }
        }

        private void bHideSelected_Click(object sender, EventArgs e)
        {
            if (lbShowColumns.SelectedItem == null)
                return;
            for (int i = 0; i < metadata.ColumnsCount; i++)
            {
                if (metadata.columnNames[i].Equals(lbShowColumns.SelectedItem.ToString()))
                    metadata.visible[i] = false;
            }
            //lbHideColumns.Items.Add(lbShowColumns.SelectedItem);
            //lbShowColumns.Items.Remove(lbShowColumns.SelectedItem);
            updateColumns();
        }

        private void bShowSelected_Click(object sender, EventArgs e)
        {
            if (lbHideColumns.SelectedItem == null)
                return;
            for (int i = 0; i < metadata.ColumnsCount; i++)
            {
                if (metadata.columnNames[i].Equals(lbHideColumns.SelectedItem.ToString()))
                    metadata.visible[i] = true;
            }
            //lbShowColumns.Items.Add(lbHideColumns.SelectedItem);
            //lbHideColumns.Items.Remove(lbHideColumns.SelectedItem);
            updateColumns();
        }
    }
}
