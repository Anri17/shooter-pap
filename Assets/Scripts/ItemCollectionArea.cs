using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectionArea : MonoBehaviour
{
    [SerializeField] float moveSpeed = 90f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            GameObject player = collision.gameObject;
            GameObject[] powerCollectables = GameObject.FindGameObjectsWithTag("PowerCollectable");
            GameObject[] bigPowerCollectables = GameObject.FindGameObjectsWithTag("BigPowerCollectable");
            GameObject[] scoreCollectables = GameObject.FindGameObjectsWithTag("ScoreCollectable");

            for (int i = 0; i < powerCollectables.Length; i++)
            {
                Collectable powerCollectable = powerCollectables[i].GetComponent<Collectable>();
                powerCollectable.Move(player.transform, moveSpeed);
            }
            for (int i = 0; i < bigPowerCollectables.Length; i++)
            {
                Collectable bigPowerCollectable = bigPowerCollectables[i].GetComponent<Collectable>();
                bigPowerCollectable.Move(player.transform, moveSpeed);
            }
            for (int i = 0; i < scoreCollectables.Length; i++)
            {
                Collectable scoreCollectable = scoreCollectables[i].GetComponent<Collectable>();
                scoreCollectable.Move(player.transform, moveSpeed);
            }
        }        
    }
}
