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
    bool stopFire = false;
    IEnumerator cooldownCoroutine;
    #endregion

    #region Public Methods
    public void FireWeapon(bool keyDown)
    {
        if (keyDown && canFire)
        {
            //You can get the activeWeapon with : Modules.Player.activeWeapon


            Shoot();
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
    private void Shoot()
    {
        canFire = false;
        Modules.Graphism.WeaponFired();
        /*Since this is a Behaviour and not a MonoBehaviour, 
        Launch Cooldown Coroutine with : Modules.Player.StartCoroutine(Cooldown(theWeaponCooldown))*/
        cooldownCoroutine = Cooldown(Modules.Player.activeWeapon.stats.FireRate);
        Modules.Player.StartCoroutine(cooldownCoroutine);

        //Checking for collisions inside a Sphere using the hittableLY
        Physics.SphereCast(Modules.Camera.transform.position, Modules.Player.activeWeapon.stats.HitRadius, Modules.Camera.transform.forward, out RaycastHit hit, 100f, Modules.Player.hittableLayers, QueryTriggerInteraction.Ignore);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
            Debug.DrawLine(start: Modules.Camera.transform.position, end: hit.point, color: Color.red, duration: 3f);
            GameObject.Instantiate(Resources.Load("Impact"), position: hit.point, rotation: Quaternion.identity);
        }
        else
        {
            Debug.Log("Nothing Hit");
        }
    }
    #endregion

    #region IEnumerators
    private IEnumerator Cooldown(float time)
    {
        yield return new WaitForSeconds(time);
        canFire = true;
    }
    #endregion
}
