using KillerSudoku.Models;

namespace KillerSudoku.Sudoku;

public class SolveKillerSudokuWithBruteForce
{
    public static KillerSudokuData KillerSudoku = new(new List<CageData>(), new[,]{{0,0}});
    public static int Iterations;
        
    public static bool SolveKillerSudoku()
    {
        bool isSolved = false;
        while (!isSolved)
        {
            Iterations++;
            KillerSudoku.GetGrid[new Random().Next(0, 9),new Random().Next(0, 9)] = new Random().Next(1, 10);

            bool isValid = true;
            for (int y = KillerSudoku.GetGrid.GetLength(0) - 1; y >= 0; y--)
            {
                for (int x = KillerSudoku.GetGrid.GetLength(0) - 1; x >= 0; x--)
                {
                    if (!isValid) break;
                    
                    int val = KillerSudoku.GetGrid[y, x];
                    if (HelperFunctions.IsKillerSudokuSafe(y, x, val, KillerSudoku) && HelperFunctions.IsCageSafe(y, x, val, KillerSudoku)) continue;
                    isValid = false;
                    break;
                }

                isSolved = isValid;
            }
        }

        return true;
    }
}