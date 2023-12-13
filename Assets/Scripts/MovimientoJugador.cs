using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MovimientoJugador : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Animator animator;

    [Header("Movimiento")]
    private float movimientoHorizontal = 0f;
    [SerializeField] private float velocidadDeMovimiento;
    [Range(0, 0.3f)][SerializeField] private float suavizadoDeMovimiento;
    private Vector3 velocidad = Vector3.zero;

    private bool mirandoDerecha = true;

    [Header("Salto")]
    [SerializeField] private float fuerzaDeSalto;
    [SerializeField] private LayerMask queEsSuelo;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private Vector3 dimensionesCaja;
    private bool enSuelo;

    private bool salto = false;

    [Header("Derrota")]
    [SerializeField] private GameObject pantallaDerrota;
    [SerializeField] private Button botonReintentar;
    [SerializeField] private Button botonSalir;


    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        // Desactivar la pantalla de derrota al inicio
        pantallaDerrota.SetActive(false);

        // Asignar funciones a los botones
        botonReintentar.onClick.AddListener(Reintentar);
        botonSalir.onClick.AddListener(Salir);
    }

    private void Update()
    {
        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadDeMovimiento;
        animator.SetFloat("Horizontal", Mathf.Abs(movimientoHorizontal));

        if (Input.GetButtonDown("Jump") && enSuelo)
        {
            salto = true;
        }
    }

    private void FixedUpdate()
    {
        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queEsSuelo);
        animator.SetBool("enSuelo", enSuelo);

        Mover(movimientoHorizontal * Time.fixedDeltaTime);

        salto = false;
    }

    private void Mover(float mover)
    {
        Vector3 velocidadObjetivo = new Vector2(mover, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObjetivo, ref velocidad, suavizadoDeMovimiento);

        if ((enSuelo || PermitirSaltoEnElAire) && salto)
        {
            enSuelo = false;
            rb2D.AddForce(new Vector2(0f, fuerzaDeSalto));
        }

        if (mover > 0 && !mirandoDerecha || mover < 0 && mirandoDerecha)
        {
            Girar();
        }
    }

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
    }

    [SerializeField] private bool PermitirSaltoEnElAire = false;

    public void VerificarDerrota()
    {
       CombateJugador combateJugador = GetComponent<CombateJugador>();
        if (combateJugador != null && combateJugador.Vida <= 0)
        {
            // Pausar el juego o realizar otras acciones necesarias
            Time.timeScale = 0f;

            // Activar la pantalla de derrota
            pantallaDerrota.SetActive(true);
        }
    }
    
    private void ActivarPantallaDerrota()
    {
        // Pausar el juego u otras acciones necesarias
        Time.timeScale = 0f;

        // Activar elementos de la pantalla de derrota
        pantallaDerrota.SetActive(true);
        botonReintentar.onClick.AddListener(Reintentar);
        botonSalir.onClick.AddListener(Salir);
    }

    private void Reintentar()
    {
        // Reactivar el tiempo y reiniciar la escena
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void Salir()
    {
        // Reactivar el tiempo y cargar la escena del menú principal
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuPrincipal"); // Asegúrate de poner el nombre correcto de la escena del menú principal
    }
}

