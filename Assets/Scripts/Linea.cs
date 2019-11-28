using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linea : MonoBehaviour
{
    //SI TIENE UN COLLIDER QUE APAREZCA CON INVOKE

    // bool si esta false, lo activamos su mesh renderer.

    //GameObject line;
    Renderer r;
    bool clickeada;

    public void Awake()
    {
        r = GetComponent<Renderer>();
    }

    private void OnMouseDown()
    { 
        clickeada = true;
    }

    private void OnMouseOver()
    {
        r.enabled = true;
    }

    private void OnMouseExit()
    {
        if (clickeada == false) 
            r.enabled = false;
    }
}
