using KillerSudoku;

// var grid = GridGenerator.GenerateBasicSudokuGrid();
//
// SudokuSolver.Print(grid);
//
// if (SudokuSolver.SolveBasicSudoku(grid, 0, 0))
// {
//     Console.WriteLine("Basic Sudoku Solution: ");
//     SudokuSolver.Print(grid);
// }
// else
// {
//     Console.WriteLine("No solution found");
// }

var killerSudoku = GridGenerator.GenerateKillerSudoGrid();
SudokuSolver.Print(killerSudoku.GetGrid);

if (SudokuSolver.SolveKillerSudoku(killerSudoku, 0, 0))
{
    Console.WriteLine("Killer Sudoku Solution: ");
    SudokuSolver.Print(killerSudoku.GetGrid);
}
else
{
    Console.WriteLine("No solution found");
}