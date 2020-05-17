using System;
using System.Collections;
using UnityEditorInternal;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ParticleSystem deathParticles;
    public GameObject[] barrages;
    public GameObject bombBarrage;
    public GameObject sprites;

    [SerializeField] GameObject[] powerOrbsLevels;

    [SerializeField] float _powerLevel = 0f;
    [SerializeField] int _lives = 2;
    [SerializeField] int _bombs = 2;

    public int Lives { get => _lives; set => _lives = value; }
    public float PowerLevel { get => _powerLevel; set => _powerLevel = value > 4 ? 4f : value < 0 ? 0f : value; }
    public int Bombs { get => _bombs; set => _bombs = value; }

    [HideInInspector] public bool canCollectItems = true;
    bool canFire = true;
    GameObject currentBarrage;
    GameObject mainBarrage;
    GameObject currentPowerLevelOrbs;
    int currentPowerLevel;

    PlayerController playerController;

    public bool hittable;

    void Awake()
    {
        hittable = false;
        canCollectItems = true;
        playerController = GetComponent<PlayerController>();
    }

    void Start()
    {
        currentPowerLevel = -1;
    }

    void Update()
    {
        if ((PowerLevel >= 0.0f && PowerLevel < 1.0f) && currentPowerLevel != 0)      // Level 0 Barrage
        {
            Destroy(currentPowerLevelOrbs);
            currentPowerLevelOrbs = Instantiate(powerOrbsLevels[0], sprites.transform);
            SetBarrage(barrages[0]);
            currentPowerLevel = 0;
        }
        else if ((PowerLevel >= 1.0f && PowerLevel < 2.0f) && currentPowerLevel != 1) // Level 1 Barrage
        {
            Destroy(currentPowerLevelOrbs);
            currentPowerLevelOrbs = Instantiate(powerOrbsLevels[1], sprites.transform);
            SetBarrage(barrages[1]);
            currentPowerLevel = 1;
        }
        else if ((PowerLevel >= 2.0f && PowerLevel < 3.0f) && currentPowerLevel != 2) // Level 2 Barrage
        {
            Destroy(currentPowerLevelOrbs);
            currentPowerLevelOrbs = Instantiate(powerOrbsLevels[2], sprites.transform);
            SetBarrage(barrages[2]);
            currentPowerLevel = 2;
        }
        else if ((PowerLevel >= 3.0f && PowerLevel < 4.0f) && currentPowerLevel != 3) // Level 3 Barrage
        {
            Destroy(currentPowerLevelOrbs);
            currentPowerLevelOrbs = Instantiate(powerOrbsLevels[3], sprites.transform);
            SetBarrage(barrages[3]);
            currentPowerLevel = 3;
        }
        else if (PowerLevel == 4 && currentPowerLevel != 4)
        {
            Destroy(currentPowerLevelOrbs);
            currentPowerLevelOrbs = Instantiate(powerOrbsLevels[4], sprites.transform);
            SetBarrage(barrages[4]);
            currentPowerLevel = 4;
        }

        FireBarrage();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collectable" && canCollectItems)
        {
            float powerToAdd = collision.GetComponent<Collectable>().powerLevelWorth;
            int scoreToAdd = collision.GetComponent<Collectable>().scoreWorth;
            int livesToAdd = collision.GetComponent<Collectable>().livesWorth;
            int bombsToAdd = collision.GetComponent<Collectable>().bombsWorth;
            AddValues(powerToAdd, scoreToAdd, livesToAdd, bombsToAdd);
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

    private void PlayDeathParticles(ParticleSystem deathParticles)
    {
        Instantiate(deathParticles, transform.position, Quaternion.identity);
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

    public void AddValues(float powerLevel, int score, int lives, int bombs)
    {
        PowerLevel += powerLevel;
        GameManager.Instance.Score += score;
        Bombs += bombs;
        Lives += lives;
    }

    public void SpawnPlayer(Vector3 position)
    {
        LevelManager.ClearBullets();
        transform.position = position;
        sprites.SetActive(true);
        GetComponent<PlayerController>().canMove = true;
        canFire = true;
        canCollectItems = true;
        PlayerCanMove();
        GameObject.Find("ItemCollectionArea").GetComponent<ItemCollectionArea>().canSucc = true;
        if (Input.GetButton("Fire1"))
        {
            SpawnBarrage(mainBarrage);
        }
    }

    public void PlayerCanMove()
    {
        StartCoroutine(BecomeVulnerable(5f));
        playerController.canMove = true;
    }

    public void PlayerCantMove()
    {
        playerController.canMove = false;
        hittable = false;
    }

    public void Die()
    {
        Debug.Log("Player died");
        PlayDeathParticles(deathParticles);
        Lives--;
        PowerLevel = 0;
        Destroy(currentBarrage);
        PlayerCantMove();
        canFire = false;
        canCollectItems = false;
        GameObject.Find("ItemCollectionArea").GetComponent<ItemCollectionArea>().canSucc = false;
        AudioPlayer.Instance.PlayDeathSound();
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

    public IEnumerator BecomeVulnerable(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        hittable = true;
    }
}
