using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HudManager : MonoBehaviour
{
    public GameObject panelPausa;
    public TextMeshProUGUI timeCounterText;
    public GameObject botonContinuar;
    public GameObject botonVolver;
    public GameObject botonOpciones;
    public GameObject panelOpciones;
    public TMP_Text[] puntuaciones;
    public Image[] avatares;
    public TMP_Text textoVictoria;
    public GameObject PanelTextoVictoria;

    public Animator anim;
    public TextMeshProUGUI textoTimer;
    int timer = 3;
    public Action OnCuentaAtrasTerminada;
    public Action OnJuegoTerminado;

    public Action OnResumeGameButton;
    public Action OnMainMenuButton;
    public Action OnGoBackToPlay;

    public void CuentaAtras()
    {
        timer--;
        if (timer > 0)
            textoTimer.text = timer.ToString();
        else { 
            textoTimer.text = "GO!";
        }
    }

    public void TerminarCuentaAtras()
    {
        OnCuentaAtrasTerminada?.Invoke();
    }

    public void ConfigurarAvatares(Color[] jugadores)
    {
        for (int i = 0; i < avatares.Length; i++)
            avatares[i].color = jugadores[i];
    }


    public void SetActivePausePanel(bool value)
    {
        panelPausa.SetActive(value);
    }

    public void SetActiveOptionsPanel(bool value)
    {
        panelOpciones.SetActive(value);
    }

    public void ResumeGame()
    {
        OnResumeGameButton?.Invoke();
    }

    public void GoMainMenu()
    {
        OnMainMenuButton?.Invoke();
    }


    public void GoBack()
    {
        if (panelPausa.activeSelf)
        {
            OnGoBackToPlay?.Invoke();
        } else if (panelOpciones.activeSelf)
        {
            panelOpciones.SetActive(false);
            panelPausa.SetActive(true);
        }
    }

    //public void SetActivePausePanel(bool value)
    //{
    //    panelPausa.SetActive(value);
    //}

    public void SetTimeCounter(float newTime)
    {
        timeCounterText.text = newTime.ToString("f0");
    }

    //public void MostrarBotonOpciones(bool value)
    //{
    //    botonOpciones.SetActive(value);
    //}

    //public void MostrarPanelOpciones(bool value)
    //{
    //    panelOpciones.SetActive(value);

    //}

    //public void MostrarBotonVolver(bool value)
    //{
    //    botonVolver.SetActive(value);
    //}

    //public void AparecerPanelOpciones(bool value)
    //{
    //    SetActivePausePanel(!value);
    //    panelOpciones.SetActive(value);
    //}

    //public void AparecerPausepanel(bool value)
    //{
    //    MostrarPanelOpciones(!value);
    //    panelPausa.SetActive(value);
    //}

    public void EscribirPuntuacion(int equipo, int puntos)
    {
        puntuaciones[equipo].text = puntos.ToString("f0");
    }

    public void TextoVictoria(int jugador, Color color)
    {
        PanelTextoVictoria.SetActive(true);
        textoVictoria.text = "Jugador " + jugador.ToString();
        textoVictoria.color = color;
        OnJuegoTerminado?.Invoke();
    }
}
