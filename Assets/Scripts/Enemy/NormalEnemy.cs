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

    public override float Health { get; set; }
    public override GameObject Shot { get; set; }
    public override List<Transform> Tragectory { get; set; }
    public override int ScoreWorth { get; set; }

    GameObject shotInstance;
    GameManager gameManager;
    BezierMove bezierMoveInstance;

    public void Awake()
    {
        gameManager = GameManager.Instance;
        bezierMoveInstance = GetComponent<BezierMove>();
    }

    public void Start()
    {
        Health = _health;
        Shot = _shot;
        ScoreWorth = _scoreWorth;
        for (int i = 0; i < tragectory.Length; i++)
        {
            Tragectory.Add(tragectory[i].transform);
        }
        bezierMoveInstance.StartMovement();
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
        Destroy(gameObject);
        gameManager.Score += ScoreWorth;
    }

    public override void EvaluateHealth()
    {
        if (Health <= 0)
        {
            Die();
        }
    }

    public override IEnumerator ShootCoroutine(float shootDelay)
    {
        yield return new WaitForSeconds(shootDelay);
        shotInstance = Instantiate(Shot, gameObject.transform);
    }
}
