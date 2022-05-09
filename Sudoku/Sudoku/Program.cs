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

var sudokuGrid = new SudokuGrid(9);
Console.WriteLine(BasicSudokuSolver.SolveSudoku(sudokuGrid));

//var killerSudokuGrid = new KillerSudokuGrid(9, cages);
//Console.WriteLine(KillerSudokuSolver.SolveSudoku(killerSudokuGrid));