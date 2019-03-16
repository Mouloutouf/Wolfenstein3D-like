using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public abstract class Entities : SerializedMonoBehaviour
{
    [FoldoutGroup("Stats"), HideLabel, InlineProperty]
    public EntityStats entityStats = new EntityStats();

    public virtual void TakeDamage(float amount)
    {
        entityStats.Hitpoints = Mathf.Clamp(entityStats.Hitpoints - amount, 0, 100);

        //Implement Visual/Sound Effects

        if (entityStats.Hitpoints == 0)
        {
            //Implement Game Over
            //Temp
            Destroy(this.gameObject);
        }
    }

    public virtual void HealDamage(float amount)
    {
        entityStats.Hitpoints = Mathf.Clamp(entityStats.Hitpoints + amount, 0, 100);

        //Implement Visual/Sound Effects
    }
}
