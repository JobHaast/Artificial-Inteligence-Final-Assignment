using Sudoku.Grids;

namespace Sudoku.Solvers.KillerSudoku;

public class BaseKillerSudokuSolver
{
    public static bool IsValidCage(KillerSudokuGrid board, int xCord, int yCord, int value)
    {
        foreach (Cage cage in board.Cages)
        {
            List<int> total = new();
            if (!cage.Contains(board.Grid[yCord][xCord])) continue;
            foreach (Cell c in cage.Cells)
            {
                if (c.XCord == xCord && c.YCord == yCord) total.Add(value);
                else total.Add(board.Grid[c.YCord][c.XCord].Value);
            }

            if (total.Sum() > cage.ExpectedTotal) return false;
            if (total.Contains(0)) return true;
            if (total.Sum() != cage.ExpectedTotal) return false;
            return total.Count == new HashSet<int>(total).Count;
        }

        return true;
    }
}
