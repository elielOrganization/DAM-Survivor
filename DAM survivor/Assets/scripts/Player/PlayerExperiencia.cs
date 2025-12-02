using UnityEngine;
using UnityEngine.UI;

public class PlayerExperiencia : MonoBehaviour
{
    public int experienciaActual = 0;
    public int experienciaMaxima = 100; // modifícalo según tu sistema de niveles
    public Image barraExp; // OJO: esto es Image, no Slider

    void Start()
    {
        ActualizarBarra();
    }

    public void AñadirExperiencia(int cantidad)
    {
        experienciaActual += cantidad;

        // Aquí puedes gestionar el nivel-up si experienciaActual >= experienciaMaxima
        // ej: subir nivel, resetear exp, aumentar experienciaMaxima, etc.

        ActualizarBarra();
    }

    private void ActualizarBarra()
    {
        float ratio = (float)experienciaActual / experienciaMaxima;
        barraExp.fillAmount = Mathf.Clamp01(ratio);
    }
}
