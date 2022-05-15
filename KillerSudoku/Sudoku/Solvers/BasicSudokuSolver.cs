namespace KillerSudoku.Sudoku;

public static class BasicSudokuSolver
{
    // --------- BASIC SUDOKU SOLVER --------- //
    public static bool SolveBasicSudoku(int[,] sudokuGrid, int yPos, int xPos)
    {
        // Move to next row when the end of the current row is reached.
        if (xPos == sudokuGrid.GetLength(0))
        {
            yPos++;
            xPos = 0;
            
            if (yPos == sudokuGrid.GetLength(1)) return true;
        }

        // Check if current value is not 0. If so, move to next position.
        if (sudokuGrid[yPos, xPos] != 0) return SolveBasicSudoku(sudokuGrid, yPos, xPos + 1);

        // Iterate over the possible domain values (n = size of x dimension of grid (n*n)).
        for (int num = 1; num < sudokuGrid.GetLength(0) + 1; num++)
        {

            // Check if the number is safe to place in the current position.
            if (!IsBasicSudokuSafe(sudokuGrid, yPos, xPos, num)) continue;
            sudokuGrid[yPos,xPos] = num;

            // Check next position.
            if (SolveBasicSudoku(sudokuGrid, yPos, xPos + 1)) return true;

            sudokuGrid[yPos,xPos] = 0;

        }
        return false;
    }
    
    // Sudoku Rules 
    // 1. Each row may only contain a number once
    // 2. Each column may only contain a number once
    // 3. Each 3x3 matrix may contain the number only once//
    private static bool IsBasicSudokuSafe(int[,] sudokuGrid, int yPos, int xPos,
        int num)
    {
        // Check if the same num is the same row
        for (int x = 0; x <= sudokuGrid.GetLength(0) - 1; x++)
            if (sudokuGrid[yPos, x] == num) return false;

            // Check if the same number is in the same column
        for (int y = 0; y <= sudokuGrid.GetLength(1) - 1; y++)
            if (sudokuGrid[y, xPos] == num) return false;

        // Get the size of a single sub-matrix of the sudoku grid.
        int matrixSize = 3;
        
        int startRow = yPos - yPos % matrixSize, startCol
            = xPos - xPos % matrixSize;
        
        // Check if the same num is in the n*n sub-matrix
        for (int i = 0; i < matrixSize; i++)
        for (int j = 0; j < matrixSize; j++)
            if (sudokuGrid[i + startRow, j + startCol] == num) return false;

        return true;
    }
}