using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float normalSpeed = 8.0f;
    public float focusSpeed = 4.0f;
    public GameObject[] barrages;
    public float powerLevel;
    public int lives;

    Vector3 spawnPoint;
	float horizontal;
	float vertical;
    float speed;
    GameObject currentBarrage;
    GameObject mainBarrage;
    Vector3 direction;

    void Awake()
    {
        speed = normalSpeed;
        powerLevel = 0.0f;
        lives = 3;
        spawnPoint = new Vector3(-3.44f, -6.76f, 0);
    }

    void Update()
    {
        // get input values
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
        // get speed value
        if (Input.GetButtonDown("Focus"))
        {
            speed = focusSpeed;
        }
        if (Input.GetButtonUp("Focus"))
        {
            speed = normalSpeed;
        }

        // get direction 
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

        // move the player
        transform.position += direction * speed * Time.deltaTime;

        // shoot barrage
        if (powerLevel >= 0.0f && powerLevel < 1.0f)      // Level 1 Barrage
        {
            // update barrage if firing
            if (mainBarrage != barrages[0] && Input.GetButton("Fire1"))
            {
                mainBarrage = barrages[0];
                Destroy(currentBarrage);
                currentBarrage = Instantiate(mainBarrage, transform.position, mainBarrage.transform.rotation, transform);
            }

            // update barrage if not firing
            if (mainBarrage != barrages[0])
            {
                mainBarrage = barrages[0];
            }
        }
        else if (powerLevel >= 1.0f && powerLevel < 2.0f) // Level 2 Barrage
        {
            // update barrage if firing
            if (mainBarrage != barrages[1] && Input.GetButton("Fire1"))
            {
                mainBarrage = barrages[1];
                Destroy(currentBarrage);
                currentBarrage = Instantiate(mainBarrage, transform.position, mainBarrage.transform.rotation, transform);
            }

            // update barrage if not firing
            if (mainBarrage != barrages[1])
            {
                mainBarrage = barrages[1];
            }
        }
        else if (powerLevel >= 2.0f && powerLevel < 3.0f) // Level 3 Barrage
        {
            // update barrage if firing
            if (mainBarrage != barrages[2] && Input.GetButton("Fire1"))
            {
                mainBarrage = barrages[2];
                Destroy(currentBarrage);
                currentBarrage = Instantiate(mainBarrage, transform.position, mainBarrage.transform.rotation, transform);
            }

            // update barrage if not firing
            if (mainBarrage != barrages[2])
            {
                mainBarrage = barrages[2];
            }
        }
        else                                                        // Level 4 Barrage
        {
            // update barrage if firing
            if (mainBarrage != barrages[3] && Input.GetButton("Fire1"))
            {
                mainBarrage = barrages[3];
                Destroy(currentBarrage);
                currentBarrage = Instantiate(mainBarrage, transform.position, mainBarrage.transform.rotation, transform);
            }

            // update barrage if not firing
            if (mainBarrage != barrages[3])
            {
                mainBarrage = barrages[3];
            }
        }

        // Fire barrage when the button is pressed
        if (Input.GetButtonDown("Fire1"))
        {
            currentBarrage = Instantiate(mainBarrage, transform.position, mainBarrage.transform.rotation, transform);
            // Debug.Log("Pressing Fire Button");
        }
        // Destroy the barrage when the button is unpressed
        if (Input.GetButtonUp("Fire1"))
        {
            Destroy(currentBarrage);
            // Debug.Log("Unpressing Fire Button");

            // Destroy any left over barrages in child object if the game is alt tabed while the player is fireing and object is still there
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PowerCollectable")
        {
            powerLevel += 0.05f;
            GameManager.Instance.score += 150;
            Destroy(collision.gameObject);
            Debug.Log("Power Level: " + powerLevel);
        }

        if (collision.gameObject.tag == "BigPowerCollectable")
        {
            powerLevel += 1.00f;
            GameManager.Instance.score += 200;
            Destroy(collision.gameObject);
            // Debug.Log("Power Level: " + Data.powerLevel);
        }

        if (collision.gameObject.tag == "ScoreCollectable")
        {
            GameManager.Instance.score += 500;
            Destroy(collision.gameObject);
            Debug.Log("Score: " + GameManager.Instance.score);
        }
    }

    public void Respawn()
    {
        Level.ClearBullets();
        transform.position = spawnPoint;
        gameObject.SetActive(true);
        if (Input.GetButton("Fire1"))
        {
            currentBarrage = Instantiate(mainBarrage, transform.position, mainBarrage.transform.rotation, transform);
        }
    }

    public void Reset()
    {
        powerLevel = 0.0f;
        lives = 3;
    }

    public void Die()
    {
        Debug.Log("Player died");
        lives--;
        gameObject.SetActive(false);
        Destroy(currentBarrage);
        if (lives >= 0)
        {
            Respawn();
        }
    }
}
