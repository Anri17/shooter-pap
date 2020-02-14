using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugGizmo : MonoBehaviour
{
    [SerializeField] Vector3[] playfieldPoints;

    void OnDrawGizmos()
    {
        DrawPlayfieldGuideline(playfieldPoints);
    }

    void DrawPlayfieldGuideline(Vector3[] points)
    {
        Gizmos.DrawLine(transform.position + points[0], transform.position + points[1]);
        Gizmos.DrawLine(transform.position + points[1], transform.position + points[2]);
        Gizmos.DrawLine(transform.position + points[2], transform.position + points[3]);
        Gizmos.DrawLine(transform.position + points[3], transform.position + points[0]);
    }
}
