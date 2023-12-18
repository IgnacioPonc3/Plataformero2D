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

    [Header("Ataque")]
    [SerializeField] private Transform controladorAtaque;
    [SerializeField] private float radioAtaque;
    [SerializeField] private float damageAtack;

    [Header("Persecución")]
    [SerializeField] private float velocidadPersecucion;
    [SerializeField] private float distanciaPersecucion;


    [SerializeField] public ParticleSystem golpeParticles;
    private float tiempoParticulasActivas = 1f;


    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        jugador = GameObject.FindGameObjectWithTag("Jugador").GetComponent<Transform>();
        golpeParticles.Stop();
    }

    public void TakeDamage(float daño)
    {
        vida -= daño;

        Debug.Log("Vida del jefe: " + vida);

        if (vida <= 0)
        {
            Muerte();
        }
        golpeParticles.Play(true);
        StartCoroutine(DesactivarParticulas());
    }


    private IEnumerator DesactivarParticulas()
    {
        yield return new WaitForSeconds(tiempoParticulasActivas);

        golpeParticles.Stop();
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
        Destroy(gameObject);
    }

    //private void OnDrawGizmos()
    //{
       // Gizmos.color = Color.yellow;
       // Gizmos.DrawWireSphere(controladorAtaque.position, radioAtaque);
    //}

    void Update()
    {
       
       
    }
}



