namespace Sudoku;

public class Cell
{
    public int Value { get; set; }
    public int XCord { get; set; }
    public int YCord { get; set; }
    public List<int> Domain { get; set; }

    // X and Y cords should start from 0 to keep things simple with lists
    public Cell(int value, int xCord, int yCord, int size)
    {
        Value = value;
        XCord = xCord;
        YCord = yCord;
        Domain = Enumerable.Range(1, size).ToList();
    }

    public Cell(int xCord, int yCord) : this(0, xCord, yCord, 9)
    {
    }

    public Cell(int value, int xCord, int yCord) : this(value, xCord, yCord, 9)
    {
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}
