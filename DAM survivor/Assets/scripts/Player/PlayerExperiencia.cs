using UnityEngine;
using UnityEngine.UI;

public class PlayerExperiencia : MonoBehaviour
{
    public int experienciaActual = 0;
    public int experienciaMaxima = 100; // modifícalo según tu sistema de niveles
    public Slider barraExp;

    void Start()
    {
        barraExp.value = 0;
        barraExp.maxValue = experienciaMaxima;
    }

    public void AñadirExperiencia(int cantidad)
    {
        experienciaActual += cantidad;
        barraExp.value = experienciaActual;
        // Aquí puedes gestionar el nivel-up si experienciaActual >= experienciaMaxima
    }
}
