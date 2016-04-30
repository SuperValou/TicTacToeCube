using UnityEngine;
using System.Collections.Generic;

public class Grid : MonoBehaviour 
{
    public Cube[] grid;

    /*
     * 
     * 0_|_1_|_2
     * 3_|_4_|_5
     * 6 | 7 | 8 
     * 
     * */

    public bool CheckIfWinner(Player p)
    {
        return 
            // horizontal
               (grid[0].Player == p && grid[1].Player == p && grid[2].Player == p)
            || (grid[3].Player == p && grid[4].Player == p && grid[5].Player == p)
            || (grid[6].Player == p && grid[7].Player == p && grid[8].Player == p)

            // vertical
            || (grid[0].Player == p && grid[3].Player == p && grid[6].Player == p)
            || (grid[1].Player == p && grid[4].Player == p && grid[7].Player == p)
            || (grid[2].Player == p && grid[5].Player == p && grid[8].Player == p)

            // diagonals
            || (grid[0].Player == p && grid[4].Player == p && grid[8].Player == p)
            || (grid[6].Player == p && grid[4].Player == p && grid[2].Player == p);
    }

    public List<Tuple> GetLines(Player p)
    {
        List<Tuple> result = new List<Tuple>();

        // horizontal up
        if (grid[0].Player == p && grid[1].Player == p && grid[2].Player == p)
        {
            result.Add(new Tuple(grid[0].transform, grid[2].transform));
        }
        // horizontal middle
        if (grid[3].Player == p && grid[4].Player == p && grid[5].Player == p)
        {
            result.Add(new Tuple(grid[3].transform, grid[5].transform));
        }
        // horizontal down
        if (grid[6].Player == p && grid[7].Player == p && grid[8].Player == p)
        {
            result.Add(new Tuple(grid[6].transform, grid[8].transform));
        }
        // vertical left
        if (grid[0].Player == p && grid[3].Player == p && grid[6].Player == p)
        {
            result.Add(new Tuple(grid[0].transform, grid[6].transform));
        }
        // vertical center
        if (grid[1].Player == p && grid[4].Player == p && grid[7].Player == p)
        {
            result.Add(new Tuple(grid[1].transform, grid[7].transform));
        }
        // vertical right
        if (grid[2].Player == p && grid[5].Player == p && grid[8].Player == p)
        {
            result.Add(new Tuple(grid[2].transform, grid[8].transform));
        }
        // diagonal \
        if (grid[0].Player == p && grid[4].Player == p && grid[8].Player == p)
        {
            result.Add(new Tuple(grid[0].transform, grid[8].transform));
        }
        // diagonal / 
        if (grid[6].Player == p && grid[4].Player == p && grid[2].Player == p)
        {
            result.Add(new Tuple(grid[6].transform, grid[2].transform));
        }

        return result;
    }
}
