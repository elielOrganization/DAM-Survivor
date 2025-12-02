using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "WeaponStats", menuName = "Weapons/StatsV2")]
public class WeaponStatsV2 : ScriptableObject
{
    [Header("Niveles del Arma")]
    public List<int> damagePerLevel = new List<int>();            // nivel 1, 2, 3...
    public List<float> cooldownPerLevel = new List<float>();
    public List<float> rangePerLevel = new List<float>();
    public List<float> projectileSpeedPerLevel = new List<float>();

    [Header("Frost Zone Levels")]
    public List<float> slowPercentPerLevel = new List<float>();

    [Header("Orbital Shield Levels")]
    public List<int> orbCountPerLevel = new List<int>();

    [Header("Magic Wand Levels")]
    public List<int> maxTargetsPerLevel = new List<int>();
}
