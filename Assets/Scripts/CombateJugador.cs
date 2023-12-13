using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateJugador : MonoBehaviour
{
    [SerializeField] public float vida;

    public void TakeDamage(float damage)
    {
        GetComponent<MovimientoJugador>().VerificarDerrota();
        vida -= damage;

        if (vida <+0)
        {
            Destroy(gameObject);
        }

    }

    public float Vida
    {
        get { return vida; }
    }

}



