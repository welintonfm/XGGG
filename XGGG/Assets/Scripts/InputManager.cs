using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GunBehavior currentGun;

    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0.1)
        {
            currentGun.MoveToRight();
        }
        else if (Input.GetAxis("Horizontal") < -0.1)
        {
            currentGun.MoveToLeft();
        }
        else
        {
            currentGun.Stop();
        }
    }
}
