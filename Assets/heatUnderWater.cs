using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heatUnderWater : MonoBehaviour {
   
    public PlayerController calor;
    
    private float timer;
    public float tiempoEspera = 10;
    public float valorAReducir = 4;

    void OnTriggerStay(Collider coll)
    {
        if (coll.gameObject.tag == "P1")
        {
            timer += Time.deltaTime;

            if (timer >= tiempoEspera)
            {
               // barraCalor = GameObject.Find("calor");
               // barraCalor.gameObject.GetComponent<Heat>().HeatDamageWater();
                calor.reduceHeat(valorAReducir);
                timer = 0f;
            }

        }
    }
}
