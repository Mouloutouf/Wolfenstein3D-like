using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "Weapon", menuName = "Wolfenstein/Weapon", order = 0)]
public class Weapon : SerializedScriptableObject
{
    [HideLabel, InlineProperty, BoxGroup("Weapon Stats")]
    public WeaponStats stats = new WeaponStats();

    [BoxGroup("Weapon Graphism")]
    public Dictionary<string, Sprite> sprites = new Dictionary<string, Sprite>
    {
        {"Idle", null },
        {"Fire", null },
        {"Pickup", null },
        {"UI", null }
    };

    public Dictionary<string, List<AudioClip>> sfx = new Dictionary<string, List<AudioClip>>
    {
        {"Fire", new List<AudioClip>() },
        {"DryFire", new List<AudioClip>() },
        {"Reload", new List<AudioClip>() }
    };

    public AudioClip PickAudio(string audioName)
    {
        AudioClip result = null;
        if (sfx.ContainsKey(audioName) && sfx[audioName].Count > 0)
        {
            result = sfx[audioName][Random.Range(0, sfx[audioName].Count - 1)];
        }

        return result;
    }
}
