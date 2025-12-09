using UnityEngine;
using UnityEngine.UI;

public class PlayerExperiencia : MonoBehaviour
{
    [Header("XP")]
    public int nivel = 1;
    public int experienciaActual = 0;
    public int experienciaMaxima = 100; // XP necesaria para subir de nivel

    [Header("UI")]
    public Image barraExp; // Barra de experiencia

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
    public void MostrarBarraXP(bool mostrar)
    {
        if (barraExp != null)
            barraExp.gameObject.SetActive(mostrar);
    }

    void SubirNivel()
    {
        nivel++;

        // Hacer que cada vez cueste más XP
        experienciaMaxima += 200; 

        // Mostrar las cartas de mejora
        LevelUpManager.Instance.ShowLevelUpChoices();
    }

    private void ActualizarBarra()
    {
        float ratio = (float)experienciaActual / experienciaMaxima;
        barraExp.fillAmount = Mathf.Clamp01(ratio);
    }
}
