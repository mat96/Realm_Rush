using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {


	// Use this for initialization
	void Start ()
    {
        Pathfinder pathFinder = FindObjectOfType<Pathfinder>();
        var path = pathFinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    { // this is a co routine

        print("Starting patrol...");
        foreach (Waypoint waypoint in path)
        {
            transform.position = new Vector3(waypoint.transform.position.x, 3f, waypoint.transform.position.z);
            yield return new WaitForSeconds(1f);
        }

        print("Ending patrol");
    }

}
