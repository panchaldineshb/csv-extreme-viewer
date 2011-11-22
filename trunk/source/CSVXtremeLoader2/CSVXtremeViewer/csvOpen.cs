using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSVFilter;

namespace CSVXtremeLoader
{
    public partial class csvOpen : Form
    {
        public string FileName;
        public string Filters;
        public string Metadata;
        public List<IFilter> FiltersIn = new List<IFilter>();
        public List<IFilter> FiltersOut = new List<IFilter>();

        public csvOpen()
        {
            InitializeComponent();
        }

        private void createFilter(string type, string subtype, string column, string result, List<IFilter> list, ListBox listbox, bool inverse)
        {
            IFilter filter2 = null;
            if (type.Equals("Text"))
                filter2 = new TextFilter(subtype, column, result);
            else if (type.Equals("Number"))
                filter2 = new NumberFilter(subtype, column, Double.Parse(result));
            else if (type.Equals("Range"))
            {
                long minID, maxID;

                minID = long.Parse(result.Substring(0, result.IndexOf("|")));
                maxID = long.Parse(result.Substring(result.IndexOf("|") + 1));

                filter2 = new RangeFilter(column, minID, maxID);
            }

            if (filter2 != null)
            {
                filter2.inverse = inverse;
                list.Add(filter2);
                listbox.Items.Add(filter2);
            }
        }

        private void bAddIn_Click(object sender, EventArgs e)
        {
            if (lbMetadata.Items.Count == 0)
            {
                MessageBox.Show("Empty metadata.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } 
            createFilters filter = new createFilters(lbMetadata);

            if (filter.ShowDialog(this) == DialogResult.OK)
            {
                createFilter(filter.filterType, filter.filterSubType, filter.filterColumn, filter.filterResult, FiltersIn, lbInFilters, false);
            }
        }

        private void bMetadata_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
                this.txtFile.Text = openFileDialog.FileName;
            updateForm();
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            if (!File.Exists(txtFile.Text))
            {
                MessageBox.Show("File does not exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FileName = txtFile.Text;

            this.Metadata = "";
            foreach (string s in lbMetadata.Items)
            {
                this.Metadata += s.Trim();
                this.Metadata += ",";
            }
            if(this.Metadata.Length>0)
                this.Metadata = this.Metadata.Substring(0, this.Metadata.Length - 1);

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
            if (lbMetadata.Items.Count == 0)
            {
                MessageBox.Show("Empty metadata.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            createFilters filter = new createFilters(lbMetadata);

            if (filter.ShowDialog() == DialogResult.OK)
                createFilter(filter.filterType, filter.filterSubType, filter.filterColumn, filter.filterResult, FiltersOut, lbOutFilters, true);
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
            lbMetadata.Visible = true;
            bAddMetadata.Visible = rbUserDefined.Checked;
            bRemoveMetadata.Visible = rbUserDefined.Checked;
            txtNewColumn.Visible = rbUserDefined.Checked;
            lblNewColumn.Visible = rbUserDefined.Checked;

            if (rbFirstLine.Checked) lbMetadata.Height = 69;
            else lbMetadata.Height = 43;

            if (rbFile.Checked) lbMetadata.Top = 76;
            else lbMetadata.Top = 49;

            if (rbFirstLine.Checked || rbFile.Checked)
            {
                string filename = "";
                if (rbFirstLine.Checked) filename = txtFile.Text;
                else filename = txtMetadata.Text;
                if (File.Exists(filename))
                {
                    StreamReader reader = new StreamReader(filename);
                    string data = reader.ReadLine();
                    reader.Close();

                    lbMetadata.Items.Clear();
                    string[] parts = data.Split(',');
                    foreach (string part in parts) lbMetadata.Items.Add(part.Trim());
                }

            }
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

            updateForm();
        }

        public bool IsFirstLineUsed()
        {
            return rbFirstLine.Checked;
        }
    }
}
