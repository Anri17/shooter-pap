using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectionArea : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player is in the item collection area.");
        }        
    }
}
