using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBullet : Bullet
{
    public abstract float Damage { get; set; }
}
