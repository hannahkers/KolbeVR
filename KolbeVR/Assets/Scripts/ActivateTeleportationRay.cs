using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateTeleportationRay : MonoBehaviour
{
    public GameObject leftTeleportation;
    public GameObject rightTeleportation;

    public InputActionProperty leftActivate;
    public InputActionProperty rightActivate;

    public InputActionProperty leftDeactivate;
    public InputActionProperty rightDeactivate;

    // Update is called once per frame
    void Update()
    {
        leftTeleportation.SetActive(leftDeactivate.action.ReadValue<float>() == 0 && leftActivate.action.ReadValue<float>()>0.1f);
        rightTeleportation.SetActive(rightDeactivate.action.ReadValue<float>() == 0 && rightActivate.action.ReadValue<float>() > 0.1f);
    }
}
