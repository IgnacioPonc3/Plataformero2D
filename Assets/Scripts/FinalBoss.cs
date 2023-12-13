using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour, Idamage
{
    private Animator animator;
    public Rigidbody2D rb2D;
    public Transform jugador;
    private bool mirandoDerecha = true;

    [Header("Vida")]
    [SerializeField] private float vida;
    [SerializeField] private BarraDeVida barraDeVida;

    [Header("Ataque")]
    [SerializeField] private Transform controladorAtaque;
    [SerializeField] private float radioAtaque;
    [SerializeField] private float damageAtack;

    //[Header("Persecución")]
    [SerializeField] private float velocidadPersecucion;
    [SerializeField] private float distanciaPersecucion;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        //barraDeVida.InicializarBarraDeVida(vida);
        jugador = GameObject.FindGameObjectWithTag("Jugador").GetComponent<Transform>();
    }

    public void TakeDamage(float daño)
    {
        vida -= daño;

       // barraDeVida.CambiarVidaActual(vida);

        if (vida <= 0)
        {
            Muerte();
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }

    public void MirarJugador()
    {
        if ((jugador.position.x > transform.position.x && !mirandoDerecha) || (jugador.position.x < transform.position.x && mirandoDerecha))
        {
            mirandoDerecha = !mirandoDerecha;
            Vector3 nuevaEscala = transform.localScale;
            nuevaEscala.x *= -1;
            transform.localScale = nuevaEscala;
        }
    }

    public void Ataque()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorAtaque.position, radioAtaque);

        foreach (Collider2D colision in objetos)
        {
            if (colision.CompareTag("Jugador"))
            {
                colision.GetComponent<CombateJugador>().TakeDamage(damageAtack);
            }
        }
    }

    private void Muerte()
    {
        animator.SetTrigger("Muerte");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(controladorAtaque.position, radioAtaque);
    }

    void Update()
    {
        float distanciaJugador = Vector2.Distance(transform.position, jugador.position);
        animator.SetFloat("distanciaJugador", distanciaJugador);

        // Verificar la distancia para activar persecución
        if (distanciaJugador < distanciaPersecucion)
        {
            // Obtener la dirección hacia el jugador
            Vector2 direccion = (jugador.position - transform.position).normalized;

            // Mover el jefe hacia el jugador en la dirección adecuada
            rb2D.velocity = new Vector2(direccion.x * velocidadPersecucion, rb2D.velocity.y);
        }
        else
        {
            // Si el jugador está fuera de la distancia de persecución, detener el movimiento
            rb2D.velocity = new Vector2(0f, rb2D.velocity.y);
        }
    }
}



