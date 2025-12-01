using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MagicWandController : WeaponBase
{
    [SerializeField] private DamageMagicWand projectilePrefab;

    public override void Tick()
    {
        base.Tick();

        if (cooldownTimer <= 0f)
        {
            cooldownTimer = stats.cooldown;
            StartCoroutine(Disparar());
        }
    }

    private IEnumerator Disparar()
    {
        // Buscar enemigos
        Collider[] hits = Physics.OverlapSphere(transform.position, stats.range);

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

        // Ordenarlos por distancia
        enemigos.Sort((a, b) =>
            Vector3.Distance(transform.position, a.transform.position)
            .CompareTo(
            Vector3.Distance(transform.position, b.transform.position))
        );

        // Tomar los 2 más cercanos (o 1 si no hay más)
        int cantidad = Mathf.Min(stats.maxTargets, enemigos.Count);

        for (int i = 0; i < cantidad; i++)
        {
            EnemyController objetivo = enemigos[i];

            DamageMagicWand m = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            m.Configure(stats.damage, stats.projectileSpeed, objetivo.transform);

            yield return new WaitForSeconds(0.1f); // pequeño retardo entre disparos
        }
    }

    public override void LevelUp()
    {
        stats.damage += 5;
        stats.projectileSpeed += 2f;
        stats.range += 1f;
    }
}
