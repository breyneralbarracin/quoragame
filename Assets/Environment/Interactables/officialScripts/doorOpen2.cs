/**
 * Universidad Autónoma de Occidente - 2018
 *
 * doorOpen2.
 *
 * @autor Cesar Salazar <cesar0572011@hotmail.com>
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpen2 : MonoBehaviour {


    GameObject doorL;
    GameObject doorR;   
    GameObject targetL;
    GameObject targetR;
    GameObject mid;

    AudioSource au;
    ParticleSystem  psLe;
    ParticleSystem  psRe;
    float distance1;
    float distance2;
    bool open = false;

    void Start()
    {
        psLe = GameObject.Find("SteamL2").GetComponent<ParticleSystem>();
        psRe = GameObject.Find("SteamR2").GetComponent<ParticleSystem>();
        au= gameObject.GetComponent<AudioSource>();
        doorL = GameObject.Find("DoorL2");
        doorR = GameObject.Find("DoorR2");
        targetL= GameObject.Find("refLeft2");
        targetR = GameObject.Find("refRight2");
        mid = GameObject.Find("middle2");
    }

    // Update is called once per frame
    void Update()
    { 
        if (open)
        {
            doorL.transform.position = Vector3.MoveTowards(doorL.transform.position, targetL.transform.position, 0.05f);
            doorR.transform.position = Vector3.MoveTowards(doorR.transform.position, targetR.transform.position, 0.05f);
        }
        if (open == false)
        {
            doorL.transform.position = Vector3.MoveTowards(doorL.transform.position, mid.transform.position, 0.05f);
            doorR.transform.position = Vector3.MoveTowards(doorR.transform.position, mid.transform.position, 0.05f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("P1"))
        {
            //Debug.Log("entro");
            open = true;
            var Le = psLe.emission;
            var Re = psRe.emission;
            Le.enabled = true;
            Re.enabled = true;
            psLe.Play();
            psRe.Play();
            au.Play();
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("P1"))
        {
            //Debug.Log("salio");
            open = false;
        }
    }
}
