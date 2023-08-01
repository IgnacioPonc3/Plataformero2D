using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilidadJefe : MonoBehaviour
{
    [SerializeField] private float damage;

    [SerializeField] private Vector2 dimensionCaja;

    [SerializeField] private Transform posicionCaja;

    [SerializeField] private float tiempoDeVida;

    void Start()
    {
        Destroy(gameObject, tiempoDeVida);
    }


    private void Golpe()
    {
        Collider2D[] objetos = Physics2D.OverlapBoxAll(posicionCaja.position, dimensionCaja, 0f);
        
        foreach (Collider2D collisiones in objetos)
        {
            if (collisiones.CompareTag("Jugador"))
            {
                collisiones.GetComponent<CombateJugador>().TakeDamage(damage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(posicionCaja.position, dimensionCaja);
    }

    void Update()
    {
        
    }
}
