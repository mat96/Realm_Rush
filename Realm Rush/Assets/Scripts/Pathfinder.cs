using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true;

    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };


	// Use this for initialization
	void Start ()
    {

        LoadBlocks();
        ColorStartAndEnd();
        Pathfind();
       // ExploreNeighbors();
	}

    private void Pathfind()
    {
        queue.Enqueue(startWaypoint); 

        while(queue.Count > 0 && isRunning)
        {
            var searchCenter = queue.Dequeue();

            print("Searching from: " + searchCenter);

            HaltIfEndFound(searchCenter);
            ExploreNeighbors(searchCenter);
            searchCenter.isExplored = true;
        }
        // todo work out path
        print("Finished Pathfinding");

    }

    private void HaltIfEndFound(Waypoint searchCenter)
    {
        if (searchCenter == endWaypoint)
        {
            print("Ending Search"); //TODO remove log later

            isRunning = false;
        }
    }

    private void ExploreNeighbors(Waypoint from)
    {
        if (!isRunning) { return; }
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighborCoordinates = from.GetGridPos() + direction;

            try
            {
                QueueNewNeighbors(neighborCoordinates);
            }
            catch
            {
                // do nothing
            }
           
        }
        
    }

    private void QueueNewNeighbors(Vector2Int neighborCoordinates)
    {
        Waypoint neighbor = grid[neighborCoordinates];

        if (neighbor.isExplored)
        {
            // do nothing
        }
        else
        {
            neighbor.SetTopColor(Color.magenta);
            queue.Enqueue(neighbor);
            print("Queuing..." + neighbor.name);
        }
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();       

        foreach (Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();

            // overlapping blocks
            bool isOverlapping = grid.ContainsKey(gridPos);

            if (isOverlapping)
            {
                Debug.LogWarning("Skipping overlapping Block at " + waypoint);

            }
            else
            {
                // add to dictionary
                grid.Add(gridPos, waypoint);
            }
        }

    }
    void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
    }
}
