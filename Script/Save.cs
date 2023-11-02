using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    public Countdown countdown;
    public Player player;

    public void GameSave()
    {
        PlayerPrefs.SetFloat("x", player.transform.position.x);
        PlayerPrefs.SetFloat("y", player.transform.position.y);
        PlayerPrefs.SetFloat("z", player.transform.position.z);
        PlayerPrefs.SetFloat("setTime", countdown.setTime);

        PlayerPrefs.Save();
    }
    public void GameLoad()
    {
        if (!PlayerPrefs.HasKey("x")) return;

        float x = PlayerPrefs.GetFloat("x");
        float y = PlayerPrefs.GetFloat("y");
        float z = PlayerPrefs.GetFloat("z");
        float setTime = PlayerPrefs.GetFloat("setTime");

        player.transform.position = new Vector3(x, y, z);
        countdown.setTime = setTime;
        countdown.gostart = true;
        countdown.count.gameObject.SetActive(true);
    }
}
