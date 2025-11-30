using UnityEngine;

public class SlashController : WeaponBase
{
    [Header("Prefab visual del slash")]
    [SerializeField] private GameObject slashPrefab;

    public override void Tick()
    {
        base.Tick();

        if (cooldownTimer > 0f)
            return;

        PerformSlash();
        cooldownTimer = stats.cooldown;
    }

    private void PerformSlash()
    {
        // Instanciar el slash en la posición del jugador
        GameObject slash = Instantiate(
            slashPrefab,
            manager.transform.position + manager.transform.forward,
            manager.transform.rotation
        );

        // Pasar daño desde WeaponStats al prefab visual
        DamageSlash dmg = slash.GetComponent<DamageSlash>();
        if (dmg != null)
            dmg.Configure(stats.damage);
    }

    public override void LevelUp()
    {
        stats.damage += 10;
    }
}
