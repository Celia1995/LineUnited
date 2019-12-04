using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumenValueChange : MonoBehaviour
{
    private AudioSource musicSource;
    private AudioSource soundSource;

    private float musicVolume = 0.5f;
    private float sonidoVolume = 1f;
    private float masterVolume = 1f;

    void Start()
    {
        AudioSource[] sources = GetComponents<AudioSource>();
        musicSource = sources[0];
        soundSource = sources[1];
    }

    void Update()
    {
        musicSource.volume = musicVolume * masterVolume;
        soundSource.volume = sonidoVolume * masterVolume;
    }

    public void SetMusicVolume(float vol)
    {
        musicVolume = vol;
    }

    public void SetVolume(float vol)
    {
        sonidoVolume = vol;
    }

    public void SetMasterVolume(float vol)
    {
        masterVolume = vol;
    }

    public void MostrarSonidoClick(bool value)
    {
    }

    public void ReproducirSonido(AudioClip clip)
    {
        soundSource.PlayOneShot(clip);
    }
}
