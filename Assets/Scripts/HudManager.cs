using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HudManager : MonoBehaviour
{
    public GameObject panelPausa;
    public TextMeshProUGUI timeCounterText;

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
}
