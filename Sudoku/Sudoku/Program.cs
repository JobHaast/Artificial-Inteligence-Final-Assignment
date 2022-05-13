using Sudoku;
using Sudoku.Grids;
using Sudoku.Solvers.KillerSudoku;
using System.Diagnostics;

//var sudokuGrid = new SudokuGrid(9);
//Console.WriteLine(BasicSudokuSolver.SolveSudoku(sudokuGrid));

var killerSudokuGrid = new KillerSudokuGrid(9, KillerSudokuGenerator.GenerateKillerSudokuCages1());

Stopwatch stopwatch = new();
stopwatch.Start();

//Console.WriteLine(BruteForceKillerSudokuSolver.SolveSudoku(killerSudokuGrid));
//Console.WriteLine(BackTrackingKillerSudokuSolver.SolveSudoku(killerSudokuGrid));
Console.WriteLine(BacktrackingAndForwardCheckingKillerSudokuSolver.SolveSudoku(killerSudokuGrid));

stopwatch.Stop();
Console.WriteLine(Convert.ToInt32(stopwatch.Elapsed.TotalMilliseconds));
