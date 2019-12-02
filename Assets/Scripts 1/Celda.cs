using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Celda : MonoBehaviour
{
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

    public void CheckCubeSides()
    {
        // Poner el color del player activo
        // Arreglar esta comprobacion con el override de == de linea....
        bool check = false;
        check = topLine == null ? true : topLine.clicked;
        Debug.Log("Top: " + check);
        check = check && (bottomLine == null ? true : bottomLine.clicked);
        Debug.Log("Bottom: " + check);
        check = check && (leftLine == null ? true : leftLine.clicked);
        Debug.Log("Left: " + check);
        check = check && (rightLine == null ? true : rightLine.clicked);
        Debug.Log("Right: " + check);


        if (check) { 
            rend.material.color = new Color(1, 0, 0);
        }
    }
}
