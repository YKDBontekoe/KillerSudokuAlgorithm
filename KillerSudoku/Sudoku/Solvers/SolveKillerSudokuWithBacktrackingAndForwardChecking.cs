using System.Numerics;
using KillerSudoku.Models;

namespace KillerSudoku.Sudoku.Heuristics;

public static class SolveKillerSudokuWithBacktrackingAndForwardChecking
{
    public static KillerSudokuData KillerSudoku = new(new List<CageData>(), new[,]{{0,0}});
    public static int Iterations;
    
    public static bool SolveKillerSudoku(int yPos, int xPos)
    {
        // Increment the number of iterations
        Iterations++;
        
        // Move to next row when the end of the current row is reached.
        if (xPos == KillerSudoku.Grid.GetLength(0))
        {
            yPos++;
            xPos = 0;

            if (yPos == KillerSudoku.Grid.GetLength(1)) return true;
        }

        // Check if current value is not 0. If so, move to next position.
        if (KillerSudoku.Grid[yPos, xPos] != 0) return SolveKillerSudoku(yPos, xPos + 1);

        // Initialize domain with all possible values.
        HashSet<int> possibleValues = new HashSet<int>{1,2,3,4,5,6,7,8,9};
        
        // Remove values that are already used in the cage.
        GetRemainingValues(possibleValues, xPos, yPos);
        
        // Check if the domain is empty and return false if it is.
       if (!possibleValues.Any()) return false;

           // Iterate through the possible values and try to set the value.
       foreach (int possibleValue in possibleValues)
       {    
           // Check if the number is safe to place in the current position.
           if (HelperFunctions.IsKillerSudokuSafe(yPos, xPos, possibleValue, KillerSudoku) &&
               HelperFunctions.IsCageSafe(yPos, xPos, possibleValue, KillerSudoku))
           {    
               KillerSudoku.Grid[yPos, xPos] = possibleValue;
                    
               // Check next position.
               if (SolveKillerSudoku(yPos, xPos + 1)) 
                   return true;
           }

           KillerSudoku.Grid[yPos, xPos] = 0;
       }

       return false;
    }

    // Get remaining values in the cage.
    private static void GetRemainingValues(HashSet<int> possibleValues, int xPos, int yPos)
    {
        foreach (CageData cage in KillerSudoku.GetCages)
        {
            // Skip positions that are already in the cage and have a value.
            if (!cage.GetPositions().Contains(new Vector2(xPos, yPos))) continue;
           
            // Iterate through the cage and remove values that are already in the cage.
            foreach (Vector2 position in cage.GetPositions())
            {
                // Skip the current position if the current position equals 0.
                if (KillerSudoku.Grid[(int)position.Y, (int)position.X] == 0 || yPos == (int)position.Y ||
                    xPos == (int)position.X) continue;
               
                // Remove the value from the domain.
                var possibleNumToRemove =
                    KillerSudoku.Grid[(int) position.Y, (int) position.X];
                   
                possibleValues.Remove(possibleNumToRemove);
            }
        }
    }
}