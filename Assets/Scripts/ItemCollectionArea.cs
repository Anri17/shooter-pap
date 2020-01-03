using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectionArea : MonoBehaviour
{
    [SerializeField] private GameObject[] itemsToCollect;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            Debug.Log("Player is in the item collection area.\n TODO: suck all items in the screen to the player");
        }        
    }
}
