using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    // Método para cargar la escena de juego
    public void CargarJuego()
    {
        SceneManager.LoadScene("level 1 prueba");
    }

    // Método para cargar la escena de opciones
    public void CargarOpciones()
    {
        SceneManager.LoadScene("level 1");
    }

    // Método para salir del juego (solo funciona en una compilación, no en el Editor)
    public void SalirDelJuego()
    {
        Application.Quit();
    }
}
