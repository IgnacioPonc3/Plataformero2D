using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    // M�todo para cargar la escena de juego
    public void CargarJuego()
    {
        SceneManager.LoadScene("level1");
    }

    // M�todo para cargar la escena de opciones
    public void CargarOpciones()
    {
        SceneManager.LoadScene("NombreDeTuEscenaDeOpciones");
    }

    // M�todo para salir del juego (solo funciona en una compilaci�n, no en el Editor)
    public void SalirDelJuego()
    {
        Application.Quit();
    }
}
