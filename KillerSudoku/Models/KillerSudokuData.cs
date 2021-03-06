using System.Numerics;
using System.Text;

namespace KillerSudoku.Models;

public class KillerSudokuData
{
    public KillerSudokuData(List<CageData> cages, int[,] grid)
    {
        GetCages = cages;
        Grid = grid;
    }
    
    public List<CageData> GetCages { get; }

    public int[,] Grid { get; set; }

    public List<CageData> GetSingleCagePositions()
    {
        List<CageData> singlePositionCages = new List<CageData>();
        foreach (CageData cage in GetCages)
        {
            if (cage.GetPositions().Count == 1)
            {
                singlePositionCages.Add(cage);
            }
        }
        return singlePositionCages;
    }

    public string ToStringGrid()
    {
        var sb = new StringBuilder();
        sb.Append("---------------------\n");
        for (var i = 0; i < Grid.GetLength(0); i++)
        {
            for (var j = 0; j < Grid.GetLength(1); j++)
            {
                sb.Append(" | ");
                sb.Append(Grid[i, j]);
            }
            sb.Append("\n");
        }
        sb.Append("---------------------\n");
        return sb.ToString();
    }
}