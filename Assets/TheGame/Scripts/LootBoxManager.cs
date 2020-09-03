using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class LootBoxManager : MonoBehaviour
{
    [SerializeField] private WeaponSO[] weapons;
    
    public WeaponSO GetRandomItem()
    {
        var itemId = Random.Range(0, weapons.Length);

        return weapons[itemId];
    }

    public void DestroyLootBox()
    {
        Destroy(transform.parent.parent.gameObject);
    }
}
