using System;
using UnityEngine;

public class Celda : MonoBehaviour
{
    public Color Color
    {
        get { return rend.material.color; }
        set { rend.material.color = value; }
    }

    public Action<Celda> OnFilled;

    MeshRenderer rend;
    Linea _topLine, _bottomLine, _leftLine, _rightLine;
    

    public Linea topLine
    {
        get
        {
            return _topLine;
        }
        set
        {
            _topLine = value;
            _topLine.OnClicked += CheckCubeSides;
        }
    }
    public Linea bottomLine
    {
        get
        {
            return _bottomLine;
        }
        set
        {
            _bottomLine = value;
            _bottomLine.OnClicked += CheckCubeSides;
        }
    }
    public Linea leftLine
    {
        get
        {
            return _leftLine;
        }
        set
        {
            _leftLine = value;
            _leftLine.OnClicked += CheckCubeSides;
        }
    }
    public Linea rightLine
    {
        get
        {
            return _rightLine;
        }
        set
        {
            _rightLine = value;
            _rightLine.OnClicked += CheckCubeSides;
        }
    }

    private void Awake()
    {
        rend = GetComponent<MeshRenderer>();
    }

    public void SetMaterial(Material material)
    {
        rend.material = material;
    }

    public void CheckCubeSides(Linea linea)
    {
        // Poner el color del player activo
        // Arreglar esta comprobacion con el override de == de linea....
        bool check = false;
        check = topLine == null ? true : topLine.Clicked;
        Debug.Log("Top: " + check);
        check = check && (bottomLine == null ? true : bottomLine.Clicked);
        Debug.Log("Bottom: " + check);
        check = check && (leftLine == null ? true : leftLine.Clicked);
        Debug.Log("Left: " + check);
        check = check && (rightLine == null ? true : rightLine.Clicked);
        Debug.Log("Right: " + check);


        if (check) { 
            OnFilled?.Invoke(this);
        }
    }
}

