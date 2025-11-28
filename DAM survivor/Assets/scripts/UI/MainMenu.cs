using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Cambia "Game" por el nombre exacto de tu escena de juego
    public string nombreEscenaJuego = "Nivel1";

    public void Jugar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nombreEscenaJuego);
    }

    public void Salir()
    {
        Application.Quit();
    }

}
