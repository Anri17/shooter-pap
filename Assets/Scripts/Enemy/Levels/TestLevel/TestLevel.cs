﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestLevel : MonoBehaviour
{
    public GameObject backgroundImage;
    public float backgroundImageScrollSpeed = 1.0f;
    public GameObject[] waves;
    public Boss boss;

    void Start()
    {
        Debug.Log("Level Start");
        StartCoroutine(Level());
    }
        
    void Update()
    {
        // Move Background
        transform.position += new Vector3(0, -1f, 0) * backgroundImageScrollSpeed * Time.deltaTime;

        // God to main Menu
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    IEnumerator Level()
    {
        yield return new WaitForSeconds(5f);
        Debug.Log("Wave 1");
        yield return new WaitForSeconds(5f);
        Debug.Log("Wave 2");
        yield return new WaitForSeconds(5f);
        Debug.Log("Wave 3");
        yield return new WaitForSeconds(5f);
        Debug.Log("Wave 4");
        yield return new WaitForSeconds(5f);
        Debug.Log("Wave 5");
        yield return new WaitForSeconds(5f);
        Debug.Log("Boss");
    }
}
