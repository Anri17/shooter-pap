using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Bezier
{
    public static Vector3 CalculateLinearPoint(float t, Vector3 p0, Vector3 p1)
    {
        // formula (1 - t)p0 + t * p1
        return p0 + t * (p1 - p0);
    }

    public static Vector3 CalculateQuadraticPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        // formula (1 - t)p0 + t * p1
        Vector3 l0 = CalculateLinearPoint(t, p0, p1);
        Vector3 l1 = CalculateLinearPoint(t, p1, p2);
        return (1 - t) * l0 + t * l1;
    }

    public static Vector3 CalculateCubicPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        // formula (1 - t)p0 + t * p1
        Vector3 q0 = CalculateQuadraticPoint(t, p0, p1, p2);
        Vector3 q1 = CalculateQuadraticPoint(t, p1, p2, p3);
        return (1 - t) * q0 + t * q1;
    }
}