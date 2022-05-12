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
                Grid[cell.YCord][cell.XCord] = cell;
            }
        }
    }

    public override void RemoveFromDomains(Cell cell)
    {
        base.RemoveFromDomains(cell);

        foreach (Cage cage in Cages)
        {
            if (cage.Contains(cell))
            {
                foreach (Cell c in cage.Cells)
                {
                    if(c != cell) c.Domain.Remove(cell.Value);
                }
            }
        }
    }

    public override void AddToDomains(Cell cell)
    {
        base.AddToDomains(cell);

        foreach (Cage cage in Cages)
        {
            if (cage.Contains(cell))
            {
                foreach (Cell c in cage.Cells)
                {
                    if (c != cell && !c.Domain.Contains(cell.Value)) c.Domain.Add(cell.Value);
                }
            }
        }
    }
}
