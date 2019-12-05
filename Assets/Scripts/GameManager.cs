using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{ 
    public HudManager hudManager;
    bool IsGamePaused = false;
    public bool gameStarted=false;

    public float tiempoTurno = 5f;
    float contadorTiempo;

    public Action TiempoTurnoTerminado;


    public void ResumeGame()
    {
        IsGamePaused = false;
        hudManager.SetActivePausePanel(false);
        Time.timeScale = 1f;
    }
    
    public void PauseGame()
    {
        IsGamePaused = true;
        hudManager.SetActivePausePanel(true);
        Time.timeScale = 0;
    }

    public IEnumerator ContarTurno()
    {
        while (contadorTiempo > 0) { 
            yield return new WaitForSeconds(1f);
            contadorTiempo--;
            hudManager.SetTimeCounter(contadorTiempo);
        }
        if (contadorTiempo <= 0)
        {
            SiguienteTurno();
            TiempoTurnoTerminado?.Invoke();
        }
    }

    public void SiguienteTurno()
    {
        StopAllCoroutines();
        contadorTiempo = tiempoTurno;
        hudManager.timeCounterText.text = contadorTiempo.ToString();
        StartCoroutine(ContarTurno());
    }

    public void EmpezarJuego()
    {
        gameStarted = true;
        StartCoroutine(ContarTurno());
    }

    public void Awake()
    {
        hudManager.OnCuentaAtrasTerminada += EmpezarJuego;
    }

    public void Start()
    {
        contadorTiempo = tiempoTurno;
        hudManager.anim.Play("AnimacionCuentaAtras");
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
}
 