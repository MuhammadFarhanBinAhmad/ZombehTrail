using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public string zombie_Name;
    public float zombie_Health;
    public float zombie_Speed;
    public float zombie_Damage;
    public Rigidbody zombie_RB;

    private void Update()
    {
        transform.Translate(zombie_Speed * Time.deltaTime, 0, 0);
    }
}
