using UnityEngine;

public class OrbitalShieldControllerV2 : WeaponBaseV2
{
    [SerializeField] private DamageOrbitalShield orbPrefab;

    private DamageOrbitalShield[] orbs;

    private int OrbCount => stats.orbCountPerLevel[level - 1];

    public override void Initialize(WeaponManager mgr)
    {
        base.Initialize(mgr);
        CreateOrbs();
    }

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

    private void DestroyExistingOrbs()
    {
        if (orbs == null) return;

        foreach (var orb in orbs)
        {
            if (orb != null)
                Destroy(orb.gameObject);
        }
    }

    public override void LevelUp()
    {
        base.LevelUp();

        DestroyExistingOrbs();
        CreateOrbs();
    }

    public override void Tick()
    {
        base.Tick();
    }
}
