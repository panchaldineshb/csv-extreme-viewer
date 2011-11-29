using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Timers;
using System.IO;
using CSVLoader;
using CSVFilter;
using CSVData;
using CSVXtremeViewer;
using System.Threading;

namespace CSVXtremeLoader
{
    public partial class MainForm : Form
    {
        private CSVLoader.CSVLoader loader;

        public MainForm()
        {
            InitializeComponent();

            System.Timers.Timer timer = new System.Timers.Timer(500);
            timer.AutoReset = true;
            timer.Elapsed += new ElapsedEventHandler(UpdateStatus);
            timer.Enabled = true;

            Thread.CurrentThread.Priority = ThreadPriority.AboveNormal;
        }

        delegate void DoUpdateStatus(object source, ElapsedEventArgs e);
        public void UpdateStatus(object source, ElapsedEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new DoUpdateStatus(UpdateStatus), new object[] { source, e });
                return;
            }
            if (loader == null) return;
            CSVStatistics statistics = loader.GetStatistics();
            LoadStatusLabel.Text = statistics.Status;
            dataGridView.RowCount = (int)statistics.FilteredLines;
            ProgressBar.Value = (int)(statistics.BytesRead * 100 / statistics.TotalBytes);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveAs();
        }

        private void bOpen_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            saveAs();
        }

        private void saveAs()
        {
            if (loader == null) return;

            if (dataGridView.RowCount == 0)
                return;

            if (saveFileDialog.ShowDialog(this) != DialogResult.OK) return;

            SaverDialog dialog = new SaverDialog(loader.GetSaver(saveFileDialog.FileName));
            dialog.ShowDialog(this);
        }

        private void openFile()
        {
            csvOpen open = new csvOpen();
            DialogResult result = open.ShowDialog(this);
            if (result != DialogResult.OK) return;

            if (loader != null) loader.Close();

            Metadata metadata = new Metadata(open.Metadata);
            setupGridWithMetadata(metadata);
            
            loader = new CSVLoader.CSVLoader(open.FileName);
            foreach (IFilter f in open.FiltersIn)
                loader.AddFilter(f);
            foreach (IFilter f in open.FiltersOut)
                loader.AddFilter(f);

            loader.SetMetadata(metadata);
            loader.IgnoreFirstLine = open.IsFirstLineUsed();
            loader.Start();
            columnsToolStripMenuItem.Enabled = true;
        }

        private void columnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loader == null)
                return;
            csvColumns columns = new csvColumns( loader.GetMetadata() );
            DialogResult result = columns.ShowDialog(this);
            if (result != DialogResult.OK)
                return;
            for (int i = 0; i < dataGridView.ColumnCount; i++)
                dataGridView.Columns[i].Visible = loader.GetMetadata().visible[i];
        }

    }
}
