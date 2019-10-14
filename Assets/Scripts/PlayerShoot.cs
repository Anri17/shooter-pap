using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject barrageLv1;
    public GameObject barrageLv2;
    public GameObject barrageLv3;
    public GameObject barrageLv4;

    void FixedUpdate()
    {
        if (Input.GetButton("Fire1"))
        {
            if (Data.powerLevel >= 0.0f & Data.powerLevel < 1.0f)
            {
                Instantiate(barrageLv1, transform.position + new Vector3(0, 1.5f, 0), barrageLv1.transform.rotation);
            }
            else if (Data.powerLevel >= 1.0f && Data.powerLevel < 2.0f)
            {
                Instantiate(barrageLv2, transform.position + new Vector3(0, 1.5f, 0), barrageLv2.transform.rotation);
            }
            else if (Data.powerLevel >= 2.0f && Data.powerLevel < 3.0f)
            {
                Instantiate(barrageLv3, transform.position + new Vector3(0, 1.5f, 0), barrageLv3.transform.rotation);
            }
            else
            {
                Instantiate(barrageLv4, transform.position + new Vector3(0, 1.5f, 0), barrageLv4.transform.rotation);
            }
        }
    }
}
