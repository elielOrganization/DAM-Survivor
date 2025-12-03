using UnityEngine;

public class FrostZoneController : WeaponBase
{
    [Header("Prefab visual del frost zone")]
    [SerializeField] private GameObject frostZonePrefab;

    private GameObject frostZoneInstance;
    private int lastLevel;

    // ---------------------------------------------------------
    // Inicializar el arma
    // ---------------------------------------------------------
    public override void Initialize(WeaponManager mgr)
    {
        base.Initialize(mgr);

        lastLevel = level;
        CreateOrRefreshFrostZone(mgr);
    }


    // ---------------------------------------------------------
    // Actualizar el FrostZone cuando suba nivel o al iniciar
    // ---------------------------------------------------------
    private void CreateOrRefreshFrostZone(WeaponManager mgr)
    {
        // Crear si no existe
        if (frostZoneInstance == null)
        {
            frostZoneInstance = Instantiate(frostZonePrefab, mgr.transform);
        }

        // Escala según el nivel
        float size = stats.rangePerLevel[level - 1] * 2f;
        frostZoneInstance.transform.localScale = new Vector3(size, size, size);

        // Configurar daño + slow + tick
        DamageFrost df = frostZoneInstance.GetComponent<DamageFrost>();
        if (df != null)
        {
            df.Configure(
                stats.damagePerLevel[level - 1],
                stats.slowPercentPerLevel[level - 1],
                stats.cooldownPerLevel[level - 1]
            );
        }
    }


    // ---------------------------------------------------------
    // Cuando sube de nivel desde el sistema normal
    // ---------------------------------------------------------
    public override void LevelUp()
    {
        base.LevelUp();
        CreateOrRefreshFrostZone(manager);
    }


    // ---------------------------------------------------------
    // AUTO REFRESH si cambias level desde el Inspector in-game
    // ---------------------------------------------------------
    public override void Tick()
    {
        base.Tick();

        if (level != lastLevel)
        {
            lastLevel = level;
            CreateOrRefreshFrostZone(manager);
        }
    }
}
