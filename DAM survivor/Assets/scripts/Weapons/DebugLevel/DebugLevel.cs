using UnityEngine;
using UnityEngine.InputSystem;

public class DebugLevel : MonoBehaviour
{
    [Header("Input Actions")]
    public InputActionReference levelUp1;
    public InputActionReference levelUp2;
    public InputActionReference levelUp3;
    public InputActionReference levelUp4;

    private WeaponManager weaponManager;

    private void Awake()
    {
        weaponManager = GetComponent<WeaponManager>();
    }

    private void OnEnable()
    {
        levelUp1.action.performed += ctx => HandleLevelUp(0);
        levelUp2.action.performed += ctx => HandleLevelUp(1);
        levelUp3.action.performed += ctx => HandleLevelUp(2);
        levelUp4.action.performed += ctx => HandleLevelUp(3);

        levelUp1.action.Enable();
        levelUp2.action.Enable();
        levelUp3.action.Enable();
        levelUp4.action.Enable();
    }

    private void OnDisable()
    {
        levelUp1.action.Disable();
        levelUp2.action.Disable();
        levelUp3.action.Disable();
        levelUp4.action.Disable();
    }

    private void HandleLevelUp(int slot)
    {
        // 1. Si NO hay arma → equiparla
        if (weaponManager.weaponSlots[slot] == null)
        {
            Debug.Log($"Añadiendo arma en slot {slot}");

            WeaponBase prefab = GetPrefabBySlot(slot);
            if (prefab != null)
                weaponManager.AddWeapon(Instantiate(prefab, transform.position, Quaternion.identity), slot);

            return;
        }

        // 2. Si YA existe → subir nivel
        Debug.Log($"Level Up en slot {slot}");

        weaponManager.weaponSlots[slot].LevelUp();
    }

    private WeaponBase GetPrefabBySlot(int slot)
    {
        return slot switch
        {
            0 => weaponManager.slashPrefab,
            1 => weaponManager.frostZonePrefab,
            2 => weaponManager.orbitalShieldPrefab,
            3 => weaponManager.magicWandPrefab,
            _ => null
        };
    }
}
