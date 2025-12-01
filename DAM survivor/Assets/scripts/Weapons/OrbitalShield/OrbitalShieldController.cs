using UnityEngine;

public class OrbitShieldController : WeaponBase
{
    [SerializeField] private DamageOrbitalShield orbPrefab;

    private DamageOrbitalShield[] orbs;

    private int orbCount => stats.orbCount; 

    public override void Initialize(WeaponManager mgr)
    {
        base.Initialize(mgr);

        orbs = new DamageOrbitalShield[orbCount];

        // Crear los orbes en posiciones equidistantes
        for (int i = 0; i < orbCount; i++)
        {
            float angle = (360f / orbCount) * i;

            DamageOrbitalShield orb = Instantiate(orbPrefab, transform);
            orbs[i] = orb;

            // Posición inicial según el ángulo
            orb.SetInitialAngle(angle);

            // Pasarle stats
            orb.Configure(stats.damage, stats.range, stats.projectileSpeed);
        }
    }

    public override void Tick()
    {
        base.Tick();

        // Actualizar velocidad/lógica si quieres más adelante
    }

    public override void LevelUp()
    {
        // Ejemplo:
        stats.damage += 5;
        stats.range += 0.3f;

        // Actualizar stats en los orbes
        foreach (var orb in orbs)
        {
            orb.Configure(stats.damage, stats.range, stats.projectileSpeed);
        }
    }
}
