using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateJugador : MonoBehaviour
{
    [SerializeField] private float vida;

    public void TakeDamage(float damage)
    {
        vida -= damage;

        if (vida <+0)
        {
            Destroy(gameObject);
        }
    }
}



