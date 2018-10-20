using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heatUnderWater : MonoBehaviour {
    GameObject barraCalor;
    private float timer;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider coll)
    {
        if (coll.gameObject.tag == "P1")
        {
            timer += Time.deltaTime;

            if (timer >= 10f)
            {
                barraCalor = GameObject.Find("calor");
                barraCalor.gameObject.GetComponent<Heat>().HeatDamageWater();
                timer = 0f;
            }

        }
    }
}
