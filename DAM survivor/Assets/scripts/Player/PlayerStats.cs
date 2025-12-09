using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;   // ← Singleton

    private int currentHealth;
    private int maxHealth = 100;
    private int ataque = 5;
    private int defensa = 0;
    private float velMov = 5f;
    private float velAtk = 1f;

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

        currentHealth = maxHealth;
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

    // Método que puede usar LevelUpManager para las pasivas
    public void AddPassive(string id, int amount)
    {
        // Aquí decides qué hace cada pasiva según el id
        // Ejemplos:
        if (id == "maxHealth")
            maxHealth += amount;
        else if (id == "defense")
            defensa += amount;
        else if (id == "attack")
            ataque += amount;
        else if (id == "speed")
            velMov += amount;
    }
}
