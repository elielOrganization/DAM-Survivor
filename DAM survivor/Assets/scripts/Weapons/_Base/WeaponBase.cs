using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [Header("Stats del arma")]
    public WeaponStats stats; 

    protected WeaponManager manager;   // referencia al manager del jugador
    protected float cooldownTimer = 0f;

    [Header("Nivel del arma")]
    [Range(1, 10)]
    public int level = 1;
    private int maxLevel = 10;

    // Inicialización del arma cuando se equipa
    public virtual void Initialize(WeaponManager mgr)
    {
        manager = mgr;
        cooldownTimer = 0f;
    }

    // Se ejecuta cada frame desde el WeaponManager
    public virtual void Tick()
    {
        if (cooldownTimer > 0f)
            cooldownTimer -= Time.deltaTime;
    }

    public virtual void LevelUp()
    {
        if (level >= maxLevel)
            return;

        level++;
    }
}
