using Sudoku.Grids;

namespace Sudoku.Solvers.KillerSudoku;

public class BacktrackingAndForwardCheckingKillerSudokuSolver : BaseKillerSudokuSolver
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
            if (yCord == board.Size) return true;
        }

        // Only set value when cell doesnt have a value
        if (board.Grid[yCord][xCord].Value != 0)
            return IsValid(board, yCord, xCord + 1);

        // Check possible values
        foreach (int value in board.Grid[yCord][xCord].Domain.ToList())
        {
            var possibleValue = new Cell(value, xCord, yCord);
            if (!(board.IsInRow(possibleValue) || board.IsInColumn(possibleValue) || board.IsInBox(possibleValue)) && IsValidCage(board, xCord, yCord, value))
            {
                board.Grid[yCord][xCord].Value = value;
                board.RemoveFromDomains(board.Grid[yCord][xCord]);

                // next position
                if (IsValid(board, yCord, xCord + 1)) return true;
                board.AddToDomains(board.Grid[yCord][xCord]);
            }

            board.Grid[yCord][xCord].Value = 0;
        }

        return false;
    }
}
