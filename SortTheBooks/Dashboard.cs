using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SortTheBooks.Classes.TestSorter;

namespace SortTheBooks
{
    //---------------------------------------------START---------------------------------------------//
    public partial class Dashboard : Form
    {
        //------------------------------------------------------------------------------------------//
        private ListViewColumnSorter lvwColumnSorter;
        Classes.Replace replaceObj = new Classes.Replace();
        List<string> callNumbers = new List<string>();

        // Initializes the form.
        public Dashboard()
        {
            InitializeComponent();

            // Create an instance of a ListView column sorter and assign it
            // to the ListView control.
            lvwColumnSorter = new ListViewColumnSorter();
            this.TestList.ListViewItemSorter = lvwColumnSorter;

            pnlNav.Height = BtnDashboard.Height;
            pnlNav.Top = BtnDashboard.Top;
            pnlNav.Left = BtnDashboard.Left;
            BtnDashboard.BackColor = Color.FromArgb(46, 51, 73);

            PopulateDataGridView();
        }
        //------------------------------------------------------------------------------------------//
        private void Dashboard_Load(object sender, EventArgs e)
        {
            LoadListView();
        }
        //------------------------------------------------------------------------------------------//
        // Method is called when BtnDashboard is clicked
        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            pnlNav.Height = BtnDashboard.Height;
            pnlNav.Top = BtnDashboard.Top;
            pnlNav.Left = BtnDashboard.Left;
            BtnDashboard.BackColor = Color.FromArgb(46, 51, 73);
            PnlVisibilityChange();
            PnlDashboard.Visible = true;
        }
        //------------------------------------------------------------------------------------------//
        // Method is called when BtnReplaceBooks is clicked
        private void BtnReplaceBooks_Click(object sender, EventArgs e)
        {
            pnlNav.Height = BtnReplaceBooks.Height;
            pnlNav.Top = BtnReplaceBooks.Top;
            BtnReplaceBooks.BackColor = Color.FromArgb(46, 51, 73);
            PnlVisibilityChange();
            PnlReplace.Visible = true;
        }
        //------------------------------------------------------------------------------------------//
        // Method is called when BtnIdentify is clicked
        private void BtnIdentify_Click(object sender, EventArgs e)
        {
            pnlNav.Height = BtnIdentify.Height;
            pnlNav.Top = BtnIdentify.Top;
            BtnIdentify.BackColor = Color.FromArgb(46, 51, 73);
            PnlVisibilityChange();
            PnlIdentify.Visible = true;
        }
        //------------------------------------------------------------------------------------------//
        // Method is called when BtnFindCallNum is clicked
        private void BtnFindCallNum_Click(object sender, EventArgs e)
        {
            pnlNav.Height = BtnFindCallNum.Height;
            pnlNav.Top = BtnFindCallNum.Top;
            BtnFindCallNum.BackColor = Color.FromArgb(46, 51, 73);
            PnlVisibilityChange();
            PnlFind.Visible = true;
        }
        //------------------------------------------------------------------------------------------//
        // Method to run when the test button is clicked
        private void BtnTest_Click(object sender, EventArgs e)
        {
            pnlNav.Height = BtnTest.Height;
            pnlNav.Top = BtnTest.Top;
            BtnTest.BackColor = Color.FromArgb(46, 51, 73);
            PnlVisibilityChange();
            PnlTest.Visible = true;
        }
        //------------------------------------------------------------------------------------------//
        // Method is called when BtnSettings is clicked
        private void BtnSettings_Click(object sender, EventArgs e)
        {
            pnlNav.Height = BtnSettings.Height;
            pnlNav.Top = BtnSettings.Top;
            BtnSettings.BackColor = Color.FromArgb(46, 51, 73);
            PnlVisibilityChange();
            PnlSettings.Visible = true;
        }
        //------------------------------------------------------------------------------------------//
        private void BtnDashboard_Leave(object sender, EventArgs e)
        {
            BtnDashboard.BackColor = Color.FromArgb(24, 30, 54);
        }
        //------------------------------------------------------------------------------------------//
        private void BtnReplaceBooks_Leave(object sender, EventArgs e)
        {
            BtnReplaceBooks.BackColor = Color.FromArgb(24, 30, 54);
        }
        //------------------------------------------------------------------------------------------//
        private void BtnIdentify_Leave(object sender, EventArgs e)
        {
            BtnIdentify.BackColor = Color.FromArgb(24, 30, 54);
        }
        //------------------------------------------------------------------------------------------//
        private void BtnFindCallNum_Leave(object sender, EventArgs e)
        {
            BtnFindCallNum.BackColor = Color.FromArgb(24, 30, 54);
        }
        //------------------------------------------------------------------------------------------//
        private void BtnTest_Leave(object sender, EventArgs e)
        {
            BtnTest.BackColor = Color.FromArgb(24, 30, 54);
        }
        //------------------------------------------------------------------------------------------//
        private void BtnSettings_Leave(object sender, EventArgs e)
        {
            BtnSettings.BackColor = Color.FromArgb(24, 30, 54);
        }
        //------------------------------------------------------------------------------------------//
        private void BtnClose_Click(object sender, EventArgs e)
        {
            PnlVisibilityChange();
            PnlDashboard.Visible = true;
        }
        //------------------------------------------------------------------------------------------//
        private void BtnUp_Click(object sender, EventArgs e)
        {
            MoveUp();
        }
        //------------------------------------------------------------------------------------------//
        private void BtnDown_Click(object sender, EventArgs e)
        {
            MoveDown();
        }
        //------------------------------------------------------------------------------------------//
        // This method will make all panels invisible
        private void PnlVisibilityChange()
        {
            PnlReplace.Visible = false;
            PnlFind.Visible = false;
            PnlIdentify.Visible = false;
            PnlSettings.Visible = false;
            PnlTest.Visible = false;
            PnlDashboard.Visible = false;
        }
        //------------------------------------------------------------------------------------------//
        // Method that loads test data into listview
        private void LoadListView()
        {
            ColumnHeader columnheader;// Used for creating column headers.
            ListViewItem listviewitem;// Used for creating listview items.

            // Ensure that the view is set to show details.
            TestList.View = View.Details;

            // Create some listview items consisting of first and last names.
            listviewitem = new ListViewItem("John");
            listviewitem.SubItems.Add("Smith");
            this.TestList.Items.Add(listviewitem);

            listviewitem = new ListViewItem("Bob");
            listviewitem.SubItems.Add("Taylor");
            this.TestList.Items.Add(listviewitem);

            listviewitem = new ListViewItem("Kim");
            listviewitem.SubItems.Add("Zimmerman");
            this.TestList.Items.Add(listviewitem);

            listviewitem = new ListViewItem("Olivia");
            listviewitem.SubItems.Add("Johnson");
            this.TestList.Items.Add(listviewitem);

            // Create some column headers for the data.
            columnheader = new ColumnHeader();
            columnheader.Text = "First Name";
            this.TestList.Columns.Add(columnheader);

            columnheader = new ColumnHeader();
            columnheader.Text = "Last Name";
            this.TestList.Columns.Add(columnheader);

            // Loop through and size each column header to fit the column header text.
            foreach (ColumnHeader ch in this.TestList.Columns)
            {
                ch.Width = -2;
            }
        }
        //------------------------------------------------------------------------------------------//
        private void TestList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.TestList.Sort();
        }
        //------------------------------------------------------------------------------------------//
        // Populates the DataGridView.
        public void PopulateDataGridView()
        {
            // Add columns to the DataGridView.
            randomGridView.ColumnCount = 1;
            randomGridView.Columns[0].HeaderText = "Call Number";

            // Put the new columns into programmatic sort mode
            randomGridView.Columns[0].SortMode = DataGridViewColumnSortMode.Programmatic;

            // Change selection mode to ColumnHeaderSelect
            randomGridView.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;

            callNumbers = replaceObj.GenerateRandomNumbers();

            // Populate the DataGridView.
            foreach (string num in callNumbers)
            {
                randomGridView.Rows.Add(num);
            }
        }
        //------------------------------------------------------------------------------------------//
        private void BtnSort_Click(object sender, EventArgs e)
        {
            // Check which column is selected, otherwise set NewColumn to null.
            DataGridViewColumn newColumn = randomGridView.Columns.GetColumnCount(
                DataGridViewElementStates.Selected) == 1 ?
                randomGridView.SelectedColumns[0] : null;

            DataGridViewColumn oldColumn = randomGridView.SortedColumn;
            ListSortDirection direction;

            // If oldColumn is null, then the DataGridView is not currently sorted.
            if (oldColumn != null)
            {
                // Sort the same column again, reversing the SortOrder.
                if (oldColumn == newColumn &&
                    randomGridView.SortOrder == SortOrder.Ascending)
                {
                    direction = ListSortDirection.Descending;
                }
                else
                {
                    // Sort a new column and remove the old SortGlyph.
                    direction = ListSortDirection.Ascending;
                    oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                }
            }
            else
            {
                direction = ListSortDirection.Ascending;
            }

            // If no column has been selected, display an error dialog  box.
            if (newColumn == null)
            {
                MessageBox.Show("Select a single column and try again.",
                    "Error: Invalid Selection", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                randomGridView.Sort(newColumn, direction);
                newColumn.HeaderCell.SortGlyphDirection =
                    direction == ListSortDirection.Ascending ?
                    SortOrder.Ascending : SortOrder.Descending;
            }
        }
        //------------------------------------------------------------------------------------------//
        // Method that moves selected row up one cell
        private void MoveUp()
        {
            try
            {
                int totalRows = randomGridView.Rows.Count;
                // get index of the row for the selected cell
                int rowIndex = randomGridView.SelectedCells[0].OwningRow.Index;
                if (rowIndex == 0)
                    return;
                // get index of the column for the selected cell
                int colIndex = randomGridView.SelectedCells[0].OwningColumn.Index;
                DataGridViewRow selectedRow = randomGridView.Rows[rowIndex];
                randomGridView.Rows.Remove(selectedRow);
                randomGridView.Rows.Insert(rowIndex - 1, selectedRow);
                randomGridView.ClearSelection();
                randomGridView.Rows[rowIndex - 1].Cells[colIndex].Selected = true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString(),
                    "Error Occured", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        //------------------------------------------------------------------------------------------//
        // Method moves selected row down one cell
        private void MoveDown()
        {
            try
            {
                int totalRows = randomGridView.Rows.Count;
                // get index of the row for the selected cell
                int rowIndex = randomGridView.SelectedCells[0].OwningRow.Index;
                if (rowIndex == totalRows - 1)
                    return;
                // get index of the column for the selected cell
                int colIndex = randomGridView.SelectedCells[0].OwningColumn.Index;
                DataGridViewRow selectedRow = randomGridView.Rows[rowIndex];
                randomGridView.Rows.Remove(selectedRow);
                randomGridView.Rows.Insert(rowIndex + 1, selectedRow);
                randomGridView.ClearSelection();
                randomGridView.Rows[rowIndex + 1].Cells[colIndex].Selected = true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString(),
                    "Error Occured", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        //------------------------------------------------------------------------------------------//
    }
    //---------------------------------------------END----------------------------------------------//
}
