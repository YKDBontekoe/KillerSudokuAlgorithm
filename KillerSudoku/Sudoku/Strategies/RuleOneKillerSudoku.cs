using KillerSudoku.Models;

namespace KillerSudoku.Sudoku.Strategies;

public class RuleOneKillerSudoku
{
    public static bool SolveKillerSudoku(int yPos, int xPos, List<CageData> singlePositionCages)
    {
        if (singlePositionCages.Count == 0)
        {
            // Move to next row when the end of the current row is reached.
            if (xPos == KillerSudokuSolver.KillerSudoku.GetGrid.GetLength(0))
            {
                yPos++;
                xPos = 0;

                if (yPos == KillerSudokuSolver.KillerSudoku.GetGrid.GetLength(1)) return true;
            }

            // Check if current value is not 0. If so, move to next position.
            if (KillerSudokuSolver.KillerSudoku.GetGrid[yPos, xPos] != 0) return SolveKillerSudoku(yPos, xPos + 1, singlePositionCages);
        }
        else
        {
            foreach (var cage in singlePositionCages)
            {
                var position = cage.GetPositions().FirstOrDefault();
                KillerSudokuSolver.KillerSudoku.GetGrid[(int)position.Y, (int)position.X] = cage.GetSum();
            }
            
            return SolveKillerSudoku(yPos, xPos, new List<CageData>());
        }

        // Iterate over the possible domain values (n = size of x dimension of grid (n*n)).
            for (int num = 1; num < KillerSudokuSolver.KillerSudoku.GetGrid.GetLength(0) + 1; num++)
            {
                // Check if the number is safe to place in the current position.
                if (KillerSudokuSolver.IsKillerSudokuSafe(yPos, xPos, num) &&
                    KillerSudokuSolver.IsCageSafe(yPos, xPos, num))
                {
                    KillerSudokuSolver.KillerSudoku.GetGrid[yPos, xPos] = num;

                    // Check next position.
                    if (SolveKillerSudoku(yPos, xPos + 1, singlePositionCages)) return true;
                }

                KillerSudokuSolver.KillerSudoku.GetGrid[yPos, xPos] = 0;
            }

            return false;
        }
    }