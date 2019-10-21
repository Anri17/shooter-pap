using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject barrageLv1;
    public GameObject barrageLv2;
    public GameObject barrageLv3;
    public GameObject barrageLv4;

    GameObject mainBarrage;

    void Update()
    {
        if (Data.powerLevel >= 0.0f & Data.powerLevel < 1.0f)
        {
            mainBarrage = barrageLv1;
        }
        else if (Data.powerLevel >= 1.0f && Data.powerLevel < 2.0f)
        {
            mainBarrage = barrageLv2;
        }
        else if (Data.powerLevel >= 2.0f && Data.powerLevel < 3.0f)
        {
            mainBarrage = barrageLv3;
        }
        else
        {
            mainBarrage = barrageLv4;
        }
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(mainBarrage, transform.position + new Vector3(0, 1.5f, 0), mainBarrage.transform.rotation);
        }
    }
}
