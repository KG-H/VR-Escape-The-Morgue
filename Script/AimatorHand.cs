using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AimatorHand : MonoBehaviour
{
    bool dogrip;
    bool dotrigger;
    public Player player;
    public InputActionProperty prnchAnimationAction;
    public InputActionProperty gripAimationAction;
    public Animator handAnimator;

    void Update()
    {
        float triggerValue = prnchAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", triggerValue);
        if (triggerValue == 1 && !dotrigger)
        {
            dotrigger = true;
            //StartCoroutine(triggerSound());
        }

        float gripValue = gripAimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", gripValue);
        if (gripValue == 1 && !dogrip)
        {
            dogrip = true;
            StartCoroutine(gripSound());
        }
    }
    IEnumerator gripSound()
    {
        SoundManager.instace.SFXPlay("Melee", player.clip[2]);
        yield return new WaitForSeconds(1f);
        dogrip = false;
    }
    IEnumerator triggerSound()
    {
        SoundManager.instace.SFXPlay("Melee", player.clip[1]);
        yield return new WaitForSeconds(1f);
        dotrigger = false;
    }
}
