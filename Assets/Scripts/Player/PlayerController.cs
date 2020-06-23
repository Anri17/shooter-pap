using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float normalSpeed = 12.0f;
    [SerializeField] float focusSpeed = 4.0f;
    [SerializeField] Animator animatorController;

    private PlayerInput playerInput;

    public float Speed { get; set; }

    public bool canMove = false;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        animatorController.SetLayerWeight(1, 1f);
        canMove = false;
        Speed = normalSpeed;
    }

    void Update()
    {

        // set focus speed value
        if (playerInput.FocusInput)
        {
            Speed = focusSpeed;
            animatorController.SetBool("FocusMode", true);
        }
        else
        {
            Speed = normalSpeed;
            animatorController.SetBool("FocusMode", false);
        }

        //// set focus speed value
        //if (Input.GetButtonDown("Focus"))
        //{
        //    Speed = focusSpeed;
        //    animatorController.SetBool("FocusMode", true);
        //}

        //// set normal speed value
        //if (Input.GetButtonUp("Focus"))
        //{
        //    Speed = normalSpeed;
        //    animatorController.SetBool("FocusMode", false);
        //}

        //if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        //{
        //    Vector3 direction = GetDirection(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //    Move(direction, Speed);
        //}

        if (playerInput.HorizontalInput || playerInput.VerticalInput)
        {
            Vector3 direction = GetDirection(playerInput.HorizontalInputValue, playerInput.VerticalInputValue);
            Move(direction, Speed);
        }
    }

    private void Move(Vector3 direction, float speed)
    {
        if (canMove)
            transform.position += direction * speed * Time.deltaTime;
    }

    Vector3 GetDirection(float horizontal, float vertical)
    {
        if (horizontal != 0 && vertical != 0)
        {
            if (horizontal > 0)
            {
                return new Vector3(Mathf.Cos(horizontal), Mathf.Sin(vertical), 0.0f);
            }
            if (horizontal < 0)
            {
                return new Vector3(-Mathf.Cos(horizontal), Mathf.Sin(vertical), 0.0f);
            }
        }

        //if (Input.GetButton("Horizontal") && Input.GetButton("Vertical"))
        //{
        //    if (horizontal > 0)
        //    {
        //        return new Vector3(Mathf.Cos(horizontal), Mathf.Sin(vertical), 0.0f);
        //    }
        //    if (horizontal < 0)
        //    {
        //        return new Vector3(-Mathf.Cos(horizontal), Mathf.Sin(vertical), 0.0f);
        //    }
        //}
        return new Vector3(horizontal, vertical, 0.0f);
    }
}
