using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public Stats stats;

	[System.Serializable]
	public class Stats
	{
		public float maxOxygen;
		public float maxHealth;
		public float maxHeat;
		public float oxygen;
		public float health;
		public float heat;
	}

	public UI ui;

	[System.Serializable]
	public class UI
	{
		public GameObject menuPausa;
	}

	private bool oxygenFlag;
	private float timeInSeconds;
	private bool pausado;
    

	void Start () {
		oxygenFlag = true;
		timeInSeconds = 0f;
		pausado = false;
        

		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		timeInSeconds += Time.deltaTime;
		//Debug.Log(oxygenFlag);
		if(timeInSeconds % 4f <= 0.2f && oxygenFlag)
		{
			//Debug.Log("reducir vida");
			reduceOxygen(stats.maxHealth*0.01f);
			oxygenFlag = false;
		}
		else if(timeInSeconds % 4f > 0.2f)
		{
			oxygenFlag = true;
		}
        if(stats.health<=100 && BulletExplosion.healthflag==true)
        {
            reduceHealth(BulletExplosion.Quitarvida);
            BulletExplosion.healthflag = false;
        }

		if(stats.health == 0)
		{
			//print("!Has muerto!");
			//Time.timeScale =0;
			//if(Input.GetKeyDown(KeyCode.Return))
			//{
				//Time.timeScale =1;
				SceneManager.LoadScene("escena1");
				//stats.health = stats.maxHealth;
			//}
		}

		if(Input.GetKeyDown(KeyCode.P))
		{
			if(!pausado)
			{
				pausar();
				pausado = true;
			}
			else
			{
				quitarPausa();
				pausado = false;
			}	
		}
	}

    public void quitarPausa()
    {
        Time.timeScale = 1;

		ui.menuPausa.SetActive(false);
		Cursor.visible = false;
    }

    public void pausar()
    {
        Time.timeScale = 0;
		
		ui.menuPausa.SetActive(true);
		Cursor.visible = true;
    }

    public void reduceOxygen(float cantidad)
	{
		if(stats.oxygen > 0)
		{
            
			stats.oxygen -= cantidad;
		}

		if(stats.oxygen < 0)
		{
			stats.oxygen = 0;
		}
	}

	public void increaseOxygen(float cantidad)
	{
		if(stats.oxygen < stats.maxOxygen)
		{
			stats.oxygen += cantidad;
		}

		if(stats.oxygen > stats.maxOxygen)
		{
			stats.oxygen = stats.maxOxygen;
		}
	}

	public void reduceHealth(float cantidad)
	{
        Debug.Log(stats.health);
		if(stats.health > 0)
		{
            print("si entra");
            stats.health -=cantidad;
            
		}

		if(stats.health < 0)
		{
			stats.health = 0;
		}
	}

	public void increaseHealth(float cantidad)
	{
		if(stats.health < stats.maxHealth)
		{
			stats.health += cantidad;
		}

		if(stats.health > stats.maxHealth)
		{
			stats.health = stats.maxHealth;
		}
	}

	public void reduceHeat(float cantidad)
	{
		if(stats.heat > 0)
		{
			stats.heat -= cantidad;
		}

		if(stats.heat < 0)
		{
			stats.heat = 0;
		}
	}

	public void increaseHeat(float cantidad)
	{
		if(stats.heat < stats.maxHeat)
		{
			stats.heat += cantidad;
		}

		if(stats.heat > stats.maxHeat)
		{
			stats.heat = stats.maxHeat;
		}
	}
}
