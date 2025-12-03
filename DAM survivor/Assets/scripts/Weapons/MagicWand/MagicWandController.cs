using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MagicWandController : WeaponBase
{
    [SerializeField] private DamageMagicWand projectilePrefab;

    private int lastLevel;

    // ---------------------------------------------------------
    // Inicialización del arma
    // ---------------------------------------------------------

    public override void Initialize(WeaponManager mgr)
    {
        base.Initialize(mgr);
        lastLevel = level;
    }


    // ---------------------------------------------------------
    // Disparo automático por cooldown
    // ---------------------------------------------------------
    public override void Tick()
    {
        base.Tick();

        // Auto-refresh si cambias el nivel desde inspector
        if (level != lastLevel)
        {
            lastLevel = level;
        }

        // Lógica de disparo
        if (cooldownTimer <= 0f)
        {
            cooldownTimer = stats.cooldownPerLevel[level - 1];
            StartCoroutine(Disparar());
        }
    }

    // ---------------------------------------------------------
    // Disparo de misiles dirigidos
    // ---------------------------------------------------------
    private IEnumerator Disparar()
    {
        float rango = stats.rangePerLevel[level - 1];
        int maxTargets = stats.maxTargetsPerLevel[level - 1];
        int damage = stats.damagePerLevel[level - 1];
        float speed = stats.projectileSpeedPerLevel[level - 1];

        Collider[] hits = Physics.OverlapSphere(transform.position, rango);

        List<EnemyController> enemigos = new List<EnemyController>();

        foreach (var hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                EnemyController e = hit.GetComponent<EnemyController>();
                if (e != null)
                    enemigos.Add(e);
            }
        }

        if (enemigos.Count == 0)
            yield break;

        enemigos.Sort((a, b) =>
            Vector3.Distance(transform.position, a.transform.position)
            .CompareTo(
            Vector3.Distance(transform.position, b.transform.position))
        );

        int cantidad = Mathf.Min(maxTargets, enemigos.Count);

        for (int i = 0; i < cantidad; i++)
        {
            EnemyController objetivo = enemigos[i];

            DamageMagicWand misil = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            misil.Configure(damage, speed, objetivo.transform);

            yield return new WaitForSeconds(0.1f);
        }
    }


    // ---------------------------------------------------------
    // Si subes nivel desde el sistema general → refresca
    // ---------------------------------------------------------
    public override void LevelUp()
    {
        base.LevelUp();
    }
}
