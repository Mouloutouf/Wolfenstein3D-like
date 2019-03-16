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
        //Modules.Player.activeWeapon.sprites["Idle"]
    }

    public void SwitchSpellGraphics()
    {

    }

    public void WeaponEffects()
    {

    }

    public void SpellEffects()
    {

    }

    public void WeaponAudio(string audioName)
    {
        //SFX
        Modules.Player.weaponAudio.clip = Modules.Player.activeWeapon.PickAudio(audioName);
        Modules.Player.weaponAudio.Play();
    }

    public void SpellAudio(string audioName)
    {
        //SFX

    }
    #endregion

    #region Private Methods

    #endregion


}
