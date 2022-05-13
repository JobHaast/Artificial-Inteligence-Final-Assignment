using Sudoku;
using Sudoku.Grids;
using Sudoku.Solvers.KillerSudoku;
using System.Diagnostics;

var killerSudokuGrid = new KillerSudokuGrid(9, KillerSudokuGenerator.GenerateKillerSudokuCages2());

Stopwatch stopwatch = new();
stopwatch.Start();

//Console.WriteLine(BruteForceKillerSudokuSolver.SolveSudoku(killerSudokuGrid));
Console.WriteLine(BackTrackingKillerSudokuSolver.SolveSudoku(killerSudokuGrid));
//Console.WriteLine(ForwardCheckingKillerSudokuSolver.SolveSudoku(killerSudokuGrid));

stopwatch.Stop();
Console.WriteLine(Convert.ToInt32(stopwatch.Elapsed.TotalMilliseconds));
