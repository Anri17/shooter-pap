using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugGizmo : MonoBehaviour
{
    void OnDrawGizmos()
    {
        DrawPlayfieldGuideline();
    }

    void DrawPlayfieldGuideline()
    {
        Gizmos.DrawLine(GameManager.GAME_FIELD_TOP_LEFT, GameManager.GAME_FIELD_TOP_RIGHT);
        Gizmos.DrawLine(GameManager.GAME_FIELD_TOP_RIGHT, GameManager.GAME_FIELD_BOTTOM_RIGHT);
        Gizmos.DrawLine(GameManager.GAME_FIELD_BOTTOM_RIGHT, GameManager.GAME_FIELD_BOTTOM_LEFT);
        Gizmos.DrawLine(GameManager.GAME_FIELD_BOTTOM_LEFT, GameManager.GAME_FIELD_TOP_LEFT);
    }
}
