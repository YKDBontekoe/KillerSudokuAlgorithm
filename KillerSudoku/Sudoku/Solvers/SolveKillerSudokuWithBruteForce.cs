using System.Numerics;
using KillerSudoku.Models;

namespace KillerSudoku.Sudoku;

public static class SolveKillerSudokuWithBruteForce
{
    public static KillerSudokuData KillerSudoku = new(new List<CageData>(), new[,]{{0,0}});
    public static int Iterations;
    private static readonly HashSet<int> UsedSeeds = new();
    public static bool SolveKillerSudoku()
    {
        bool isSolved = false;
        while (!isSolved)
        {
            // Count the number of iterations
            Iterations++;
            
            // Generate a seed for the random number generator
            int seed = Guid.NewGuid().GetHashCode();
            var isUnique = false;

            // Check if the seed has already been used
            while (!isUnique)
            {
                // Check if the seed is unique
                if (!UsedSeeds.Contains(seed))
                {
                    // Add the seed to the list of used seeds
                    UsedSeeds.Add(seed);
                    isUnique = true;
                }
                else
                {
                    // Generate a new seed
                    seed = Guid.NewGuid().GetHashCode();
                }
            }
            
            // Generate a random number generator
            List<int> numbers = new ();
            var maxPositions = KillerSudoku.Grid.GetLength(0) * KillerSudoku.Grid.GetLength(1);
            while (numbers.Count <=  maxPositions)
            {
                numbers.Add(new Random(numbers.Count == 0 ? seed  : seed % numbers.Count).Next(1, 10));
            }
            
            bool isValid = true;
            int numIndex = 0;
            for (int y = KillerSudoku.Grid.GetLength(0) - 1; y >= 0; y--)
            {
                for (int x = KillerSudoku.Grid.GetLength(0) - 1; x >= 0; x--)
                {
                    if (numIndex > 10)
                    {
                        Console.WriteLine(numIndex);
                    }
                    
                    int val = KillerSudoku.Grid[y, x] = numbers[0];
                    numIndex++;
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