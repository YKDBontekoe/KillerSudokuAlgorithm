using System.Numerics;
using System.Text;

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

    public Dictionary<Vector2, SumZoneData> GetSumZoneDictionary()
    {
        Dictionary<Vector2, SumZoneData> sumZoneDictionary = new Dictionary<Vector2, SumZoneData>();
        foreach (SumZoneData sumZone in GetSumZones)
        {
            foreach (Vector2 position in sumZone.GetPositions())
            {
                sumZoneDictionary.Add(position, sumZone);
            }
        }
        return sumZoneDictionary;
    }
    
    public string ToStringGrid()
    {
        var sb = new StringBuilder();
        sb.Append("---------------------\n");
        for (var i = 0; i < GetGrid.GetLength(0); i++)
        {
            for (var j = 0; j < GetGrid.GetLength(1); j++)
            {
                sb.Append(" | ");
                sb.Append(GetGrid[i, j]);
            }
            sb.Append("\n");
        }
        sb.Append("---------------------\n");
        return sb.ToString();
    }
}