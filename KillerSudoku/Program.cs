using KillerSudoku;
using KillerSudoku.Models;
using KillerSudoku.Sudoku;
using KillerSudoku.Sudoku.Heuristics;

var grid = GridGenerator.GenerateBasicSudokuGrid();

var basicWatch = System.Diagnostics.Stopwatch.StartNew();
if (BasicSudokuSolver.SolveBasicSudoku(grid, 0, 0))
{
    Console.WriteLine("Basic Sudoku Solution: ");
    Printer.Print(grid);
}
else
{
    Console.WriteLine("No solution found");
}

basicWatch.Stop();
Console.WriteLine("Time taken: {0}ms", basicWatch.ElapsedMilliseconds);
Console.WriteLine("-----------------------------------------------------");
// -------------------- KILLER SUDOKU --------------------
// -------------------- BASIC --------------------
var killerSudoku = GridGenerator.GenerateEasyKillerSudokuGrid();
KillerSudokuSolver.KillerSudoku = killerSudoku;
KillerSudokuSolver.Iterations = 0;

var killerWatch = System.Diagnostics.Stopwatch.StartNew();
if (KillerSudokuSolver.SolveKillerSudoku( 0, 0))
{
    Console.WriteLine("Killer Sudoku Solution: ");
    Printer.Print(killerSudoku.GetGrid);
}
else
{
    Console.WriteLine("No solution found");
}

killerWatch.Stop();
Console.WriteLine("Time taken: {0}ms", killerWatch.ElapsedMilliseconds);
Console.WriteLine("Iterations taken: " +  KillerSudokuSolver.Iterations);
Console.WriteLine("-----------------------------------------------------");

// -------------------- RULE ONE --------------------
var killerRuleOneSudoku = GridGenerator.GenerateEasyKillerSudokuGrid();
KillerSudokuSolver.KillerSudoku = killerRuleOneSudoku;
KillerSudokuSolver.Iterations = 0;

var killerRuleOneWatch = System.Diagnostics.Stopwatch.StartNew();
if (RuleOneKillerSudoku.SolveKillerSudoku( 0, 0, killerSudoku.GetSingleCagePositions()))
{
    Console.WriteLine("Killer Sudoku Solution with rule one: ");
    Printer.Print(killerRuleOneSudoku.GetGrid);
}
else
{
    Console.WriteLine("No solution found");
}

killerRuleOneWatch.Stop();
Console.WriteLine("Time taken: {0}ms", killerRuleOneWatch.ElapsedMilliseconds);
Console.WriteLine("Iterations taken: " +  KillerSudokuSolver.Iterations);

// -------------------- RULE REMAINING --------------------
var killerRulerRemainingSudoku = GridGenerator.GenerateEasyKillerSudokuGrid();
KillerSudokuSolver.KillerSudoku = killerRulerRemainingSudoku;
KillerSudokuSolver.Iterations = 0;

var killerRuleRemainingWatch = System.Diagnostics.Stopwatch.StartNew();
if (RuleRemainingKillerSudoku.SolveKillerSudoku( 0, 0))
{
    Console.WriteLine("Killer Sudoku Solution with remaining rule: ");
    Printer.Print(killerRulerRemainingSudoku.GetGrid);
}
else
{
    Console.WriteLine("No solution found");
}

killerRuleRemainingWatch.Stop();
Console.WriteLine("Time taken: {0}ms", killerRuleRemainingWatch.ElapsedMilliseconds);
Console.WriteLine("Iterations taken: " +  KillerSudokuSolver.Iterations);

// -------------------- BRUTE-FORCE --------------------
// var bruteKillerSudoku = GridGenerator.GenerateEasyKillerSudokuGrid();
// KillerSudokuSolver.KillerSudoku = bruteKillerSudoku;
// KillerSudokuSolver.Iterations = 0;
//
// var killerWatchBruteForce = System.Diagnostics.Stopwatch.StartNew();
// if (KillerSudokuSolver.SolveKillerSudokuBruteForce())
// {
//     Console.WriteLine("Killer Sudoku Brute Force Solution: ");
//     Printer.Print(bruteKillerSudoku.GetGrid);
// }
// else
// {
//     Console.WriteLine("No solution found");
// }
//
// killerWatchBruteForce.Stop();
// Console.WriteLine("Time taken: {0}ms", killerWatchBruteForce.ElapsedMilliseconds);
