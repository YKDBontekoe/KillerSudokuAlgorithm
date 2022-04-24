using KillerSudoku;

var grid = GridGenerator.GenerateBasicSudokuGrid();

SudokuSolver.Print(grid);

if (SudokuSolver.SolveBasicSudoku(grid, 0, 0))
{
    Console.WriteLine("Solution: ");
    SudokuSolver.Print(grid);
}
else
{
    Console.WriteLine("No solution found");
}