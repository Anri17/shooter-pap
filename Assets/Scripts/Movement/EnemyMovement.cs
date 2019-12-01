using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Movement", menuName = "Enemy/Movement")]
public class EnemyMovement : ScriptableObject
{
    public Vector3[] positions;
}
