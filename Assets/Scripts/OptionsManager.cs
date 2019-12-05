using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class OptionsManager : MonoBehaviour
{

    public AudioMixer mixer;

    public Slider sliderVolumenGeneral;
    public TextMeshProUGUI textoGeneral;
    public Slider sliderVolumenMusica;
    public TextMeshProUGUI textoMusica;
    public Slider sliderVolumenFX;
    public TextMeshProUGUI textoFX;

    public void Start()
    {
        textoGeneral.text = textoMusica.text = textoFX.text = "10";
    }

    public void CambiarVolumenMusica()
    {
        mixer.SetFloat("volumenMusica", sliderVolumenMusica.value);
        textoMusica.text = (10+(sliderVolumenMusica.value * 0.33333f)).ToString("f0");
    }

    public void CambiarVolumenFX()
    {
        mixer.SetFloat("volumenFX", sliderVolumenFX.value);
        textoFX.text = (10 + (sliderVolumenFX.value * 0.33333f)).ToString("f0");
    }

    public void CambiarVolumenGeneral()
    {
        mixer.SetFloat("volumenMaster", sliderVolumenGeneral.value);
        textoGeneral.text = (10 + (sliderVolumenGeneral.value * 0.33333f)).ToString("f0");
    }
}
