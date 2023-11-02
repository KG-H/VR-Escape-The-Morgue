using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    GameObject player;
    public AudioSource bgSound;
    public static SoundManager instace;
    public float Effectvolume = 0.5f;
    private void Start()
    {
        player = GameObject.Find("Player");
        Effectvolume = 0.5f;
    }
    private void Awake()
    {
        if (instace == null)
        {
            instace = this;
            DontDestroyOnLoad(instace);
        }
        else Destroy(gameObject);
    }

    public void SFXPlay(string sfxName, AudioClip clip)
    {
        GameObject go = new GameObject(sfxName + "Sound");
        AudioSource audioSource = go.AddComponent<AudioSource>();
        audioSource.volume = Effectvolume;
        audioSource.clip = clip;
        audioSource.Play();

        Destroy(go, clip.length);
    }
    public void BgSoundPlay(AudioClip clip)
    {
        bgSound.clip = clip;
        bgSound.loop = true;
        bgSound.volume = 0.5f;
        bgSound.Play();
    }
    public void BgSoundStop(AudioClip clip)
    {
        bgSound.Stop();
    }
    public void SetBgVolume(float volum)
    {
        bgSound.volume = volum;
    }
    public void EffectVolume(float volume)
    {
        Effectvolume = volume;
    }
}