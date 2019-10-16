using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMenuHandler : MonoBehaviour
{
    public GameObject player;

    public void RespawnPlayer()
    {
        Instantiate(player, new Vector3(0.0f, -7.0f, 0.0f), player.transform.rotation);
    }
}
