using System.Numerics;
using KillerSudoku.Models;

namespace KillerSudoku.Sudoku;

public static class KillerSudokuSolver
{
    public static KillerSudokuData KillerSudoku = new(new List<CageData>(), new[,]{{0,0}});
    public static int Iterations;
        
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

        // Increment the number of iterations.
        Iterations++;
        
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

    public static bool SolveKillerSudokuBruteForce()
    {
        bool isSolved = false;
        while (!isSolved)
        {
            KillerSudoku.GetGrid[new Random().Next(0, 9),new Random().Next(0, 9)] = new Random().Next(1, 10);

            bool isValid = true;
            for (int y = KillerSudoku.GetGrid.GetLength(0) - 1; y >= 0; y--)
            {
                for (int x = KillerSudoku.GetGrid.GetLength(0) - 1; x >= 0; x--)
                {
                    if (!isValid) break;
                    
                    int val = KillerSudoku.GetGrid[y, x];
                    if (IsKillerSudokuSafe(y, x, val) && IsCageSafe(y, x, val)) continue;
                    isValid = false;
                    break;
                }

                isSolved = isValid;
            }
        }

        return true;
    }
    
    // Killer Sudoku Rules: 
    // 1. Each row may only contain a number once
    // 2. Each column may only contain a number once
    // 3. Each 3x3 matrix may contain the number only once
    // 4. Each zone must be summed up to the maximum value of the zone.
    // 5. Each zone may only contain a number once.
    public static bool IsKillerSudokuSafe(int yPos, int xPos,
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

    public static bool IsCageSafe(int yPos, int xPos,
        int num)
    {
        List<int> cageValues = new List<int>();
        foreach (var cage in KillerSudoku.GetCages)
        {
            if (!cage.IsInCage(new Vector2(xPos, yPos))) continue;
            foreach (Vector2 position in cage.GetPositions())
            {
                if ((int)position.X == xPos && (int)position.Y == yPos) cageValues.Add(num);
                else cageValues.Add(KillerSudoku.GetGrid[(int)position.Y, (int)position.X]);
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