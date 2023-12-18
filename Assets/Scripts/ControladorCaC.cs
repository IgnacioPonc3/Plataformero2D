using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCaC : MonoBehaviour
{
    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private Transform controladorGolpe2;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float dañoGolpe;
    [SerializeField] private float tiempoEntreAtaques;
    [SerializeField] private float tiempoSiguienteAtaque;
    [SerializeField] public float vida;
    [SerializeField] private float maximoVida;
    [SerializeField] private ParticleSystem golpeParticles;
    private Animator animator;
    private AudioSource audioSource;



    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }


    private void Update()
    {
        if (tiempoSiguienteAtaque > 0)
        {
            tiempoSiguienteAtaque -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Fire1") && tiempoSiguienteAtaque <= 0)
        {
            Golpe();
            tiempoSiguienteAtaque = tiempoEntreAtaques;
        }
    }

    public void TakeDamage(float damage)
    {
            audioSource.PlayOneShot(audioSource.clip);
            golpeParticles.Play();
        

        vida -= damage;
        if (vida <= 0)
        {
            Destroy(gameObject);
        }       
    }


    private void Golpe()
    {
        animator.SetTrigger("Golpe");

        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);

        foreach (Collider2D colisionador in objetos)
        {
            Idamage objeto = colisionador.GetComponent<Idamage>();
            if (objeto != null)
            {
                objeto.TakeDamage(dañoGolpe);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }



}



