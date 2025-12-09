using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;   // ← Singleton
    public PlayerStats stats;
    private int maxHealth;
    private int currentHealth;
    private int defensa;
    private float velMov;
    private bool estaVivo = true;

    private void Awake()
    {
        // Singleton básico
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        maxHealth = stats.MaxHP;
        currentHealth = maxHealth;
        defensa = stats.Defense;
        velMov = stats.Speed;
    }

    //////////////////////////////// Funciones propias /////////////////////////

    public void RecibirDmg(int dmg)
    {
        if (!estaVivo) return;

        if (dmg > defensa)
        {
            currentHealth -= dmg - defensa;

            if (currentHealth <= 0)
                estaVivo = false;
        }
    }
}
