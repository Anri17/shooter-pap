using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierMove : MonoBehaviour
{
    public bool loopMovement = false;
    public float speedModifier = 0.5f;
    public Transform path;
    public Transform[] routes;
    public Vector2 startPoint;
    public bool pause = false;

    private int routeToGo;

    private float tParam;

    private Vector2 catPosition;

    private bool coroutineAllowed = false;

    private void Start()
    {
        startPoint = routes[0].GetChild(0).position;
        ResetValuesAndRun();
    }

    private void Update()
    {
        if (coroutineAllowed && !pause)
        {
            StartCoroutine(GoByTheRoute(routeToGo));
        }
    }

    public void ResetValuesAndRun()
    {
        routes = new Transform[path.childCount];
        routes = GetRoutesFromPath(path);
        routeToGo = 0;
        tParam = 0f;
        coroutineAllowed = true;
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
        coroutineAllowed = false;

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
                coroutineAllowed = true;
            }

            coroutineAllowed = true;
        }
        else
        {
            if (routeToGo <= routes.Length - 1)
            {
                coroutineAllowed = true;
            }
        }
            
        
    }
}
