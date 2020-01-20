using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Player player;
    void Awake()
    {
        player = GetComponent<Player>();
    }

}
