using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpell : Behaviour, IPlClass
{
    #region References
    public PlayerModules Modules { get; set; }
    public void SetClasses(PlayerModules _Modules) { Modules = _Modules; }

    #endregion

    #region Private Fields
    bool canFire = true;

    #endregion

    #region Public Methods
    public void FireSpell(bool keyDown)
    {
        if (keyDown && canFire)
        {
            //You can get the activeSpell with : Modules.Player.activeSpell
            canFire = false;
            Modules.Player.StartCoroutine(Cooldown(0.6f));
            /*Since this is a Behaviour and not a MonoBehaviour, 
            Launch Cooldown Coroutine with : Modules.Player.StartCoroutine(Cooldown(theSpellCooldown))*/
        }
        else
        {

        }
    }

    public void SwitchSpell(int index)
    {
        //You can get the activeSpell with : Modules.Player.activeSpell
        //You can get the spells list with : Modules.Player.spells
        canFire = false;
        Modules.Graphism.SwitchSpellGraphics();
        Modules.Player.StartCoroutine(Cooldown(0.6f));
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
