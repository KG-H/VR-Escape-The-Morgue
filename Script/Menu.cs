using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Menu : MonoBehaviour
{
    bool doMenu;
    public GameObject menu;
    public InputActionProperty showmenu;

    void Update()
    {
        float triggerValue = showmenu.action.ReadValue<float>();
        if (triggerValue == 1 && !doMenu)
        {
            doMenu = true;
            menu.gameObject.SetActive(true);
        }
        else doMenu = false;
    }
}
