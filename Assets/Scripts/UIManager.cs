using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject botonJugar;
    public GameObject botonTitulo;
    public GameObject botonMenuPrincipal;
    public GameObject segundaPantalla;
    public GameObject botonDosJugadores;
    public GameObject botonTresJugadores;
    public GameObject botonCuatroJugadores;
    public GameObject botonOpciones;
    public GameObject botonVolver;
    public GameObject botonesSalir;
    public GameObject botonNo;
    public GameObject panelOpciones;


    public void MostrarBotonTitulo(bool value)
    {
        botonTitulo.SetActive(value);
    }

    public void MostrarBotonJugar(bool value)
    {
        botonJugar.SetActive(value);
    }

    public void MostrarBotonDosJugadores(bool value)
    {
        botonDosJugadores.SetActive(value);
    }

    public void MostrarBotonTresJugadores(bool value)
    {
        botonTresJugadores.SetActive(value);
    }

    public void MostrarBotonCuatroJugadores(bool value)
    {
        botonCuatroJugadores.SetActive(value);
    }

    public void MostrarBotonOpciones(bool value)
    {
        botonOpciones.SetActive(value);
    }

    public void MostrarBotonVolver(bool value)
    {
        botonVolver.SetActive(value);
    }

    public void MostrarBotonSalir(bool value)
    {
        botonesSalir.SetActive(value);
    }

    public void MostrarBotonNo(bool value)
    {
        botonNo.SetActive(value);
    }

    public void MostrarBotonPanelOpciones(bool value)
    {
        panelOpciones.SetActive(value);
    }

    public void MostrarBotonMenuPrincipal(bool value)
    {
        MostrarBotonJugar(!value);
        botonMenuPrincipal.SetActive(value);
    }

    public void MostrarOpciones(bool value)
    {
        MostrarBotonMenuPrincipal(!value);
        MostrarBotonJugar(!value);
        MostrarBotonTitulo(!value);
        panelOpciones.SetActive(value);
    }

    public void MostrarSegundaPantalla(bool value)
    {
        MostrarBotonMenuPrincipal(!value);
        MostrarBotonTitulo(!value);
        MostrarBotonJugar(!value);
        segundaPantalla.SetActive(value);
    }

    public void MostrarVolverBotonMenuPrincipal(bool value)
    {
        MostrarSegundaPantalla(!value);
        MostrarBotonJugar(!value);
        MostrarBotonSalir(!value);
        MostrarBotonPanelOpciones(!value);
        botonMenuPrincipal.SetActive(value);
    }

    public void MostrarPreguntaSalir(bool value)
    {
        MostrarBotonMenuPrincipal(!value);
        MostrarBotonJugar(!value);
        botonesSalir.SetActive(value);
    }

}
