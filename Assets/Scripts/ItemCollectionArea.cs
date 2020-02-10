using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectionArea : MonoBehaviour
{
    [SerializeField] float moveSpeed = 90f;

    GameManager gameManager;
    Player player;

    public bool canSucc = true;

    void Awake()
    {
        gameManager = GameManager.Instance;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") && canSucc)
        {
            GameObject[] powerCollectables = GameObject.FindGameObjectsWithTag("PowerCollectable");
            GameObject[] bigPowerCollectables = GameObject.FindGameObjectsWithTag("BigPowerCollectable");
            GameObject[] scoreCollectables = GameObject.FindGameObjectsWithTag("ScoreCollectable");

            for (int i = 0; i < powerCollectables.Length; i++)
            {
                Collectable powerCollectable = powerCollectables[i].GetComponent<Collectable>();
                // powerCollectable.Move(player.transform, moveSpeed, 0);
                powerCollectable.MoveToPlayer(moveSpeed);
            }
            for (int i = 0; i < bigPowerCollectables.Length; i++)
            {
                Collectable bigPowerCollectable = bigPowerCollectables[i].GetComponent<Collectable>();
                // bigPowerCollectable.Move(player.transform, moveSpeed, 0);
                bigPowerCollectable.MoveToPlayer(moveSpeed);
            }
            for (int i = 0; i < scoreCollectables.Length; i++)
            {
                Collectable scoreCollectable = scoreCollectables[i].GetComponent<Collectable>();
                // scoreCollectable.Move(player.transform, moveSpeed, 0);
                scoreCollectable.MoveToPlayer(moveSpeed);
            }
        }        
    }
}
