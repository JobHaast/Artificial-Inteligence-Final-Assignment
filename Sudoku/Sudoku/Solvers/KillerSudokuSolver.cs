using Sudoku.Grids;

namespace Sudoku.Solvers;

public class KillerSudokuSolver
{
    public static string SolveSudoku(KillerSudokuGrid board)
    {
        if (IsValid(board, 0, 0))
        {
            return board.ToString();
        };
        return "Unable to solve";
    }

    public static bool IsValid(KillerSudokuGrid board, int yCord, int xCord)
    {
        // Move to next row when at the end of a row
        if (xCord == board.Size)
        {
            yCord++;
            xCord = 0;

            // Return true when at the end of the board
            if (yCord == board.Size)
            {
                return true;
            }
        }

        // Only set value when cell doesnt have a value
        if (board.Grid[yCord][xCord].Value != 0)
            return IsValid(board, yCord, xCord + 1);

        // Check possible values
        foreach (int value in board.ValidNumbers)
        {
            var possibleValue = new Cell(value, xCord, yCord);
            if (board.IsInRow(possibleValue) || board.IsInColumn(possibleValue) || board.IsInBox(possibleValue))
            {
                continue;
            }
            board.Grid[yCord][xCord].Value = value;

            // next position
            if (IsValid(board, yCord, xCord + 1)) return true;

            board.Grid[yCord][xCord].Value = 0;
        }

        return false;
    }

    public static bool IsValidCage(KillerSudokuGrid board, Cell cell)
    {
        foreach(Cage cage in board.Cages)
        {
            List<int> total = new List<int>();
            if (!cage.Contains(cell)) continue;
            foreach (Cell c in cage.Cells)
            {
                if (c.XCord == cell.XCord && c.YCord == cell.YCord) total.Add(cell.Value);
                else total.Add(board.Grid[c.YCord][c.XCord].Value);
            }

            //if (total.Sum() > cage.ExpectedTotal) return false;
            if (total.Contains(0)) return true;
            if (total.Sum() != cage.ExpectedTotal) return false;
            return total.Count == new HashSet<int>(total).Count;
        }

        return false;
    }
}
