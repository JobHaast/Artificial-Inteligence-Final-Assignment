using Sudoku;
using Sudoku.Grids;
using Sudoku.Solvers;

var cages = new List<Cage>
{
    new Cage(33, new List<Cell>
    {
        new Cell(0, 0),
        new Cell(1, 0),
        new Cell(0, 1),
        new Cell(1, 1),
        new Cell(2, 0)
    })
};

var killerSudokuGrid = new KillerSudokuGrid(9, cages);
var sudokuGrid = new SudokuGrid(9);

BasicSudokuSolver.IsValid(sudokuGrid, 0, 0);

Console.WriteLine(sudokuGrid);