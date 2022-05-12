using System.Text;

namespace Sudoku.Grids;

public class SudokuGrid
{
    public int Size { get; set; }
    public List<int> ValidNumbers { get; set; }
    public List<List<Cell>> Grid { get; set; } = new List<List<Cell>>();

    public SudokuGrid(int size)
    {
        Size = size;
        ValidNumbers = Enumerable.Range(1, size).ToList();

        for (int i = 0; i < size; i++)
        {
            Grid.Add(new List<Cell>());
            for (int j = 0; j < size; j++)
            {
                Grid[i].Add(new Cell(0, j, i));
            }
        }
    }

    // Check if the number already exists in row
    public bool IsInRow(Cell cell)
    {
        foreach (Cell c in Grid[cell.YCord])
        {
            if (c.Value == cell.Value) { return true; }
        }
        return false;
    }

    // Check if the number already exists in column
    public bool IsInColumn(Cell cell)
    {
        foreach (List<Cell> row in Grid)
        {
            if (row[cell.XCord].Value == cell.Value)
            {
                return true;
            }
        }
        return false;
    }

    // Check if the number already exists in box
    public bool IsInBox(Cell cell)
    {
        int boxSize = (int)Math.Sqrt(Size);
        int col = cell.XCord - cell.XCord % boxSize;
        int row = cell.YCord - cell.YCord % boxSize;

        for (int i = row; i < row + boxSize; i++)
        {
            for (int j = col; j < col + boxSize; j++)
            {
                if (Grid[i][j].Value == cell.Value)
                    return true;
            }
        }
        return false;
    }

    public override string ToString()
    {
        var x = new StringBuilder();
        foreach (List<Cell> row in Grid)
        {
            x.Append('\n');
            x.Append('|');
            foreach (Cell cell in row)
            {
                x.Append(cell.ToString());
                x.Append('|');
            }

        }

        return x.ToString();
    }

    public virtual void RemoveFromDomains(Cell cell)
    {
        foreach (Cell c in Grid[cell.YCord])
        {
            if (c.XCord != cell.XCord)
            {
                c.Domain.Remove(cell.Value);
            }
        }

        foreach (List<Cell> r in Grid)
        {
            if (r[cell.XCord].YCord != cell.YCord)
            {
                r[cell.XCord].Domain.Remove(cell.Value);
            }
        }

        int boxSize = (int)Math.Sqrt(Size);
        int col = cell.XCord - cell.XCord % boxSize;
        int row = cell.YCord - cell.YCord % boxSize;

        for (int i = row; i < row + boxSize; i++)
        {
            for (int j = col; j < col + boxSize; j++)
            {
                if (Grid[i][j] != cell) Grid[i][j].Domain.Remove(cell.Value);
            }
        }
    }

    public virtual void AddToDomains(Cell cell)
    {
        foreach (Cell c in Grid[cell.YCord])
        {
            if (c.XCord != cell.XCord && !c.Domain.Contains(cell.Value))
            {
                c.Domain.Add(cell.Value);
            }
        }

        foreach (List<Cell> r in Grid)
        {
            if (r[cell.XCord].YCord != cell.YCord && !r[cell.XCord].Domain.Contains(cell.Value))
            {
                r[cell.XCord].Domain.Add(cell.Value);
            }
        }

        int boxSize = (int)Math.Sqrt(Size);
        int col = cell.XCord - cell.XCord % boxSize;
        int row = cell.YCord - cell.YCord % boxSize;

        for (int i = row; i < row + boxSize; i++)
        {
            for (int j = col; j < col + boxSize; j++)
            {
                if (Grid[i][j] != cell && !Grid[i][j].Domain.Contains(cell.Value)) Grid[i][j].Domain.Add(cell.Value);
            }
        }
    }
}
