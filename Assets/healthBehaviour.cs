using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBehaviour : MonoBehaviour {
    // Use this for initialization

    public Image health;
    float hp, maxHp = 100f;
    float amount = 10f;

    // Use this for initialization
    void Start()
    {
        hp = maxHp;
    }

    public void TakeDamage(float amount)
    {
        hp = Mathf.Clamp(hp - amount, 0f, maxHp);
        health.transform.localScale = new Vector2(hp / maxHp, 1);
    }

    public void TakeHelath(float amount)
    {
        hp = Mathf.Clamp(hp + amount, 0f, maxHp);
        health.transform.localScale = new Vector2(hp / maxHp, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(amount);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            TakeHelath(amount);
        }
    }
}
