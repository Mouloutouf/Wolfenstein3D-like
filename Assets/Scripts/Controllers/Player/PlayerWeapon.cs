using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : Behaviour, IPlClass
{
    #region References
    public PlayerModules Modules { get; set; }
    public void SetClasses(PlayerModules _Modules) { Modules = _Modules; }

    #endregion

    #region Private Fields
    bool canFire = true;
    #endregion

    #region Public Methods
    public void FireWeapon(bool keyDown)
    {
        if (keyDown)
        {
            //You can get the activeWeapon with : Modules.Player.activeWeapon
            Modules.Graphism.WeaponFired();
            canFire = false;
            /*Since this is a Behaviour and not a MonoBehaviour, 
            Launch Cooldown Coroutine with : Modules.Player.StartCoroutine(Cooldown(theWeaponCooldown))*/
        }
        else
        {

        }
    }

    public void SwitchWeapon(int index)
    {
        //You can get the activeWeapon with : Modules.Player.activeWeapon
        //You can get the weapons list with : Modules.Player.weapons
        canFire = true;
        Modules.Graphism.SwitchWeaponGraphics();
    }

    public void FireGrenade()
    {
        //You will need Modules.Player.grenadAmount
    }

    #endregion

    #region Private Methods

    #endregion

    #region IEnumerators
    private IEnumerator Cooldown(float time)
    {
        yield return new WaitForSeconds(time);
        canFire = true;
    }
    #endregion
}
