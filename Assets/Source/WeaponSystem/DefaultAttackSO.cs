using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Attacks/DefalutAttack")]
public class DefaultAttackSO : AttackPatternSO
{
    public GameObject projectile;
    public override void Perform(Transform shootingStartPoint)
    {
        Instantiate(projectile, shootingStartPoint.position, shootingStartPoint.rotation);
    }
}
