using System.Numerics;
using KillerSudoku.Models;

namespace KillerSudoku.Sudoku;

public static class KillerSudokuSolver
{
    public static KillerSudokuData KillerSudoku = new(new List<SumZoneData>(), new[,]{{0,0}});
    public static Dictionary<Vector2, SumZoneData> SumZones = new();
    
    public static bool SolveKillerSudoku(int yPos, int xPos)
    {
        // Move to next row when the end of the current row is reached.
        if (xPos == KillerSudoku.GetGrid.GetLength(0))
        {
            yPos++;
            xPos = 0;
            
            if (yPos == KillerSudoku.GetGrid.GetLength(1)) return true;
        }
        
        // Check if current value is not 0. If so, move to next position.
        if (KillerSudoku.GetGrid[yPos, xPos] != 0) return SolveKillerSudoku(yPos, xPos + 1);

        // Iterate over the possible domain values (n = size of x dimension of grid (n*n)).
        for (int num = 1; num < KillerSudoku.GetGrid.GetLength(0) + 1; num++) {
            
            // Check if the number is safe to place in the current position.
            if (IsKillerSudokuSafe(yPos, xPos, num) && IsCageSafe(yPos, xPos, num)){
                KillerSudoku.GetGrid[yPos,xPos] = num;
                
                // Check next position.
                if (SolveKillerSudoku(yPos, xPos + 1)) return true;
            }
            KillerSudoku.GetGrid[yPos,xPos] = 0;
        }
        
        return false;
    }


    // Killer Sudoku Rules: 
    // 1. Each row may only contain a number once
    // 2. Each column may only contain a number once
    // 3. Each 3x3 matrix may contain the number only once
    // 4. Each zone must be summed up to the maximum value of the zone.
    // 5. Each zone may only contain a number once.
    private static bool IsKillerSudokuSafe(int yPos, int xPos,
        int num)
    {
        // Check if the same num is the same row
        for (int x = 0; x <= KillerSudoku.GetGrid.GetLength(0) - 1; x++)
            if (KillerSudoku.GetGrid[yPos, x] == num) return false;

        // Check if the same number is in the same column
        for (int y = 0; y <= KillerSudoku.GetGrid.GetLength(1) - 1; y++)
            if (KillerSudoku.GetGrid[y, xPos] == num) return false;

        // Get the size of a single sub-matrix of the sudoku grid.
        int matrixSize = 3;
        
        // Check if the same num is in the n*n sub-matrix
        int startRow = yPos - yPos % matrixSize, startCol
            = xPos - xPos % matrixSize;
        
        for (int i = 0; i < matrixSize; i++)
        for (int j = 0; j < matrixSize; j++)
            if (KillerSudoku.GetGrid[i + startRow, j + startCol] == num) return false;

        return true;
    }

    private static bool IsCageSafe(int yPos, int xPos,
        int num)
    {
        if (SumZones.TryGetValue(new Vector2(xPos, yPos), out var sumZone))
        {
            int sum = 0;
            foreach (Vector2 position in sumZone.GetPositions())
            {
                int posY = (int) position.Y;
                int posX = (int) position.X;
                
                if (KillerSudoku.GetGrid[posY, posX] == num) return false;
                sum += KillerSudoku.GetGrid[posY, posX];
            }
            
            if (sum + num <= sumZone.GetSum()) return true;
        }
        
        return false;
    }
}