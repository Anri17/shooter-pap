using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BulletMovement))]
public class BulletMovementEditor : Editor
{
    override public void OnInspectorGUI()
    {
        var bulletMovementScript = target as BulletMovement;

        bulletMovementScript.isStatic = GUILayout.Toggle(bulletMovementScript.isStatic, "Is Static");
        bulletMovementScript.isHoming = GUILayout.Toggle(bulletMovementScript.isHoming, "Is Homing");
        bulletMovementScript.isAcelerating = GUILayout.Toggle(bulletMovementScript.isAcelerating, "Is Acelerating");
        bulletMovementScript.isDesacelerating = GUILayout.Toggle(bulletMovementScript.isDesacelerating, "Is Desacelerating");

        if (bulletMovementScript.isStatic)
        {
            bulletMovementScript.speed = EditorGUILayout.FloatField("Speed:", bulletMovementScript.speed);
        }

        if (bulletMovementScript.isHoming)
        {
            // TODO: add variables related to isHoming
        }

        if (bulletMovementScript.isAcelerating)
        {
            bulletMovementScript.minSpeed = EditorGUILayout.FloatField("Min speed:", bulletMovementScript.minSpeed);
            bulletMovementScript.maxSpeed = EditorGUILayout.FloatField("Max speed:", bulletMovementScript.maxSpeed);
        }

        if (bulletMovementScript.isDesacelerating)
        {
            // TODO: add variables related to isDesacelerating
        }
    }
}
