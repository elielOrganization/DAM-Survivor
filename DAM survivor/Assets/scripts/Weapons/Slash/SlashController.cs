using UnityEngine;

public class SlashController : WeaponBase
{
    [Header("Prefab visual del slash")]
    [SerializeField] private GameObject slashPrefab;

    // -------------------------------------------------------------------
    // TICK PRINCIPAL DEL ARMA (disparo automático según cooldown)
    // -------------------------------------------------------------------
    public override void Tick()
    {
        base.Tick();

        if (cooldownTimer > 0f)
            return;

        PerformSlash();
        cooldownTimer = stats.cooldownPerLevel[level - 1];
    }

    // -------------------------------------------------------------------
    // LÓGICA PRINCIPAL DEL SLASH: apunta, instancia y ajusta escala
    // -------------------------------------------------------------------
    private void PerformSlash()
    {
        float scale = stats.slashScalePerLevel[level - 1];

        // Buscar enemigo más cercano
        Transform target = GetClosestEnemy();

        // Dirección base: hacia delante del manager
        Vector3 forward = manager.transform.forward;

        // Si hay enemigo, apuntar hacia él
        if (target != null)
        {
            Vector3 dirToTarget = (target.position - manager.transform.position).normalized;
            forward = dirToTarget;
        }

        // Rotación del slash basada en la dirección calculada
        Quaternion slashRotation = Quaternion.LookRotation(forward, Vector3.up);

        GameObject slash = Instantiate(
            slashPrefab,
            manager.transform.position + forward,
            slashRotation
        );

        // Escala original del prefab
        Vector3 originalScale = slashPrefab.transform.localScale;

        // Nueva escala aplicando crecimiento en X y Z
        Vector3 newScale = new Vector3(
            originalScale.x * scale,
            originalScale.y,
            originalScale.z * scale
        );

        slash.transform.localScale = newScale;

        // Ajuste para que no crezca hacia atrás
        float depthIncrease = (newScale.z - originalScale.z) * 0.5f;
        slash.transform.position += forward * depthIncrease;

        // Pasar daño al componente del slash
        DamageSlash dmg = slash.GetComponent<DamageSlash>();
        if (dmg != null)
            dmg.Configure(stats.damagePerLevel[level - 1]);
    }

    // -------------------------------------------------------------------
    // LEVEL-UP 
    // -------------------------------------------------------------------
    public override void LevelUp()
    {
        base.LevelUp();
    }

    // -------------------------------------------------------------------
    // ENCONTRAR EL ENEMIGO MÁS CERCANO PARA APUNTAR EL SLASH
    // -------------------------------------------------------------------
    private Transform GetClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0)
            return null;

        Transform closest = null;
        float minSqrDistance = Mathf.Infinity;
        Vector3 origin = manager.transform.position; // posición del jugador

        foreach (GameObject enemy in enemies)
        {
            float sqrDist = (enemy.transform.position - origin).sqrMagnitude;
            if (sqrDist < minSqrDistance)
            {
                minSqrDistance = sqrDist;
                closest = enemy.transform;
            }
        }

        return closest;
    }
}
