using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [Header("Stats del arma")]
    public WeaponStats stats; 

    protected WeaponManager manager;   // referencia al manager
    protected float cooldownTimer = 0f;

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

    // Subir nivel (puede estar vacío si no lo usas ahora)
    public abstract void LevelUp();
}
