using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellMoveDown : SpellMovement
{
    public float speedModifier;

    public override IEnumerator MoveCoroutine()
    {
        while (true)
        {
            mainTransform.Translate(Vector3.down * (speedModifier / 10) * Time.deltaTime);
            yield return null;
        }
    }
}
