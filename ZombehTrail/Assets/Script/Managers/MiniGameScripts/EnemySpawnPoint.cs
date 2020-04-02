using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    //Spawn Box
    public int min_y_Axis,max_y_Axis;
    public int min_x_Axis,max_x_Axis;

    //Transform Position
    public bool use_Transform_X, use_Transform_Y;
    //spawning enemy
    public List<GameObject> enemy_To_Spawn = new List<GameObject>();
    Vector2 pos;

    ScavengeGameManager the_Scavange_Game_Manager;
    // Start is called before the first frame update
    void Start()
    {
        the_Scavange_Game_Manager = FindObjectOfType<ScavengeGameManager>();
    }
    public void SpawnEnemy()
    {

        if (!use_Transform_X && !use_Transform_Y)
        {
            pos = new Vector2(Random.Range(min_x_Axis, max_x_Axis), Random.Range(min_y_Axis, max_y_Axis));//set pos of random range on X and Y Axis
        }
        if (use_Transform_X && !use_Transform_Y)
        {
            pos = new Vector2(transform.position.x, Random.Range(min_y_Axis, max_y_Axis));//set pos of random range on X and Y Axis
        }
        if (use_Transform_Y && !use_Transform_X)
        {
            pos = new Vector2(Random.Range(min_x_Axis, max_x_Axis), transform.position.y);//set pos of random range on X and Y Axis
        }

        int i;
        int zombie_To_Spawn = 0;

        //deciding what enemy to spawn
        i = Random.Range(0, 10);

        if (i <= 4)
        {
            zombie_To_Spawn = 0;
        }
        else if (i > 4 && i <= 7)
        {
            zombie_To_Spawn = 1;
        }
        else if (i > 7 && i <= 10)
        {
            zombie_To_Spawn = 2;
        }

        GameObject OBJ = Instantiate(enemy_To_Spawn[zombie_To_Spawn], pos, transform.rotation);
    }
}
