using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public void Move(GameObject target)
    {
        transform.Translate(target.transform.position);
    }
}
