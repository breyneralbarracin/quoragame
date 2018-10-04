/**
 * @autor Gisler Garcés <gislersoft@hotmail.com>
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioOnStartScript : MonoBehaviour {

	public AudioClip clip2;
	public float delayTimeClip2 = 100;

    public Text refTextMessage;
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


        yield return new WaitForSeconds(audio.clip.length + delayTimeClip2);
        audio.clip = clip2;
        audio.Play();

        StartCoroutine(MostrarTexto("[!!! ALERT !!!] YOU MUST SHUTDOWN THE SENTINEL ROBOT.", 0.0f));
        StartCoroutine(MostrarTexto("The robot is in BASE_DEFEND_MODE.", 4.0f)); 
        StartCoroutine(MostrarTexto("Doors of the base are locked.", 6.0f));
        StartCoroutine(MostrarTexto("The switch to shutdown the robot is inside the base.", 9.0f));
        StartCoroutine(MostrarTexto("Find a way to enter into the base without being killed by the Sentinel.", 13.0f));
        StartCoroutine(MostrarTexto("Watch your oxigen and temperature levels.", 16.0f));
        StartCoroutine(MostrarTexto("", 20.0f));
    }

    IEnumerator MostrarTexto (string mensaje, float delayTime) {
		yield return new WaitForSeconds(delayTime);
		refTextMessage.text = mensaje;
	}
}
