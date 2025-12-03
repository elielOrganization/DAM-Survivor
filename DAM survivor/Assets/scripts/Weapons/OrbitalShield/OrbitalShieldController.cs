using UnityEngine;

public class OrbitalShieldController : WeaponBase
{
    [Header("Prefab del orbe")]
    [SerializeField] private DamageOrbitalShield orbPrefab;

    private DamageOrbitalShield[] orbs;

    private int lastLevel;

    // Acceso al número de orbes para este nivel
    private int OrbCount => stats.orbCountPerLevel[level - 1];


    // -------------------------------------------------------------------
    // Inicialización del arma cuando es equipada
    // -------------------------------------------------------------------
    public override void Initialize(WeaponManager mgr)
    {
        base.Initialize(mgr);

        lastLevel = level;  
        CreateOrbs();       
    }


    // -------------------------------------------------------------------
    // Crear todos los orbes del nivel actual
    // -------------------------------------------------------------------
    private void CreateOrbs()
    {
        int count = OrbCount;

        if (count <= 0)
        {
            Debug.LogWarning("OrbCount es 0 para " + name);
            return;
        }

        orbs = new DamageOrbitalShield[count];

        for (int i = 0; i < count; i++)
        {
            float angle = (360f / count) * i;

            DamageOrbitalShield orb = Instantiate(orbPrefab, transform);
            orbs[i] = orb;

            orb.SetInitialAngle(angle);

            orb.Configure(
                stats.damagePerLevel[level - 1],
                stats.rangePerLevel[level - 1],
                stats.projectileSpeedPerLevel[level - 1]
            );
        }
    }


    // -------------------------------------------------------------------
    // Destruir todos los orbes existentes
    // -------------------------------------------------------------------
    private void DestroyExistingOrbs()
    {
        if (orbs == null) return;

        foreach (var orb in orbs)
        {
            if (orb != null)
                Destroy(orb.gameObject);
        }
    }


    // -------------------------------------------------------------------
    // Subir de nivel (llamado por el sistema principal)
    // -------------------------------------------------------------------
    public override void LevelUp()
    {
        base.LevelUp();
        RefreshOrbs();
    }


    // -------------------------------------------------------------------
    // Versión central que regenera los orbes
    // -------------------------------------------------------------------
    private void RefreshOrbs()
    {
        DestroyExistingOrbs();
        CreateOrbs();
    }


    // -------------------------------------------------------------------
    // AUTO-REFRESH: Detecta cambios en 'level' durante el juego
    // -------------------------------------------------------------------
    public override void Tick()
    {
        base.Tick();

        if (level != lastLevel)
        {
            lastLevel = level;
            RefreshOrbs();
        }
    }
}
