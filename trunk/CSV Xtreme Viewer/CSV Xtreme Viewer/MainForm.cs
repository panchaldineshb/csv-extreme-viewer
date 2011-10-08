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

namespace CSVXtremeLoader
{
    public partial class MainForm : Form, LoaderListener
    {
        private LinesBuffer buffer;
        private CSVStatistics statistics;

        public MainForm()
        {
            InitializeComponent();

            buffer = new LinesBuffer();
            statistics = new CSVStatistics();

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openCSVFileDialog.ShowDialog(this);
            if (result != DialogResult.OK) return;

            Metadata metadata = new Metadata("Id,Name,Phone");
            setupGridWithMetadata(metadata);

            CSVLoader loader = new CSVLoader(openCSVFileDialog.FileName, buffer, statistics);
            loader.SetListener(this);
            //loader.AddFilter(new FilterByID(0, 5, 10));
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
            int result = buffer.GoTo(e.RowIndex);
            if (result == LinesBuffer.READY) {
                Line line = buffer.CurrentValue();
                if (e.ColumnIndex >= line.columns.Length) return;
                e.Value = line.columns[e.ColumnIndex];
            } else if (result == LinesBuffer.LOAD_REQUIRED) {
                e.Value = "...";
            } else if (result == LinesBuffer.EMPTY) {
                // Do nothing?
            }
        }

    }
}
