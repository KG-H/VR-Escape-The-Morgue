using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{   
    public Text PlayTime;
    public Transform Door;
    public GameObject ClearText;
    public GameObject MenuUI;
    public Countdown countdown;
    public Player player;
    public GameObject settingUI;
    public GameObject infoUI;
    public GameObject StartFloor;
    public GameObject Canvas;
    public GameObject Map;
    public Image Panel;
    float time = 0f;
    float F_time = 1f;
    void Start()
    {

    }
    void Update()
    {
        
    }
    public void OpenDoor()
    {
        Door.transform.localEulerAngles = new Vector3(0, -80f, 0);
    }
    public void GameClear()
    {
        countdown.ClearG();
    }
    public void showMenu()
    {
        MenuUI.gameObject.SetActive(true);
    }
    public void OutMenu()
    {
        MenuUI.gameObject.SetActive(false);
    }
    public void showInfo()
    {   
        infoUI.gameObject.SetActive(true);
        SoundManager.instace.SFXPlay("Melee", player.clip[0]);
    }
    public void Outinfo()
    {
        infoUI.gameObject.SetActive(false);
        SoundManager.instace.SFXPlay("Melee", player.clip[0]);
    }
    public void Fade()
    {
        SoundManager.instace.SFXPlay("Melee", player.clip[0]);
        StartCoroutine(FadeFlow());
    }
    public void showSetting()
    {
        settingUI.gameObject.SetActive(true);
        SoundManager.instace.SFXPlay("Melee", player.clip[0]);
    }
    public void outSetting()
    {
        settingUI.gameObject.SetActive(false);
        SoundManager.instace.SFXPlay("Melee", player.clip[0]);
    }
    public IEnumerator FadeFlow()
    {   
        Panel.gameObject.SetActive(true);
        time = 0f;
        Color alpha = Panel.color;
        while(alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }
        time = 0f;
        SoundManager.instace.bgSound.Stop();
        yield return new WaitForSeconds(2f);
        SoundManager.instace.BgSoundPlay(player.Back[1]);
        player.gameObject.transform.position = countdown.mapStartPos.position;
        countdown.count.gameObject.SetActive(true);
        countdown.countdownText.text = "남은시간 : " + countdown.setTime.ToString() + "초";
        countdown.gostart = true;
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            Panel.color = alpha;
            yield return null;
        }
        Panel.gameObject.SetActive(false);
        player.Hint1.gameObject.SetActive(true);
        yield return null;
    }
    public void Stage1Cout()
    {
        player.Hint2_0.gameObject.SetActive(false);
        player.Hint2.gameObject.SetActive(true);
    }
    public void Stage2Cout()
    {
        player.Hint3_0.gameObject.SetActive(false);
        player.Hint3.gameObject.SetActive(true);
    }
    public void GameExit()
    {
        Application.Quit();
    }
}
