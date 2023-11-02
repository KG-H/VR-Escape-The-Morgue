using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class ActivateTeleportationRay : MonoBehaviour
{
    public Player player;
    public GameObject leftTel;
    public GameObject RightTel;

    public InputActionProperty leftAct;
    public InputActionProperty RightAct;

    void Update()
    {   
        leftTel.SetActive(leftAct.action.ReadValue<float>() > 0.1f);
        RightTel.SetActive(RightAct.action.ReadValue<float>() > 0.1f);

        if (leftAct.action.ReadValue<float>() > 0.1f) player.left = true;
        else player.left = false;
        if (RightAct.action.ReadValue<float>() > 0.1f) player.right = true;
        else player.right = false;
    }
}
