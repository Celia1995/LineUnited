using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Text;

public class Tablero : MonoBehaviour
{
    public Celda celda;
    public Linea lineaH, lineaV;
    public Material[] materialsRegions;
    float offset;
    Vector3 offsetX, offsetY;

    List<List<int>> intmap;
    List<List<Celda>> tablero;
    

    public void Start()
    {
        intmap = ReadMap("./assets/SceneFile/CatFile.txt");

        Transform goCeldas = new GameObject("Celdas").transform;
        goCeldas.parent = transform;
        Transform goLineas = new GameObject("Lineas").transform;
        goLineas.parent = transform;

        offset = 0.55f;
        offsetX = new Vector3(offset, 0, 0);
        offsetY = new Vector3(0, offset, 0);

        tablero = new List<List<Celda>>();
        // Create Board
        for (int j = 0; j < intmap.Count; j++)
        {
            tablero.Add(new List<Celda>());
            for (int i = 0; i < intmap[j].Count; i++)
            {
                Celda tempCell = Instantiate(celda, new Vector3(i + i * 0.1f, -j - j*0.1f, 0), Quaternion.identity).GetComponent<Celda>();
                tempCell.name = "Celda[" + i + "," + j + "]";
                tempCell.SetMaterial(materialsRegions[intmap[j][i]]);
                tempCell.transform.parent = goCeldas;
                if (i > 0)
                    tempCell.leftLine = tablero[j][i-1].rightLine;
                if (j > 0)
                    tempCell.topLine = tablero[j-1][i].bottomLine;
                if (i< (intmap[j].Count))
                {
                    Linea linVertical = Instantiate(lineaV, tempCell.transform.position + new Vector3(0.55f, 0, 0), Quaternion.identity);
                    tempCell.rightLine = linVertical;
                    linVertical.name = "LineaV[" + i + "," + j + "]";
                }
                if (j < (intmap.Count))
                {
                    Linea linHorizontal = Instantiate(lineaH, tempCell.transform.position + new Vector3(0, -0.55f, 0), Quaternion.identity);
                    tempCell.bottomLine = linHorizontal;
                    linHorizontal.name = "LineaH[" + i + "," + j + "]";
                }
                tablero[j].Add(tempCell);
            }
        }

        // Create board borders
        Transform cube = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
        cube.localScale = new Vector3(intmap[0].Count + (intmap[0].Count - 1) * 0.1f, .25f, 1);
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
        cube.localScale = new Vector3(intmap[0].Count + (intmap[0].Count - 1) * 0.1f, .25f, 1);
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
        cube.localScale = new Vector3(intmap[0].Count + (intmap[0].Count - 1) * 0.1f, .25f, 1);
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
        cube.localScale = new Vector3(intmap[0].Count + (intmap[0].Count - 1) * 0.1f, .25f, 1);
    }

    private List<List<int>> ReadMap(string file)
    {
        List<List<int>> tempMap = new List<List<int>>();

        using (StreamReader reader = new StreamReader(file, Encoding.ASCII))
        {
            string str;
            while ((str = reader.ReadLine()) != null)
            {
                List<int> currentLine = new List<int>();
                for (int i = 0; i < str.Length; i++)
                    currentLine.Add(Convert.ToInt32(str[i].ToString()));
                tempMap.Add(currentLine);
            }
        }
        return tempMap;
    }
}
