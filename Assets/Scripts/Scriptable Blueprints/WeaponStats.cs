using Sirenix.OdinInspector.PinkBlood.Data;
using System;
using UnityEngine;
using Sirenix.OdinInspector;

public class WeaponStats
{
    [HideInInspector]
    public StatList Stats = new StatList();

    [ShowInInspector]
    public bool Automatic;

    [ProgressBar(0, 3), ShowInInspector]
    public float HitRadius
    {
        get { return this.Stats[StatType.HitRadius]; }
        set { this.Stats[StatType.HitRadius] = value; }
    }

    [ProgressBar(0, 3), ShowInInspector]
    public float FireRate
    {
        get { return this.Stats[StatType.FireRate]; }
        set { this.Stats[StatType.FireRate] = value; }
    }

    [ProgressBar(0, 10), ShowInInspector]
    public float Damages
    {
        get { return this.Stats[StatType.Damages]; }
        set { this.Stats[StatType.Damages] = Mathf.FloorToInt(value); }
    }

    [ProgressBar(0, 50), ShowInInspector, ]
    public float MaxAmmo
    {
        get { return this.Stats[StatType.MaxAmmo]; }
        set { this.Stats[StatType.MaxAmmo] = Mathf.FloorToInt(value); }
    }

    [ProgressBar(0, 50), ShowInInspector]
    public float Ammunitions
    {
        get { return this.Stats[StatType.Ammunitions]; }
        set { this.Stats[StatType.Ammunitions] = Mathf.FloorToInt(value); }
    }

    [ProgressBar(0, 10), ShowInInspector]
    public float Recoil
    {
        get { return this.Stats[StatType.Recoil]; }
        set { this.Stats[StatType.Recoil] = value; }
    }

}
