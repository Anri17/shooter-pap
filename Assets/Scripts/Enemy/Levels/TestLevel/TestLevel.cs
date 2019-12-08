using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestLevel : MonoBehaviour
{
    public GameObject backgroundImage;
    public float backgroundImageScrollSpeed = 1.0f;
    public GameObject[] waves;
    public Boss boss;

    void Awake()
    {
        foreach (GameObject wave in waves)
        {
            wave.SetActive(false);
        }
    }

    void Start()
    {
        
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
        Debug.Log("Level Start");
        yield return new WaitForSeconds(5.5f);
        Debug.Log("Wave 1");
        waves[0].SetActive(true);
        yield return new WaitForSeconds(10f);
        Debug.Log("Wave 2");
        waves[1].SetActive(true);
        Debug.Log("Boss");
    }
}
