using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : EnemyManager
{
    public BaseZombieStats the_Base_Stats;
    PlayerManager the_Player;

    private void Awake()
    {
        zombie_Name = the_Base_Stats.zombie_Name;
        zombie_Health = the_Base_Stats.zombie_Health;
        zombie_Speed = the_Base_Stats.zombie_Speed;
    }

    private void Start()
    {
        the_Player = FindObjectOfType<PlayerManager>();
    }
    private void FixedUpdate()
    {
        AttackingPlayer();
    }

    void AttackingPlayer()
    {
        //facing player always
        Vector2 face_Direction = new Vector2(the_Player.transform.position.x - transform.position.x, the_Player.transform.position.y - transform.position.y);
        transform.right = face_Direction;
        //chasing player
        transform.position = Vector2.MoveTowards(transform.position, the_Player.transform.position, zombie_Speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Bullet>() != null)
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

}
