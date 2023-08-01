using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilidadJefe : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private Vector2 dimesionCaja;
    [SerializeField] private Transform posicionCaja;
    [SerializeField] private float tiempoDeVida;

    private void Start()
    {
         Destroy(gameObject, tiempoDeVida);
    }

    void Update()
    {
        
    }

    private void Golpe()
    {
        Collider2D[] objetos = Physics2D.OverlapBoxAll(posicionCaja.position, dimesionCaja, 0f);

        foreach (Collider2D colisiones in objetos)
        {
            if (colisiones.CompareTag("Jugador"))
            {
                colisiones.GetComponent<CombateJugador>().TakeDamage(damage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(posicionCaja.position, dimesionCaja);
    }
}
