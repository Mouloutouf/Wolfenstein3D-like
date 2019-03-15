using Sirenix.OdinInspector.PinkBlood.Data;
using System;
using UnityEngine;
using Sirenix.OdinInspector;

// 
// CharacterStats is simply a StatList, that expose the relevant stats for a character.
// Also note that the StatList might look like a dictionary, in how it's used, 
// but it's actually just a regular list, serialized by Unity. Take a look at the StatList to learn more.
// 

[Serializable]
public class PlayerStats
{
    [HideInInspector]
    public StatList Stats = new StatList();

    [ProgressBar(0, 20), ShowInInspector]
    public float Damages
    {
        get { return this.Stats[StatType.Damages]; }
        set { this.Stats[StatType.Damages] = value; }
    }

    [ProgressBar(0, 100), ShowInInspector]
    public float Rage
    {
        get { return this.Stats[StatType.Rage]; }
        set { this.Stats[StatType.Rage] = value; }
    }

    [ProgressBar(0, 300), ShowInInspector]
    public float Ammunitions
    {
        get { return this.Stats[StatType.Ammunitions]; }
        set { this.Stats[StatType.Ammunitions] = value; }
    }

    [ProgressBar(0, 20), ShowInInspector]
    public float SpeedMax
    {
        get { return this.Stats[StatType.SpeedMax]; }
        set { this.Stats[StatType.SpeedMax] = value; }
    }

    [ProgressBar(0, 20), ShowInInspector]
    public float SpeedAcc
    {
        get { return this.Stats[StatType.SpeedAcc]; }
        set { this.Stats[StatType.SpeedAcc] = value; }
    }

    [ProgressBar(0, 20), ShowInInspector]
    public float SpeedDecc
    {
        get { return this.Stats[StatType.SpeedDecc]; }
        set { this.Stats[StatType.SpeedDecc] = value; }
    }
}