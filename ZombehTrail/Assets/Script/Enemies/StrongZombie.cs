using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongZombie : EnemyManager
{
    private void Awake()
    {
        zombie_Name = "Strong Zombie";
        zombie_Health = 250;
        zombie_Damage = 15;
        zombie_Speed = 5;
        zombie_RB = gameObject.AddComponent<Rigidbody>();
    }
    private void Start()
    {
        zombie_RB.mass = 5;
    }
}
