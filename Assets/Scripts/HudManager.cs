using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudManager : MonoBehaviour
{
    public GameObject panelPausa;

    private void Start()
    {
        SetActivePausePanel(false);
    }

    public void SetActivePausePanel(bool valor)
    {
        panelPausa.SetActive(valor);
    }
}
