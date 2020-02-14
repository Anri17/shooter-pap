using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float normalSpeed = 12.0f;
    [SerializeField] float focusSpeed = 4.0f;
    [SerializeField] GameObject hitboxSprite;

    public float Speed { get; set; }

    public bool canMove = true;

    float horizontal;
    float vertical;
    Vector3 direction;

    void Awake()
    {
        canMove = true;
        Speed = normalSpeed;
        hitboxSprite.SetActive(false);
    }

    void Update()
    {
        direction = GetDirection();
        Move();
    }

    private void Move()
    {
        if (canMove)
            transform.position += direction * Speed * Time.deltaTime;
    }

    private Vector3 GetDirection()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        // get speed value
        if (Input.GetButtonDown("Focus"))
        {
            Speed = focusSpeed;
            hitboxSprite.SetActive(true);
        }
        if (Input.GetButtonUp("Focus"))
        {
            Speed = normalSpeed;
            hitboxSprite.SetActive(false);
        }

        if (Input.GetButton("Horizontal") && Input.GetButton("Vertical"))
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
        return new Vector3(horizontal, vertical, 0.0f);
    }
}
