using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float scrollSpeed = 1f;
    public Vector3 endPosTransform;
    Vector3 startPos;
    Vector3 endPos;
    float max;


    private void Start()
    {
        startPos = transform.localPosition; // the position where the object starts
        endPos = endPosTransform; // the position where the object should end
        max = Mathf.Abs(endPos.z - startPos.z); // the maximum it can move
        print(max);
    }

    void Update()
    {
        float newPos = Mathf.Repeat(Time.time * scrollSpeed, max);
        transform.localPosition = startPos + Vector3.forward * -newPos;


    }
}
