using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : EnemyManager
{ 

    private void Awake()
    {
        zombie_Name = "Normal Zombie";
        zombie_Health = 100;
        zombie_Damage = 10;
        zombie_Speed = 10;
        zombie_RB = gameObject.AddComponent<Rigidbody>();
    }

}
