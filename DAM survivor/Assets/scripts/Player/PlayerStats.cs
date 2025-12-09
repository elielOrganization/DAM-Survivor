using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Stats/PlayerStats", order = 1)]
public class PlayerStats : ScriptableObject {
    public int MaxHP;
    public int Defense;
    public float Speed;

}
