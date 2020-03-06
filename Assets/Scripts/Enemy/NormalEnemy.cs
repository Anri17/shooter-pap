using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : Enemy
{
    [HideInInspector] public GameObject[] tragectory;
    
    [SerializeField] float _health;
    [SerializeField] GameObject _shot;
    [SerializeField] int _scoreWorth;
    [SerializeField] float shootDelay;
    [SerializeField] ParticleSystem deathParticles;
    [SerializeField] AudioSource hitSound;
    [SerializeField] bool randomizeShotDelay = false;
    [SerializeField] int powerItemsToDrop = 1;
    [SerializeField] int bigPowerItemsToDrop = 1;
    [SerializeField] int scoreItemsToDrop = 1;
    [SerializeField] int lifeItemsToDrop = 0;
    [SerializeField] int bombItemsToDrop = 0;

    public override float Health { get; set; }
    public override GameObject Shot { get; set; }
    public override List<Transform> Tragectory { get; set; }
    public override int ScoreWorth { get; set; }

    GameObject shotInstance;
    GameManager gameManager;
    BezierMove bezierMoveInstance;
    LevelManager levelManager;

    public void Awake()
    {
        Health = _health;
        Shot = _shot;
        ScoreWorth = _scoreWorth;
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        gameManager = GameManager.Instance;
        bezierMoveInstance = GetComponent<BezierMove>();
    }

    public void Start()
    {
        if (randomizeShotDelay)
        {
            shootDelay = Random.Range(0.2f, 1f);
        }

        for (int i = 0; i < tragectory.Length; i++)
        {
            Tragectory.Add(tragectory[i].transform);
        }
        if (bezierMoveInstance != null)
        {
            bezierMoveInstance.StartMovement();
        }
    }

    private void Update()
    {
        EvaluateHealth();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("PlayerBullet") || collision.tag.Equals("PlayerLazer"))
        {
            Health -= collision.GetComponent<PlayerBullet>().Damage;
            gameManager.Score += 40;
            Destroy(collision.gameObject);
            hitSound.Play();
        }

        if (collision.tag.Equals("PlayArea") && shotInstance == null)
        {
            StartCoroutine(ShootCoroutine(shootDelay));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("PlayArea") && shotInstance != null)
        {
            Destroy(shotInstance);
        }
    }

    public override void Die()
    {
        PlayDeathParticles(deathParticles);
        Destroy(gameObject);
        GiveScoreWorth(ScoreWorth);
    }

    private void PlayDeathParticles(ParticleSystem deathParticles)
    {
        Instantiate(deathParticles, transform.position, Quaternion.identity);
    }
    
    private void GiveScoreWorth(long scoreWorth)
    {
        gameManager.Score += scoreWorth;
    }

    public override void EvaluateHealth()
    {
        if (Health <= 0)
        {
            DropItems(powerItemsToDrop, bigPowerItemsToDrop, scoreItemsToDrop, lifeItemsToDrop, bombItemsToDrop);
            Die();
        }
    }

    public void DropItems(int powerItemQuantity, int bigPowerItemQuantity, int scoreItemQuantity, int lifeItemQuantity, int bombItemQuantity)
    {
        levelManager.SpawnItems(transform.position, powerItemQuantity, bigPowerItemQuantity, scoreItemQuantity, lifeItemQuantity, bombItemQuantity);
    }

    public override IEnumerator ShootCoroutine(float shootDelay)
    {
        yield return new WaitForSeconds(shootDelay);
        shotInstance = Instantiate(Shot, gameObject.transform);
    }
}
