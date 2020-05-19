using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class L_Enemy : MonoBehaviour
{
    public abstract float Health { get; set; }
    public abstract GameObject Shot { get; set; }
    public abstract List<Transform> Tragectory { get; set; }
    public abstract int ScoreWorth { get; set; }
    public abstract void EvaluateHealth();
    public abstract void Die();
    public abstract IEnumerator ShootCoroutine(float shootDelay);
}
