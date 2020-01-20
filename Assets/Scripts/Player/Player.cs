﻿using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float normalSpeed = 8.0f;
    [SerializeField] float focusSpeed = 4.0f;

    public GameObject[] barrages;

    public int Lives { get; set; }
    public float Speed { get; set;  }
    public float PowerLevel { get; set; }

    Vector3 spawnPoint;
    Vector3 direction;
    GameObject currentBarrage;
    GameObject mainBarrage;
	float horizontal;
	float vertical;

    void Awake()
    {
        Speed = normalSpeed;
        PowerLevel = 0.0f;
        Lives = 3;
        spawnPoint = new Vector3(-3.44f, -6.76f, 0);
    }

    void Update()
    {
        SetDirection();
        Move();

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

    public void Move()
    {
        transform.position += direction * Speed * Time.deltaTime;
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

    public void SetDirection()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        // get speed value
        if (Input.GetButtonDown("Focus"))
        {
            Speed = focusSpeed;
        }
        if (Input.GetButtonUp("Focus"))
        {
            Speed = normalSpeed;
        }

        if (Input.GetButton("Horizontal") && Input.GetButton("Vertical"))
        {
            if (horizontal > 0)
            {
                direction = new Vector3(Mathf.Cos(horizontal), Mathf.Sin(vertical), 0.0f);
            }
            if (horizontal < 0)
            {
                direction = new Vector3(-Mathf.Cos(horizontal), Mathf.Sin(vertical), 0.0f);
            }
        }
        else
        {
            direction = new Vector3(horizontal, vertical, 0.0f);
        }
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
