using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unlock : MonoBehaviour {
    public BoxCollider door;
    public BoxCollider door2;
    public Shooting shooting;
    public Light ligh;
    public Text refTextMessage;

    bool onswitch=false;
    bool open = false;
    bool shoot = true;
	// Use this for initialization
	void Start () {
        door = GameObject.Find("doorTrigger").GetComponent<BoxCollider>();
        door2 = GameObject.Find("doorTrigger2").GetComponent<BoxCollider>();
        shooting = GameObject.Find("SentinelHead").GetComponent<Shooting>();
        ligh = GameObject.Find("PointLightSwitch").GetComponent<Light>();
        door.enabled = false;
        door2.enabled = false;
        shooting.enabled = true;

    }
	
	// Update is called once per frame
	void Update () {
        if (onswitch) {

            if (Input.GetKeyDown(KeyCode.E)) {
                open = true;
                shoot = false;
                door.enabled=open;
                door2.enabled = open;
                shooting.enabled = shoot;
                ligh.color = new Color(37, 240, 30, 255);
                ligh.intensity = 0.01f;
                StartCoroutine(MostrarTexto("Sentinel has been deactivated", 0.0f));
                StartCoroutine(MostrarTexto("Doors have been enabled", 2.0f));
                StartCoroutine(MostrarTexto("", 7.0f));
            }
            
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("P1")) {
            onswitch = true;
            Debug.Log("entro");
        }
    }
    private void OnTriggerExit(Collider other){
        if (other.CompareTag("P1")) {
            onswitch = false;
        }
    }

    IEnumerator MostrarTexto(string mensaje, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        refTextMessage.text = mensaje;
    }
}
