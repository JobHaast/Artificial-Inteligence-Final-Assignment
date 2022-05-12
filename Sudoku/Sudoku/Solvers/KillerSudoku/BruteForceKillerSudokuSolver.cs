using Sudoku.Grids;

namespace Sudoku.Solvers.KillerSudoku;

public class BruteForceKillerSudokuSolver : BaseKillerSudokuSolver
{
    public static string SolveSudoku(KillerSudokuGrid board)
    {
        if (IsValid(board))
        {
            return board.ToString();
        };
        return "Unable to solve";
    }

    public static bool IsValid(KillerSudokuGrid board)
    {
        bool isSolved = false;
        while (!isSolved)
        {
            int xCord = new Random().Next(0, board.Size);
            int yCord = new Random().Next(0, board.Size);
            board.Grid[yCord][xCord] = new Cell(new Random().Next(1, board.Size), xCord, yCord);

            bool isValid = true;
            for (int y = board.Size - 1; y >= 0; y--)
            {
                for (int x = board.Size - 1; x >= 0; x--)
                {
                    if (!isValid) break;

                    int value = board.Grid[y][x].Value;
                    var possibleValue = new Cell(value, xCord, yCord);
                    if (!(board.IsInRow(possibleValue) || board.IsInColumn(possibleValue) || board.IsInBox(possibleValue)) && IsValidCage(board, x, y, value))
                    {
                        continue;
                    }
                    isValid = false;
                    break;
                }

                isSolved = isValid;
            }
        }

        return true;
    }
}
