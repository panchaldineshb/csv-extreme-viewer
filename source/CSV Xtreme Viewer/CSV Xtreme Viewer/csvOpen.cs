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
        public string Filters;
        public string Metadata;

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
            if (!File.Exists(txtFile.Text))
                MessageBox.Show("File does not exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            FileName = txtFile.Text;
            this.Filters = string.Empty;
            foreach (string s in lbInFilters.Items)
            {
                this.Filters += s;
                this.Filters += '\n';
            }
            this.Metadata = string.Empty;
            if (rbUserDefined.Checked)
            {
                foreach (string s in lbMetadata.Items)
                {
                    this.Metadata += s.Trim();
                    this.Metadata += ",";
                }
                if(this.Metadata.Length>0)
                    this.Metadata = this.Metadata.Substring(0, this.Metadata.Length - 1);
            }
            else if (rbFirstLine.Checked)
            {
                if (!File.Exists(txtFile.Text))
                {
                    MessageBox.Show("File does not exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                StreamReader sr = new StreamReader(this.txtFile.Text);
                this.Metadata = sr.ReadLine();
                sr.Close();
            }
            else if(rbFile.Checked)
            {
                if (!File.Exists(txtFile.Text))
                {
                    MessageBox.Show("Metadata File does not exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                StreamReader sr = new StreamReader(this.txtMetadata.Text);
                this.Metadata = sr.ReadLine();
                sr.Close();
            }
            if (this.Metadata == string.Empty)
            {
                MessageBox.Show("Empty metadata", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
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

        private void csvOpen_Load(object sender, EventArgs e)
        {
            this.updateForm();
        }

        private void rbFile_CheckedChanged(object sender, EventArgs e)
        {
            this.updateForm();
        }

        private void rbFirstLine_CheckedChanged(object sender, EventArgs e)
        {
            this.updateForm();
        }

        private void rbUserDefined_CheckedChanged(object sender, EventArgs e)
        {
            this.updateForm();
        }

        private void updateForm()
        {
            txtMetadata.Visible = rbFile.Checked;
            bMetadata.Visible = rbFile.Checked;
            lbMetadata.Visible = rbUserDefined.Checked;
            bAddMetadata.Visible = rbUserDefined.Checked;
            bRemoveMetadata.Visible = rbUserDefined.Checked;
            txtNewColumn.Visible = rbUserDefined.Checked;
            lblNewColumn.Visible = rbUserDefined.Checked;
        }

        private void bAddMetadata_Click(object sender, EventArgs e)
        {
            if(txtNewColumn.Text.Trim() == string.Empty)
                return;
            lbMetadata.Items.Add(txtNewColumn.Text.Trim());
        }

        private void bRemoveMetadata_Click(object sender, EventArgs e)
        {
            this.lbMetadata.Items.Remove(this.lbMetadata.SelectedItem);
        }

        private void bMetadata_Click_1(object sender, EventArgs e)
        {
            if (openMetadataDialog.ShowDialog() != DialogResult.Cancel)
                this.txtMetadata.Text = openMetadataDialog.FileName;
        }
    }
}
