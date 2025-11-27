using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    /// <summary>
    /// ///////////////////// Variables /////////////////////////
    /// </summary>
    [Header("Configuración de Spawn")]
    [SerializeField]
    private float spawnRadius = 10f;

    [Header("GameObjects")]
    [SerializeField]
    private Transform player;

    [SerializeField]
    private List<DataOleadas> oleadas;


    
    ////////////////////////////////////// Funciones Unity//////////////////
    void Start()
    {
        StartCoroutine(GenerarOleadas());
    }

    ///////////////////////////// Funciones Propias ////////////////////

    private IEnumerator spawn(DataOleadas oleada)
    {
        for (int i = 0; i < oleada.CantidadDeEnemigos; i++)
        {
            Vector2 randomPoint = Random.insideUnitCircle * spawnRadius;
            Vector3 spawnPosition = player.position + new UnityEngine.Vector3(randomPoint.x, 0f, randomPoint.y);
            Instantiate(oleada.EnemyPrefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(oleada.SpawnRate);
        }
    }
    
    public IEnumerator GenerarOleadas()
    {
        foreach(DataOleadas oleadaActual in oleadas)
        {
            yield return new WaitForSeconds(oleadaActual.TiempoEntreOleadas);
            StartCoroutine(spawn(oleadaActual));
        }
    }
}
