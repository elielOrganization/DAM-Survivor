using UnityEngine;

[CreateAssetMenu(fileName = "GrupoEnemigos", menuName = "Oleadas/Grupo Enemigos")]
public class EnemyGroupData : ScriptableObject
{
    [Header("Tipo de enemigo")]
    public GameObject enemyPrefab;

    [Header("Spawn")]
    public int cantidadTotal;      // Total de enemigos
    public int cantidadPorRonda;   // Cuántos se spawnean cada vez
    public float cadencia;         // Cada cuántos segundos spawnea

    [Header("¿Todos de golpe?")]
    public bool oleadaInstantanea; // Opcional
}
