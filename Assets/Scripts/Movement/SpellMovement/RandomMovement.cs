﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : SpellMovement
{
    public override IEnumerator MoveCoroutine()
    {
        while (true)
        {
            Vector3 point = GetRandomPoint();
            StartCoroutine(LerpMoveBoss(point, 1f));
            yield return new WaitForSeconds(2f);
        }
    }

    public Vector3 GetRandomPoint()
    {
        float spriteWidthSize;
        float spriteHeightSize;
        if (mainTransform.GetComponent<SpriteRenderer>() != null)
        {
            spriteWidthSize = mainTransform.GetComponent<SpriteRenderer>().sprite.bounds.size.x / 2;
            spriteHeightSize = mainTransform.GetComponent<SpriteRenderer>().sprite.bounds.size.y / 2;
        }
        else
        {
            spriteWidthSize = 1;
            spriteHeightSize = 1;
        }

        float randX = UnityEngine.Random.Range((GameManager.GAME_FIELD_TOP_LEFT.x + spriteWidthSize) + GameManager.GAME_FIELD_CENTER.x, (GameManager.GAME_FIELD_TOP_RIGHT.x - spriteWidthSize) + GameManager.GAME_FIELD_CENTER.x);
        float randY = UnityEngine.Random.Range(1 + spriteHeightSize, (GameManager.GAME_FIELD_TOP_LEFT.y - spriteHeightSize));

        return new Vector3(randX, randY, 0);
    }

    public IEnumerator LerpMoveBoss(Vector3 destination, float timeToMove)
    {
        Vector3 currentPos = mainTransform.position;
        float t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
            mainTransform.position = Vector3.Lerp(currentPos, destination, t);
            yield return null;
        }
    }
}