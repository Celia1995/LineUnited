using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{ 
    public HudManager hudManager;
    public static bool IsGamePaused = false;
    public static bool IsGamestarted = false;

    public float tiempoTurno = 5f;
    float contadorTiempo;
    public Tablero tablero;

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

    public void ExitMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
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
            tablero.SetPerderTurnoJugadorActivo(true);
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
        IsGamestarted = true;
        StartCoroutine(ContarTurno());
    }

    public void Awake()
    {
        Time.timeScale = 1f;
        IsGamePaused = false;
        IsGamestarted = false;
        hudManager.OnCuentaAtrasTerminada += EmpezarJuego;
        hudManager.OnJuegoTerminado += PararTodo;
        hudManager.OnResumeGameButton += ResumeGame;
        hudManager.OnMainMenuButton += ExitMainMenu;
        hudManager.OnGoBackToPlay += ResumeGame;
    }

    public void PararTodo()
    {
        StopAllCoroutines();
    }

    public void Start()
    {
        contadorTiempo = tiempoTurno;
        hudManager.anim.Play("AnimacionCuentaAtras");   
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
        hudManager.OnCuentaAtrasTerminada -= EmpezarJuego;
        hudManager.OnJuegoTerminado -= PararTodo;
        hudManager.OnResumeGameButton -= ResumeGame;
        hudManager.OnMainMenuButton -= ExitMainMenu;
        hudManager.OnGoBackToPlay -= ResumeGame;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsGamePaused)
            {
                hudManager.GoBack();
            }
            else
            {
                PauseGame();
            }
        }
    }
}
 