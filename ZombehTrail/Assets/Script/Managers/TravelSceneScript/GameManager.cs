using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LocationInfo
{
    public string LocationLegend;
    public int location_Distance;
    public int location_Risk;

    public LocationInfo(string name, int distance, int risk)//set up default name, distance and risk for location
    {
        LocationLegend = name;
        location_Distance = distance;
        location_Risk = risk;
    }
}
public class GameManager : MonoBehaviour
{
    //Location and distance
    public string location_Name;
    public int destination_Distance;
    public int total_Distance;
    public int location_Number;
    //Random event
    int destination_Risk;
    int percentage;
    //speed of vehicle
    public int current_Speed;
    //location info & Time
    public LocationInfo[] the_Location_Info = new LocationInfo[6];
    public GameObject map_Screen;
    public GameObject stats_Screen;
    //Player inventory
    public static int total_Food = 200;//total food
    public int consume_Food;//food consume
    public static int total_Fuel = 12;//total fuel
    public static int total_Scrap = 40;//total scrap
    public static int total_Ammo = 20;

    public void Awake()
    {
        InvokeRepeating("GameUpdate", 3, 3);
        current_Speed = 60;
    }
    private void Start()
    {
        Time.timeScale = 1;
        //name,distance and risk of location
        the_Location_Info[0] = new LocationInfo("The Mall", 150, 20);
        the_Location_Info[1] = new LocationInfo("The Farm", 270, 35);
        the_Location_Info[2] = new LocationInfo("The Base", 300, 80);
        the_Location_Info[3] = new LocationInfo("The Forest", 420, 60);
        the_Location_Info[4] = new LocationInfo("The Safehouse", 200, 45);
        the_Location_Info[5] = new LocationInfo("The Moon", 7000, 10);
    }
    void GameUpdate()
    {
        print(destination_Distance);
        // Count and handle distance. If distance to location is more than 0, then value will continue to go down
        if (destination_Distance >= 0)
        {
            destination_Distance -= current_Speed;
            total_Food -= consume_Food;
        }
        if (destination_Distance <= 0)
        {
            destination_Distance = 0;
        }
        if (total_Food <= 0)
        {
            total_Food = 0;
        }
        percentage = Random.Range(0, 100);
        if (percentage <= the_Location_Info[location_Number].location_Risk)
        {
            print("Eventoccur");
        }
    }
    //Speed of vehicle
    public void Slow()
    {
        current_Speed = 15;
    }
    public void Normal()
    {
        current_Speed = 30;
    }
    public void Fast()
    {
        current_Speed = 60;
    }
    public void SmallRation()
    {
        consume_Food = 10;
    }
    public void NormalRation()
    {
        consume_Food = 20;
    }
    public void LargeRation()
    {
        consume_Food = 30;
    }
    //Location Button
    public void FirstLocation()
    {
        location_Number = 1;
        LocationLegend();
    }
    public void SecondLocation()
    {
        location_Number = 2;
        LocationLegend();
    }
    public void ThirdLocation()
    {
        location_Number = 3;
        LocationLegend();

    }
    public void FourthLocation()
    {
        location_Number = 4;
        LocationLegend();
    }
    public void FifthLocation()
    {
        location_Number = 5;
        LocationLegend();
    }
    public void SixthLocation()
    {
        location_Number = 6;
        LocationLegend();
    }
    public void LocationLegend()
    {
        location_Name = the_Location_Info[location_Number].LocationLegend;
        destination_Risk = the_Location_Info[location_Number].location_Risk;
        destination_Distance = the_Location_Info[location_Number].location_Distance;
    }
}
