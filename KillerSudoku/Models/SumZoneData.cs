using System.Numerics;

namespace KillerSudoku.Models;

public class SumZoneData
{
    private readonly int _sum;
    private readonly HashSet<Vector2> _positions;
    
    public SumZoneData(int sum, HashSet<Vector2> positions)
    {
        _sum = sum;
        _positions = positions;
    }
    
    public bool IsInZone(Vector2 position)
    {
        return _positions.Contains(position);
    }

    public int GetSum()
    {
        return _sum;
    }
}