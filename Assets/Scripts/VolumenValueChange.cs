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

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }

    public void MostrarSonidoClick(bool value)
    {
        Instantiate(sonidoClic);
    }
}
