using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LineaNuestra : MonoBehaviour
{
   
    //APAREZCAN LINEAS

    public GameObject lineaHorizontal;
    public GameObject lineaVertical;





    void Start()
    {
        for (int i = 0; i < 10; i++)

        {

            if (i != 9)
            {
                GameObject lineaV = Instantiate(lineaVertical, Vector3.zero, lineaVertical.transform.rotation);
                lineaV.transform.position = transform.position + new Vector3(1.05f, -.5f, 0);


                {
                    if (i != 9)


                    {
                        GameObject lineaaV = Instantiate(lineaVertical, Vector3.zero, lineaVertical.transform.rotation);
                        lineaV.transform.position = transform.position + new Vector3(1.05f, -0.5f, 0);
                        lineaV.name = "lineaV" + i;
                    }


                    GameObject lineaH = Instantiate(lineaHorizontal, Vector3.zero, lineaHorizontal.transform.rotation);
                    lineaH.transform.position = transform.position + new Vector3(0.5f, -1.05f, 0);

                    lineaH.name = "lineaH" + i;


                    transform.position += Vector3.right + new Vector3(0.1f, 0, 0);


                }
                transform.position = new Vector3(0, 0, 0);
                for (int a = 0; a < 10; a++)
                {

                    if (a != 9)
                    {
                        GameObject lineaV01 = Instantiate(lineaVertical, Vector3.zero, lineaVertical.transform.rotation);
                        lineaV01.transform.position = transform.position + new Vector3(1.05f, -1.6f, 0);
                        lineaV01.name = "lineaVa" + a;
                    }


                    GameObject lineaH01 = Instantiate(lineaHorizontal, Vector3.zero, lineaHorizontal.transform.rotation);
                    lineaH01.transform.position = transform.position + new Vector3(0.5f, -2.15f, 0);

                    lineaH01.name = "lineaHa" + a;



                    transform.position += Vector3.right + new Vector3(0.1f, 0, 0);


                }

                transform.position = new Vector3(0, 0, 0);

                for (int b = 0; b < 10; b++)
                {

                    if (b != 9)
                    {
                        GameObject lineaV02 = Instantiate(lineaVertical, Vector3.zero, lineaVertical.transform.rotation);
                        lineaV02.transform.position = transform.position + new Vector3(1.05f, -2.7f, 0);
                        lineaV02.name = "lineaVb" + b;
                    }


                    GameObject lineaH02 = Instantiate(lineaHorizontal, Vector3.zero, lineaHorizontal.transform.rotation);
                    lineaH02.transform.position = transform.position + new Vector3(0.5f, -3.25f, 0);

                    lineaH02.name = "lineaHb" + b;



                    transform.position += Vector3.right + new Vector3(0.1f, 0, 0);


                }

                transform.position = new Vector3(0, 0, 0);

                for (int c = 0; c < 10; c++)
                {

                    if (c != 9)
                    {
                        GameObject lineaV03 = Instantiate(lineaVertical, Vector3.zero, lineaVertical.transform.rotation);
                        lineaV03.transform.position = transform.position + new Vector3(1.05f, -3.8f, 0);
                        lineaV03.name = "lineaVc" + c;
                    }


                    GameObject lineaH03 = Instantiate(lineaHorizontal, Vector3.zero, lineaHorizontal.transform.rotation);
                    lineaH03.transform.position = transform.position + new Vector3(0.5f, -4.35f, 0);

                    lineaH03.name = "lineaHc" + c;



                    transform.position += Vector3.right + new Vector3(0.1f, 0, 0);


                }

                transform.position = new Vector3(0, 0, 0);

                for (int d = 0; d < 10; d++)
                {

                    if (d != 9)
                    {
                        GameObject lineaV04 = Instantiate(lineaVertical, Vector3.zero, lineaVertical.transform.rotation);
                        lineaV04.transform.position = transform.position + new Vector3(1.05f, -4.9f, 0);
                        lineaV04.name = "lineaVd" + d;
                    }


                    GameObject lineaH04 = Instantiate(lineaHorizontal, Vector3.zero, lineaHorizontal.transform.rotation);
                    lineaH04.transform.position = transform.position + new Vector3(0.5f, -5.45f, 0);

                    lineaH04.name = "lineaHd" + d;



                    transform.position += Vector3.right + new Vector3(0.1f, 0, 0);


                }

                transform.position = new Vector3(0, 0, 0);

                for (int e = 0; e < 10; e++)
                {

                    if (e != 9)
                    {
                        GameObject lineaV05 = Instantiate(lineaVertical, Vector3.zero, lineaVertical.transform.rotation);
                        lineaV05.transform.position = transform.position + new Vector3(1.05f, -6, 0);
                        lineaV05.name = "lineaVd" + e;
                    }


                    GameObject lineaH05 = Instantiate(lineaHorizontal, Vector3.zero, lineaHorizontal.transform.rotation);
                    lineaH05.transform.position = transform.position + new Vector3(0.5f, -6.55f, 0);

                    lineaH05.name = "lineaHd" + e;



                    transform.position += Vector3.right + new Vector3(0.1f, 0, 0);
                }
            }
        }
    }
}



        //Vector3 posicionVertical = Vector3.zero;
        //lineaVertical.transform.position = posicionVertical;

        //Vector3 posicionBorde=Vector3.zero;
        //posicionBorde.x = (casillasX + (casillasX * offset)) / 2;
        //posicionBorde.y = (-casillasY - (casillasY * offset)) / 2;
        //bordeTemporal.transform.position = posicionBorde;


   
     // AL CLICKEAR SE ILUMINE Y SE SELECCIONE

  