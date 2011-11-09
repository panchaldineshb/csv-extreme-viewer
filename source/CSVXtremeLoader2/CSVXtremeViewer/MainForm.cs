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
            csvOpen open = new csvOpen();
            DialogResult result = open.ShowDialog(this);
            if (result != DialogResult.OK) return;

            if (loader != null) loader.Close();

            StreamReader sr = new StreamReader(open.FileName);
            string headers = sr.ReadLine();
            sr.Close();
            Metadata metadata = new Metadata(headers.Length, headers);
            setupGridWithMetadata(metadata);
            
            string[] strFilters;
            string[] strFilter;
            List<IFilter> Filters = new List<IFilter>();
            
            strFilters = open.Filters.Split('\n');
            foreach (string s in strFilters)
            {
                strFilter = s.Split('|');
                for(int i=0; i<=strFilter.GetUpperBound(0); i++)
                    strFilter[i] = strFilter[i].Trim();
                if (strFilter[0].Equals("Text"))
                    Filters.Add(new TextFilter(strFilter[2], strFilter[1], strFilter[3]));
                else if (strFilter[0].Equals("Number"))
                    Filters.Add(new NumberFilter(strFilter[2], strFilter[1], Double.Parse(strFilter[3])));
            }

            loader = new CSVLoader.CSVLoader(open.FileName);
            foreach(IFilter f in Filters)
                loader.AddFilter(f);
            //loader.AddFilter(new FilterByID(0, 5000, 10000));
            loader.SetMetadata(metadata);
            loader.Start();

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loader == null) return;

            if (saveFileDialog.ShowDialog(this) != DialogResult.OK) return;

            SaverDialog dialog = new SaverDialog(loader.GetSaver(saveFileDialog.FileName));
            dialog.ShowDialog(this);
        }


    }
}
