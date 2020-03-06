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
            GameObject[] collectables = GameObject.FindGameObjectsWithTag("Collectable");

            for (int i = 0; i < collectables.Length; i++)
            {
                Collectable collectable = collectables[i].GetComponent<Collectable>();
                // bigPowerCollectable.Move(player.transform, moveSpeed, 0);
                collectable.MoveToPlayer(moveSpeed);
            }
        }        
    }
}
