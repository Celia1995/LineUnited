using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public GameObject panelPausa;

    public void SetActivePausePanel(bool valor)
    {
        panelPausa.SetActive(valor);
    }
}
