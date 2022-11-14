using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortTheBooks.Classes
{
    //-----------------------------------------------------------------------------------------------//
    //This class will store some of the general strings that might get repeated and operations that are repeated
    internal class OperationsandStorage
    {
        public string scoredText = "You scored: ";
        //------------------------------------------------------------------------------------------//
        // Method that moves selected row up one cell
        public void MoveUp(DataGridView selectedView)
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
        public void MoveDown(DataGridView selectedView)
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
        //Calls when the reset button is clicked
        public bool ResetButton()
        {
            DialogResult dialogResult = MessageBox.Show("Your points will be reset to 0 if you clicked yes.",
               "Are you sure you want to Reset?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                return true;
            }
            else if (dialogResult == DialogResult.No)
            {
                return false;
            }
            return false;
        }
    }
}
