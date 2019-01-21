using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon", order = 1)]
public class Weapon : ScriptableObject
{
    public string weaponName = "Pistol";
    public int bullets = 3;

    public float reloadTime = 0.5f;
}