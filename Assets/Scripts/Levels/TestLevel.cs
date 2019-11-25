using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLevel : MonoBehaviour
{
    public float backgroundScrollSpeed = 1.0f;

    void Start()
    {
        Debug.Log("Level Start");
        StartCoroutine(Level());
    }
        

    void Update()
    {
        transform.position += new Vector3(0, -1f, 0) * backgroundScrollSpeed * Time.deltaTime;
    }

    IEnumerator Level()
    {
        // TODO: LEVEL
        yield return new WaitForSeconds(5f);
        Debug.Log("Level 3");
    }

}
