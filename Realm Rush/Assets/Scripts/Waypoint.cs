using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    //public ok here as is a data class
    public bool isExplored = false;
    public Waypoint ExploredFrom; //  is this being used?
    const int gridSize = 10;
    Vector2Int gridPosition;

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
        Mathf.RoundToInt(transform.position.x / gridSize),
        Mathf.RoundToInt(transform.position.z / gridSize) 
        );
    }

    public int GetGridSize()
    {
       return gridSize;
    }

    public void SetTopColor(Color color)
    {
    
        MeshRenderer topMeshRenderer = transform.Find("Top Face").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }

}
