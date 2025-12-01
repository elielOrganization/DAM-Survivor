using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [Header("Slots de armas")]
    public WeaponBase[] weaponSlots = new WeaponBase[4];

    [Header("Prefabs de armas")]
    public WeaponBase frostZonePrefab;
    public WeaponBase orbitalShieldPrefab;
    public WeaponBase magicWandPrefab;
    public WeaponBase slashPrefab;

    private void Start()
    {
        // Equipar automáticamente Slash en el slot 0
        // if (frostZonePrefab != null)
        //     AddWeapon(Instantiate(frostZonePrefab, transform.position, Quaternion.identity), 0);
        // if (slashPrefab != null)
        //     AddWeapon(Instantiate(slashPrefab, transform.position, Quaternion.identity), 0);
        // if (orbitalShieldPrefab != null)
        //     AddWeapon(Instantiate(orbitalShieldPrefab, transform.position, Quaternion.identity), 0);
        if (magicWandPrefab != null)
            AddWeapon(Instantiate(magicWandPrefab, transform.position, Quaternion.identity), 0);
    }

    private void Update()
    {
        for (int i = 0; i < weaponSlots.Length; i++)
        {
            if (weaponSlots[i] != null)
                weaponSlots[i].Tick();
        }
    }

    public void AddWeapon(WeaponBase newWeapon, int slotIndex)
    {
        if (slotIndex < 0 || slotIndex >= weaponSlots.Length)
        {
            Debug.LogWarning("Slot de arma fuera de rango");
            return;
        }

        weaponSlots[slotIndex] = newWeapon;
        newWeapon.Initialize(this);
        newWeapon.transform.SetParent(transform);
    }
}
