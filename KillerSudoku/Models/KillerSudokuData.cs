namespace KillerSudoku.Models;

public class KillerSudokuData
{
    private readonly List<SumZoneData> _sumZones;
    private readonly int[,] _grid;

    public KillerSudokuData(List<SumZoneData> sumZones, int[,] grid)
    {
        _sumZones = sumZones;
        _grid = grid;
    }
}