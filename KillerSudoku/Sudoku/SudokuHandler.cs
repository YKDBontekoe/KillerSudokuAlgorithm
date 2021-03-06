using KillerSudoku.Models;
using KillerSudoku.Sudoku.Heuristics;

namespace KillerSudoku.Sudoku;

public static class SudokuHandler
{
    public static void Execute(int difficulty, int solution)
    {
        KillerSudokuData killerSudokuData = difficulty switch
        {
            1 => GridGenerator.GenerateEasyKillerSudokuGrid(),
            2 => GridGenerator.GenerateMediumKillerSudokuGrid(),
            3 => GridGenerator.GenerateHardKillerSudoGrid(),
            _ => GridGenerator.GenerateEasyKillerSudokuGrid()
        };

        bool isSuccess;
        int iterations;
        var killerWatch = System.Diagnostics.Stopwatch.StartNew();
        switch (solution)
        {
            case 1:
                SolveKillerSudokuWithBacktracking.KillerSudoku = killerSudokuData;
                isSuccess = SolveKillerSudokuWithBacktracking.SolveKillerSudoku(0, 0);
                iterations = SolveKillerSudokuWithBacktracking.Iterations;
                break;
            
            case 2:
                SolveKillerSudokuWithBacktrackingAndRuleOne.KillerSudoku = killerSudokuData;
                isSuccess = SolveKillerSudokuWithBacktrackingAndRuleOne.SolveKillerSudoku(0, 0, killerSudokuData.GetSingleCagePositions());
                iterations = SolveKillerSudokuWithBacktrackingAndRuleOne.Iterations;
                break;
            
            case 3:
                SolveKillerSudokuWithBacktrackingAndForwardChecking.KillerSudoku = killerSudokuData;
                isSuccess = SolveKillerSudokuWithBacktrackingAndForwardChecking.SolveKillerSudoku(0, 0);
                iterations = SolveKillerSudokuWithBacktrackingAndForwardChecking.Iterations;
                break;
            
            case 4:
                SolveKillerSudokuWithBruteForce.KillerSudoku = killerSudokuData;
                isSuccess = SolveKillerSudokuWithBruteForce.SolveKillerSudoku();
                iterations = SolveKillerSudokuWithBruteForce.Iterations;
                break;
            
            default:
                SolveKillerSudokuWithBacktracking.KillerSudoku = killerSudokuData;
                isSuccess = SolveKillerSudokuWithBacktracking.SolveKillerSudoku(0,0);
                iterations = SolveKillerSudokuWithBacktracking.Iterations;
                break;
        }
        
        killerWatch.Stop();
        
        if (isSuccess)
        {
            Console.WriteLine("Solution: ");
            Printer.Print(killerSudokuData.Grid);
        }
        else
        {
            Console.WriteLine("No solution found");
        }
        
        Console.WriteLine("Time taken: {0}ms", killerWatch.ElapsedMilliseconds);
        Console.WriteLine("Iterations taken: " +  iterations);
    }
}