using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuPuzzleValidator
{
    public class Sudoku
    {
        private List<List<int>> _sudokuData;
        public Sudoku(List<List<int>> sudokuData)
        {
            this._sudokuData = sudokuData;
        }

        public bool IsValid()
        {
            var rowLength = _sudokuData[0].Count;
            var standard = Enumerable.Range(1, rowLength);

            if (IsInteger(Math.Sqrt(rowLength)) == false)
            {
                return false;
            }

            foreach (var row in _sudokuData)
            {
                if (row.Count != rowLength)
                    return false;

                if (ValidateArr(row, standard) == false)
                    return false;
            }

            var columns = from y in Enumerable.Range(0, rowLength)
                          select (
                            from x in Enumerable.Range(0, rowLength)
                            select _sudokuData[x][y]);

            foreach (var column in columns)
            {
                if (ValidateArr(column, standard) == false)
                    return false;
            }

            return true;
        }

        private bool IsInteger(double d)
        {
            return d == (int)d;
        }

        private bool ValidateArr(IEnumerable<int> arr, IEnumerable<int> standard)
        {
            return arr.OrderBy(x => x).SequenceEqual(standard);
        }
    }
}
