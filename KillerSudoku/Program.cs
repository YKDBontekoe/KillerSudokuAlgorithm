using KillerSudoku.Sudoku;

while (true)
{
    int difficulty = 1;
    int solution = 1;
    Console.WriteLine("Choose Difficulty: ");
    Console.WriteLine("1. Easy");
    Console.WriteLine("2. Medium");
    Console.WriteLine("3. Hard");
    
    Console.Write("Difficulty: ");
    int.TryParse(Console.ReadLine(), out difficulty);

    Console.WriteLine("Choose Solution Approach: ");
    Console.WriteLine("1. Basic");
    Console.WriteLine("2. Heuristic: Rule One");
    Console.WriteLine("3. Forward Checking");
    Console.WriteLine("4. Brute Force");
    
    Console.Write("Solution: ");
    int.TryParse(Console.ReadLine(), out solution);

    Console.WriteLine("Chosen difficulty: " + difficulty);
    Console.WriteLine("Chosen solution: " + solution);
    
    SudokuHandler.Execute(difficulty, solution);
}