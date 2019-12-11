using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PowerCollectable")
        {
            GameManager.Instance.powerLevel += 0.05f;
            GameManager.Instance.score += 150;
            Destroy(collision.gameObject);
            Debug.Log("Power Level: " + GameManager.Instance.powerLevel);
        }

        if (collision.gameObject.tag == "BigPowerCollectable")
        {
            GameManager.Instance.powerLevel += 1.00f;
            GameManager.Instance.score += 200;
            Destroy(collision.gameObject);
            // Debug.Log("Power Level: " + Data.powerLevel);
        }

        if (collision.gameObject.tag == "ScoreCollectable")
        {
            GameManager.Instance.score += 500;
            Destroy(collision.gameObject);
            Debug.Log("Score: " + GameManager.Instance.score);
        }
    }
}
