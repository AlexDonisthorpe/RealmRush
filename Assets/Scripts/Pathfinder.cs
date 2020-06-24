using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Waypoint startPoint, endPoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        ColourStartAndEnd();
    }

    private void ColourStartAndEnd()
    {
        startPoint.SetTopColor(Color.green);
        endPoint.SetTopColor(Color.red);
    }

    private void LoadBlocks()
    {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            bool isOverlapping = grid.ContainsKey(waypoint.GetGridPos());
            if (!isOverlapping)
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
            } else
            {
                Debug.LogWarning("Overlapping block: " + waypoint);
            }
        }
        print(grid.Count);
    }

}
