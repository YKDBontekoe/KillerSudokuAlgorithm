using System.Numerics;
using System.Text;

namespace KillerSudoku.Models;

public class KillerSudokuData
{
    public KillerSudokuData(List<CageData> sumZones, int[,] grid)
    {
        GetSumZones = sumZones;
        GetGrid = grid;
    }
    
    public List<CageData> GetSumZones { get; }

    public int[,] GetGrid { get; }

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