using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Player : Entities
{
    #region Interface
    [BoxGroup("Stats"), HideLabel]
    public PlayerStats stats = new PlayerStats();

    [FoldoutGroup("Player Equipement")]
    public Weapon activeWeapon;
    [FoldoutGroup("Player Equipement")]
    public List<Weapon> weapons;
    [FoldoutGroup("Player Equipement")]
    public Spell activeSpell;
    [FoldoutGroup("Player Equipement")]
    public List<Spell> spells;
    [FoldoutGroup("Player Equipement")]
    public int grenadeAmount;

    #region References
    public Rigidbody rb;

    #endregion

    #endregion

    #region Private Fields
    PlayerModules Modules;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //Initialization of Player Modules
        Modules.Player = this;
        Modules.Inputs = GameManager.Instance.inputManager;

        List<IPlClass> plClasses = new List<IPlClass>();
        plClasses.Add(Modules.Camera = transform.GetComponentInChildren<PlayerCamera>());
        plClasses.Add(Modules.Movement = new PlayerMovement());
        plClasses.Add(Modules.Graphism = new PlayerGraphism());
        plClasses.Add(Modules.Weapon = new PlayerWeapon());
        plClasses.Add(Modules.Spell = new PlayerSpell());

        foreach (IPlClass plClass in plClasses)
        {
            plClass.Modules = Modules;
        }

        //Subscribing Modules Methods to corresponding InputManager Events
        Modules.Inputs.Fire += Modules.Weapon.FireWeapon;
        Modules.Inputs.Spell += Modules.Spell.FireSpell;
        Modules.Inputs.Grenade += Modules.Weapon.FireGrenade;
        Modules.Inputs.MovementInput += Modules.Movement.Move;
        Modules.Inputs.SwitchSpells += Modules.Spell.SwitchSpell;
        Modules.Inputs.SwitchWeapons += Modules.Weapon.SwitchWeapon;

        //References
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public struct PlayerModules
{
    public Player Player;
    public InputManager Inputs;
    public PlayerCamera Camera;

    public PlayerMovement Movement;
    public PlayerGraphism Graphism;
    public PlayerWeapon Weapon;
    public PlayerSpell Spell;
}

public interface IPlClass
{
    PlayerModules Modules { get; set; }

    void SetClasses(PlayerModules _Modules);
}