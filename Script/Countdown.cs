using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Countdown : MonoBehaviour
{
    public bool ClearGame;
    public Transform StartPos;
    public Transform mapStartPos;
    public GameObject StartFloor;
    bool endGame;
    public GameObject Map;
    public GameObject StartUI;
    public Player player;
    public Image Panel;
    float time = 0f;
    float F_time = 1f;
    public bool gostart;
    public UI ui;
    public bool gameout;
    public GameObject gameover;
    public GameObject count;
    public float setTime;
    public Text countdownText;
    public float RealTime;

    void Update()
    {
        if(gostart) goCount();
    }
    public void goCount()
    {
        if (setTime > 0) setTime -= Time.deltaTime;
        else if (setTime <= 0 && !endGame)
        {
            SoundManager.instace.SFXPlay("Melee", player.clip[3]);
            endGame = true;
            gameover.gameObject.SetActive(true);
            gameout = true;
            StartCoroutine(goLobi());
        }

        countdownText.text = "남은시간 : " + Mathf.Round(setTime).ToString() + "초";
    }
    IEnumerator goLobi()
    {
        yield return new WaitForSeconds(4f);
        Panel.gameObject.SetActive(true);
        time = 0f;
        Color alpha = Panel.color;
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }
        gameover.gameObject.SetActive(false);
        count.gameObject.SetActive(false);
        time = 0f;
        SoundManager.instace.bgSound.Stop();
        yield return new WaitForSeconds(2f);
        //Map.gameObject.SetActive(false);
        player.gameObject.transform.position = StartPos.position;
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            Panel.color = alpha;
            yield return null;
        }
        SoundManager.instace.BgSoundPlay(player.Back[0]);
        Panel.gameObject.SetActive(false);
        yield return null;
    }
    public void ClearG()
    {
        ClearGame = true;
        ui.ClearText.gameObject.SetActive(true);
        countdownText.gameObject.SetActive(false);
        int myInt = Mathf.RoundToInt(setTime);
        ui.PlayTime.text = "플레이 시간 : " + (200 - myInt).ToString() + "초";
    }
}
