using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [Header("Configuración de Spawn")]
    [SerializeField]
    private float spawnRadius = 10f;

    [Header("GameObjects")]
    [SerializeField]
    private Transform player;

    [Header("Oleadas (WaveData ScriptableObjects)")]
    [SerializeField]
    private List<WaveData> oleadas; 

    private void Start()
    {
        StartCoroutine(GenerarOleadas());
    }


    ////////////////////////////////////////////////////////////////
    //    FUNCIONES DE SPAWN
    ////////////////////////////////////////////////////////////////

    private IEnumerator SpawnGrupo(EnemyGroupData grupo)
    {
        // CASO 1 — OLEADA INSTANTÁNEA
        if (grupo.oleadaInstantanea)
        {
            for (int i = 0; i < grupo.cantidadTotal; i++)
            {
                SpawnEnemy(grupo.enemyPrefab);
            }

            yield break; 
        }

        // CASO 2 — OLEADA NORMAL
        int spawnCount = 0;

        while (spawnCount < grupo.cantidadTotal)
        {
            for (int i = 0; i < grupo.cantidadPorRonda; i++)
            {
                if (spawnCount >= grupo.cantidadTotal)
                    break;

                SpawnEnemy(grupo.enemyPrefab);
                spawnCount++;
            }

            yield return new WaitForSeconds(grupo.cadencia);
        }
    }


    private void SpawnEnemy(GameObject enemy)
    {
        Vector2 randomPos = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPos = player.position + new Vector3(randomPos.x, 0f, randomPos.y);

        Instantiate(enemy, spawnPos, Quaternion.identity);
    }


    ////////////////////////////////////////////////////////////////
    //    CONTROL GENERAL DE OLEADAS
    ////////////////////////////////////////////////////////////////

    private IEnumerator GenerarOleadas()
    {
        foreach (WaveData oleadaActual in oleadas)
        {
            // Mantengo tu "TiempoEntreOleadas" para cada oleada
            yield return new WaitForSeconds(oleadaActual.tiempoEntreOleada);

            // Recorre todos los grupos dentro de esta oleada
            foreach (EnemyGroupData grupo in oleadaActual.grupos)
            {
                // Ejecuta el grupo
                yield return StartCoroutine(SpawnGrupo(grupo));
            }
        }
    }
}
