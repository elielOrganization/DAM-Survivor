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
        cooldownTimer = stats.cooldownPerLevel[level - 1];
    }

    private void PerformSlash()
    {
        float scale = stats.slashScalePerLevel[level - 1];

        GameObject slash = Instantiate(
            slashPrefab,
            manager.transform.position + manager.transform.forward,
            manager.transform.rotation
        );

        // Escala original del prefab
        Vector3 originalScale = slashPrefab.transform.localScale;

        // Nueva escala
        Vector3 newScale = new Vector3(
            originalScale.x * scale,
            originalScale.y,
            originalScale.z * scale
        );

        slash.transform.localScale = newScale;

        // ---------- AJUSTE PARA QUE NO CREZCA HACIA ATRÁS ----------
        float depthIncrease = (newScale.z - originalScale.z) * 0.5f;

        slash.transform.position += manager.transform.forward * depthIncrease;
        // -------------------------------------------------------------

        // Pasar daño
        DamageSlash dmg = slash.GetComponent<DamageSlash>();
        if (dmg != null)
            dmg.Configure(stats.damagePerLevel[level - 1]);
    }



    public override void LevelUp()
    {
        base.LevelUp();
    }
}
