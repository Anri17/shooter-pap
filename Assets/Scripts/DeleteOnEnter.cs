using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOnEnter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log(collision.gameObject + "exited the screen");
        Destroy(collision.gameObject);

    }
}
