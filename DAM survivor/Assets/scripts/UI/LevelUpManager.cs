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

        // Limpiar cartas anteriores
        foreach (Transform child in cardsParent)
            Destroy(child.gameObject);

        // Selecciona 3 cartas aleatorias
        var selected = GetRandomCards(3);

        // Crear las cartas en la UI
        foreach (var card in selected)
        {
            var ui = Instantiate(cardPrefab, cardsParent);
            ui.Setup(card, OnCardSelected);
        }

        // Pausar el juego
        Time.timeScale = 0f;
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
        WeaponManager wm = FindAnyObjectByType<WeaponManager>();
        if (wm == null) return;

        int slot = card.slotIndex;

        // Si el slot está vacío → arma nueva
        if (wm.weaponSlots[slot] == null)
        {
            AddWeaponBySlot(wm, slot);
        }
        else
        {
            // Si ya está ocupada → subir nivel
            wm.weaponSlots[slot].LevelUp();
        }
    }

    void AddWeaponBySlot(WeaponManager wm, int slot)
    {
        WeaponBase prefab = null;

        switch (slot)
        {
            case 0: prefab = wm.slashPrefab; break;
            case 1: prefab = wm.frostZonePrefab; break;
            case 2: prefab = wm.orbitalShieldPrefab; break;
            case 3: prefab = wm.magicWandPrefab; break;
        }

        if (prefab == null)
        {
            Debug.LogWarning("No hay prefab para el slot: " + slot);
            return;
        }

        WeaponBase instance = Instantiate(prefab, wm.transform.position, Quaternion.identity);
        wm.AddWeapon(instance, slot);
    }

    void CloseLevelUp()
    {
        levelUpPanel.SetActive(false);
        IsLevelUpOpen = false;
        Time.timeScale = 1f;  // reanudar
    }
}
