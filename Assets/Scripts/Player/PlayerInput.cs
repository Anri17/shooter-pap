using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public bool FocusInput { get; private set; }
    public bool HorizontalInput { get; private set; }
    public bool VerticalInput { get; private set; }
    public float HorizontalInputValue { get; private set; }
    public float VerticalInputValue { get; private set; }

    private void Update()
    {
        if (Input.GetButtonDown("Focus"))
        {
            FocusInput = true;
        }
        if (Input.GetButtonUp("Focus"))
        {
            FocusInput = false;
        }

        HorizontalInput = Input.GetButton("Horizontal");
        VerticalInput = Input.GetButton("Vertical");
        HorizontalInputValue = Input.GetAxis("Horizontal");
        VerticalInputValue = Input.GetAxis("Vertical");
    }
}
