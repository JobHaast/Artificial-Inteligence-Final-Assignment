namespace Sudoku;

public class Cage
{
    public int ExpectedTotal { get; set; }
    public List<Cell> Cells { get; set; }

    public Cage(int expectedTotal)
    {
        ExpectedTotal = expectedTotal;
        Cells = new List<Cell>();
    }

    public Cage(int expectedTotal, List<Cell> cells) : this(expectedTotal)
    {
        Cells = cells;
    }

    public bool IsValid()
    {
        int total = 0;
        foreach (Cell cell in Cells)
        {
            total += cell.Value;
        }
        // The total value should be the same as the expected total.
        // A cage may only contain unique values in its cells
        return total == ExpectedTotal && Cells.Distinct().Count() == Cells.Count;
    }

    public bool Contains(Cell cell)
    {
        return Cells.Contains(cell);
    }
}
