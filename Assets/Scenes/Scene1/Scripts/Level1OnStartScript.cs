/**
 * @autor Gisler Garcés <gislersoft@hotmail.com>
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Level1OnStartScript : MonoBehaviour {

	public AudioClip sheThaInstructionsAudioClip;
	public float delayTimeInSeconds = 3;

    public Text refTextMessage;

    private Vector3 cameraPosition;
    private Quaternion cameraRotation;

    private Vector3 characterPosition;
    private Quaternion characterRotation;
    IEnumerator Start()
    {
        AudioSource audio = GetComponent<AudioSource>();

        audio.Play();

        StartCoroutine(MostrarTexto("Commander Welcome to Quora Moon.", 0.0f));
        StartCoroutine(MostrarTexto("I'am She-Tha your suit computer.", 2.0f));
        StartCoroutine(MostrarTexto("Right down in the display of your helmet, you can watch your oxigen levels.", 5.0f));
        StartCoroutine(MostrarTexto("Left top corner in the display of your helmet, you can watch your health and body temperature levels.", 10.0f));
        StartCoroutine(MostrarTexto("Right top corner in the display of your helmet, your ammo.", 15.0f));
        StartCoroutine(MostrarTexto("Be careful Commander.", 17.0f));
        StartCoroutine(MostrarTexto("Something is happening with the base.\ngathering data, please wait...", 21.0f));
        StartCoroutine(MostrarTexto("", 24.0f));


        yield return new WaitForSeconds(audio.clip.length + delayTimeInSeconds);
        audio.clip = sheThaInstructionsAudioClip;
        audio.Play();

        StartCoroutine(RotarCamara(0.0f));
        StartCoroutine(MostrarTexto("[!!! ALERT !!!] YOU MUST SHUTDOWN THE SENTINEL ROBOT.", 0.0f));
        StartCoroutine(MostrarTexto("The robot is in BASE_DEFEND_MODE.", 4.0f)); 
        StartCoroutine(MostrarTexto("Doors of the base are locked.", 6.0f));
        StartCoroutine(MostrarTexto("The switch to shutdown the robot is inside the base.", 9.0f));
        StartCoroutine(MostrarTexto("Find a way to enter into the base without being killed by the Sentinel.", 13.0f));
        StartCoroutine(MostrarTexto("Watch your oxigen and temperature levels.", 16.0f));
        StartCoroutine(MostrarTexto("", 20.0f));

        StartCoroutine(DejarDeRotarCamara(20.0f));
    }

    IEnumerator MostrarTexto (string mensaje, float delayTime) {
		yield return new WaitForSeconds(delayTime);
		refTextMessage.text = mensaje;
	}

    IEnumerator RotarCamara(float delayTime) {
        yield return new WaitForSeconds(delayTime);
        this.characterPosition = GameObject.Find("RigidBodyFPSController").GetComponent<RigidbodyFirstPersonController>().transform.position;
        this.characterRotation = GameObject.Find("RigidBodyFPSController").GetComponent<RigidbodyFirstPersonController>().transform.rotation;
        this.cameraPosition = Camera.main.transform.position;
        this.cameraRotation = Camera.main.transform.rotation;
        GameObject.Find("MainCamera").GetComponent<HeadBob>().enabled = false;
        GameObject.Find("RigidBodyFPSController").GetComponent<RigidbodyFirstPersonController>().enabled = false;
        GameObject.Find("MainCamera").GetComponent<CameraRotateAround>().enabled = true;
    }
    IEnumerator DejarDeRotarCamara(float delayTime) {
        yield return new WaitForSeconds(delayTime);

        GameObject.Find("RigidBodyFPSController").GetComponent<RigidbodyFirstPersonController>().transform.position = this.characterPosition;
        GameObject.Find("RigidBodyFPSController").GetComponent<RigidbodyFirstPersonController>().transform.rotation = this.characterRotation;
        Camera.main.transform.position = this.cameraPosition;
        Camera.main.transform.rotation = this.cameraRotation;

        GameObject.Find("MainCamera").GetComponent<CameraRotateAround>().enabled = false;
        GameObject.Find("MainCamera").GetComponent<HeadBob>().enabled = true;
        GameObject.Find("RigidBodyFPSController").GetComponent<RigidbodyFirstPersonController>().enabled = true;


    }
}
