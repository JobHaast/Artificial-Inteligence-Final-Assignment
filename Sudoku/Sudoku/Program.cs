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
    })
};

//var sudokuGrid = new SudokuGrid(9);
//Console.WriteLine(BasicSudokuSolver.SolveSudoku(sudokuGrid));

var killerSudokuGrid = new KillerSudokuGrid(9, cages);

Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();
//Console.WriteLine(KillerSudokuSolver.SolveSudoku(killerSudokuGrid));
//Console.WriteLine(BackTrackingKillerSudokuSolver.SolveSudoku(killerSudokuGrid));
Console.WriteLine(ForwardCheckingKillerSudokuSolver.SolveSudoku(killerSudokuGrid));
stopwatch.Stop();
Console.WriteLine(Convert.ToInt32(stopwatch.Elapsed.TotalMilliseconds));
