using System.Numerics;
using KillerSudoku.Models;

namespace KillerSudoku;

public static class GridGenerator
{
    public static int[,] GenerateBasicSudokuGrid()
    {
        return new[,]
        {
            {5, 3, 0, 0, 7, 0, 0, 0, 0},
            {6, 0, 0, 1, 9, 5, 0, 0, 0},
            {0, 9, 8, 0, 0, 0, 0, 6, 0},
            {8, 0, 0, 0, 6, 0, 0, 0, 3},
            {4, 0, 0, 8, 0, 3, 0, 0, 1},
            {7, 0, 0, 0, 2, 0, 0, 0, 6},
            {0, 6, 0, 0, 0, 0, 2, 8, 0},
            {0, 0, 0, 4, 1, 9, 0, 0, 5},
            {0, 0, 0, 0, 8, 0, 0, 7, 9}
        };
    }
    
    public static KillerSudokuData GenerateKillerSudoGrid()
    {
        var grid = new[,]
        {
            {0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0}
        };
        var sumZones = new List<SumZoneData>();
        sumZones.Add(new SumZoneData(13, new HashSet<Vector2>{new(0,0), new(1,0)}));
        sumZones.Add(new SumZoneData(20, new HashSet<Vector2>{new(2,0), new(3,0), new(3,1), new(3,2)}));
        sumZones.Add(new SumZoneData(11, new HashSet<Vector2>{new(0,1), new(1,1), new(1,2), new(2,1)}));
        sumZones.Add(new SumZoneData(19, new HashSet<Vector2>{new()}));
        return new KillerSudokuData(sumZones, grid);
    }
}