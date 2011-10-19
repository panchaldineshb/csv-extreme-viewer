using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSVXtremeLoader
{
    public partial class csvOpen : Form
    {
        public string FileName;

        public csvOpen()
        {
            InitializeComponent();
        }
        
        private void bAddIn_Click(object sender, EventArgs e)
        {
            createFilters filter = new createFilters();
                       
            if (filter.ShowDialog(this) == DialogResult.OK)
                lbInFilters.Items.Add(filter.filterType + " | " + filter.filterColumn + " | " + filter.filterSubType + " | " + filter.filterResult);
        }

        private void bMetadata_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
                this.txtFile.Text = openFileDialog.FileName;
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            FileName = txtFile.Text;
            if (!File.Exists(txtFile.Text))
                MessageBox.Show("File does not exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void bAddOut_Click(object sender, EventArgs e)
        {
            createFilters filter = new createFilters();

            if (filter.ShowDialog() == DialogResult.OK)
                lbInFilters.Items.Add(filter.filterType + " | " + filter.filterColumn + " | " + filter.filterSubType + " | " + filter.filterResult);
        }

        private void bRemoveIn_Click(object sender, EventArgs e)
        {
            this.lbInFilters.Items.Remove(this.lbInFilters.SelectedItem);
        }

        private void bRemoveOut_Click(object sender, EventArgs e)
        {
            this.lbOutFilters.Items.Remove(this.lbOutFilters.SelectedItem);
        }

    }
}
