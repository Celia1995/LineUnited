using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Linea : MonoBehaviour
{
    //SI TIENE UN COLLIDER QUE APAREZCA CON INVOKE

    // bool si esta false, lo activamos su mesh renderer.

    //GameObject line;

    //ejercicio de crear dos lineas formando una L al reves

    public GameObject lineaHorizontal;
    public GameObject lineaVertical;



    void Start()
    {
        for (int i = 0; i < 10; i++) {
            if (i != 9) { 
                GameObject lineaV = Instantiate(lineaVertical, Vector3.zero, lineaVertical.transform.rotation);
                lineaV.transform.position = transform.position + new Vector3(0.55f, 0, 0);
                lineaV.name = "lineaV" + i;
            }

            GameObject lineaH = Instantiate(lineaHorizontal, Vector3.zero, lineaHorizontal.transform.rotation);
            lineaH.transform.position = transform.position + new Vector3(0, -0.55f, 0);

            lineaH.name = "lineaH" + i;

            transform.position += Vector3.right+new Vector3(0.1f,0,0);
        }


        //Vector3 posicionVertical = Vector3.zero;
        //lineaVertical.transform.position = posicionVertical;

        //Vector3 posicionBorde=Vector3.zero;
        //posicionBorde.x = (casillasX + (casillasX * offset)) / 2;
        //posicionBorde.y = (-casillasY - (casillasY * offset)) / 2;
        //bordeTemporal.transform.position = posicionBorde;


    }


    //bordeTemporal = Instantiate(borde, Vector3.zero, Quaternion.identity);





    /* Renderer r;
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
     }*/
}
