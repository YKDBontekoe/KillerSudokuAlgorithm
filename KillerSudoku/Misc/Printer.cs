using System.Text;

namespace KillerSudoku.Sudoku;

public static class Printer
{
    // --------- SUDOKU PRINTER --------- //
    public static void Print(int[,] grid)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++) 
                sb.Append(j != grid.GetLength(1) - 1 ? "|---" : "|---|");
            
            sb.Append("\n");
            
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                if (j == 0)
                    sb.Append("| ");
                sb.Append(grid[i, j] + " | ");
            }

            if (grid.GetLength(0) - 1 == i)
            {
                sb.Append("\n");
                
                for (int j = 0; j < grid.GetLength(1); j++)
                    sb.Append(j != grid.GetLength(1) - 1 ? "|---" : "|---|");
                
            }

            sb.AppendLine();
        }
        
        Console.WriteLine(sb.ToString());
    }
}