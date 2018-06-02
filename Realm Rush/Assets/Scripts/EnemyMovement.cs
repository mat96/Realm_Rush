using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] List<Waypoint> path;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    { // this is a co routine

        print("Starting patrol...");
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(1f);
        }

        print("Ending patrol");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
