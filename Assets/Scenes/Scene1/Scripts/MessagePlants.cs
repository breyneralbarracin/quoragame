using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagePlants : MonoBehaviour {

    float contadorSegundos;
    public GameObject mensaje;
    
    int contador = 0;
    //int contador1 = 0;

   
    



    void OnTriggerEnter(Collider other)
    {
        //contadorSegundos += Time.deltaTime;
        if (other.gameObject.tag == "P1" && contador == 0)
        {

            Debug.Log("entra");
            mensaje.SetActive(true);
            //contador1 += 1;


        }
        Debug.Log(contadorSegundos);
    }
    void OnTriggerStay(Collider other)
    {
        contadorSegundos += Time.deltaTime;
        if (other.gameObject.tag == "P1" && contador == 1)
        {
            if (contadorSegundos >= 15 || contador == 1)
            {
                mensaje.SetActive(false);
                //contador+=1;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "P1")
        {
            
            Debug.Log("sale");
            mensaje.SetActive(false);
            //contador +=1;
        }
    }


    // debo pasarle el script al objeto que va a ser el colisionado y al gameobject, recordar en el fps controles cambair el tag a player
}
