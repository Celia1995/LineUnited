using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionNivel : MonoBehaviour
{

    public void NumeroJugadores(int i)
    {
        PlayerPrefs.SetInt("Jugadores", i);
    }
}
