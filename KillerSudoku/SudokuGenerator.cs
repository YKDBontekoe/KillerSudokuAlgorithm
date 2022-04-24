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
        sumZones.Add(new SumZoneData(10, new HashSet<Vector2>{new(0,0), new(0,1), new(0,2)}));
        sumZones.Add(new SumZoneData(13, new HashSet<Vector2>{new(1,0), new(2,0), new(1,1)}));
        sumZones.Add(new SumZoneData(17, new HashSet<Vector2>{new(2,1), new(3,1), new(2,2)}));
        sumZones.Add(new SumZoneData(24, new HashSet<Vector2>{new(1,2), new(1,3), new(0,3), new(0,4)}));
        sumZones.Add(new SumZoneData(14, new HashSet<Vector2>{new(2,3), new(2,4), new(3,3)}));
        sumZones.Add(new SumZoneData(5, new HashSet<Vector2>{new(3,2), new(4,2)}));
        sumZones.Add(new SumZoneData(22, new HashSet<Vector2>{new(3,0), new(4,0), new(5,0)}));
        sumZones.Add(new SumZoneData(8, new HashSet<Vector2>{new(4,1), new(5,1)}));
        sumZones.Add(new SumZoneData(45, new HashSet<Vector2>{new(6,1), new(5,2), new(6,2), new(7,2), new(4,3), new(5,3), new(6,3), new(4,4), new(5,4)}));
        sumZones.Add(new SumZoneData(34, new HashSet<Vector2>{new(6,0), new(7,0), new(8,0), new(7,1), new(8,1), new(8,2)}));
        sumZones.Add(new SumZoneData(11, new HashSet<Vector2>{new(7,3), new(7,4)}));
        sumZones.Add(new SumZoneData(11, new HashSet<Vector2>{new(8,3), new(8,4), new(8,6)}));
        sumZones.Add(new SumZoneData(7, new HashSet<Vector2>{new(6,4), new(6,5)}));
        sumZones.Add(new SumZoneData(22, new HashSet<Vector2>{new(1,4), new(1,5), new(0,5), new(0,6)}));
        sumZones.Add(new SumZoneData(27, new HashSet<Vector2>{new(3,4), new(2,5), new(3,5), new(4,5), new(3,6)}));
        sumZones.Add(new SumZoneData(12, new HashSet<Vector2>{new(5,5), new(5,6), new(4,6)}));
        sumZones.Add(new SumZoneData(22, new HashSet<Vector2>{new(7,5), new(7,6), new(6,6)}));
        sumZones.Add(new SumZoneData(13, new HashSet<Vector2>{new(8,6), new(8,7), new(7,7)}));
        sumZones.Add(new SumZoneData(9, new HashSet<Vector2>{new(6,8), new(7,8), new(8,8)}));
        sumZones.Add(new SumZoneData(23, new HashSet<Vector2>{new(5,7), new(6,7), new(5,8), new(4,8)}));
        sumZones.Add(new SumZoneData(27, new HashSet<Vector2>{new(3,7), new(4,7), new(3,8), new(2,8)}));
        sumZones.Add(new SumZoneData(29, new HashSet<Vector2>{new(1,6), new(2,6), new(1,7), new(0,7), new(0,8), new(1,8), new(2,7)}));
        
        return new KillerSudokuData(sumZones, grid);
    }
}