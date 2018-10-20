using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarCalor : MonoBehaviour
{

    public PlayerController calor;
    public float tiempo = 0;
    public float tiempoEspera = 4;
    public float valorRecuperar = 2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "P1")
        {
            calor.increaseHeat(valorRecuperar);
            print("Generando calor");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "P1")
        {
            tiempo += Time.deltaTime;

            if (tiempo >= tiempoEspera)
            {
                calor.increaseHeat(valorRecuperar);
                print("Generando calor");
                tiempo = 0;
            }
        }
    }
}
