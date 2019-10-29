/*
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
            bulletMovementScript.targetDirection = EditorGUILayout.Vector3Field("Target Direction", bulletMovementScript.targetDirection);
        }

        if (bulletMovementScript.isHoming)
        {
            bulletMovementScript.targetTag = EditorGUILayout.TagField("Target Tag:", bulletMovementScript.targetTag);
            bulletMovementScript.speed = EditorGUILayout.FloatField("Speed:", bulletMovementScript.speed);
            bulletMovementScript.homingDelay = EditorGUILayout.FloatField("Delay:", bulletMovementScript.homingDelay);
        }

        if (bulletMovementScript.isAcelerating)
        {
            bulletMovementScript.minSpeed = EditorGUILayout.FloatField("Min speed:", bulletMovementScript.minSpeed);
            bulletMovementScript.maxSpeed = EditorGUILayout.FloatField("Max speed:", bulletMovementScript.maxSpeed);
        }

        if (bulletMovementScript.isDesacelerating)
        {
            bulletMovementScript.minSpeed = EditorGUILayout.FloatField("Min speed:", bulletMovementScript.minSpeed);
            bulletMovementScript.maxSpeed = EditorGUILayout.FloatField("Max speed:", bulletMovementScript.maxSpeed);
        }
    }
}
*/