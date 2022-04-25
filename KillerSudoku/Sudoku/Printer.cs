namespace KillerSudoku.Sudoku;

public static class Printer
{
    // --------- SUDOKU PRINTER --------- //
    public static void Print(int[,] grid)
    {
        for (int i = 0; i < grid.GetLength(0); i++) {
            for (int j = 0; j < grid.GetLength(1); j++)
                Console.Write(grid[i,j] + " ");
            Console.WriteLine();
        }
    }
}