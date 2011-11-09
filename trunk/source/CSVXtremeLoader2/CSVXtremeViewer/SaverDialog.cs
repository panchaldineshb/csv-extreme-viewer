using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSVLoader;
using System.Timers;

namespace CSVXtremeViewer
{
    public partial class SaverDialog : Form
    {
        private Saver saver;
        private System.Timers.Timer timer;

        public SaverDialog(Saver saver)
        {            
            InitializeComponent();

            this.saver = saver;
            saver.Start();

            timer = new System.Timers.Timer(500);
            timer.AutoReset = true;
            timer.Elapsed += new ElapsedEventHandler(UpdateStatus);
            timer.Enabled = true;
        }

        delegate void DoUpdateStatus(object source, ElapsedEventArgs e);
        public void UpdateStatus(object source, ElapsedEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new DoUpdateStatus(UpdateStatus), new object[] { source, e });
                return;
            }
            int percent = (int)(saver.CurrentLine * 100 / saver.TotalLines);
            progressBar.Value = percent;

            if (saver.CurrentLine == saver.TotalLines)
            {
                timer.Enabled = false;
                Close();
            }
        }

    }
}
