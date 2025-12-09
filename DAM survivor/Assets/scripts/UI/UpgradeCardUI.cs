using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeCardUI : MonoBehaviour
{
    public Image iconImage;
    public Button button;

    UpgradeCardData data;
    System.Action<UpgradeCardData> onSelected;

    public void Setup(UpgradeCardData cardData, System.Action<UpgradeCardData> callback)
    {
        data = cardData;
        onSelected = callback;
        iconImage.sprite = data.icon;

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() =>
        {
            Debug.Log("CLICK CARTA: " + data.upgradeName);
            onSelected?.Invoke(data);
        });

    }
}
