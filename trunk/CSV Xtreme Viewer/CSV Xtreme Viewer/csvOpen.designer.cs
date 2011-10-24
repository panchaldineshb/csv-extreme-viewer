namespace CSVXtremeLoader
{
    partial class csvOpen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(csvOpen));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.txtMetadata = new System.Windows.Forms.TextBox();
            this.lbInFilters = new System.Windows.Forms.ListBox();
            this.bAddIn = new System.Windows.Forms.Button();
            this.bOpen = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbOutFilters = new System.Windows.Forms.ListBox();
            this.bMetadata = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.bRemoveIn = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.bRemoveOut = new System.Windows.Forms.Button();
            this.bAddOut = new System.Windows.Forms.Button();
            this.bOk = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Metadata";
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(68, 8);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(215, 20);
            this.txtFile.TabIndex = 2;
            // 
            // txtMetadata
            // 
            this.txtMetadata.Location = new System.Drawing.Point(68, 35);
            this.txtMetadata.Name = "txtMetadata";
            this.txtMetadata.Size = new System.Drawing.Size(215, 20);
            this.txtMetadata.TabIndex = 3;
            // 
            // lbInFilters
            // 
            this.lbInFilters.FormattingEnabled = true;
            this.lbInFilters.Location = new System.Drawing.Point(36, 17);
            this.lbInFilters.Name = "lbInFilters";
            this.lbInFilters.Size = new System.Drawing.Size(220, 69);
            this.lbInFilters.TabIndex = 5;
            // 
            // bAddIn
            // 
            this.bAddIn.Image = ((System.Drawing.Image)(resources.GetObject("bAddIn.Image")));
            this.bAddIn.Location = new System.Drawing.Point(262, 17);
            this.bAddIn.Name = "bAddIn";
            this.bAddIn.Size = new System.Drawing.Size(24, 24);
            this.bAddIn.TabIndex = 6;
            this.bAddIn.UseVisualStyleBackColor = true;
            this.bAddIn.Click += new System.EventHandler(this.bAddIn_Click);
            // 
            // bOpen
            // 
            this.bOpen.Image = ((System.Drawing.Image)(resources.GetObject("bOpen.Image")));
            this.bOpen.Location = new System.Drawing.Point(289, 8);
            this.bOpen.Name = "bOpen";
            this.bOpen.Size = new System.Drawing.Size(24, 24);
            this.bOpen.TabIndex = 7;
            this.bOpen.UseVisualStyleBackColor = true;
            this.bOpen.Click += new System.EventHandler(this.bMetadata_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "In:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Out:";
            // 
            // lbOutFilters
            // 
            this.lbOutFilters.FormattingEnabled = true;
            this.lbOutFilters.Location = new System.Drawing.Point(36, 125);
            this.lbOutFilters.Name = "lbOutFilters";
            this.lbOutFilters.Size = new System.Drawing.Size(220, 69);
            this.lbOutFilters.TabIndex = 9;
            // 
            // bMetadata
            // 
            this.bMetadata.Image = ((System.Drawing.Image)(resources.GetObject("bMetadata.Image")));
            this.bMetadata.Location = new System.Drawing.Point(289, 35);
            this.bMetadata.Name = "bMetadata";
            this.bMetadata.Size = new System.Drawing.Size(24, 24);
            this.bMetadata.TabIndex = 12;
            this.bMetadata.UseVisualStyleBackColor = true;
            // 
            // openFileDialog
            // 
            this.openFileDialog.CheckPathExists = false;
            this.openFileDialog.DefaultExt = "csv";
            this.openFileDialog.Filter = "CSV File|*.csv";
            // 
            // bRemoveIn
            // 
            this.bRemoveIn.Image = ((System.Drawing.Image)(resources.GetObject("bRemoveIn.Image")));
            this.bRemoveIn.Location = new System.Drawing.Point(262, 49);
            this.bRemoveIn.Name = "bRemoveIn";
            this.bRemoveIn.Size = new System.Drawing.Size(24, 24);
            this.bRemoveIn.TabIndex = 13;
            this.bRemoveIn.Text = "-";
            this.bRemoveIn.UseVisualStyleBackColor = true;
            this.bRemoveIn.Click += new System.EventHandler(this.bRemoveIn_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(209, 92);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(47, 26);
            this.button5.TabIndex = 15;
            this.button5.Text = "Edit";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(209, 200);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(47, 26);
            this.button6.TabIndex = 16;
            this.button6.Text = "Edit";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // bRemoveOut
            // 
            this.bRemoveOut.Image = ((System.Drawing.Image)(resources.GetObject("bRemoveOut.Image")));
            this.bRemoveOut.Location = new System.Drawing.Point(262, 157);
            this.bRemoveOut.Name = "bRemoveOut";
            this.bRemoveOut.Size = new System.Drawing.Size(24, 24);
            this.bRemoveOut.TabIndex = 18;
            this.bRemoveOut.Text = "-";
            this.bRemoveOut.UseVisualStyleBackColor = true;
            this.bRemoveOut.Click += new System.EventHandler(this.bRemoveOut_Click);
            // 
            // bAddOut
            // 
            this.bAddOut.Image = ((System.Drawing.Image)(resources.GetObject("bAddOut.Image")));
            this.bAddOut.Location = new System.Drawing.Point(262, 125);
            this.bAddOut.Name = "bAddOut";
            this.bAddOut.Size = new System.Drawing.Size(24, 24);
            this.bAddOut.TabIndex = 17;
            this.bAddOut.UseVisualStyleBackColor = true;
            this.bAddOut.Click += new System.EventHandler(this.bAddOut_Click);
            // 
            // bOk
            // 
            this.bOk.Location = new System.Drawing.Point(193, 307);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(57, 26);
            this.bOk.TabIndex = 19;
            this.bOk.Text = "&Ok";
            this.bOk.UseVisualStyleBackColor = true;
            this.bOk.Click += new System.EventHandler(this.bOk_Click);
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(256, 307);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(57, 26);
            this.bCancel.TabIndex = 20;
            this.bCancel.Text = "&Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bRemoveOut);
            this.groupBox1.Controls.Add(this.bAddOut);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.bRemoveIn);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lbOutFilters);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.bAddIn);
            this.groupBox1.Controls.Add(this.lbInFilters);
            this.groupBox1.Location = new System.Drawing.Point(13, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 236);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filters";
            // 
            // csvOpen
            // 
            this.AcceptButton = this.bOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(325, 343);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bOk);
            this.Controls.Add(this.bMetadata);
            this.Controls.Add(this.bOpen);
            this.Controls.Add(this.txtMetadata);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "csvOpen";
            this.Text = "Open";
            this.Load += new System.EventHandler(this.csvOpen_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.TextBox txtMetadata;
        private System.Windows.Forms.ListBox lbInFilters;
        private System.Windows.Forms.Button bAddIn;
        private System.Windows.Forms.Button bOpen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lbOutFilters;
        private System.Windows.Forms.Button bMetadata;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button bRemoveIn;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button bRemoveOut;
        private System.Windows.Forms.Button bAddOut;
        private System.Windows.Forms.Button bOk;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

