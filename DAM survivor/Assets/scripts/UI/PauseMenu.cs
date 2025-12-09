using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public string nombreEscenaMenu = "MainMenu";

    public Image barraXP;   // arrastra aquí la Image de la barra (la que está FUERA del PauseMenu)

    [HideInInspector] public bool juegoPausado = false;

    public void Pausar()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        juegoPausado = true;

        if (barraXP != null)
            barraXP.gameObject.SetActive(false);
    }

    public void Reanudar()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        juegoPausado = false;

        if (barraXP != null)
            barraXP.gameObject.SetActive(true);
    }

    public void SalirAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nombreEscenaMenu);
    }
}
