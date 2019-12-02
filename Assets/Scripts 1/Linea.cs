using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Linea : MonoBehaviour
{
    public Action OnClicked;
    MeshRenderer rend;
    public bool clicked = false;

    private void Awake()
    {
        rend = GetComponent<MeshRenderer>();
    }

    private void OnMouseOver()
    {
        if (!clicked)
            rend.material.color = new Color(0.5f, 0, 0);
    }

    private void OnMouseDown()
    {
        if (!clicked) {
            clicked = true;
            rend.material.color = new Color(1f, 0, 0);
            OnClicked?.Invoke();
        }
    }

    private void OnMouseExit() {
        if (!clicked)
            rend.material.color = new Color(1, 1,1);
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