using UnityEngine;

public class LevelUpManager : MonoBehaviour
{
    public static LevelUpManager Instance;

    [Header("UI")]
    [SerializeField] GameObject levelUpPanel;
    [SerializeField] Transform cardsParent;
    [SerializeField] UpgradeCardUI cardPrefab;

    [Header("Pool de cartas")]
    [SerializeField] UpgradeCardData[] allCards;

    void Awake()
    {
        Instance = this;
        levelUpPanel.SetActive(false);
    }

    public static bool IsLevelUpOpen { get; private set; }

    public void ShowLevelUpChoices()
        {
            IsLevelUpOpen = true;
            levelUpPanel.SetActive(true);

            foreach (Transform child in cardsParent)
                Destroy(child.gameObject);

            var selected = GetRandomCards(3);
            foreach (var card in selected)
            {
                var ui = Instantiate(cardPrefab, cardsParent);
                ui.Setup(card, OnCardSelected);
            }

            Time.timeScale = 0f;   // pausa TODO
        }
        


    UpgradeCardData[] GetRandomCards(int count)
    {
        int max = Mathf.Min(count, allCards.Length);
        UpgradeCardData[] result = new UpgradeCardData[max];

        var pool = new System.Collections.Generic.List<UpgradeCardData>(allCards);

        for (int i = 0; i < max; i++)
        {
            int index = Random.Range(0, pool.Count);
            result[i] = pool[index];
            pool.RemoveAt(index);   // evita repetidas
        }

        return result;
    }


    void OnCardSelected(UpgradeCardData card)
    {
        ApplyUpgrade(card);
        CloseLevelUp();
    }

    void ApplyUpgrade(UpgradeCardData card)
    {
        // Aquí llamas a tu sistema de armas / stats
        // Ejemplo muy genérico:
        switch (card.type)
        {
            case UpgradeCardData.UpgradeType.NewWeapon:
                WeaponManager wm = FindAnyObjectByType<WeaponManager>();
                if (wm != null)
                    AddWeaponById(wm, card.targetId);
                break;

            case UpgradeCardData.UpgradeType.WeaponLevelUp:
                // Más adelante implementamos la mejora de nivel
                break;

            case UpgradeCardData.UpgradeType.Passive:
                PlayerStats.Instance.AddPassive(card.targetId, card.levelIncrease);
                break;
        }
    void AddWeaponById(WeaponManager wm, string id)
    {
        // Busca el primer slot libre
        int freeIndex = -1;
        for (int i = 0; i < wm.weaponSlots.Length; i++)
        {
            if (wm.weaponSlots[i] == null)
            {
                freeIndex = i;
                break;
            }
        }

        if (freeIndex == -1)
        {
            Debug.Log("No hay slots libres para nuevas armas");
            return;
        }

        WeaponBase prefab = null;

        // Aquí mapeas ids de las cartas a prefabs de WeaponManager
        switch (id)
        {
            case "Slash":
                prefab = wm.slashPrefab;
                break;
            case "FrostZone":
                prefab = wm.frostZonePrefab;
                break;
            case "OrbitalShield":
                prefab = wm.orbitalShieldPrefab;
                break;
            case "MagicWand":
                prefab = wm.magicWandPrefab;
                break;
        }

        if (prefab == null)
        {
            Debug.LogWarning("No se encontró prefab para id: " + id);
            return;
        }

        WeaponBase instance = Instantiate(prefab, wm.transform.position, Quaternion.identity);
        wm.AddWeapon(instance, freeIndex);
    }


    }

    void CloseLevelUp()
    {
        levelUpPanel.SetActive(false);
        IsLevelUpOpen = false;
        Time.timeScale = 1f;   // reanuda TODO
    }
}
