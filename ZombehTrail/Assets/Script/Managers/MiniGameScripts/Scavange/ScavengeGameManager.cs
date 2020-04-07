using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScavengeGameManager : MonoBehaviour
{
    //time you have to scavenge
    public float scavenge_Total_Time;
    public float scavenge_Current_Time;
    //Times Up screen
    public GameObject your_Bounty;
    public List<GameObject> end_Text = new List<GameObject>();
    bool time_End;
    //Amount of item gathered
    public int food_Gathered, fuel_Gathered, scrap_Gathered;
    public float spawn_Item_Rate;
    //Random object to Spawn
    public GameObject [] drop_Items = new GameObject[3];
    //Size of Scene
    public int y_Axis;
    public int x_Axis;
    //Random object spawn position
    Vector2 centre;
    //UI Canvas
    public Text total_Ammo_Text, food_Gathered_Text, fuel_Gathered_Text, scrap_Gathered_Text;
    //Exit Point
    public GameObject the_Exit_Point;
    //spawning enemy
    public float enemy_Spawn_Rate;
    public EnemySpawnPoint[] the_Enemy_Spawn_Point;

    private void Start()
    {
        the_Enemy_Spawn_Point = FindObjectsOfType<EnemySpawnPoint>();
        scavenge_Current_Time = scavenge_Total_Time;
        InvokeRepeating("SpawnItem", 5, spawn_Item_Rate);
        InvokeRepeating("CallSpawnEnemy", 5, enemy_Spawn_Rate);
    }

    void FixedUpdate()
    {
        //Text for all countable items
        total_Ammo_Text.text = "" + GameManager.total_Ammo;
        food_Gathered_Text.text = "" + food_Gathered;
        fuel_Gathered_Text.text = "" + fuel_Gathered;
        scrap_Gathered_Text.text = "" + scrap_Gathered;
        //scene Timer
        if (!time_End)
        {
            Timer();
        }
    }
    void Timer()
    {
        if (scavenge_Current_Time >= 0)
        {
            scavenge_Current_Time -= Time.deltaTime;
        }
        else
        {
            ExitOpen();
        }
    }
    void CallSpawnEnemy()
    {
        int i = Random.Range(0, the_Enemy_Spawn_Point.Length - 1);

        if (scavenge_Current_Time < 0)
        {
            enemy_Spawn_Rate /= 1.25f;
        }

        the_Enemy_Spawn_Point[i].SpawnEnemy();
    }
    void SpawnItem()
    {
        Vector3 pos = centre + new Vector2(Random.Range(-x_Axis+2, x_Axis-2), Random.Range(-y_Axis+2, y_Axis-2));//set pos of random range on X and Y Axis
        GameObject OBJ = Instantiate(drop_Items[Random.Range(0, 3)], pos, transform.rotation);
    }
    void ExitOpen()
    {
        the_Exit_Point.SetActive(true);
    }
    public void ScavengeOver()
    {
        your_Bounty.SetActive(true);//pop up times up screen
        time_End = true;
        //add on the amount of item you have gather
        GameManager.total_Food = GameManager.total_Food + food_Gathered;
        GameManager.total_Fuel = GameManager.total_Fuel + fuel_Gathered;
        GameManager.total_Scrap = GameManager.total_Scrap + scrap_Gathered;
        Time.timeScale = 0;//stop time
    }
    //change scene
    public void TravelScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
