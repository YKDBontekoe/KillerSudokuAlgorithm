using System.Numerics;

namespace KillerSudoku.Models;

public class CageData
{
    private readonly int _sum;
    private readonly HashSet<Vector2> _positions;
    
    public CageData(int sum, HashSet<Vector2> positions)
    {
        _sum = sum;
        _positions = positions;
    }
    
    public bool IsInCage(Vector2 position)
    {
        return _positions.Contains(position);
    }

    public int GetSum()
    {
        return _sum;
    }

    public HashSet<Vector2> GetPositions()
    {
        return _positions;
    }
}