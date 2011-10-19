namespace CSVXtremeLoader
{
    partial class createFilters
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bCancel = new System.Windows.Forms.Button();
            this.bOk = new System.Windows.Forms.Button();
            this.tabDescription = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtString = new System.Windows.Forms.TextBox();
            this.cbText = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.cbNumber = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtRegEx = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.cbDate = new System.Windows.Forms.ComboBox();
            this.dateTime = new System.Windows.Forms.DateTimePicker();
            this.cbColumn = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabDescription.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(28, 30);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(116, 21);
            this.cbType.TabIndex = 0;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Type:";
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(333, 231);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(57, 26);
            this.bCancel.TabIndex = 22;
            this.bCancel.Text = "&Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bOk
            // 
            this.bOk.Location = new System.Drawing.Point(270, 231);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(57, 26);
            this.bOk.TabIndex = 21;
            this.bOk.Text = "&Ok";
            this.bOk.UseVisualStyleBackColor = true;
            this.bOk.Click += new System.EventHandler(this.bOk_Click);
            // 
            // tabDescription
            // 
            this.tabDescription.Controls.Add(this.tabPage1);
            this.tabDescription.Controls.Add(this.tabPage2);
            this.tabDescription.Controls.Add(this.tabPage3);
            this.tabDescription.Controls.Add(this.tabPage4);
            this.tabDescription.Location = new System.Drawing.Point(28, 65);
            this.tabDescription.Name = "tabDescription";
            this.tabDescription.SelectedIndex = 0;
            this.tabDescription.Size = new System.Drawing.Size(362, 159);
            this.tabDescription.TabIndex = 23;
            this.tabDescription.SelectedIndexChanged += new System.EventHandler(this.tabDescription_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtString);
            this.tabPage1.Controls.Add(this.cbText);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(354, 133);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Text";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtString
            // 
            this.txtString.Location = new System.Drawing.Point(118, 7);
            this.txtString.Name = "txtString";
            this.txtString.Size = new System.Drawing.Size(230, 20);
            this.txtString.TabIndex = 27;
            this.txtString.TextChanged += new System.EventHandler(this.txtString_TextChanged);
            // 
            // cbText
            // 
            this.cbText.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbText.FormattingEnabled = true;
            this.cbText.Items.AddRange(new object[] {
            "STARTS WITH",
            "EQUALS",
            "CONTAINS",
            "ENDS WITH"});
            this.cbText.Location = new System.Drawing.Point(6, 6);
            this.cbText.Name = "cbText";
            this.cbText.Size = new System.Drawing.Size(106, 21);
            this.cbText.TabIndex = 26;
            this.cbText.SelectedIndexChanged += new System.EventHandler(this.cbText_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtNum);
            this.tabPage2.Controls.Add(this.cbNumber);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(354, 133);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Number";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(144, 7);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(204, 20);
            this.txtNum.TabIndex = 25;
            this.txtNum.TextChanged += new System.EventHandler(this.txtNum_TextChanged);
            this.txtNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtText_KeyPress);
            // 
            // cbNumber
            // 
            this.cbNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNumber.FormattingEnabled = true;
            this.cbNumber.Items.AddRange(new object[] {
            "MORE THAN",
            "MORE THAN OR EQUAL",
            "EQUALS",
            "LESS THAN OR EQUAL",
            "LESS THAN"});
            this.cbNumber.Location = new System.Drawing.Point(6, 6);
            this.cbNumber.Name = "cbNumber";
            this.cbNumber.Size = new System.Drawing.Size(132, 21);
            this.cbNumber.TabIndex = 24;
            this.cbNumber.SelectedIndexChanged += new System.EventHandler(this.cbRange_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtRegEx);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(354, 133);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "RegEx";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtRegEx
            // 
            this.txtRegEx.Location = new System.Drawing.Point(6, 6);
            this.txtRegEx.Name = "txtRegEx";
            this.txtRegEx.Size = new System.Drawing.Size(342, 20);
            this.txtRegEx.TabIndex = 26;
            this.txtRegEx.TextChanged += new System.EventHandler(this.txtRegEx_TextChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.cbDate);
            this.tabPage4.Controls.Add(this.dateTime);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(354, 133);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Date";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // cbDate
            // 
            this.cbDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDate.FormattingEnabled = true;
            this.cbDate.Items.AddRange(new object[] {
            "BEFORE",
            "EQUALS",
            "AFTER"});
            this.cbDate.Location = new System.Drawing.Point(6, 5);
            this.cbDate.Name = "cbDate";
            this.cbDate.Size = new System.Drawing.Size(141, 21);
            this.cbDate.TabIndex = 25;
            this.cbDate.SelectedIndexChanged += new System.EventHandler(this.cbDate_SelectedIndexChanged);
            // 
            // dateTime
            // 
            this.dateTime.Location = new System.Drawing.Point(153, 6);
            this.dateTime.Name = "dateTime";
            this.dateTime.Size = new System.Drawing.Size(195, 20);
            this.dateTime.TabIndex = 0;
            this.dateTime.ValueChanged += new System.EventHandler(this.dateTime_ValueChanged);
            // 
            // cbColumn
            // 
            this.cbColumn.FormattingEnabled = true;
            this.cbColumn.Location = new System.Drawing.Point(176, 29);
            this.cbColumn.Name = "cbColumn";
            this.cbColumn.Size = new System.Drawing.Size(210, 21);
            this.cbColumn.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Column:";
            // 
            // frmFilter
            // 
            this.AcceptButton = this.bOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(402, 269);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbColumn);
            this.Controls.Add(this.tabDescription);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bOk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbType);
            this.Name = "frmFilter";
            this.Text = "Filter";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.tabDescription.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bOk;
        private System.Windows.Forms.TabControl tabDescription;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.ComboBox cbNumber;
        private System.Windows.Forms.TextBox txtString;
        private System.Windows.Forms.ComboBox cbText;
        private System.Windows.Forms.ComboBox cbDate;
        private System.Windows.Forms.DateTimePicker dateTime;
        private System.Windows.Forms.TextBox txtRegEx;
        private System.Windows.Forms.ComboBox cbColumn;
        private System.Windows.Forms.Label label2;
    }
}