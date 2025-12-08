using UnityEngine;

[CreateAssetMenu(menuName = "LevelUp/UpgradeCard")]
public class UpgradeCardData : ScriptableObject
{
    public int slotIndex;
    public string upgradeName;
    [TextArea] public string description;
    public Sprite icon;
}
