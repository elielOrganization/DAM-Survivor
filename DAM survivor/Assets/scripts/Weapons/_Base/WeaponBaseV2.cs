using UnityEngine;

public abstract class WeaponBaseV2 : MonoBehaviour
{
    [Header("Stats del arma")]
    public WeaponStatsV2 stats; 

    protected WeaponManager manager;   // referencia al manager del jugador
    protected float cooldownTimer = 0f;

    [Header("Nivel del arma")]
    public int level = 1;   // por si quieres usar niveles más adelante

    // Inicialización del arma cuando se equipa
    public virtual void Initialize(WeaponManager mgr)
    {
        manager = mgr;
        cooldownTimer = 0f;

        // Aquí podrías hacer algo con level si quieres más adelante
        // De momento no tocamos stats, usamos los del ScriptableObject tal cual
    }

    // Se ejecuta cada frame desde el WeaponManager
    public virtual void Tick()
    {
        if (cooldownTimer > 0f)
            cooldownTimer -= Time.deltaTime;
    }

    // Subir nivel: por defecto solo aumenta el número,
    // cada arma concreta decide qué hacer con ese nivel
    public virtual void LevelUp()
    {
        level++;
        // Aquí NO tocamos stats directamente.
        // Cada arma hija puede overridear esto si quiere.
    }
}
