using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierMove : MonoBehaviour
{
    public bool loopMovement = false;
    public float speedModifier = 1f;
    public Transform path;
    public Transform[] routes;

    private int routeToGo;

    private float tParam;

    private Vector2 catPosition;

    private bool movementAllowed = false;

    private void Update()
    {
        if (movementAllowed)
        {
            StartCoroutine(GoByTheRoute(routeToGo));
        }

        Debug.Log($"Movement Allowed: {movementAllowed}");
    }

    public void UnpackPath(Transform path)
    {
        this.path = path;
        routes = new Transform[path.childCount];
        routes = GetRoutesFromPath(path);
    }

    public void ResetValues(float speed)
    {
        movementAllowed = false;
        routeToGo = 0;
        tParam = 0f;
        speedModifier = speed;
    }

    public void RunPath()
    {
        movementAllowed = true;
    }

    public void StopMovement()
    {
        movementAllowed = false;
        StopCoroutine("GoByTheRoute");
    }

    public Vector3 GetStartingPoint()
    {
        return routes[0].GetChild(0).position;
    }

    private Transform[] GetRoutesFromPath(Transform path)
    {
        Transform[] routes = new Transform[path.childCount];
        for (int i = 0; i < path.childCount; i++)
        {
            routes[i] = path.GetChild(i);
        }
        return routes;
    }

    private IEnumerator GoByTheRoute(int routeNumber)
    {
        movementAllowed = false;

        Vector2 p0 = routes[routeNumber].GetChild(0).position;
        Vector2 p1 = routes[routeNumber].GetChild(1).position;
        Vector2 p2 = routes[routeNumber].GetChild(2).position;
        Vector2 p3 = routes[routeNumber].GetChild(3).position;

        while (tParam < 1)
        {
            tParam += Time.deltaTime * speedModifier;

            catPosition = Bezier.CalculateCubicPoint(tParam, p0, p1, p2, p3);

            transform.position = catPosition;
            yield return new WaitForEndOfFrame();
        }

        tParam = 0f;

        routeToGo++;

        if (loopMovement)
        {
            if (routeToGo >= routes.Length)
            {
                routeToGo = 0;
                movementAllowed = true;
            }

            movementAllowed = true;
        }
        else
        {
            if (routeToGo <= routes.Length - 1)
            {
                movementAllowed = true;
            }
        }
    }
}
