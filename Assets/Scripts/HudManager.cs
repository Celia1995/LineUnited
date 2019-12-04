using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HudManager : MonoBehaviour
{
    public GameObject panelPausa;
    public TextMeshProUGUI timeCounterText;
    public GameObject botonContinuar;
    public GameObject botonVolver;
    public GameObject botonOpciones;
    public GameObject panelOpciones;
    public TMP_Text[] puntuaciones;

    private void Start()
    {
        SetActivePausePanel(false);
    }

    public void SetActivePausePanel(bool value)
    {
        panelPausa.SetActive(value);
    }

    public void SetTimeCounter(float newTime)
    {
        timeCounterText.text = newTime.ToString("f0");
    }

    public void MostrarBotonOpciones(bool value)
    {
       botonOpciones.SetActive(value);
    }

    public void MostrarPanelOpciones(bool value)
    {
        panelOpciones.SetActive(value);
    }

    public void MostrarBotonVolver(bool value)
    {
        botonVolver.SetActive(value);
    }

    public void AparecerPanelOpcioens(bool value)
    {
        SetActivePausePanel(!value);
        panelOpciones.SetActive(value);
    }

    public void AparecerPausepanel(bool value)
    {
        MostrarPanelOpciones(!value);
        panelPausa.SetActive(value);
    }

    public void EscribirPuntuacion(int equipo, int puntos)
    {
        puntuaciones[equipo].text = puntos.ToString("f0");
    }

    public void Salir()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
