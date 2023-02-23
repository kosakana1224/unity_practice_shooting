using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackPatternSO : ScriptableObject
{
    [SerializeField]
    protected float attackDelay = 0.2f;
    public float AttackDelay => attackDelay;

    public abstract void Perform(Transform shootingStartPoint);
}
