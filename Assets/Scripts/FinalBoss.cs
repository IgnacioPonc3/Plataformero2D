using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
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
    [SerializeField] private float damageAtaque;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        barraDeVida.InicializarBarraDeVida(vida);
        jugador = GameObject.FindGameObjectWithTag("Jugador").GetComponent<Transform>();
       
    }

    public void TakeDamage(float da�o)
    {
        vida -= da�o;

        barraDeVida.CambiarVidaActual(vida);

        if(vida <= 0)
        {
            animator.SetTrigger("Muerte");
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
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 100, 0);
        }
    }

    void Update()
    {
       float DistanciaJugador = Vector2.Distance(transform.position, jugador.position);
        animator.SetFloat("DistanciaJugador", DistanciaJugador);
    }

    private void Ataque()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorAtaque.position, radioAtaque);

        foreach (Collider2D collsion in objetos)
        {
            if (collsion.CompareTag("Jugador"))
            {
                collsion.GetComponent<CombateJugador>().TakeDamage(damageAtaque);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(controladorAtaque.position, radioAtaque);
    }
}


