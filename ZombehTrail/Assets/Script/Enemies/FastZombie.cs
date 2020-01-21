using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastZombie : EnemyManager
{
    private void Awake()
    {
        zombie_Name = "Fast Zombie";
        zombie_Health = 50;
        zombie_Damage = 10;
        zombie_Speed = 15;
        zombie_RB = gameObject.AddComponent<Rigidbody>();
    }
    private void Start()
    {
        zombie_RB.useGravity = false;
    }
}
