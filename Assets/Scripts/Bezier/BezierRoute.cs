using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierRoute : MonoBehaviour
{
    [SerializeField]
    private Transform[] controlPoints;

    private Vector2 gizmoPosition;

    private void OnDrawGizmos()
    {

        for (float t = 0; t <= 1; t += 0.05f)
        {
            gizmoPosition = CalculateCubicBezierPoint(t, controlPoints[0].position, controlPoints[1].position, controlPoints[2].position, controlPoints[3].position);

            Gizmos.DrawSphere(gizmoPosition, 0.25f);
        }

        Gizmos.DrawLine(controlPoints[0].position, controlPoints[1].position);
        Gizmos.DrawLine(controlPoints[2].position, controlPoints[3].position);

    }

    private Vector3 CalculateLinerBezierPoint(float t, Vector3 p0, Vector3 p1)
    {
        // formula (1 - t)p0 + t * p1
        return p0 + t * (p1 - p0);
    }

    private Vector3 CalculateQuadraticBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        // formula (1 - t)p0 + t * p1
        Vector3 l0 = CalculateLinerBezierPoint(t, p0, p1);
        Vector3 l1 = CalculateLinerBezierPoint(t, p1, p2);
        return (1 - t) * l0 + t * l1;
    }

    private Vector3 CalculateCubicBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        // formula (1 - t)p0 + t * p1
        Vector3 q0 = CalculateQuadraticBezierPoint(t, p0, p1, p2);
        Vector3 q1 = CalculateQuadraticBezierPoint(t, p1, p2, p3);
        return (1 - t) * q0 + t * q1;
    }
}
