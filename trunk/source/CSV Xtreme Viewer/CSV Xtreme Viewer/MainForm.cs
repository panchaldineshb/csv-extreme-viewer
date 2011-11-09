using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSVXtremeLoader.Structures;
using System.Text.RegularExpressions;
using System.Timers;
using System.IO;

namespace CSVXtremeLoader
{
    public partial class MainForm : Form
    {
        private CSVLoader loader;
        private LinesBuffer buffer;
        private CSVStatistics statistics;

        public MainForm()
        {
            InitializeComponent();

            buffer = new LinesBuffer();
            statistics = new CSVStatistics();

            System.Timers.Timer timer = new System.Timers.Timer(500);
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
            LoadStatusLabel.Text = statistics.Status;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            csvOpen open = new csvOpen();
            DialogResult result = open.ShowDialog(this);
            if (result != DialogResult.OK) return;

            Metadata metadata = new Metadata(open.Metadata);
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

            loader = new CSVLoader(open.FileName, buffer, statistics);
            loader.SetListener(this);
            foreach(IFilter f in Filters)
                loader.AddFilter(f);
            //loader.AddFilter(new FilterByID(0, 5000, 10000));
            loader.SetMetatada(metadata);
            loader.Start();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (loader != null) loader.SetListener(null);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
