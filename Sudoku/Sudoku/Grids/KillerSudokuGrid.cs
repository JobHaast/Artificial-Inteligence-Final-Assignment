namespace Sudoku.Grids;

public class KillerSudokuGrid : SudokuGrid
{
    public List<Cage> Cages { get; set; }

    public KillerSudokuGrid(int size, List<Cage> cages) : base(size)
    {
        Cages = cages;
        foreach (Cage cage in Cages)
        {
            foreach (Cell cell in cage.Cells)
            {
                Grid[cell.XCord][cell.YCord] = cell;
            }
        }
    }
}
