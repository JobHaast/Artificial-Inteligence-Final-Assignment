using Sudoku;
using Sudoku.Grids;
using Sudoku.Solvers.KillerSudoku;
using System.Diagnostics;

var cages = new List<Cage>
{
    new Cage(33, new List<Cell>
    {
        new Cell(0, 0),
        new Cell(0, 1),
        new Cell(1, 0),
        new Cell(1, 1),
        new Cell(0, 2),
        new Cell(0, 3)
    }),
    new Cage(12, new List<Cell>
    {
        new Cell(2, 0),
        new Cell(2, 1),
        new Cell(3, 1),
    }),
    new Cage(1, new List<Cell>
    {
        new Cell(3, 0)
    }),
    new Cage(8, new List<Cell>
    {
        new Cell(4, 0),
        new Cell(5, 0)
    }),
    new Cage(17, new List<Cell>
    {
        new Cell(6, 0),
        new Cell(6, 1),
        new Cell(6, 2)
    }),
    new Cage(13, new List<Cell>
    {
        new Cell(7, 0),
        new Cell(7, 1)
    }),
    new Cage(14, new List<Cell>
    {
        new Cell(8, 0),
        new Cell(8, 1),
        new Cell(8, 2),
    }),
    new Cage(20, new List<Cell>
    {
        new Cell(1, 2),
        new Cell(2, 2),
        new Cell(3, 2)
    }),
    new Cage(12, new List<Cell>
    {
        new Cell(4, 1),
        new Cell(5, 1),
        new Cell(4, 2),
    }),
    new Cage(20, new List<Cell>
    {
        new Cell(5, 2),
        new Cell(5, 3),
        new Cell(6, 3),
    }),
    new Cage(8, new List<Cell>
    {
        new Cell(7, 2),
        new Cell(7, 3)
    }),
    new Cage(8, new List<Cell>
    {
        new Cell(8, 3)
    }),
    new Cage(8, new List<Cell>
    {
        new Cell(1, 3),
        new Cell(2, 3),
        new Cell(3, 3)
    }),
    new Cage(13, new List<Cell>
    {
        new Cell(4, 3),
        new Cell(4, 4)
    }),
    new Cage(8, new List<Cell>
    {
        new Cell(5, 4),
        new Cell(6, 4)
    }),
    new Cage(7, new List<Cell>
    {
        new Cell(7, 4),
        new Cell(8, 4)
    }),
    new Cage(11, new List<Cell>
    {
        new Cell(0, 4),
        new Cell(1, 4)
    }),
    new Cage(12, new List<Cell>
    {
        new Cell(2, 4),
        new Cell(3, 4)
    }),
    new Cage(8, new List<Cell>
    {
        new Cell(0, 5),
        new Cell(0, 6)
    }),
    new Cage(29, new List<Cell>
    {
        new Cell(1, 5),
        new Cell(1, 6),
        new Cell(1, 7),
        new Cell(2, 5),
        new Cell(2, 6)
    }),
    new Cage(26, new List<Cell>
    {
        new Cell(3, 5),
        new Cell(4, 5),
        new Cell(4, 6),
        new Cell(5, 6)
    }),
    new Cage(13, new List<Cell>
    {
        new Cell(5, 5),
        new Cell(6, 5),
        new Cell(6, 6)
    }),
    new Cage(5, new List<Cell>
    {
        new Cell(7, 5),
        new Cell(7, 6)
    }),
    new Cage(11, new List<Cell>
    {
        new Cell(8, 5),
        new Cell(8, 6)
    }),
    new Cage(2, new List<Cell>
    {
        new Cell(0, 7)
    }),
    new Cage(13, new List<Cell>
    {
        new Cell(3, 6),
        new Cell(2, 7),
        new Cell(3, 7)
    }),
    new Cage(13, new List<Cell>
    {
        new Cell(4, 7),
        new Cell(5, 7),
        new Cell(6, 7)
    }),
    new Cage(20, new List<Cell>
    {
        new Cell(7, 7),
        new Cell(8, 7),
        new Cell(8, 8)
    }),
    new Cage(12, new List<Cell>
    {
        new Cell(0, 8),
        new Cell(1, 8)
    }),
    new Cage(15, new List<Cell>
    {
        new Cell(2, 8),
        new Cell(3, 8),
        new Cell(4, 8)
    }),
    new Cage(2, new List<Cell>
    {
        new Cell(5, 8)
    }),
    new Cage(11, new List<Cell>
    {
        new Cell(6, 8),
        new Cell(7, 8)
    })
};
var cagesV2 = new List<Cage>
{
    new Cage(12, new List<Cell>
    {
        new Cell(0, 0),
        new Cell(0, 1),
        new Cell(1, 1)
    }),
    new Cage(11, new List<Cell>
    {
        new Cell(1, 0),
        new Cell(2, 0)
    }),
    new Cage(3, new List<Cell>
    {
        new Cell(3, 0)
    }),
    new Cage(13, new List<Cell>
    {
        new Cell(4, 0),
        new Cell(4, 1),
        new Cell(3, 1)
    }),
    new Cage(13, new List<Cell>
    {
        new Cell(5, 0),
        new Cell(6, 0),
        new Cell(7, 0)
    }),
    new Cage(15, new List<Cell>
    {
        new Cell(8, 0),
        new Cell(8, 1),
        new Cell(7, 1)
    }),
    new Cage(15, new List<Cell>
    {
        new Cell(5, 1),
        new Cell(6, 1)
    }),
    new Cage(19, new List<Cell>
    {
        new Cell(2, 1),
        new Cell(2, 2),
        new Cell(1, 2)
    }),
    new Cage(8, new List<Cell>
    {
        new Cell(0, 2),
        new Cell(0, 3)
    }),
    new Cage(14, new List<Cell>
    {
        new Cell(1, 3),
        new Cell(2, 3)
    }),
    new Cage(12, new List<Cell>
    {
        new Cell(3, 2),
        new Cell(3, 3)
    }),
    new Cage(17, new List<Cell>
    {
        new Cell(4, 2),
        new Cell(5, 2),
        new Cell(4, 3)
    }),
    new Cage(22, new List<Cell>
    {
        new Cell(6, 2),
        new Cell(7, 2),
        new Cell(5, 3),
        new Cell(6, 3)
    }),
    new Cage(6, new List<Cell>
    {
        new Cell(8, 2),
        new Cell(7, 3),
        new Cell(8, 3)
    }),
    new Cage(7, new List<Cell>
    {
        new Cell(0, 4),
        new Cell(1, 4)
    }),
    new Cage(18, new List<Cell>
    {
        new Cell(2, 4),
        new Cell(3, 4),
        new Cell(2, 5),
        new Cell(3, 5),
        new Cell(4, 5)
    }),
    new Cage(8, new List<Cell>
    {
        new Cell(4, 4),
        new Cell(5, 4)
    }),
    new Cage(25, new List<Cell>
    {
        new Cell(6, 4),
        new Cell(6, 5),
        new Cell(6, 6),
        new Cell(7, 5)
    }),
    new Cage(21, new List<Cell>
    {
        new Cell(7, 4),
        new Cell(8, 4),
        new Cell(8, 5)
    }),
    new Cage(17, new List<Cell>
    {
        new Cell(0, 5),
        new Cell(0, 6)
    }),
    new Cage(7, new List<Cell>
    {
        new Cell(1, 5),
        new Cell(1, 6)
    }),
    new Cage(14, new List<Cell>
    {
        new Cell(2, 6),
        new Cell(2, 7)
    }),
    new Cage(12, new List<Cell>
    {
        new Cell(5, 5),
        new Cell(5, 6),
        new Cell(4, 6)
    }),
    new Cage(4, new List<Cell>
    {
        new Cell(8, 6)
    }),
    new Cage(11, new List<Cell>
    {
        new Cell(7, 6),
        new Cell(7, 7),
        new Cell(7, 8)
    }),
    new Cage(6, new List<Cell>
    {
        new Cell(0, 7),
        new Cell(1, 7)
    }),
    new Cage(7, new List<Cell>
    {
        new Cell(0, 8)
    }),
    new Cage(24, new List<Cell>
    {
        new Cell(2, 7),
        new Cell(3, 7),
        new Cell(4, 7),
        new Cell(3, 8),
        new Cell(4, 8)
    }),
    new Cage(10, new List<Cell>
    {
        new Cell(1, 8),
        new Cell(2, 8)
    }),
    new Cage(11, new List<Cell>
    {
        new Cell(5, 7),
        new Cell(5, 8)
    }),
    new Cage(8, new List<Cell>
    {
        new Cell(6, 7),
        new Cell(6, 8)
    }),
    new Cage(15, new List<Cell>
    {
        new Cell(8, 7),
        new Cell(8, 8)
    }),
};
//var sudokuGrid = new SudokuGrid(9);
//Console.WriteLine(BasicSudokuSolver.SolveSudoku(sudokuGrid));

var killerSudokuGrid = new KillerSudokuGrid(9, cagesV2);

Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();
//Console.WriteLine(BruteForceKillerSudokuSolver.SolveSudoku(killerSudokuGrid));
//Console.WriteLine(BackTrackingKillerSudokuSolver.SolveSudoku(killerSudokuGrid));
Console.WriteLine(ForwardCheckingKillerSudokuSolver.SolveSudoku(killerSudokuGrid));
stopwatch.Stop();
Console.WriteLine(Convert.ToInt32(stopwatch.Elapsed.TotalMilliseconds));
