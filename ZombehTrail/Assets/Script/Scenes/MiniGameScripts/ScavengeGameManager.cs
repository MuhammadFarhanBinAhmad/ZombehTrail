﻿using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScavengeGameManager : MonoBehaviour
{
    //time you have to scavenge
    float scavenge_Total_Time = 20;
    public float scavenge_Current_Time;
    //Times Up screen
    public GameObject your_Bounty;
    bool time_End;
    //Amount of item gathered
    public int food_Gathered;
    public int fuel_Gathered;
    public int scrap_Gathered;
    //Random object to Spawn
    public GameObject [] drop_Items = new GameObject[3];
    //Size of Scene
    public int y_Axis;
    public int x_Axis;
    //Random object spawn position
    Vector2 centre;
    Vector2 size;
    //UI Canvas
    public Text total_Ammo_Text;
    public Text food_Gathered_Text;
    public Text fuel_Gathered_Text;
    public Text scrap_Gathered_Text;
    public GameObject exit_Open;
    //Exit Point
    public GameObject[] exit_Point = new GameObject[4];
    //spawning enemy
    public List<GameObject> enemy_To_Spawn = new List<GameObject>();
    public float spawn_Rate;

    private void Start()
    {
        scavenge_Current_Time = scavenge_Total_Time;
        InvokeRepeating("SpawnItem", 5, 15);
        InvokeRepeating("SpawnEnemy", 5, spawn_Rate);
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
    void SpawnEnemy()
    {
        CancelInvoke("SpawnEnemy");
        Vector3 pos = centre + new Vector2(Random.Range(-x_Axis, x_Axis), Random.Range(-y_Axis, y_Axis));//set pos of random range on X and Y Axis
        GameObject OBJ = Instantiate(enemy_To_Spawn[Random.Range(0, enemy_To_Spawn.Count-1)], pos, transform.rotation);
        if (scavenge_Current_Time < 0)
        {
            spawn_Rate /= 1.25f;
        }
        InvokeRepeating("SpawnEnemy", spawn_Rate, spawn_Rate);
    }
    void SpawnItem()
    {
        Vector3 pos = centre + new Vector2(Random.Range(-x_Axis+2, x_Axis-2), Random.Range(-y_Axis+2, y_Axis-2));//set pos of random range on X and Y Axis
        GameObject OBJ = Instantiate(drop_Items[Random.Range(0, 3)], pos, transform.rotation);
    }
    void ExitOpen()
    {
        for (int i = 0; i <= exit_Point.Length-1; i++)
        {
            exit_Point[i].SetActive(true);
        }
        exit_Open.SetActive(true);
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