using UnityEngine;

[CreateAssetMenu(menuName = "LevelUp/UpgradeCard")]
public class UpgradeCardData : ScriptableObject
{
    public int slotIndex;
    public string upgradeName;
    public Sprite icon;
}
