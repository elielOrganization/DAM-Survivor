using UnityEngine;

[CreateAssetMenu(fileName = "Oleada_", menuName = "Oleadas/Oleada")]
public class WaveData : ScriptableObject
{
    [Header("Tiempo entre oleadas")]
    public float tiempoEntreOleada = 2f;
    
    [Header("Grupos que componen la oleada")]
    public EnemyGroupData[] grupos;
}
    