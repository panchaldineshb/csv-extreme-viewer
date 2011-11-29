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
        public string filterResult;
        public string filterType;
        public string filterSubType;
        public string filterColumn;

        private ListBox listbox;

        public createFilters(ListBox listbox)
        {
            this.listbox = listbox;
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
            this.cbText.SelectedIndex = 0;
            this.cbNumber.SelectedIndex = 0;
            foreach (object item in listbox.Items)
                cbColumn.Items.Add(item);
            this.cbColumn.SelectedIndex = 0;
            RefreshVariables();
            
        }

        private void RefreshVariables()
        {
            this.filterType = this.tabDescription.SelectedTab.Text;
            if (this.tabDescription.SelectedTab.Text == "Text")
            {
                this.filterSubType = this.cbText.Text;
                this.filterResult = this.txtString.Text;
            }
            else if (this.tabDescription.SelectedTab.Text == "Number")
            {
                this.filterSubType = this.cbNumber.Text;
                this.filterResult = this.txtNum.Text;
            }
            else if (this.tabDescription.SelectedTab.Text == "Range")
            {
                this.filterSubType = "FROM TO";
                this.filterResult = this.txtIDFrom.Text + "|" + this.txtIDTo.Text;
            }
        }

        private void tabDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbType.Text = this.tabDescription.SelectedTab.Text;
            RefreshVariables();
        }

        private void txtText_KeyDown(object sender, KeyEventArgs e)
        {
            if (isNumber(e))
                return;
            if (e.KeyCode != Keys.OemPeriod && e.KeyCode != Keys.Decimal || txtNum.Text.Contains('.'))
            {
                if (e.KeyCode != Keys.OemMinus && e.KeyCode != Keys.Subtract || txtNum.Text.IndexOf("-") != -1 || txtNum.SelectionStart != 0)
                    e.SuppressKeyPress = true;
            }    
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            RefreshVariables();
            if (String.IsNullOrWhiteSpace(filterResult) || String.IsNullOrWhiteSpace(cbColumn.Text))
                MessageBox.Show("Empty or null value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (this.filterType == "Range" && ( Double.Parse(this.txtIDFrom.Text) > Double.Parse(this.txtIDTo.Text)))
                MessageBox.Show("Value FROM should be less than TO", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        
        private void cbText_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.filterSubType = this.cbText.Text;
        }

        private void cbRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.filterSubType = this.cbNumber.Text;
        }

        private bool isNumber(KeyEventArgs e)
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
                    return true;
                default:
                    break;
            }
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                    nonNumberEntered = true;
            if (nonNumberEntered)
                return false;
            return true;
        }

        private void txtIDTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (isNumber(e))
                return;
            if (e.KeyCode != Keys.OemPeriod && e.KeyCode != Keys.Decimal || txtIDTo.Text.Contains('.'))
            {
                if (e.KeyCode != Keys.OemMinus && e.KeyCode != Keys.Subtract || txtIDTo.Text.IndexOf("-") != -1 || txtIDTo.SelectionStart != 0)
                    e.SuppressKeyPress = true;
            }
        }

        private void txtIDFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (isNumber(e))
                return;
            if (e.KeyCode != Keys.OemPeriod && e.KeyCode != Keys.Decimal || txtIDFrom.Text.Contains('.'))
            {
                if (e.KeyCode != Keys.OemMinus && e.KeyCode != Keys.Subtract || txtIDFrom.Text.IndexOf("-") != -1 || txtIDFrom.SelectionStart != 0)
                    e.SuppressKeyPress = true;
            }
        }
        
    }
}
