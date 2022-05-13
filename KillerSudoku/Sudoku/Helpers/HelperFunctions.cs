using System.Numerics;
using KillerSudoku.Models;

namespace KillerSudoku.Sudoku;

public static class HelperFunctions
{
    // Basic Sudoku Rules: 
    // 1. Each row may only contain a number once
    // 2. Each column may only contain a number once
    // 3. Each 3x3 matrix may contain the number only once
    public static bool IsKillerSudokuSafe(int yPos, int xPos,
        int num, KillerSudokuData sudokuData)
    {
        // Check if the same num is the same row
        for (int x = 0; x <= sudokuData.GetGrid.GetLength(0) - 1; x++)
            if (sudokuData.GetGrid[yPos, x] == num) return false;

        // Check if the same number is in the same column
        for (int y = 0; y <= sudokuData.GetGrid.GetLength(1) - 1; y++)
            if (sudokuData.GetGrid[y, xPos] == num) return false;

        // Get the size of a single sub-matrix of the sudoku grid.
        int matrixSize = 3;
        
        // Check if the same num is in the n*n sub-matrix
        int startRow = yPos - yPos % matrixSize, startCol
            = xPos - xPos % matrixSize;
        
        for (int i = 0; i < matrixSize; i++)
        for (int j = 0; j < matrixSize; j++)
            if (sudokuData.GetGrid[i + startRow, j + startCol] == num) return false;

        return true;
    }

    // Killer Sudoku Rules:
    // 1. Each zone must be summed up to the maximum value of the zone.
    // 2. Each zone may only contain a number once.
    public static bool IsCageSafe(int yPos, int xPos,
        int num, KillerSudokuData sudokuData)
    {
        List<int> cageValues = new List<int>();
        foreach (var cage in sudokuData.GetCages)
        {
            if (!cage.IsInCage(new Vector2(xPos, yPos))) continue;
            foreach (Vector2 position in cage.GetPositions())
            {
                if ((int)position.X == xPos && (int)position.Y == yPos) cageValues.Add(num);
                else cageValues.Add(sudokuData.GetGrid[(int)position.Y, (int)position.X]);
            }
            
            int currentSum  = cageValues.Sum();
            if (currentSum > cage.GetSum()) return false;

            bool hasZero = cageValues.Any(s => s == 0);
            if (hasZero) return true;
            if (currentSum != cage.GetSum()) return false;
            return cageValues.Count == new HashSet<int>(cageValues).Count;
        }

        return false;
    }
}