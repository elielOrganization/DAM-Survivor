using UnityEngine;

[CreateAssetMenu(menuName = "LevelUp/UpgradeCard")]
public class UpgradeCardData : ScriptableObject
{
    public string upgradeName;
    [TextArea] public string description;
    public Sprite icon;

    // Tipo de upgrade
    public enum UpgradeType { NewWeapon, WeaponLevelUp, Passive }
    public UpgradeType type;

    // Identificador del arma o stat a mejorar
    public string targetId;
    public int levelIncrease = 1;
}
