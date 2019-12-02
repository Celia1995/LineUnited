using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Drawing;
using System;
using System.Text;

public class ReadFile : MonoBehaviour {

    List<List<int>> intMap;
    public GameObject imagen;

    public void Start()
    {
        ReadMap("./assets/SceneFile/CatFile.txt");
        for (int j = 0; j< intMap.Count; j++)
        {
            for (int i = 0; i < intMap[j].Count; i++)
            {
                SpriteRenderer img =  Instantiate(imagen, new Vector3(i, -j, 0), Quaternion.identity).GetComponent<SpriteRenderer>();
                img.name = "Celda[" + i + "," + j + "]";
                switch (intMap[j][i])
                {
                    case 0:
                        img.color = new UnityEngine.Color(0, 0, 0);
                        break;
                    case 1:
                        img.color = new UnityEngine.Color(.25f, .25f, .25f);
                        break;
                    case 2:
                        img.color = new UnityEngine.Color(.50f, .50f, .50f);
                        break;
                    default:
                        img.color = new UnityEngine.Color(.75f, .75f, .75f);
                        break;
                }
            }
        }
    }

    public void ReadMap(string file)
    {
        intMap = new List<List<int>>();

        using (StreamReader reader = new StreamReader(file, Encoding.ASCII))
        {
            string str;
            while ((str = reader.ReadLine()) != null)
            {
                List<int> currentLine = new List<int>();
                for (int i = 0; i < str.Length; i++) {
                    currentLine.Add(Convert.ToInt32(str[i].ToString()));
                    
                }

                intMap.Add(currentLine);
            }
        }
    }
}
