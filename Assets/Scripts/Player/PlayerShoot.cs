using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject barrageLv1;
    public GameObject barrageLv2;
    public GameObject barrageLv3;
    public GameObject barrageLv4;

    GameObject currentBarrage;
    GameObject mainBarrage;

    void Update()
    {
        if (Data.powerLevel >= 0.0f && Data.powerLevel < 1.0f)      // Level 1 Barrage
        {
            // update barrage if firing
            if (mainBarrage != barrageLv1 && Input.GetButton("Fire1"))
            {
                mainBarrage = barrageLv1;
                Destroy(currentBarrage);
                currentBarrage = Instantiate(mainBarrage, transform.position, mainBarrage.transform.rotation, transform);
            }

            // update barrage if not firing
            if (mainBarrage != barrageLv1)
            {
                mainBarrage = barrageLv1;
            }
        }
        else if (Data.powerLevel >= 1.0f && Data.powerLevel < 2.0f) // Level 2 Barrage
        {
            // update barrage if firing
            if (mainBarrage != barrageLv2 && Input.GetButton("Fire1"))
            {
                mainBarrage = barrageLv2;
                Destroy(currentBarrage);
                currentBarrage = Instantiate(mainBarrage, transform.position, mainBarrage.transform.rotation, transform);
            }

            // update barrage if not firing
            if (mainBarrage != barrageLv2)
            {
                mainBarrage = barrageLv2;
            }
        }
        else if (Data.powerLevel >= 2.0f && Data.powerLevel < 3.0f) // Level 3 Barrage
        {
            // update barrage if firing
            if (mainBarrage != barrageLv3 && Input.GetButton("Fire1"))
            {
                mainBarrage = barrageLv3;
                Destroy(currentBarrage);
                currentBarrage = Instantiate(mainBarrage, transform.position, mainBarrage.transform.rotation, transform);
            }

            // update barrage if not firing
            if (mainBarrage != barrageLv3)
            {
                mainBarrage = barrageLv3;
            }
        }
        else                                                        // Level 4 Barrage
        {
            // update barrage if firing
            if (mainBarrage != barrageLv4 && Input.GetButton("Fire1"))
            {
                mainBarrage = barrageLv4;
                Destroy(currentBarrage);
                currentBarrage = Instantiate(mainBarrage, transform.position, mainBarrage.transform.rotation, transform);
            }

            // update barrage if not firing
            if (mainBarrage != barrageLv4)
            {
                mainBarrage = barrageLv4;
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
