using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    [Header("Cannon Configuration")]
    public Transform Objective;
    public float MovementSpeed = 5f;
    public Rigidbody Bullet;
    public float BulletSpeed = 100f;
    public float scope = 85000;
    [Space(10)]

    [Header("Audio Effects")]
    public AudioClip ShotSound;
    public AudioClip ExplosionSound;
    public float Volume = 1.0f;

    [HideInInspector]
    public bool AllowShot = true;
    private Rigidbody bullets;
    private int serie;
    private float myTime;

    public void setAllowShot(bool permitirDisparo) { this.AllowShot = permitirDisparo; }
    public bool getAllowShot() { return AllowShot; }


    void Start()
    {
        this.serie = 0;
        this.myTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Vdistance = Objective.transform.position - transform.position;
        LookPoint();
        if(Vdistance.sqrMagnitude <= scope)
        {
            gameObject.GetComponentInParent<Animator>().enabled = false;
            Shoot();
        }else gameObject.GetComponentInParent<Animator>().enabled = true;

    }

    private void LookPoint()
    {
        Vector3 direccion = Objective.position - transform.position;
        Quaternion rotacion = Quaternion.LookRotation(direccion);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotacion, MovementSpeed * Time.deltaTime);
    }

    private void Shoot()
    {
        if(AllowShot && Time.time - this.myTime >= 2f && serie % 1 == 0)
        {
            AllowShot = false;
            this.myTime = Time.time;
            //Vector3 salidaDisparo = transform.position + new Vector3(0, 0, 2);
            bullets = Instantiate(Bullet, transform.position, transform.rotation);
            AudioSource.PlayClipAtPoint(ShotSound, transform.position, Volume);
            bullets.name = "bala1";
            //Physics.IgnoreCollision(bullets.GetComponent<Collider>(), GetComponent<Collider>());
            bullets.velocity = transform.TransformDirection(new Vector3(0, 0, BulletSpeed));
        }
    }
}
