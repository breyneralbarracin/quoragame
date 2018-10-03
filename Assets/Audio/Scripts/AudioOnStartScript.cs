/**
 * @autor Gisler Garcés <gislersoft@hotmail.com>
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOnStartScript : MonoBehaviour {

	public AudioClip clip2;
	public float delayTimeClip2 = 100;
    IEnumerator Start()
    {
        AudioSource audio = GetComponent<AudioSource>();

        audio.Play();
        yield return new WaitForSeconds(audio.clip.length + delayTimeClip2);
        audio.clip = clip2;
        audio.Play();
    }
}
