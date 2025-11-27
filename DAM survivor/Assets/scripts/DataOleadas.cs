using UnityEngine;

[CreateAssetMenu(fileName = "OleadaNueva", menuName="Oleadas")]
public class DataOleadas : ScriptableObject
{
    [Header("Propiedades de la Oleada")]
    public GameObject EnemyPrefab;
    public float SpawnRate;
    public int CantidadDeEnemigos;
    public float TiempoEntreOleadas;
}

