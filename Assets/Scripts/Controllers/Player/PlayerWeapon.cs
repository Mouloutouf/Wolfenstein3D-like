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
            if (Modules.Player.activeWeapon.stats.Ammunitions > 0) Shoot();
            else Modules.Graphism.WeaponAudio("DryFire");
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

    public void Reload()
    {
        Weapon activeWeapon = Modules.Player.activeWeapon;
        if(activeWeapon.stats.Ammunitions != activeWeapon.stats.MaxAmmo && Modules.Player.stats.Ammunitions > 0)
        {
            canFire = false;
            Modules.Player.StartCoroutine(Cooldown(0.5f));
            Modules.Graphism.WeaponAudio("Reload");
            if(Modules.Player.stats.Ammunitions < activeWeapon.stats.MaxAmmo)
            {
                activeWeapon.stats.Ammunitions = Modules.Player.stats.Ammunitions;
                Modules.Player.stats.Ammunitions = 0;
            }
            else
            {
                activeWeapon.stats.Ammunitions = activeWeapon.stats.MaxAmmo;
                Modules.Player.stats.Ammunitions -= activeWeapon.stats.MaxAmmo;
            }
        }
    }

    public void FireGrenade()
    {
        //You will need Modules.Player.grenadAmount
    }

    #endregion

    #region Private Methods
    private void Shoot()
    {
        Modules.Graphism.WeaponAudio("Fire");

        canFire = false;
        cooldownCoroutine = Cooldown(Modules.Player.activeWeapon.stats.FireRate);
        Modules.Player.StartCoroutine(cooldownCoroutine);

        Modules.Player.activeWeapon.stats.Ammunitions -= 1;

        //Checking for collisions inside a Sphere using the hittableLY
        Physics.SphereCast(Modules.Camera.transform.position, Modules.Player.activeWeapon.stats.HitRadius, Modules.Camera.transform.forward, out RaycastHit hit, 100f, Modules.Player.hittableLayers, QueryTriggerInteraction.Ignore);
        if (hit.collider != null)
        {
            Debug.Log("[PlayerWeapon] Hit : (" + hit.collider.name +")");
            Debug.DrawLine(start: Modules.Camera.transform.position, end: hit.point, color: Color.red, duration: 3f);
            GameObject.Instantiate(Resources.Load("Impact"), position: hit.point, rotation: Quaternion.identity, hit.collider.transform.parent);
            if (hit.collider.GetComponent<EnemyCollider>())
            {
                EnemyCollider target = hit.collider.GetComponent<EnemyCollider>();
                target.Hit(Mathf.FloorToInt(Modules.Player.activeWeapon.stats.Damages));
            }
        }
        else
        {
            Debug.Log("[PlayerWeapon] Nothing Hit");
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
