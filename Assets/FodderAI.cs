using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FodderAI : MonoBehaviour
{
    public int horizontalDirection = 0;
    public int verticalDirection = 0;
    public float speed = 1.0f;
    public float sinAmplitude = 1.0f;
    public float sinFrequency = 1.0f;
    private float horizontalOffset = 0.0f;
    private float time;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        time += Time.deltaTime;

        // Remove offset from object
        transform.position -= horizontalOffset * transform.right;

        // Moves object forward
        transform.position += new Vector3(horizontalDirection, verticalDirection, 0) * speed * Time.deltaTime;

        // Adjust horizontal position by sine wave
        horizontalOffset = Mathf.Sin(time * sinFrequency) * sinAmplitude;

        transform.position += horizontalOffset * transform.right;
    }
}
