using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float maxOxygen;
	public float maxHealth;
	public float maxHeat;
	public float oxygen;
	public float health;
	public float heat;

	private bool oxygenFlag;
	private float timeInSeconds;

	void Start () {
		oxygenFlag = true;
		timeInSeconds = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		timeInSeconds += Time.deltaTime;
		Debug.Log(oxygenFlag);
		if(timeInSeconds % 4f <= 0.2f && oxygenFlag)
		{
			Debug.Log("reducir vida");
			reduceOxygen(maxHealth*0.01f);
			oxygenFlag = false;
		}
		else if(timeInSeconds % 4f > 0.2f)
		{
			oxygenFlag = true;
		}
	}

	public void reduceOxygen(float cantidad)
	{
		if(oxygen > 0)
		{
			oxygen -= cantidad;
		}

		if(oxygen < 0)
		{
			oxygen = 0;
		}
	}

	public void increaseOxygen(float cantidad)
	{
		if(oxygen < maxOxygen)
		{
			oxygen += cantidad;
		}

		if(oxygen > maxOxygen)
		{
			oxygen = maxOxygen;
		}
	}

	public void reduceHealth(float cantidad)
	{
		if(health > 0)
		{
			health -= cantidad;
		}

		if(health < 0)
		{
			health = 0;
		}
	}

	public void increaseHealth(float cantidad)
	{
		if(health < maxHealth)
		{
			health += cantidad;
		}

		if(health > maxHealth)
		{
			health = maxHealth;
		}
	}

	public void reduceHeat(float cantidad)
	{
		if(heat > 0)
		{
			heat -= cantidad;
		}

		if(heat < 0)
		{
			heat = 0;
		}
	}

	public void increaseHeat(float cantidad)
	{
		if(heat < maxHeat)
		{
			heat += cantidad;
		}

		if(heat > maxHeat)
		{
			heat = maxHeat;
		}
	}
}
