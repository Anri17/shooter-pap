using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float normalSpeed = 8.0f;
    public float focusSpeed = 4.0f;

    public GameObject[] barrages;

    GameObject currentBarrage;
    GameObject mainBarrage;

    float speed = 1.0f;
	float horizontal;
	float vertical;
    Vector3 direction;

    void Awake()
    {
        speed = normalSpeed;
    }

    void Update()
    {
        // get movement speed
        if (Input.GetButtonDown("Focus"))
        {
            speed = focusSpeed;
            // Debug.Log("Focus Key Down");
        }
        if (Input.GetButtonUp("Focus"))
        {
            speed = normalSpeed;
            // Debug.Log("Focus Key Up");
        }

        // get input values
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        // get direction 
        if (Input.GetButton("Horizontal") && Input.GetButton("Vertical"))
        {
            if (horizontal > 0)
            {
                direction = new Vector3(Mathf.Cos(horizontal), Mathf.Sin(vertical), 0.0f);
            }
            if (horizontal < 0)
            {
                direction = new Vector3(-Mathf.Cos(horizontal), Mathf.Sin(vertical), 0.0f);
            }
        }
        else
        {
            direction = new Vector3(horizontal, vertical, 0.0f);
        }

        // move the player to the direction defined
        transform.position += direction * speed * Time.deltaTime;


        // shoot barrage
        if (GameManager.Instance.powerLevel >= 0.0f && GameManager.Instance.powerLevel < 1.0f)      // Level 1 Barrage
        {
            // update barrage if firing
            if (mainBarrage != barrages[0] && Input.GetButton("Fire1"))
            {
                mainBarrage = barrages[0];
                Destroy(currentBarrage);
                currentBarrage = Instantiate(mainBarrage, transform.position, mainBarrage.transform.rotation, transform);
            }

            // update barrage if not firing
            if (mainBarrage != barrages[0])
            {
                mainBarrage = barrages[0];
            }
        }
        else if (GameManager.Instance.powerLevel >= 1.0f && GameManager.Instance.powerLevel < 2.0f) // Level 2 Barrage
        {
            // update barrage if firing
            if (mainBarrage != barrages[1] && Input.GetButton("Fire1"))
            {
                mainBarrage = barrages[1];
                Destroy(currentBarrage);
                currentBarrage = Instantiate(mainBarrage, transform.position, mainBarrage.transform.rotation, transform);
            }

            // update barrage if not firing
            if (mainBarrage != barrages[1])
            {
                mainBarrage = barrages[1];
            }
        }
        else if (GameManager.Instance.powerLevel >= 2.0f && GameManager.Instance.powerLevel < 3.0f) // Level 3 Barrage
        {
            // update barrage if firing
            if (mainBarrage != barrages[2] && Input.GetButton("Fire1"))
            {
                mainBarrage = barrages[2];
                Destroy(currentBarrage);
                currentBarrage = Instantiate(mainBarrage, transform.position, mainBarrage.transform.rotation, transform);
            }

            // update barrage if not firing
            if (mainBarrage != barrages[2])
            {
                mainBarrage = barrages[2];
            }
        }
        else                                                        // Level 4 Barrage
        {
            // update barrage if firing
            if (mainBarrage != barrages[3] && Input.GetButton("Fire1"))
            {
                mainBarrage = barrages[3];
                Destroy(currentBarrage);
                currentBarrage = Instantiate(mainBarrage, transform.position, mainBarrage.transform.rotation, transform);
            }

            // update barrage if not firing
            if (mainBarrage != barrages[3])
            {
                mainBarrage = barrages[3];
            }
        }

        // Fire the barrage when the button is pressed
        if (Input.GetButtonDown("Fire1"))
        {
            currentBarrage = Instantiate(mainBarrage, transform.position, mainBarrage.transform.rotation, transform);
            // Debug.Log("Pressing Fire Button");
        }
        // Destroy the barrage when the button is unpressed
        if (Input.GetButtonUp("Fire1"))
        {
            Destroy(currentBarrage);
            // Debug.Log("Unpressing Fire Button");

            // Destroy any left over barrages in child object if the game is alt tabed while the player is fireing and object is still there
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).tag.Equals("PlayerBullet"))
                {
                    Debug.Log("Found a left over fireing thing");
                    Destroy(transform.GetChild(i).gameObject);
                    break;
                }
            }
        }
    }
}
