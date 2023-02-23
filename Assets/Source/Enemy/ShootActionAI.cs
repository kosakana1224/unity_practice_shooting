using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootActionAI : MonoBehaviour
{
    private Player player;
    [SerializeField]
    private Weapon weapon;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        weapon = GetComponentInChildren<Weapon>();
    }

    private void Update()
    {
        if (player.isAlive)
        {
            weapon.PerformAttack();
        }
    }
}
