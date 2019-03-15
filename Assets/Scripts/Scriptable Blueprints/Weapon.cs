using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "Weapon", menuName = "Wolfenstein/Weapon", order = 0)]
public class Weapon : SerializedScriptableObject
{
    public enum WeaponType { RANGED, CLOSECOMBAT }
    public WeaponType weaponType;

    public float rateOfFire;

    public AnimatorOverrideController animator;

    public Sprite UISprite;
    public Sprite PickUpSprite;
}
