using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float scrollSpeed = 1f;
    public Transform endPosTransform;
    public Vector3 direction;
    Vector2 startPos;
    Vector2 endPos;
    float max;


    private void Start()
    {
        startPos = transform.position;
        endPos = endPosTransform.position;
        max = Mathf.Abs(endPos.y - startPos.y);
    }

    void Update()
    {
        float newPos = Mathf.Repeat(Time.time * scrollSpeed, max);
        transform.position = startPos + Vector2.down * newPos;
        /*
        Vector3 velocity = Vector3.zero;
        Vector3 desiredPosition = transform.position + direction * scrollSpeed;
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, 0.3f);
        transform.position = smoothPosition;
        */
    }
}
