using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool stage2;
    public bool stage1_1;
    public bool stage1_2;
    public bool stage1_3;
    public int stage = 1;
    public GameObject Hint2_0;
    public GameObject Hint3_0;
    public GameObject Hint1;
    public GameObject Hint2;
    public GameObject Hint3;
    public UI ui;
    public Save save;
    public bool left;
    public bool right;
    public AudioClip[] clip;
    public AudioClip[] Back;
    Vector3 first;
    void Start()
    {
        save.GameLoad();
        first = gameObject.transform.position;
        SoundManager.instace.BgSoundPlay(Back[0]);
    }
    public void updateBackSound()
    {
        SoundManager.instace.BgSoundPlay(Back[1]);
    }
    private void Update()
    {
        if (stage == 1 && stage1_1 && stage1_2 && stage1_3) Stage1Clear();
        if (stage2) Stage2Clear();

        float difference = first.x - gameObject.transform.position.x;
        if (difference > 2 || difference < -2f)
        {
            //SoundManager.instace.SFXPlay("Melee",clip[1]);
            first = gameObject.transform.position;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Clear")
        {
            ui.GameClear();
        }
    }
    public void Stage1Clear()
    {
        stage++;
        Hint2_0.gameObject.SetActive(true);
    }
    public void Stage2Clear()
    {
        stage2 = false;
        stage = 3;
        Hint3_0.gameObject.SetActive(true);
    }
}
