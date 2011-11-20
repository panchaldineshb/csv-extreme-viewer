namespace CSVXtremeViewer
{
    partial class csvColumns
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
            this.bOk = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.lbShowColumns = new System.Windows.Forms.ListBox();
            this.lblShowColumns = new System.Windows.Forms.Label();
            this.lblHideColumns = new System.Windows.Forms.Label();
            this.lbHideColumns = new System.Windows.Forms.ListBox();
            this.bHideAll = new System.Windows.Forms.Button();
            this.bShowAll = new System.Windows.Forms.Button();
            this.bHideSelected = new System.Windows.Forms.Button();
            this.bShowSelected = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bOk
            // 
            this.bOk.Location = new System.Drawing.Point(255, 212);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(57, 23);
            this.bOk.TabIndex = 0;
            this.bOk.Text = "&Ok";
            this.bOk.UseVisualStyleBackColor = true;
            this.bOk.Click += new System.EventHandler(this.bOk_Click);
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(318, 212);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(57, 23);
            this.bCancel.TabIndex = 1;
            this.bCancel.Text = "&Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // lbShowColumns
            // 
            this.lbShowColumns.FormattingEnabled = true;
            this.lbShowColumns.Location = new System.Drawing.Point(12, 33);
            this.lbShowColumns.Name = "lbShowColumns";
            this.lbShowColumns.Size = new System.Drawing.Size(158, 173);
            this.lbShowColumns.TabIndex = 2;
            // 
            // lblShowColumns
            // 
            this.lblShowColumns.AutoSize = true;
            this.lblShowColumns.Location = new System.Drawing.Point(12, 9);
            this.lblShowColumns.Name = "lblShowColumns";
            this.lblShowColumns.Size = new System.Drawing.Size(37, 13);
            this.lblShowColumns.TabIndex = 3;
            this.lblShowColumns.Text = "Show:";
            // 
            // lblHideColumns
            // 
            this.lblHideColumns.AutoSize = true;
            this.lblHideColumns.Location = new System.Drawing.Point(197, 9);
            this.lblHideColumns.Name = "lblHideColumns";
            this.lblHideColumns.Size = new System.Drawing.Size(32, 13);
            this.lblHideColumns.TabIndex = 5;
            this.lblHideColumns.Text = "Hide:";
            // 
            // lbHideColumns
            // 
            this.lbHideColumns.FormattingEnabled = true;
            this.lbHideColumns.Location = new System.Drawing.Point(217, 33);
            this.lbHideColumns.Name = "lbHideColumns";
            this.lbHideColumns.Size = new System.Drawing.Size(158, 173);
            this.lbHideColumns.TabIndex = 4;
            // 
            // bHideAll
            // 
            this.bHideAll.Location = new System.Drawing.Point(176, 33);
            this.bHideAll.Name = "bHideAll";
            this.bHideAll.Size = new System.Drawing.Size(35, 22);
            this.bHideAll.TabIndex = 6;
            this.bHideAll.Text = ">>";
            this.bHideAll.UseVisualStyleBackColor = true;
            this.bHideAll.Click += new System.EventHandler(this.bHideAll_Click);
            // 
            // bShowAll
            // 
            this.bShowAll.Location = new System.Drawing.Point(176, 61);
            this.bShowAll.Name = "bShowAll";
            this.bShowAll.Size = new System.Drawing.Size(35, 22);
            this.bShowAll.TabIndex = 7;
            this.bShowAll.Text = "<<";
            this.bShowAll.UseVisualStyleBackColor = true;
            this.bShowAll.Click += new System.EventHandler(this.bShowAll_Click);
            // 
            // bHideSelected
            // 
            this.bHideSelected.Location = new System.Drawing.Point(176, 89);
            this.bHideSelected.Name = "bHideSelected";
            this.bHideSelected.Size = new System.Drawing.Size(35, 22);
            this.bHideSelected.TabIndex = 8;
            this.bHideSelected.Text = ">";
            this.bHideSelected.UseVisualStyleBackColor = true;
            this.bHideSelected.Click += new System.EventHandler(this.bHideSelected_Click);
            // 
            // bShowSelected
            // 
            this.bShowSelected.Location = new System.Drawing.Point(176, 117);
            this.bShowSelected.Name = "bShowSelected";
            this.bShowSelected.Size = new System.Drawing.Size(35, 22);
            this.bShowSelected.TabIndex = 9;
            this.bShowSelected.Text = "<";
            this.bShowSelected.UseVisualStyleBackColor = true;
            this.bShowSelected.Click += new System.EventHandler(this.bShowSelected_Click);
            // 
            // csvColumns
            // 
            this.AcceptButton = this.bOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(388, 244);
            this.Controls.Add(this.bShowSelected);
            this.Controls.Add(this.bHideSelected);
            this.Controls.Add(this.bShowAll);
            this.Controls.Add(this.bHideAll);
            this.Controls.Add(this.lblHideColumns);
            this.Controls.Add(this.lbHideColumns);
            this.Controls.Add(this.lblShowColumns);
            this.Controls.Add(this.lbShowColumns);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bOk);
            this.Name = "csvColumns";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Columns";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bOk;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.ListBox lbShowColumns;
        private System.Windows.Forms.Label lblShowColumns;
        private System.Windows.Forms.Label lblHideColumns;
        private System.Windows.Forms.ListBox lbHideColumns;
        private System.Windows.Forms.Button bHideAll;
        private System.Windows.Forms.Button bShowAll;
        private System.Windows.Forms.Button bHideSelected;
        private System.Windows.Forms.Button bShowSelected;
    }
}