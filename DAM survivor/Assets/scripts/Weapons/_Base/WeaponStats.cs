using UnityEngine;

[CreateAssetMenu(fileName = "WeaponStats", menuName = "Weapons/Stats")]
public class WeaponStats : ScriptableObject
{
    [Header("Daño / Ritmo")]
    public int damage = 10;
    public float cooldown = 1f;

    [Header("Rango / Tamaño")]
    public float range = 5f;       // Frost radius, rango de target, etc.
    public float projectileSpeed = 10f;

    [Header("Frost Zone Settings")]
    public float slowPercent = 0.3f; // Para Frost Zone, por ejemplo
    [Header("Orbital Shield Settings")]
    public int orbCount = 3;
    [Header("Magic Wand Settings")]
    public int maxTargets = 2;

}
