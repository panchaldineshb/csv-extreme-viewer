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
    public partial class MainForm : Form, LoaderListener
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
            StreamReader sr = new StreamReader(open.FileName);
            string headers = sr.ReadLine();
            string type = sr.ReadLine();
            sr.Close();
            Metadata metadata = new Metadata(headers.Length,headers,type);
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
            //loader.AddFilter(new FilterByID(0, 5000, 100000));
            loader.SetMetatada(metadata);
            loader.Start();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        delegate void StatisticsChanged(CSVStatistics statistics);
        public void OnStatisticsChanged(CSVStatistics statistics)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new StatisticsChanged(OnStatisticsChanged), new object[] { statistics });
                return;
            }
        }

        delegate void NewLinesAvailable(CSVStatistics statistics);
        public void OnNewLinesAvailable(CSVStatistics statistics)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new NewLinesAvailable(OnNewLinesAvailable), new object[] { statistics });
                return;
            }
            dataGridView.RowCount = (int)statistics.FilteredLines;
            ProgressBar.Value = (int)(statistics.BytesRead * 100 / statistics.TotalBytes);
        }

        public void OnCorruptedFile(string message)
        {

        }


        private void setupGridWithMetadata(Metadata metadata)
        {
            dataGridView.Columns.Clear();
            foreach (string columnName in metadata.columnNames)
            {
                DataGridViewCell cell = new DataGridViewTextBoxCell();                    
                DataGridViewColumn column = new DataGridViewColumn(cell);
                column.Name = columnName;
                dataGridView.Columns.Add(column);
            }
        }

        private void dataGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            int result = buffer.GoTo(e.RowIndex+2);
            if (result == LinesBuffer.READY) {
                Line line = buffer.CurrentValue();
                if (e.ColumnIndex >= line.columns.Length) return;
                e.Value = line.columns[e.ColumnIndex];
            } else if (result == LinesBuffer.LOAD_REQUIRED) {
                e.Value = "...";
                loader.RefillBuffer(e.RowIndex);
            } else if (result == LinesBuffer.EMPTY) {
                // Do nothing?
            }
        }

        private void ToolStripContainer_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

    }
}
