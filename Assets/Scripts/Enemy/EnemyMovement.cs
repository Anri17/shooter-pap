using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject path;

    // List of waypoints of the path
    List<GameObject> waypoints = new List<GameObject>();

    // Movement speed
    public float moveSpeed = 2f;

    // Index of current waypoint from which Enemy walks
    // to the next one
    private int waypointIndex = 0;

    private void Start()
    {
        path = Instantiate(path, gameObject.transform);
        for (int childIndex = 0; childIndex < path.transform.childCount; ++childIndex)
            waypoints.Add(path.transform.GetChild(childIndex).gameObject);
        // Set position of Enemy as position of the first waypoint
        transform.position = waypoints.ToArray()[waypointIndex].transform.position;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        // If Enemy didn't reach last waypoint it can move
        // If enemy reached last waypoint then it stops
        if (waypointIndex <= waypoints.ToArray().Length - 1)
        {

            // Move Enemy from current waypoint to the next one
            // using MoveTowards method
            transform.position = Vector2.MoveTowards(transform.position,
               waypoints[waypointIndex].transform.position,
               moveSpeed * Time.deltaTime);

            // If Enemy reaches position of waypoint he walked towards
            // then waypointIndex is increased by 1
            // and Enemy starts to walk to the next waypoint
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }
    }
}
