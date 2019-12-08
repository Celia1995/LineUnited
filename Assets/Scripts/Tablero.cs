﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Text;
using TMPro;

public class Tablero : MonoBehaviour
{
    public TextAsset fichero;
    public Celda celda;
    public Linea lineaH, lineaV;
    public Material[] materialsRegions;
    public float tamCelda = 1F;
    public float tamLinea = .1f;
    public float anchoBorde = .25f;
    public int blackCells = 0;
    public AudioClip lineaClickClip;
    public AudioClip celdaFillClip;
    public Color colorFondo = new Color(0.2f, 0.2f, 0.2f);
    public ParticleSystem particulas;
    public int jugadoresActivos;
    public Color[] jugadores = new Color[] { Color.red, Color.green, Color.blue, Color.yellow };
    public bool[] perderTurnoJugador = new bool[] {false,false,false,false};
    public TMP_Text[] nombresJugadores;
    public GameObject[] panelesJugadores;

    AudioSource audioSource;

    List<List<int>> intmap;
    List<List<Celda>> tablero;

    public Vector2 Tamanyo { get; private set; }

    public int Turno { get; private set; }

    public int[] Puntuaciones { get; private set; }

    private int celdasActivas = 0;

    private Celda ultimaCelda;

    public bool JuegoTerminado { get; private set; }

    public GameManager gameManager;
    public HudManager hud;

    public void Awake()
    {
        gameManager.TiempoTurnoTerminado += SiguienteTurno;
        jugadoresActivos = PlayerPrefs.GetInt("Jugadores");
        if (jugadoresActivos < 2)
            jugadoresActivos = 2;
        if (jugadoresActivos > 4)
            jugadoresActivos = 4;

        for (int i=2; i < jugadoresActivos; i++)
        {
            panelesJugadores[i].SetActive(true);
        }

        Puntuaciones = new int[jugadoresActivos];

        transform.position = Vector3.zero;  

        intmap = ReadMap(fichero);

        int filas = intmap.Count;
        int columnas = 0;

        Transform goCeldas = new GameObject("Celdas").transform;
        goCeldas.parent = transform;
        Transform goLineas = new GameObject("Lineas").transform;
        goLineas.parent = transform;
        Transform goBordes = new GameObject("Bordes").transform;
        goBordes.parent = transform;

        tablero = new List<List<Celda>>();
        // Create Board
        for (int j = 0; j < intmap.Count; j++)
        {
            if (intmap[j].Count > columnas)
                columnas = intmap[j].Count;

            tablero.Add(new List<Celda>());
            for (int i = 0; i < intmap[j].Count; i++)
            {
                Celda tempCell = Instantiate(celda, new Vector3(i * tamCelda + i * tamLinea, -j * tamCelda - j* tamLinea, 0F), Quaternion.identity);
                tempCell.name = "Celda[" + j + "," + i + "]";
                tempCell.SetMaterial(materialsRegions[intmap[j][i]]);
                tempCell.transform.SetParent(goCeldas);
                tempCell.OnFilled += OnCeldaFilled;

                if (i > 0 && tablero[j][i - 1].rightLine)
                    tempCell.leftLine = tablero[j][i - 1].rightLine;

                if (j > 0 && tablero[j - 1][i].bottomLine)
                    tempCell.topLine = tablero[j - 1][i].bottomLine;

                if (i < intmap[j].Count - 1 && intmap[j][i] > blackCells && intmap[j][i+1] > blackCells) 
                {
                    Linea linVertical = Instantiate(lineaV, tempCell.transform.position + Vector3.right * (tamCelda * 0.5f + tamLinea * 0.5f), Quaternion.identity);
                    tempCell.rightLine = linVertical;
                    linVertical.name = "LineaV[" + j + "," + i + "]";
                    linVertical.transform.rotation = Quaternion.Euler(90F, 0F, 0F);
                    linVertical.transform.SetParent(goLineas);
                    linVertical.OnOver += OnLineaOver;
                    linVertical.OnClicked += OnLineaClick;
                }

                if (j < intmap.Count - 1 && intmap[j][i] > blackCells && intmap[j+1][i] > blackCells) 
                {
                    Linea linHorizontal = Instantiate(lineaH, tempCell.transform.position + Vector3.down * (tamCelda * 0.5f + tamLinea * 0.5f), Quaternion.identity);
                    tempCell.bottomLine = linHorizontal;
                    linHorizontal.name = "LineaH[" + j + "," + i + "]";
                    linHorizontal.transform.SetParent(goLineas);
                    linHorizontal.OnOver += OnLineaOver;
                    linHorizontal.OnClicked += OnLineaClick;
                }

                if (intmap[j][i] > blackCells)
                    celdasActivas++;
                
                tablero[j].Add(tempCell);
            }
        }        

        float ancho = columnas * tamCelda + (columnas - 1F) * tamLinea;
        float alto = filas * tamCelda + (filas - 1) * tamLinea;

        Tamanyo = new Vector2(ancho, alto);

        // Create board borders
        //Borde izquierdo
        Transform cube = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
        cube.name = "Left";
        cube.GetComponent<Renderer>().material.color = Color.black;
        cube.localScale = new Vector3(anchoBorde, alto + anchoBorde * 2F, 1F);
        cube.transform.position = new Vector3(-tamCelda *0.5f - anchoBorde * 0.5f, tamCelda * 0.5f - alto * 0.5f, 0F);
        cube.SetParent(goBordes);
        
        //Borde Arriba
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
        cube.name = "Top";
        cube.GetComponent<Renderer>().material.color = Color.black;
        cube.localScale = new Vector3(ancho + anchoBorde * 2F, anchoBorde, 1F);
        cube.transform.position = new Vector3(-tamCelda * 0.5f + ancho * 0.5f, tamCelda * 0.5f + anchoBorde * 0.5f, 0F);
        cube.SetParent(goBordes);

        //Borde derecha
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
        cube.name = "Right";
        cube.GetComponent<Renderer>().material.color = Color.black;
        cube.localScale = new Vector3(anchoBorde, alto + anchoBorde * 2F, 1F);
        cube.transform.position = new Vector3(-tamCelda * 0.5f + ancho + anchoBorde * 0.5f, tamCelda * 0.5f - alto * 0.5f, 0F);
        cube.SetParent(goBordes);

        //Borde Abajo
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
        cube.name = "Bottom";
        cube.GetComponent<Renderer>().material.color = Color.black;
        cube.localScale = new Vector3(ancho + anchoBorde * 2F, anchoBorde, 1F);
        cube.transform.position = new Vector3(-tamCelda * 0.5f + ancho * 0.5f, tamCelda * 0.5f - alto - anchoBorde * 0.5f, 0F);
        cube.SetParent(goBordes);

        cube = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
        cube.name = "Background";
        cube.GetComponent<Renderer>().material.color = colorFondo;
        cube.localScale = new Vector3(ancho, alto, 1F);
        cube.transform.position = new Vector3(-tamCelda * 0.5f +ancho * 0.5f, tamCelda * 0.5f -alto * 0.5f, 1F);

        audioSource = GetComponent<AudioSource>();
        nombresJugadores[0].color = jugadores[Turno];
    }

