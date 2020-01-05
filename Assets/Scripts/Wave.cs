using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public GameObject enemy;

    public Transform[] Trajectory;

    void GiveTrajectoryToEnemy()
    {
        foreach (Transform point in Trajectory)
        {
            enemy.GetComponent<Enemy>().Tragectory.Add(point);
        }
    }
}
