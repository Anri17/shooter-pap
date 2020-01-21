using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject[] barrages;

    public int Lives { get; set; }
    public float Speed { get; set;  }
    public float PowerLevel { get; set; }

    Vector3 spawnPoint;
    GameObject currentBarrage;
    GameObject mainBarrage;
    GameManager gameManager;

    void Awake()
    {
        gameManager = GameManager.Instance;
        PowerLevel = 0.0f;
        Lives = 99;
        spawnPoint = new Vector3(-3.44f, -6.76f, 0);
    }

    void Update()
    {
        if (PowerLevel > 4)
        {
            PowerLevel = 4f;
        }

        // shoot barrage
        if (PowerLevel >= 0.0f && PowerLevel < 1.0f)      // Level 1 Barrage
        {
            SetBarrage(barrages[0]);
        }
        else if (PowerLevel >= 1.0f && PowerLevel < 2.0f) // Level 2 Barrage
        {
            SetBarrage(barrages[1]);
        }
        else if (PowerLevel >= 2.0f && PowerLevel < 3.0f) // Level 3 Barrage
        {
            SetBarrage(barrages[2]);
        }
        else                                              // Level 4 Barrage
        {
            SetBarrage(barrages[3]);
        }
        FireBarrage();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PowerCollectable")
        {
            AddValues(0.05f, 150);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "BigPowerCollectable")
        {
            AddValues(1.00f, 200);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "ScoreCollectable")
        {
            AddValues(0f, 500);
            Destroy(collision.gameObject);
        }
    }

    public void SetBarrage(GameObject barrage)
    {
        if (mainBarrage != barrage)
        {
            AssignBarrage(barrage);
            // update barrage if firing
            if (Input.GetButton("Fire1"))
            {
                Destroy(currentBarrage);
                SpawnBarrage(mainBarrage);
            }
        }
    } 

    public void FireBarrage()
    {
        // Fire barrage when the button is pressed
        if (Input.GetButtonDown("Fire1"))
        {
            SpawnBarrage(mainBarrage);
        }
        // Destroy the barrage when the button is unpressed
        if (Input.GetButtonUp("Fire1"))
        {
            Destroy(currentBarrage);
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).tag.Equals("PlayerBullet"))
                {
                    // Debug.Log("Found a left over fireing thing");
                    Destroy(transform.GetChild(i).gameObject);
                    break;
                }
            }
        }
    }

    public void AssignBarrage(GameObject barrage)
    {
        mainBarrage = barrage;
    }

    public void AddValues(float powerLevel, int score)
    {
        PowerLevel += powerLevel;
        GameManager.Instance.Score += score;
    }

    public void Respawn(Vector3 position)
    {
        LevelManager.ClearBullets();
        transform.position = position;
        gameObject.SetActive(true);
        if (Input.GetButton("Fire1"))
        {
            SpawnBarrage(mainBarrage);
        }
    }

    public void Die()
    {
        Debug.Log("Player died");
        Lives--;
        PowerLevel = 0;
        gameObject.SetActive(false);
        Destroy(currentBarrage);
        if (Lives >= 0)
        {
            Respawn(spawnPoint);
        }
    }

    public void SpawnBarrage(GameObject barrage)
    {
        currentBarrage = Instantiate(barrage, transform.position, mainBarrage.transform.rotation, transform);
    }
}
