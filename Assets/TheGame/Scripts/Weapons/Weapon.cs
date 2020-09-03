using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damage;
    public WeaponType weaponType;
    public AttackType attackType;
    public Color color;

    [SerializeField]private GameObject[] existingWeapons;

    public void SetWeapon(WeaponSO weapon)
    {
        damage = weapon.damage;
        color = weapon.color;
        attackType = weapon.attackType;
        weaponType = weapon.weaponType;

        EnableWeapon(weaponType);
    }

    public void EnableWeapon(WeaponType type)
    {
        foreach (var weapon in existingWeapons)
        {
            weapon.SetActive(false);
        }
        
        existingWeapons[(int)type].GetComponent<SpriteRenderer>().color = color;
        existingWeapons[(int)type].SetActive(true);
    }
}


