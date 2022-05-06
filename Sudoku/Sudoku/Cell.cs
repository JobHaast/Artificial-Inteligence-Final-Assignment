namespace Sudoku;

public class Cell
{
    public int Value { get; set; }
    public int XCord { get; set; }
    public int YCord { get; set; }

    // X and Y cords should start from 0 to keep things simple with lists
    public Cell(int xCord, int yCord)
    {
        Value = 0;
        XCord = xCord;
        YCord = yCord;
    }

    public Cell(int value, int xCord, int yCord)
    {
        Value = value;
        XCord = xCord;
        YCord = yCord;
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}
