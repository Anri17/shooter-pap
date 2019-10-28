using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BulletMovement))]
public class BulletMovementEditor : Editor
{
    void OnInspectorGUI()
    {
        var bulletMovementScript = target as BulletMovement;

        bulletMovementScript.isStatic = GUILayout.Toggle(bulletMovementScript.isStatic, "Is Static");
        bulletMovementScript.isAcelerating = GUILayout.Toggle(bulletMovementScript.isAcelerating, "Is Acelerating");

        if (bulletMovementScript.isStatic)
        {
            bulletMovementScript.speed = EditorGUILayout.FloatField(bulletMovementScript.speed);
        }

        if (bulletMovementScript.isAcelerating)
        {
            bulletMovementScript.minSpeed = EditorGUILayout.FloatField(bulletMovementScript.minSpeed);
            bulletMovementScript.maxSpeed = EditorGUILayout.FloatField(bulletMovementScript.maxSpeed);
        }
    }
}
