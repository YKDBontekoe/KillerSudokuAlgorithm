using KillerSudoku;
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

// -------------------- KILLER SUDOKU --------------------
// -------------------- BACKTRACKING --------------------
var killerSudoku = GridGenerator.GenerateEasyKillerSudokuGrid();
KillerSudokuSolver.KillerSudoku = killerSudoku;

var killerWatch = System.Diagnostics.Stopwatch.StartNew();
if (RuleOneKillerSudoku.SolveKillerSudoku( 0, 0, killerSudoku.GetSingleCagePositions()))
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

// -------------------- BRUTE-FORCE --------------------
var bruteKillerSudoku = GridGenerator.GenerateEasyKillerSudokuGrid();
KillerSudokuSolver.KillerSudoku = bruteKillerSudoku;

var killerWatchBruteForce = System.Diagnostics.Stopwatch.StartNew();
if (KillerSudokuSolver.SolveKillerSudokuBruteForce())
{
    Console.WriteLine("Killer Sudoku Brute Force Solution: ");
    Printer.Print(bruteKillerSudoku.GetGrid);
}
else
{
    Console.WriteLine("No solution found");
}

killerWatchBruteForce.Stop();
Console.WriteLine("Time taken: {0}ms", killerWatchBruteForce.ElapsedMilliseconds);