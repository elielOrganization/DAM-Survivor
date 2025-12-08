using UnityEngine;
using UnityEngine.UI;

public class PlayerExperiencia : MonoBehaviour
{
    [Header("XP")]
    public int nivel = 1;
    public int experienciaActual = 0;
    public int experienciaMaxima = 100; // XP necesaria para subir de nivel

    [Header("UI")]
    public Image barraExp; // Barra de experiencia (Image tipo Fill)

    void Start()
    {
        ActualizarBarra();
    }

    public void AñadirExperiencia(int cantidad)
    {
        experienciaActual += cantidad;

        // Comprobar subida de nivel
        while (experienciaActual >= experienciaMaxima)
        {
            experienciaActual -= experienciaMaxima;
            SubirNivel();
        }

        ActualizarBarra();
    }

    void SubirNivel()
    {
        nivel++;

        // Aquí puedes hacer que cada vez cueste más XP
        experienciaMaxima += 20; // por ejemplo

        // Mostrar las cartas de mejora
        LevelUpManager.Instance.ShowLevelUpChoices();
    }

    private void ActualizarBarra()
    {
        float ratio = (float)experienciaActual / experienciaMaxima;
        barraExp.fillAmount = Mathf.Clamp01(ratio);
    }
}
