using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSVXtremeLoader.Structures;
using System.Timers;

namespace CSVXtremeLoader
{
    public partial class MainForm : LoaderListener
    {
        private bool repaintRequired = false;

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
            if (result == LinesBuffer.READY)
            {
                Line line = buffer.CurrentValue();
                if (e.RowIndex < 20) Console.WriteLine("l: " + line.LineNumber + ", " + line.columns[0]);
                if (e.ColumnIndex >= line.columns.Length) return;
                e.Value = line.columns[e.ColumnIndex];
            }
            else if (result == LinesBuffer.LOAD_REQUIRED)
            {
                //e.Value = "...";
                loader.RefillBuffer(e.RowIndex);

                if (!repaintRequired)
                {
                    System.Timers.Timer timer = new System.Timers.Timer(250);
                    timer.AutoReset = false;
                    timer.Elapsed += new ElapsedEventHandler(RepaintRequired);
                    timer.Enabled = true;
                    repaintRequired = true;
                }
            }
            else if (result == LinesBuffer.EMPTY)
            {
                // Do nothing?
            }
        }


        delegate void DoRepaintRequired(object source, ElapsedEventArgs e);
        public void RepaintRequired(object source, ElapsedEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new DoRepaintRequired(RepaintRequired), new object[] { source, e });
                return;
            }
            repaintRequired = false;
            dataGridView.Refresh();
        }

        
    }
}
