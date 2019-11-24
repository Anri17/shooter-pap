using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PowerCollectable")
        {
            Data.powerLevel += 0.05f;
            Data.score += 150;
            Destroy(collision.gameObject);
            Debug.Log("Power Level: " + Data.powerLevel);
        }

        if (collision.gameObject.tag == "BigPowerCollectable")
        {
            Data.powerLevel += 1.00f;
            Data.score += 200;
            Destroy(collision.gameObject);
            Debug.Log("Power Level: " + Data.powerLevel);
        }

        if (collision.gameObject.tag == "ScoreCollectable")
        {
            Data.score += 500;
            Destroy(collision.gameObject);
            Debug.Log("Score: " + Data.score);
        }
    }
}
