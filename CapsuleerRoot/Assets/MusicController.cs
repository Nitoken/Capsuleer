using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioClip peace, wave, dead;
    GameController gc;
    AudioSource asorc;
    bool isWave = false;
    public bool IsWave
    {
        get
        {
            return isWave;
        }
        set
        {
            if(value != isWave)
            {
                isWave = value;
                ChangeMusic(isAlive, isWave);
            }
        }
    }
    bool isAlive = true;
    public bool IsAlive
    {
        get
        {
            return isAlive;
        }
        set
        {
            if(isAlive != value)
            {
                isAlive = value;
                ChangeMusic(isAlive, isWave);
            }
        }
    }
    void Awake()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        asorc = GetComponent<AudioSource>();
    }
    void Update()
    {
        IsAlive = gc.isAlive;
        IsWave = gc.waving;
    }

    void ChangeMusic(bool alive, bool waveing)
    {
        if(alive)
        {
            if(waveing)
            {
                StartCoroutine(Changing(wave));
            }
            else
            {
                StartCoroutine(Changing(peace));
            }
        }
        else
        {
            StartCoroutine(Changing(dead));
        }
    }
    IEnumerator Changing(AudioClip clip)
    {
        while (asorc.volume > 0)
        {
            asorc.volume -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        asorc.clip = clip;
        asorc.Play();
        while (asorc.volume < 1)
        {
            asorc.volume += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
