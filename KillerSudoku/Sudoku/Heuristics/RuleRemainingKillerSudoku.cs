using System.Numerics;
using KillerSudoku.Models;

namespace KillerSudoku.Sudoku.Heuristics;

public static class RuleRemainingKillerSudoku
{
    public static bool SolveKillerSudoku(int yPos, int xPos)
    {
        // Move to next row when the end of the current row is reached.
        if (xPos == KillerSudokuSolver.KillerSudoku.GetGrid.GetLength(0))
        {
            yPos++;
            xPos = 0;

            if (yPos == KillerSudokuSolver.KillerSudoku.GetGrid.GetLength(1)) return true;
        }

        // Check if current value is not 0. If so, move to next position.
        if (KillerSudokuSolver.KillerSudoku.GetGrid[yPos, xPos] != 0) return SolveKillerSudoku(yPos, xPos + 1);
        
        // Increment iterations counter.
        KillerSudokuSolver.Iterations++;
        
        HashSet<int> possibleValues = new HashSet<int>{1,2,3,4,5,6,7,8,9};
       foreach (CageData cage in KillerSudokuSolver.KillerSudoku.GetCages)
       {
           if (!cage.GetPositions().Contains(new Vector2(xPos, yPos))) continue;
           
           foreach (Vector2 position in cage.GetPositions())
           {
               if (KillerSudokuSolver.KillerSudoku.GetGrid[(int) position.Y, (int) position.X] != 0 &&
                   yPos != (int) position.Y && xPos != (int) position.X)
               {
                   var possibleNumToRemove =
                       KillerSudokuSolver.KillerSudoku.GetGrid[(int) position.Y, (int) position.X];
                   
                   possibleValues.Remove(possibleNumToRemove);
               }
           }
       }
       
       foreach (int possibleValue in possibleValues)
       {    
           // Check if the number is safe to place in the current position.
           if (KillerSudokuSolver.IsKillerSudokuSafe(yPos, xPos, possibleValue) &&
               KillerSudokuSolver.IsCageSafe(yPos, xPos, possibleValue))
           {    
               KillerSudokuSolver.KillerSudoku.GetGrid[yPos, xPos] = possibleValue;
                    
               // Check next position.
               if (SolveKillerSudoku(yPos, xPos + 1)) 
                   return true;
           }

           KillerSudokuSolver.KillerSudoku.GetGrid[yPos, xPos] = 0;
       }

       return false;
    }
}