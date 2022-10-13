using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SortTheBooks
{
    //---------------------------------------------START---------------------------------------------//
    public partial class Dashboard : Form
    {
        //------------------------------------------------------------------------------------------//
        Classes.Replace replaceObj = new Classes.Replace();
        Classes.Identify identifyObj = new Classes.Identify();
        //------------------------------------------------------------------------------------------//
        List<string> callNumbers = new List<string>();
        IDictionary<string, string> topLevelNum = new Dictionary<string, string>();
        private int orderPoints;
        private int matchPoints;

        // Initializes the form.
        public Dashboard()
        {
            InitializeComponent();

            pnlNav.Height = BtnDashboard.Height;
            pnlNav.Top = BtnDashboard.Top;
            pnlNav.Left = BtnDashboard.Left;
            BtnDashboard.BackColor = Color.FromArgb(46, 51, 73);
        }
        //------------------------------------------------------------------------------------------//
        // DASHBOARD BUTTON ON SIDEBAR
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
        // REPLACE BOOKS BUTTON ON SIDEBAR
        private void BtnReplaceBooks_Click(object sender, EventArgs e)
        {
            pnlNav.Height = BtnReplaceBooks.Height;
            pnlNav.Top = BtnReplaceBooks.Top;
            BtnReplaceBooks.BackColor = Color.FromArgb(46, 51, 73);

            PopulateReplaceDataGridView();
            PnlVisibilityChange();
            PnlReplace.Visible = true;
        }
        //------------------------------------------------------------------------------------------//
        // IDENTIFY AREAS BUTTON ON SIDEBAR
        private void BtnIdentify_Click(object sender, EventArgs e)
        {
            pnlNav.Height = BtnIdentify.Height;
            pnlNav.Top = BtnIdentify.Top;
            BtnIdentify.BackColor = Color.FromArgb(46, 51, 73);
            PnlVisibilityChange();
            PopulateMatchColumnsView();
            PnlIdentify.Visible = true;
        }
        //------------------------------------------------------------------------------------------//
        // FIND CALL NUMBERS BUTTON ON SIDEBAR
        private void BtnFindCallNum_Click(object sender, EventArgs e)
        {
            pnlNav.Height = BtnFindCallNum.Height;
            pnlNav.Top = BtnFindCallNum.Top;
            BtnFindCallNum.BackColor = Color.FromArgb(46, 51, 73);
            PnlVisibilityChange();
            PnlFind.Visible = true;
        }
        //------------------------------------------------------------------------------------------//
        // SETTINGS BUTTON ON SIDEBAR
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
        private void BtnSettings_Leave(object sender, EventArgs e)
        {
            BtnSettings.BackColor = Color.FromArgb(24, 30, 54);
        }
        //------------------------------------------------------------------------------------------//
        // THE 'X' AT THE TOP RIGHT OF EVERY PANEL
        private void BtnClose_Click(object sender, EventArgs e)
        {
            PnlVisibilityChange();
            PnlDashboard.Visible = true;
        }
        //------------------------------------------------------------------------------------------//
        // THE 'X' ON THE DASHBOARD THAT WILL CLOSE THE APPLICATION
        private void BtnCloseApp_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //------------------------------------------------------------------------------------------//
        // UP BUTTON ON REPLACE BOOKS
        private void BtnUp_Click(object sender, EventArgs e)
        {
            MoveUp(randomGridView);
        }
        //------------------------------------------------------------------------------------------//
        // DOWN BUTTON ON REPLACE BOOKS
        private void BtnDown_Click(object sender, EventArgs e)
        {
            MoveDown(randomGridView);
        }
        //------------------------------------------------------------------------------------------//
        // RESET BUTTON ON REPLACE BOOKS
        private void BtnReset_Click(object sender, EventArgs e)
        {
            PopulateReplaceDataGridView();
        }
        //------------------------------------------------------------------------------------------//
        // UP BUTTON ON IDENTIFY AREAS
        private void BtnUp2_Click(object sender, EventArgs e)
        {
            MoveUp(rightColumnView);
            BtnFinishMatching.Visible = true;
        }
        //------------------------------------------------------------------------------------------//
        // DOWN BUTTON ON IDENTIFY AREAS
        private void BtnDown2_Click(object sender, EventArgs e)
        {
            MoveDown(rightColumnView);
            BtnFinishMatching.Visible = true;
        }
        //------------------------------------------------------------------------------------------//
        // RESET BUTTON ON IDENTIFY AREAS
        private void BtnReset2_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Your points will be reset to 0 if you clicked yes.", "Are you sure you want to Reset?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                this.matchPoints = 0;

                PopulateMatchColumnsView();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }
        //------------------------------------------------------------------------------------------//
        // FINISH BUTTON ON IDENTIFY AREAS
        private void BtnFinishMatching_Click(object sender, EventArgs e)
        {
            CheckMatchColumns();
        }
        //------------------------------------------------------------------------------------------//
        // This method will make all panels invisible
        private void PnlVisibilityChange()
        {
            PnlReplace.Visible = false;
            PnlFind.Visible = false;
            PnlIdentify.Visible = false;
            PnlSettings.Visible = false;
            PnlDashboard.Visible = false;
        }
        //------------------------------------------------------------------------------------------//
        // Populates the replacing books DataGridView.
        public void PopulateReplaceDataGridView()
        {
            // Reset everything before user begins
            this.orderPoints = 0;
            this.randomGridView.Rows.Clear();
            this.sortedGridView.Rows.Clear();
            sortedGridView.Visible = false;
            randomGridView.Enabled = true;
            LblError.Visible = false;
            BtnReset.Visible = false;
            fireworksBox.Visible = false;
            // Add columns to both the DataGridViews.
            randomGridView.ColumnCount = 1;
            sortedGridView.ColumnCount = 1;
            randomGridView.Columns[0].HeaderText = "Call Number";
            sortedGridView.Columns[0].HeaderText = "Ordered List";
            // Put the new columns into programmatic sort mode
            randomGridView.Columns[0].SortMode = DataGridViewColumnSortMode.Programmatic;
            sortedGridView.Columns[0].SortMode = DataGridViewColumnSortMode.Programmatic;

            // Change selection mode to ColumnHeaderSelect
            randomGridView.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;

            callNumbers = replaceObj.GenerateRandomNumbers();

            // Populate the DataGridView.
            foreach (string num in callNumbers)
            {
                randomGridView.Rows.Add(num);
            }
            callNumbers.Sort();
            foreach (string str in callNumbers)
            {
                sortedGridView.Rows.Add(str);
            }
        }
        //------------------------------------------------------------------------------------------//
        // Checks the users list with an already sorted list
        private void CheckUserList()
        {
            for (int x = 0; x < 10; x++)
            {
                string callNum = randomGridView.Rows[x].Cells[0].Value.ToString();
                string sorted = sortedGridView.Rows[x].Cells[0].Value.ToString();

                switch (callNum == sorted)
                {
                    case true:
                        this.orderPoints++;
                        randomGridView.Rows[x].Cells[0].Style.BackColor = Color.Green;
                        break;

                    default:
                        randomGridView.Rows[x].Cells[0].Style.BackColor = Color.Red;
                        break;
                }
            }
            randomGridView.Enabled = false;
            randomGridView.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            LblError.Visible = true;

            switch (this.orderPoints)
            {
                case 0:
                    LblError.ForeColor = Color.Red;
                    LblError.Text = "You haven't even tried sorting the list of books.";

                    sortedGridView.Visible = true;
                    break;

                case 1:
                    LblError.ForeColor = Color.AntiqueWhite;
                    LblError.Text = "You scored: " + this.orderPoints + " point! Really? You can do better.";
                    break;

                case 10:
                    LblError.ForeColor = Color.AntiqueWhite;
                    LblError.Text = "You scored: " + this.orderPoints + " points!";

                    fireworksBox.Visible = true;
                    break;

                default:
                    LblError.ForeColor = Color.AntiqueWhite;
                    LblError.Text = "You scored: " + this.orderPoints + " points!";

                    sortedGridView.Visible = true;
                    break;
            }
            BtnReset.Visible = true;
        }
        //------------------------------------------------------------------------------------------//
        // CHECK BUTTON ON REPLACE BOOKS
        private void BtnSort_Click(object sender, EventArgs e)
        {
            CheckUserList();
        }
        //------------------------------------------------------------------------------------------//
        // Method that moves selected row up one cell
        private void MoveUp(DataGridView selectedView)
        {
            try
            {
                int totalRows = selectedView.Rows.Count;
                // get index of the row for the selected cell
                int rowIndex = selectedView.SelectedCells[0].OwningRow.Index;
                if (rowIndex == 0)
                    return;
                // get index of the column for the selected cell
                int colIndex = selectedView.SelectedCells[0].OwningColumn.Index;
                DataGridViewRow selectedRow = selectedView.Rows[rowIndex];
                selectedView.Rows.Remove(selectedRow);
                selectedView.Rows.Insert(rowIndex - 1, selectedRow);
                selectedView.ClearSelection();
                selectedView.Rows[rowIndex - 1].Cells[colIndex].Selected = true;
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
        private void MoveDown(DataGridView selectedView)
        {
            try
            {
                int totalRows = selectedView.Rows.Count;
                // get index of the row for the selected cell
                int rowIndex = selectedView.SelectedCells[0].OwningRow.Index;
                if (rowIndex == totalRows - 1)
                    return;
                // get index of the column for the selected cell
                int colIndex = selectedView.SelectedCells[0].OwningColumn.Index;
                DataGridViewRow selectedRow = selectedView.Rows[rowIndex];
                selectedView.Rows.Remove(selectedRow);
                selectedView.Rows.Insert(rowIndex + 1, selectedRow);
                selectedView.ClearSelection();
                selectedView.Rows[rowIndex + 1].Cells[colIndex].Selected = true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString(),
                    "Error Occured", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        //------------------------------------------------------------------------------------------//
        // Populates the Match the columns DataGridView.
        public void PopulateMatchColumnsView()
        {
            // Reset everything before user begins
            this.leftColumnView.Rows.Clear();
            this.rightColumnView.Rows.Clear();
            leftColumnView.Visible = true;
            rightColumnView.Visible = true;
            rightColumnView.Enabled = true;
            //LblError.Visible = false;

            // Add columns to both the DataGridViews.
            leftColumnView.ColumnCount = 1;
            rightColumnView.ColumnCount = 1;
            leftColumnView.Columns[0].HeaderText = "Call Number";
            rightColumnView.Columns[0].HeaderText = "Description";

            // Put the new columns into programmatic sort mode
            rightColumnView.Columns[0].SortMode = DataGridViewColumnSortMode.Programmatic;

            // Change selection mode to ColumnHeaderSelect
            rightColumnView.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;

            this.topLevelNum = identifyObj.PopDict();

            // Populate left column
            for (int i = 0; i < 3; i++)
            {
                leftColumnView.Rows.Add(this.topLevelNum.ElementAt(i).Key);
            }
            // Populate right column
            for (int x = 0; x < 7; x++)
            {
                rightColumnView.Rows.Add(this.topLevelNum.ElementAt(x).Value);
            }
            LblIdentifyError.Text = matchPoints.ToString() + " Points!";
            LblIdentifyError.Visible = true;
        }
        //------------------------------------------------------------------------------------------//
        // Method that checks the matching columns
        public void CheckMatchColumns()
        {
            for (int x = 0; x < 3; x++)
            {
                string callNum = leftColumnView.Rows[x].Cells[0].Value.ToString();
                string definition = rightColumnView.Rows[x].Cells[0].Value.ToString();

                switch (this.topLevelNum[callNum] == definition)
                {
                    case true:
                        this.matchPoints++;
                        rightColumnView.Rows[x].Cells[0].Style.BackColor = Color.Green;
                        break;

                    default:
                        rightColumnView.Rows[x].Cells[0].Style.BackColor = Color.Red;
                        break;
                }
            }

            LblIdentifyError.Visible = true;

            switch (this.matchPoints)
            {
                case 0:
                    LblIdentifyError.ForeColor = Color.Red;
                    LblIdentifyError.Text = "You haven't even tried matching the columns.";
                    break;

                case 1:
                    LblIdentifyError.ForeColor = Color.AntiqueWhite;
                    LblIdentifyError.Text = "You scored: " + this.matchPoints + " point! Really? You can do better.";
                    break;

                case 3:
                    LblIdentifyError.ForeColor = Color.AntiqueWhite;
                    LblIdentifyError.Text = "You scored: " + this.matchPoints + " points!";
                    break;

                default:
                    LblIdentifyError.ForeColor = Color.AntiqueWhite;
                    LblIdentifyError.Text = "You scored: " + this.matchPoints + " points!";
                    break;
            }
            BtnReset2.Visible = true;
        }
        //------------------------------------------------------------------------------------------//
    }
    //---------------------------------------------END----------------------------------------------//
}
