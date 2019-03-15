using Sirenix.OdinInspector.PinkBlood.Data;
using System;
using UnityEngine;
using Sirenix.OdinInspector;

public class EntityStats
{
    [HideInInspector]
    public StatList Stats = new StatList();

    [ProgressBar(0, 100), ShowInInspector]
    public float Hitpoints
    {
        get { return this.Stats[StatType.Hitpoints]; }
        set { this.Stats[StatType.Hitpoints] = value; }
    }
}
