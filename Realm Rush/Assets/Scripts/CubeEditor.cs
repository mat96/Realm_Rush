using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
[SelectionBase]
[RequireComponent (typeof(Waypoint))]

public class CubeEditor : MonoBehaviour
{
    Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    void Update()
    {
        SnapTpGrid();
        UpdateLabel();
    }


    private void SnapTpGrid()
    {
        int gridSize = waypoint.GetGridSize();
        transform.position = new Vector3(waypoint.GetGridPos().x * gridSize,
            -5f,
            waypoint.GetGridPos().y * gridSize
            );
    }

    private void UpdateLabel()
    {
        int gridSize = waypoint.GetGridSize();

        string labelText =
            waypoint.GetGridPos().x + 
            "," + 
            waypoint.GetGridPos().y;

        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = labelText;
        gameObject.name = "Cube Positioned at " + labelText;
    }

}
