namespace KillerSudoku.Models;

public class KillerSudokuData
{
    public KillerSudokuData(List<SumZoneData> sumZones, int[,] grid)
    {
        GetSumZones = sumZones;
        GetGrid = grid;
    }
    
    public List<SumZoneData> GetSumZones { get; }

    public int[,] GetGrid { get; }
}