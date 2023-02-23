using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public bool shootingDelayed;
    [SerializeField]
    private AttackPatternSO attackPatternSO;
    [SerializeField]
    private Transform shootingStartPoint;

    public GameObject projecttile;
    public void PerformAttack()
    {
        if(shootingDelayed == false)
        {
            shootingDelayed = true;
            //GameObject p = Instantiate(projecttile, transform.position, Quaternion.identity);
            attackPatternSO.Perform(shootingStartPoint);
            StartCoroutine(DelayShooting());
        }
    }

    private IEnumerator DelayShooting()
    {
        yield return new WaitForSeconds(attackPatternSO.AttackDelay);
        shootingDelayed = false;
    }
}
