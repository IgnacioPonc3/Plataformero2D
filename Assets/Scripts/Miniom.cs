using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miniom : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator ani;
    public int direccion;
    public float speedWalk;
    public float speedRun;
    public GameObject target;
    public bool atacando;


    public float rangoVision;
    public float rangoAtaque;
    public GameObject rango;
    public GameObject Hit;

    void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.Find("Player");
    }
    void Update()
    {
        Comportameientos();
    }
    public void Comportameientos()
    {
        if (Mathf.Abs(transform.position.x - target.transform.position.x) > rangoVision && !atacando)
        {
            ani.SetBool("run", false);
            cronometro += 1 * Time.deltaTime;
            if (cronometro >= 4)
            {
                rutina = UnityEngine.Random.Range(0, 2);
                cronometro = 0;
            }
            switch (rutina)
            {
                case 0:
                    ani.SetBool("walk", false);
                    break;
                case 1:
                    direccion = UnityEngine.Random.Range(0, 2);
                    rutina++;
                    break;
                case 2:
                    switch (direccion)
                    {
                        case 0:
                            transform.rotation = Quaternion.Euler(0, 0, 0);
                            transform.Translate(Vector3.right * speedWalk * Time.deltaTime);
                            break;
                        case 1:
                            transform.rotation = Quaternion.Euler(0, 100, 0);
                            transform.Translate(Vector3.right * speedWalk * Time.deltaTime);
                            break;
                    }
                    ani.SetBool("walk", true);
                    break;
            }
        }
        else
        {
            if(Mathf.Abs(transform.position.x - target.transform.position.x) > rangoAtaque && !atacando)
            {
                if (transform.position.x < target.transform.position.x)
                {
                    ani.SetBool("Walk", false);
                    ani.SetBool("Run", true);
                    transform.Translate(Vector3.right * speedRun *Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    ani.SetBool("atack", false);
                }
                else
                {
                    ani.SetBool("Walk", false);
                    ani.SetBool("Run", true);
                    transform.Translate(Vector3.right * speedRun *Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    ani.SetBool("atack", false);
                }
            }
            else
            {
                if (!atacando) 
                {
                    if (transform.position.x < target.transform.position.x)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                    }

                    else 
                    {
                        transform.rotation = Quaternion.Euler(0, 180, 0);
                    }
                    ani.SetBool("Walk", false);
                    ani.SetBool("run", false);
                }
            }
        }
    }


    public void FixedUpdate()
    {
        ani.SetBool("atack", false);
        atacando =false;
        rango.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void ColliderWeaponTrue()
    {
        Hit.GetComponent<BoxCollider2D>().enabled=true;
    }
    public void ColliderWeaponFalse()
    {
        Hit.GetComponent<BoxCollider2D>().enabled=false;
    }
}
