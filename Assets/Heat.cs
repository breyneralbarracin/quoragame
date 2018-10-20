using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heat : MonoBehaviour
{
    // Use this for initialization

    public Image calor;
    float hp, maxHp = 100f;
    float amount = 10f;
    private float timer;
    healthBehaviour vida;
    GameObject barravida;

    // Use this for initialization
    void Start()
    {
        hp = maxHp;
    }

    public void HeatDamage()
    {
        hp = Mathf.Clamp(hp - 4f, 0f, maxHp);
        calor.transform.localScale = new Vector2(hp / maxHp, 0.2560809f);
    }

    public void HeatDamageWater()
    {
        hp = Mathf.Clamp(hp - 8f, 0f, maxHp);
        calor.transform.localScale = new Vector2(hp / maxHp, 0.2560809f);
    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 10f)
        {
            HeatDamage();
            timer = 0f;
        }

        if (hp == 0)
        {
            barravida = GameObject.Find("vida");
            barravida.gameObject.GetComponent<healthBehaviour>().TakeDamage(10f);

        }


    }
}
