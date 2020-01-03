using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : Enemy
{
    [SerializeField] float _health;
    [SerializeField] GameObject _shot;
    [SerializeField] int _scoreWorth;
    [SerializeField] GameObject[] _tragectory;
    [SerializeField] float shootDelay;

    public override float Health { get; set; }
    public override GameObject Shot { get; set; }
    public override List<Transform> Tragectory { get; set; }
    public override int ScoreWorth { get; set; }

    GameObject shotInstance;
    GameManager gameManager;

    public void Awake()
    {
        gameManager = GameManager.Instance;
    }

    public void Start()
    {
        Health = _health;
        Shot = _shot;
        ScoreWorth = _scoreWorth;
        for (int i = 0; i < _tragectory.Length; i++)
        {
            Tragectory.Add(_tragectory[i].transform);
        }
    }

    public void Update()
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

    public override void Move(Transform[] tragectory)
    {
        throw new System.NotImplementedException();
    }

    public override IEnumerator ShootCoroutine(float shootDelay)
    {
        yield return new WaitForSeconds(shootDelay);
        shotInstance = Instantiate(Shot, gameObject.transform);
    }
}
