using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OxygenBehaviour : MonoBehaviour {
	// Use this for initialization

    public Image oxygen;
    public PlayerController playerController; 

    // Update is called once per frame
    void Update()
    {
        oxygen.fillAmount = playerController.oxygen / playerController.maxOxygen;
        // if (hp == 0f)
        // {
        //     Debug.Log("Me mori");
        //     TakeHealth(100f);

        // }
    }
}
