using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Linea : MonoBehaviour
{
    public Action<Linea> OnOver;
    public Action<Linea> OnClicked;

    public Color Color
    {
        get { return rend.material.color; }
        set { rend.material.color = value; }
    }

    public bool Clicked { get; private set; }

    private Renderer rend;
    private Color colorNativo;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        colorNativo = Color;
    }

    private void OnMouseOver()
    {
        if (!Clicked && GameManager.IsGamestarted && !GameManager.IsGamePaused)
            OnOver?.Invoke(this);
    }

    private void OnMouseDown()
    {
        if (!Clicked && GameManager.IsGamestarted && !GameManager.IsGamePaused)
        {
            Clicked = true;
            OnClicked?.Invoke(this);            
        }
    }

    private void OnMouseExit()
    {
        if (!Clicked && GameManager.IsGamestarted && !GameManager.IsGamePaused)
            rend.material.color = colorNativo;
    }

    //public static bool operator ==(Linea obj1, Linea obj2)
    //{
    //    return ((obj1.clicked  == obj2.clicked) || (obj1 == null && obj2.clicked) || (obj1.clicked && obj2 == null));
    //}

    //public static bool operator !=(Linea obj1, Linea obj2)
    //{
    //    return ((obj1.clicked != obj2.clicked) || (obj1 == null && !obj2.clicked)  || (!obj1.clicked && obj2 == null));
    //}
}