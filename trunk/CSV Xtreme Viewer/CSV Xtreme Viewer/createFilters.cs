using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSVXtremeLoader
{
    
    public partial class createFilters : Form
    {
        //public List<string> filterResult;
        public string filterResult;
        public string filterType;
        public string filterSubType;
        public string filterColumn;
        
        public createFilters()
        {
            InitializeComponent();
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (TabPage t in tabDescription.TabPages)
                if (t.Text == cbType.Text)
                    this.tabDescription.SelectTab(t);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            foreach (TabPage t in tabDescription.TabPages)
                this.cbType.Items.Add(t.Text);
            this.cbType.Text = this.tabDescription.SelectedTab.Text;
            this.cbText.SelectedIndex = 1;
            this.cbNumber.SelectedIndex = 1;
            this.cbDate.SelectedIndex = 1;
            this.filterType = this.tabDescription.SelectedTab.Text;
        }

        private void tabDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbType.Text = this.tabDescription.SelectedTab.Text;
            this.filterType = this.tabDescription.SelectedTab.Text;
            if (this.tabDescription.SelectedTab.Text == "Text")
            {
                this.filterSubType = this.cbText.Text;
                this.filterResult = this.txtString.Text;
            }
            else if (this.tabDescription.SelectedTab.Text == "Range")
            {
                this.filterSubType = this.cbNumber.Text;
                this.filterResult = this.txtNum.Text;
            }
            else if (this.tabDescription.SelectedTab.Text == "RegEx")
            {
                this.filterSubType = "EQUALS";
                this.filterResult = this.txtRegEx.Text;
            }
            else if (this.tabDescription.SelectedTab.Text == "Date")
            {
                this.filterSubType = this.cbDate.Text;
                this.filterResult = this.dateTime.Value.ToString();
            }
        }
        private void txtText_KeyPress(object sender, KeyEventArgs e)
        {
            bool nonNumberEntered = false;

            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                case Keys.End:
                case Keys.Home:
                case Keys.Back:
                    return;
                default:
                    break;
            }
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.OemPeriod && e.KeyCode != Keys.Decimal || txtNum.Text.Contains('.'))
                    {
                        if (e.KeyCode != Keys.OemMinus && e.KeyCode != Keys.Subtract || txtNum.Text.IndexOf("-") != -1 || txtNum.SelectionStart != 0)
                            nonNumberEntered = true;
                    }
                }
            }
            if (nonNumberEntered)
                e.SuppressKeyPress = true;
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(filterResult) || String.IsNullOrWhiteSpace(cbColumn.Text))
                MessageBox.Show("Empty or null value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                this.DialogResult = DialogResult.OK;
                this.filterColumn = cbColumn.Text;
                this.Close();
            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtString_TextChanged(object sender, EventArgs e)
        {
            this.filterResult = this.txtString.Text;
        }

        private void txtNum_TextChanged(object sender, EventArgs e)
        {
            this.filterResult = this.txtNum.Text;
        }

        private void txtRegEx_TextChanged(object sender, EventArgs e)
        {
            this.filterResult = this.txtRegEx.Text;
        }

        private void cbText_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.filterSubType = this.cbText.Text;
        }

        private void cbRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.filterSubType = this.cbNumber.Text;
        }

        private void cbDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.filterSubType = this.cbDate.Text;
        }

        private void dateTime_ValueChanged(object sender, EventArgs e)
        {
            this.filterResult = this.dateTime.Value.ToString();
        }
    }
}
