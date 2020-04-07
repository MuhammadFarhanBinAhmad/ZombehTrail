using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    //Spawn Box
    [Header("SpawnAreaSize")]

    public int min_y_Axis;
    public int max_y_Axis;
    public int min_x_Axis;
    public int max_x_Axis;

    //Transform Position
    [Header("Use Transform Position")]
    public bool use_Transform_X_Pos;
    public bool use_Transform_Y_Pos;
    //follow object pos
    [Header("Follow GameObject")]
    public bool follow_Object;
    public bool use_X_Distance, use_Y_Distance;
    public GameObject the_Object_To_Follow;
    float distance_From_Object;
    //spawning enemy
    [Header("Type of Enemy")]
    public List<GameObject> enemy_To_Spawn = new List<GameObject>();
    Vector2 pos;
    private void Start()
    {
        if (use_X_Distance)
        {
            distance_From_Object = transform.localPosition.x;
        }
        if (use_Y_Distance)
        {
            distance_From_Object = transform.localPosition.y;
        }        
    }
    public void SpawnEnemy()
    {
        if (follow_Object)
        {
            if (use_Transform_X_Pos && use_Transform_Y_Pos)
            {
                pos = new Vector2(the_Object_To_Follow.transform.position.x + distance_From_Object, the_Object_To_Follow.transform.position.y + distance_From_Object);//Follow game object with a set distance
            }
            if (use_Transform_X_Pos && !use_Transform_Y_Pos)
            {
                pos = new Vector2(the_Object_To_Follow.transform.position.x + distance_From_Object, the_Object_To_Follow.transform.position.y + Random.Range(min_y_Axis, max_y_Axis));//Follow game object with a set distance in x but random in y
            }
            if (!use_Transform_X_Pos && use_Transform_Y_Pos)
            {
                pos = new Vector2(the_Object_To_Follow.transform.position.x + Random.Range(min_x_Axis, max_x_Axis), the_Object_To_Follow.transform.position.y + distance_From_Object);//Follow game object with a set distance in y but random in x
            }
        }
        else
        {
            if (!use_Transform_X_Pos && !use_Transform_Y_Pos)
            {
                pos = new Vector2(Random.Range(min_x_Axis, max_x_Axis), Random.Range(min_y_Axis, max_y_Axis));//set pos of random range on X and Y Axis
            }
            if (use_Transform_X_Pos && !use_Transform_Y_Pos)
            {
                pos = new Vector2(transform.position.x, Random.Range(min_y_Axis, max_y_Axis));//set pos of random range on X and Y Axis
            }
            if (use_Transform_Y_Pos && !use_Transform_X_Pos)
            {
                pos = new Vector2(Random.Range(min_x_Axis, max_x_Axis), transform.position.y);//set pos of random range on X and Y Axis
            }
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
