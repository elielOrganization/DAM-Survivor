using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public string nombreEscenaMenu = "MainMenu";

    [HideInInspector] public bool juegoPausado = false;

    public void Pausar()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        juegoPausado = true;
    }

    public void Reanudar()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        juegoPausado = false;
    }

    public void SalirAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nombreEscenaMenu);
    }
}
