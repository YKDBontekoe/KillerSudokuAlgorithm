using KillerSudoku;
using KillerSudoku.Sudoku;
using KillerSudoku.Sudoku.Strategies;

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
var killerSudoku = GridGenerator.GenerateHardKillerSudoGrid();
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