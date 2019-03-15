using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    public Weapon[] weapons;
    public Weapon currentWeapon;
    private int currentIndexWeapon = 0;
    [SerializeField]
    private Animator weaponAnimator;


    private void Awake()
    {
        
    }

    void Start()
    {
        currentWeapon = weapons[0];
    }

    void NextWeapon()
    {
        if (currentIndexWeapon + 1 > weapons.Length - 1)
        {
            currentIndexWeapon = 0;
            currentWeapon = weapons[currentIndexWeapon];
        }
        else {
            currentIndexWeapon++;
            currentWeapon = weapons[currentIndexWeapon];
        }

        weaponAnimator.runtimeAnimatorController = currentWeapon.animator;
    }

    void PreviousWeapon()
    {
        if (currentIndexWeapon -1 < 0)
        {
            currentIndexWeapon = weapons.Length - 1;
            currentWeapon = weapons[currentIndexWeapon];
        }
        else
        {
            currentIndexWeapon--;
            currentWeapon = weapons[currentIndexWeapon];
        }

        weaponAnimator.runtimeAnimatorController = currentWeapon.animator;
    }

    void SelectWeapon(int index) {
        currentIndexWeapon = index;
        currentWeapon = weapons[currentIndexWeapon];
    }
}