    private void OnLineaOver(Linea linea)
    {
        if (!JuegoTerminado && GameManager.IsGamestarted && Time.timeScale > 0f)
            linea.Color = jugadores[Turno];
    }

    private void OnLineaClick(Linea linea)
    {
        if (!JuegoTerminado && GameManager.IsGamestarted && Time.timeScale > 0f)
        {
            linea.Color = jugadores[Turno];
            audioSource.PlayOneShot(lineaClickClip);
            StartCoroutine(RevisarTurno());
        }
    }

    private IEnumerator RevisarTurno()
    {
        yield return new WaitForEndOfFrame();

        int ganador = 0;
        for (int i = 1; i < Puntuaciones.Length; i++)
        {
            if (Puntuaciones[i] > Puntuaciones[ganador])
                ganador = i;
        }

        bool rival = false;
        for (int i = 0; i < Puntuaciones.Length; i++)
        {
            if (i != ganador && Puntuaciones[i] + celdasActivas > Puntuaciones[ganador])
            {
                rival = true;
                break;
            }
        }

        if (!rival)
            GameOver(ganador, jugadores[ganador]);
        else
            SiguienteTurno();
    }

    private void OnCeldaFilled(Celda celda)
    {
        if (!JuegoTerminado)
        {
            Puntuaciones[Turno]++;
            celdasActivas--;
            celda.Color = jugadores[Turno];
            audioSource.PlayOneShot(celdaFillClip);
            hud.puntuaciones[Turno].text = Puntuaciones[Turno].ToString();
            gameManager.SiguienteTurno();
            if (ultimaCelda != null)
            {
                ParticleSystem tempParticle = Instantiate(particulas, ultimaCelda.transform.position, Quaternion.identity);
                tempParticle.gameObject.SetActive(true);
                //Crear particula en ultimaCelda.trasform.position

                //Crear particula en celda.transform.position
            }
            ultimaCelda = celda;
        }
    }

    public void SetPerderTurnoJugadorActivo(bool value)
    {
        perderTurnoJugador[Turno] = value;
    }

    private void SiguienteTurno()
    {
        if (ultimaCelda == null) {
            
            nombresJugadores[Turno].color = Color.white;
            Turno = (Turno + 1) % jugadoresActivos;
            if (perderTurnoJugador[Turno] == false)
            {
                nombresJugadores[Turno].color = jugadores[Turno];
                gameManager.SiguienteTurno();
            }
            else
            {
                perderTurnoJugador[Turno] = false;
                SiguienteTurno();
            }
        }

        ultimaCelda = null;
    }

    private void GameOver(int jugador, Color color)
    {
        JuegoTerminado = true;
        print("Jugador " + (jugador + 1).ToString() + " ha ganado.");
        hud.TextoVictoria(jugador + 1, jugadores[jugador]);
    }

    private List<List<int>> ReadMap(TextAsset file)
    {
        List<List<int>> tempMap = new List<List<int>>();

        string[] lines = file.text.Split('\n');
        for (int l = 0; l < lines.Length; l++)
        {
            string line = lines[l].Trim();
            List<int> currentLine = new List<int>();
            for (int c = 0; c < line.Length; c++)
                currentLine.Add(Convert.ToInt32(line[c].ToString()));
            tempMap.Add(currentLine);
        }

        return tempMap;
    }
}