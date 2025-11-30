using UnityEngine;

public class FrostZoneController : WeaponBase
{
    [Header("Prefab visual del frost zone")]
    [SerializeField] private GameObject frostZonePrefab;
    private GameObject frostZoneInstance;
    
    public override void Initialize(WeaponManager mgr)
{
    base.Initialize(mgr);

    if (frostZonePrefab != null)
    {
        frostZoneInstance = Instantiate(frostZonePrefab, transform);
        float size = stats.range * 2f;  // range = radio → escala = diámetro
        frostZoneInstance.transform.localScale = new Vector3(size, size, size);

        // Le paso el daño al script DamageFrost
        DamageFrost df = frostZoneInstance.GetComponent<DamageFrost>();
        if (df != null)
        {
            df.Configure(stats.damage, stats.slowPercent, stats.cooldown);
        }
    }
}

    public override void LevelUp()
    {
        stats.damage += 10;
    }
}
