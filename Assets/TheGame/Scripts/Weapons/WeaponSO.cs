using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "TheGame/ScriptableObjects/New Weapon")]
public class WeaponSO : ScriptableObject
{
    public int damage;
    public Color color;
    public WeaponType weaponType;
    public AttackType attackType;
}

public enum WeaponType
{
    FIST,
    CLUB,
    PISTOL
}

public enum AttackType
{
    Melee,
    Range
}