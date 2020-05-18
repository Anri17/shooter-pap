using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BezierPathMovement : SpellMovement
{
    public bool loopMovement = true;

    public float speedModifier = 1f;
    public Transform pathPrefab;


    private Transform deployedPath;
    private Transform[] deployedRoutes;
    private int routeToGo;
    private Coroutine goByTheRouteCoroutine;

    public override IEnumerator MoveCoroutine()
    {
        ResetValues();
        DeployPath();
        goByTheRouteCoroutine = StartCoroutine(GoByTheRouteCoroutine(routeToGo));
        yield return null;
    }

    public void DeployPath()
    {
        deployedPath = Instantiate(pathPrefab, mainTransform.position, mainTransform.rotation);
        deployedRoutes = new Transform[deployedPath.childCount];
        deployedRoutes = GetRoutesFromPath(deployedPath);
    }

    public void ResetValues()
    {
        routeToGo = 0;
    }

    public void StopMovement()
    {
        StopCoroutine(goByTheRouteCoroutine);
    }

    public Vector3 GetStartingPoint()
    {
        return deployedRoutes[0].GetChild(0).position;
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

    private IEnumerator GoByTheRouteCoroutine(int routeNumber)
    {
        float tParam = 0f;
        Vector2 p0 = deployedRoutes[routeNumber].GetChild(0).position;
        Vector2 p1 = deployedRoutes[routeNumber].GetChild(1).position;
        Vector2 p2 = deployedRoutes[routeNumber].GetChild(2).position;
        Vector2 p3 = deployedRoutes[routeNumber].GetChild(3).position;

        while (tParam < 1)
        {
            tParam += Time.deltaTime * speedModifier;

            mainTransform.position = Bezier.CalculateCubicPoint(tParam, p0, p1, p2, p3);
            yield return new WaitForEndOfFrame();
        }

        routeToGo++;

        if (loopMovement)
        {
            if (routeToGo >= deployedRoutes.Length)
            {
                ResetValues();
            }
            goByTheRouteCoroutine = StartCoroutine(GoByTheRouteCoroutine(routeToGo));
        }
    }

    private void OnDestroy()
    {
        StopCoroutine(goByTheRouteCoroutine);
        foreach (Transform deployedRoute in deployedRoutes)
        {
            Destroy(deployedRoute.gameObject);
        }
        Destroy(deployedPath.gameObject);
    }
}
