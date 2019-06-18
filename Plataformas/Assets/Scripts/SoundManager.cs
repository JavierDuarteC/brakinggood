using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{

[Header("Salto:")] 
    public AudioSource jumpEfx;

[Header("Ambiente:")] 
    public AudioSource playingEfx;

[Header("Quimicos:")] 
    public AudioSource plusEfx;
    [Header("Break:")] 
    public AudioSource breakEfx;
    [Header("Cocinando:")] 
    public AudioSource cookingEfx;
[Header("Ganador:")] 
    public AudioSource winEfx;

    public static SoundManager instance = null;

    // Start is called before the first frame update
    void Start()
    {
    }

    void Awake()
    {
    }


    public void playPlayingEfx(AudioClip clip)
    {
        playingEfx.clip = clip;
        playingEfx.Play();
    }
    public void stopPlayingEfx()
    {
        playingEfx.Stop();
    }
    public void playJumpEfx(AudioClip clip)
    {
        jumpEfx.clip = clip;
        jumpEfx.Play();
    }
    public void playPlusEfx(AudioClip clip)
    {
        plusEfx.clip = clip;
        plusEfx.Play();
    }
    public void playBreakEfx(AudioClip clip)
    {
        breakEfx.clip = clip;
        breakEfx.Play();
    }
    public void playCookingEfx(AudioClip clip)
    {
        cookingEfx.clip = clip;
        cookingEfx.Play();
    }
    public void playWinEfx(AudioClip clip)
    {
        winEfx.clip = clip;
        winEfx.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
