using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGraphism : Behaviour, IPlClass
{
    #region References
    public PlayerModules Modules { get; set; }
    public void SetClasses(PlayerModules _Modules) { Modules = _Modules; }

    #endregion

    #region Private Fields

    #endregion

    #region Public Methods
    public void SwitchWeaponGraphics()
    {
        //You can get the activeWeapon with : Modules.Player.activeWeapon
    }

    public void SwitchSpellGraphics()
    {

    }

    public void WeaponFired()
    {
        //You can get the activeWeapon with : Modules.Player.activeWeapon
    }

    public void SpellFired()
    {

    }
    #endregion

    #region Private Methods

    #endregion
}
