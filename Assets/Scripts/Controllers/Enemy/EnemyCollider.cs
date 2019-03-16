using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class EnemyCollider : MonoBehaviour
{
    [BoxGroup("Collider Settings")]
    public Entities parent;
    [BoxGroup("Collider Settings")]
    public int damageBoost;

    public void Hit(int amount)
    {
        parent.TakeDamage(amount + damageBoost);
    }
}
