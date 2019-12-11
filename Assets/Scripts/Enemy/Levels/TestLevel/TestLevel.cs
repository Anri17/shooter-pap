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

    public GameObject pauseMenu;

    void Awake()
    {
        foreach (GameObject wave in waves)
        {
            wave.SetActive(false);
            pauseMenu.SetActive(false);
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

        // Go to main Menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // SceneManager.LoadScene(0);
            if (pauseMenu.active)
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
            }
        }
    }

    IEnumerator Level()
    {
        Debug.Log("Level Start");
        yield return new WaitForSeconds(5.5f);
        Debug.Log("Wave 1");
        waves[0].SetActive(true);
        yield return new WaitForSeconds(11f);
        Debug.Log("Wave 2");
        waves[1].SetActive(true);
        Debug.Log("Boss");
    }
}
