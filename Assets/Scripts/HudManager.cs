using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HudManager : MonoBehaviour
{
    public GameObject panelPausa;
    public TextMeshProUGUI timeCounterText;
    public GameObject botonContinuar;

    private void Start()
    {
        SetActivePausePanel(false);
    }

    public void SetActivePausePanel(bool valor)
    {
        panelPausa.SetActive(valor);
    }

    public void SetTimeCounter(float newTime)
    {
        timeCounterText.text = newTime.ToString("f0");
    }

    public void MostrarBotonContinuar(bool value)
    {
        SetActivePausePanel(!value);
        botonContinuar.SetActive(value);
    }
}
