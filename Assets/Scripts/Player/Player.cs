using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject[] barrages;
    public GameObject bombBarrage;
    public GameObject sprites;

    [SerializeField] float _powerLevel = 0f;
    [SerializeField] int _lives = 2;

    public int Lives { get => _lives; set => _lives = value; }
    public float PowerLevel { get => _powerLevel; set => _powerLevel = value > 4 ? 4f : value < 0 ? 0f : value; }

    [HideInInspector] public bool canCollectItems = true;
    bool canFire = true;
    GameObject currentBarrage;
    GameObject mainBarrage;

    void Awake()
    {
        canCollectItems = true;
    }

    void Update()
    {
        // shoot barrage
        if (PowerLevel >= 0.0f && PowerLevel < 1.0f)      // Level 0 Barrage
        {
            SetBarrage(barrages[0]);
        }
        else if (PowerLevel >= 1.0f && PowerLevel < 2.0f) // Level 1 Barrage
        {
            SetBarrage(barrages[1]);
        }
        else if (PowerLevel >= 2.0f && PowerLevel < 3.0f) // Level 2 Barrage
        {
            SetBarrage(barrages[2]);
        }
        else if (PowerLevel >= 3.0f && PowerLevel < 4.0f) // Level 3 Barrage
        {
            SetBarrage(barrages[3]);
        }
        else if (PowerLevel == 4)
        {
            SetBarrage(barrages[4]);
        }

        FireBarrage();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PowerCollectable" && canCollectItems)
        {
            AddValues(0.05f, 150);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "BigPowerCollectable" && canCollectItems)
        {
            AddValues(1.00f, 200);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "ScoreCollectable" && canCollectItems)
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
        if (Input.GetButtonDown("Fire1") && canFire)
        {
            SpawnBarrage(mainBarrage);
        }
        // Destroy the barrage when the button is unpressed
        if (Input.GetButtonUp("Fire1") && canFire)
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

        if (!canFire)
        {
            Destroy(currentBarrage);
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

    public void SpawnPlayer(Vector3 position)
    {
        LevelManager.ClearBullets();
        transform.position = position;
        sprites.SetActive(true);
        GetComponent<PlayerController>().canMove = true;
        canFire = true;
        canCollectItems = true;
        GameObject.Find("ItemCollectionArea").GetComponent<ItemCollectionArea>().canSucc = true;
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
        Destroy(currentBarrage);
        GetComponent<PlayerController>().canMove = false;
        canFire = false;
        canCollectItems = false;
        GameObject.Find("ItemCollectionArea").GetComponent<ItemCollectionArea>().canSucc = false;
        sprites.SetActive(false);
    }

    public void SpawnBarrage(GameObject barrage)
    {
        currentBarrage = Instantiate(barrage, transform.position, mainBarrage.transform.rotation, transform);
    }

    public void RespawnPlayer(Vector3 position, float time)
    {
        Die();
        if (Lives >= 0)
            StartCoroutine(Respawn(position, time));
    }

    public IEnumerator Respawn(Vector3 position, float time)
    {
        yield return new WaitForSeconds(time);
        SpawnPlayer(position);
    }
}
