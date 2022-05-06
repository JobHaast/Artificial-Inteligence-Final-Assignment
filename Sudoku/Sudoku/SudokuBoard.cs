namespace Sudoku;

public class SudokuBoard
{
    public List<List<string>> Board { get; set; }

    public SudokuBoard(List<List<string>> board)
    {
        Board = board;
    }

    private static bool IsValid(char[,] board, int row, int col, char c)
    {
        for (int i = 0; i < 9; i++)
        {
            //check row  
            if (board[i, col] != '.' && board[i, col] == c)
                return false;
            //check column  
            if (board[row, i] != '.' && board[row, i] == c)
                return false;
            //check 3*3 block  
            if (board[3 * (row / 3) + i / 3, 3 * (col / 3) + i % 3] != '.' && board[3 * (row / 3) + i / 3, 3 * (col / 3) + i % 3] == c)
                return false;
        }
        return true;
    }
}
