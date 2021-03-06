using System.Numerics;
using KillerSudoku.Models;

namespace KillerSudoku.Sudoku;

public static class SolveKillerSudokuWithBacktracking
{
    public static KillerSudokuData KillerSudoku = new(new List<CageData>(), new[,]{{0,0}});
    public static int Iterations;
        
    public static bool SolveKillerSudoku(int yPos, int xPos)
    {
        // Move to next row when the end of the current row is reached.
        if (xPos == KillerSudoku.Grid.GetLength(0))
        {
            yPos++;
            xPos = 0;
            
            if (yPos == KillerSudoku.Grid.GetLength(1)) return true;
        }
        
        // Check if current value is not 0. If so, move to next position.
        if (KillerSudoku.Grid[yPos, xPos] != 0) return SolveKillerSudoku(yPos, xPos + 1);

        // Increment the number of iterations.
        Iterations++;
        
        // Iterate over the possible domain values (n = size of x dimension of grid (n*n)).
        for (int num = 1; num < KillerSudoku.Grid.GetLength(0) + 1; num++) {
            // Check if the number is safe to place in the current position.
            if (HelperFunctions.IsKillerSudokuSafe(yPos, xPos, num, KillerSudoku) && HelperFunctions.IsCageSafe(yPos, xPos, num, KillerSudoku)){
                KillerSudoku.Grid[yPos,xPos] = num;
                
                
                // Check next position.
                if (SolveKillerSudoku(yPos, xPos + 1)) return true;
            }
            KillerSudoku.Grid[yPos,xPos] = 0;
        }
        
        return false;
    }
}