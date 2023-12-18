using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombateJugador : MonoBehaviour
{
    [SerializeField] public float vida;
    public Image barraDeVida;
    public float vidaActual;
    public float vidaMaxima;

    public void TakeDamage(float damage)
    {
        GetComponent<MovimientoJugador>().VerificarDerrota();
        vida -= damage;

        if (vida <+0)
        {
            Destroy(gameObject);
        }
        if (barraDeVida != null)
        {
            vida = Mathf.Clamp(vida, 0f, vidaMaxima);
            ActualizarBarraDeVida();
        }
    }

    private void Start()
    {
        if (barraDeVida != null) 
        {
            barraDeVida.fillAmount = 1f;
        }
    }

    private void ActualizarBarraDeVida()
    {
        float vidaMaximaActualizada = Mathf.Max(1f, vidaMaxima);

        float proporcionVida = Mathf.Clamp01(vida / vidaMaximaActualizada);

        barraDeVida.fillAmount = proporcionVida;
    }

    public float Vida
    {
        get { return vida; }
    }

    void Update()
    {
    }

}



