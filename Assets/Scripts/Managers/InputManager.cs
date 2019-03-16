using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class InputManager : MonoBehaviour
{
    #region Private Fields
    Camera activeCamera;

    #endregion

    #region Public Fields
    //Events
    public event Action<bool> Fire = delegate { };
    public event Action<bool> Spell = delegate { };
    public event Action Reload = delegate { };
    public event Action Action = delegate { };
    public event Action<Vector2> MouseMoved = delegate { };
    public event Action<Vector3> MovementInput = delegate { };
    public event Action Pause = delegate { };

    public event Action Grenade = delegate { };
    public event Action<int> SwitchWeapons = delegate { };
    public event Action<int> SwitchSpells = delegate { };

    #region Keycodes
    public Dictionary<string, KeyCode> Keys = new Dictionary<string, KeyCode>
    {
        {"Fire", KeyCode.Mouse0 },
        {"Reload", KeyCode.R },
        {"Spell", KeyCode.Mouse1 },
        {"Action", KeyCode.Space },
        {"Left", KeyCode.Q },
        {"Right", KeyCode.D },
        {"Forward", KeyCode.Z },
        {"Backward", KeyCode.S },
        {"Grenade", KeyCode.G },
        {"SwitchWeaponUp", KeyCode.UpArrow },
        {"SwitchWeaponDown", KeyCode.DownArrow },
        {"SwitchSpellUp", KeyCode.LeftArrow },
        {"SwitchSpellDown", KeyCode.RightArrow },
        {"Pause", KeyCode.Escape }
    };
    #endregion
    #endregion

    #region MonoBehaviour Callbacks
    void Start()
    {
        activeCamera = Camera.main;
    }

    void Update()
    {
        OnClickEvents();
        MouseEvents();
        MovementEvents();
        KeybordEvents();
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods
    void OnClickEvents()
    {
        if (Input.GetKeyDown(Keys["Fire"])) Fire(true);
        if (Input.GetKeyDown(Keys["Spell"])) Spell(true);

        if (Input.GetKeyUp(Keys["Fire"])) Fire(false);
        if (Input.GetKeyUp(Keys["Spell"])) Spell(false);
    }

    void MouseEvents()
    {
        var mouseMovement = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        if (mouseMovement != Vector2.zero) MouseMoved(mouseMovement);
    }

    void MovementEvents()
    {
        var movement = new Vector3();
        movement.x = Input.GetKey(Keys["Left"]) ? -1 : Input.GetKey(Keys["Right"]) ? 1 : 0;
        movement.z = Input.GetKey(Keys["Forward"]) ? 1 : Input.GetKey(Keys["Backward"]) ? -1 : 0;
        MovementInput(movement);
    }

    void KeybordEvents()
    {
        if (Input.GetKeyDown(Keys["Pause"])) Pause();
        if (Input.GetKeyDown(Keys["Reload"])) Reload();
        if (Input.GetKeyDown(Keys["Action"])) Action();
        if (Input.GetKeyDown(Keys["Grenade"])) Grenade();

        if (Input.GetKeyDown(Keys["SwitchWeaponUp"])) SwitchWeapons(-1);
        if (Input.GetKeyDown(Keys["SwitchWeaponDown"])) SwitchWeapons(1);
        if (Input.GetKeyDown(Keys["SwitchSpellUp"])) SwitchSpells(-1);
        if (Input.GetKeyDown(Keys["SwitchSpellDown"])) SwitchSpells(1);
    }

    #endregion
}
