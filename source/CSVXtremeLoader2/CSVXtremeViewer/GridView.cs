using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using CSVData;
using CSVLoader;

namespace CSVXtremeLoader
{
    public partial class MainForm
    {

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
            if (loader == null) return;
            LineReader lineReader = loader.GetLineReader();
            Line line = lineReader.GetLine(e.RowIndex);
            if (line == null) return;
            if (e.ColumnIndex >= line.columns.Length) return;
            e.Value = line.columns[e.ColumnIndex];
        }
    }
}
