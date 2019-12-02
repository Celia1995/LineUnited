using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableroNuestro : MonoBehaviour
{
   
    public GameObject borde;
    public GameObject casilla;
    Vector3 posicionInicial;
    Vector3 tamañoBorde;
    float offset;
    int casillasX, casillasY;

    // Start is called before the first frame update
    void Start()
    {
        posicionInicial = new Vector3(0.5f, -0.5f, 0);
        casillasX = 10;
        casillasY = 10;
        offset = 0.1f;

        GameObject bordeTemporal;

        // MurO EnterO
        bordeTemporal = Instantiate(borde, Vector3.zero, Quaternion.identity);
        Vector3 posicionBorde=Vector3.zero;
        posicionBorde.x = (casillasX + (casillasX * offset))/2;
        posicionBorde.y = (-casillasY - (casillasY * offset)) /2;
        bordeTemporal.transform.position = posicionBorde;
        bordeTemporal.transform.localScale = new Vector3(casillasX + casillasX * offset + .5f, casillasY + casillasY * offset + .5f, .2f);
       //()
                //=2.5f                                 //=2.5f         //0.2f          Z


        //float longitudTablero = casillasX + (casillasX * offset);
        //bordeTemporal.transform.position = posicionInicial + new Vector3(((casillasX+(casillasX*offset)-offset)/2)-.5f, +.5f+.1f, 0);
        //bordeTemporal.transform.localScale = new Vector3(11, .2f, 1);


        for (int j = 0; j < casillasY; j++)
        {
            for (int i = 0; i < casillasX; i++)
            {
                GameObject casillaTemporal = Instantiate(casilla, 
                    posicionInicial + new Vector3(i+i*offset, -j-j*offset, 0), Quaternion.identity);
                casillaTemporal.name = "Casilla["+i+","+j+"]";
                casillaTemporal.transform.parent = transform; 
            }
        }
         
        //posicionInicial = Vector3.zero;
        //Instantiate(casilla, posicionInicial, Quaternion.identity);
        //posicionInicial += Vector3.right;
        //Instantiate(casilla, posicionInicial, Quaternion.identity);
        //posicionInicial += Vector3.right;
        //Instantiate(casilla, posicionInicial, Quaternion.identity);
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
