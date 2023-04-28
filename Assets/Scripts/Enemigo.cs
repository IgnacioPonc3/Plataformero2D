using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float distancia;
    [SerializeField] private LayerMask queEsSuelo;
    private Rigidbody2D rb2D;
    private Animator animator;


    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    private void Update()
    {
        rb2D.velocity = new Vector2(velocidadMovimiento * transform.right.x, rb2D.velocity.y);

        RaycastHit2D inforamcionSuelo = Physics2D.Raycast(transform.position, transform.right, distancia, queEsSuelo );

        if(inforamcionSuelo)
        {
            Girar();
        }
    }

    private void Girar()
    {
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 100, 0);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.right * distancia);
    }


    public void TomarDaño(float daño)
    {
        vida -= daño;
        
        if (vida <= 0)
        {
            Muerte();
        }

    }
    

    private void Muerte()
    {
        animator.SetTrigger("Muerte");
        Destroy(gameObject);
    }

}
