using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementDirection
{
    Up,
    Down,
    Left,
    Right
}

public class MovementLinear : SpellMovement
{
    [SerializeField] MovementDirection movementDirection;
    [SerializeField] float firstMovementSpeed;
    [SerializeField] float movementDuration;
    [SerializeField] float secondMovementSpeed;

    float speedModifier;

    public override IEnumerator MoveCoroutine()
    {
        StartCoroutine(ChangeSpeedCoroutine(movementDuration));
        speedModifier = firstMovementSpeed;

        switch (movementDirection)
        {
            case MovementDirection.Up:
                while (true)
                {
                    mainTransform.Translate(Vector3.up * (speedModifier / 10) * Time.deltaTime);
                    yield return null;
                }
                break;
            case MovementDirection.Down:
                while (true)
                {
                    mainTransform.Translate(Vector3.down * (speedModifier / 10) * Time.deltaTime);
                    yield return null;
                }
                break;
            case MovementDirection.Left:
                while (true)
                {
                    mainTransform.Translate(Vector3.left * (speedModifier / 10) * Time.deltaTime);
                    yield return null;
                }
                break;
            case MovementDirection.Right:
                while (true)
                {
                    mainTransform.Translate(Vector3.right * (speedModifier / 10) * Time.deltaTime);
                    yield return null;
                }
                break;
            default:
                mainTransform.Translate(Vector3.down * (speedModifier / 10) * Time.deltaTime);
                yield return null;
                break;
        }
    }

    IEnumerator ChangeSpeedCoroutine(float movementduration)
    {
        yield return new WaitForSeconds(movementduration);
        speedModifier = secondMovementSpeed;
    }

}
