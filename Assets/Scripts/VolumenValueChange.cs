using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumenValueChange : MonoBehaviour
{
    public GameObject sonidoClic;

    private AudioSource audioSrc;

    private float musicVolume = 0.5f;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        audioSrc.volume = musicVolume;
    }

    public void SetMusicVolume(float vol)
    {
        musicVolume = vol;
    }

    public void SetVolume(float vol)
    {

    }

    public void SetMasterVolume(float vol)
    {

    }

    public void MostrarSonidoClick(bool value)
    {
        Instantiate(sonidoClic);
    }
}
