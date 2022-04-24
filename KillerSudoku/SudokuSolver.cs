namespace KillerSudoku;

public static class SudokuSolver
{
    public static bool SolveBasicSudoku(int[,] sudokuGrid, int xPos, int yPos)
    {
        // Check if the one before last row has been reached and the last position of the row
        // has been reached. If so, return true to avoid further backtracking.
        if (xPos == sudokuGrid.GetLength(0) - 1 && yPos == sudokuGrid.GetLength(1))
        {
            return true;
        }

        // Move to next row when the end of the current row is reached.
        if (yPos == sudokuGrid.GetLength(1))
        {
            xPos++;
            yPos = 0;
        }

        // Check if current value is not 0. If so, move to next position.
        if (sudokuGrid[xPos, yPos] != 0)
        {
            return SolveBasicSudoku(sudokuGrid, xPos, yPos + 1);
        }
        
        for (int num = 1; num < 9; num++) {
            
            // Check if the number is safe to place in the current position.
            if (IsSafe(sudokuGrid, xPos, yPos, num)) {
                sudokuGrid[xPos,yPos] = num;
                
                // Check next position.
                if (SolveBasicSudoku(sudokuGrid, xPos, yPos + 1))
                    return true;
            }
            sudokuGrid[xPos,yPos] = 0;
        }
        return false;
    }
    
    private static bool IsSafe(int[,] sudokuGrid, int xPos, int yPos,
        int num)
    {
        // Check if the same num is the same row
        for (int x = 0; x <= sudokuGrid.GetLength(0) - 1; x++)
            if (sudokuGrid[x,yPos] == num)
                return false;
        
        // Check if the same number is in the same column
        for (int y = 0; y <= sudokuGrid.GetLength(1) - 1; y++)
            if (sudokuGrid[xPos,y] == num)
                return false;
 
        // Check if the same num is in the 3*3 matrix
        int startRow = xPos - xPos % 3, startCol
            = yPos - yPos % 3;
        for (int i = 0; i < 3; i++)
        for (int j = 0; j < 3; j++)
            if (sudokuGrid[i + startRow,j + startCol] == num)
                return false;
 
        return true;
    }
    
    public static void Print(int[,] grid)
    {
        for (int i = 0; i < grid.GetLength(0) - 1; i++) {
            for (int j = 0; j < grid.GetLength(1); j++)
                Console.Write(grid[i,j] + " ");
            Console.WriteLine();
        }
    }
}