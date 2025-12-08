using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeCardUI : MonoBehaviour
{
    public Image iconImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public Button button;

    UpgradeCardData data;
    System.Action<UpgradeCardData> onSelected;

    public void Setup(UpgradeCardData cardData, System.Action<UpgradeCardData> callback)
    {
        data = cardData;
        onSelected = callback;
        iconImage.sprite = data.icon;
        nameText.text = data.upgradeName;
        descriptionText.text = data.description;

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() =>
        {
            Debug.Log("CLICK CARTA: " + data.upgradeName);
            onSelected?.Invoke(data);
        });

    }
}
