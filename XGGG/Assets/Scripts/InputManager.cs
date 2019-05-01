using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    bool shiftedPlanet;
    float verticalInput, horizontalInput;
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput > 0.1)
        {
            GunController.MoveToRight();
        }
        else if (horizontalInput < -0.1)
        {
            GunController.MoveToLeft();
        }
        else
        {
            GunController.Stop();
        }

        if (Input.GetButton("Jump"))
        {
            GunController.Shoot();
        }


        if (verticalInput > 0.1)
        {
            if (!shiftedPlanet)
                GunController.SwitchPlanet(verticalInput);
            shiftedPlanet = true;
        }
        else if (verticalInput < -0.1)
        {
            if (!shiftedPlanet)
                GunController.SwitchPlanet(verticalInput);
            shiftedPlanet = true;
        }
        else
        {
            shiftedPlanet = false;
        }

    }
}
