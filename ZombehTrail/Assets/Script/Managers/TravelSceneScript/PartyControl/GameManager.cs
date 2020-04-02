using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    internal enum FoodConsumption { Small, Medium, Large};
    internal enum CarSpeed { Slow, Normal, Fast}

    internal FoodConsumption the_Food_Consumption;
    internal CarSpeed the_Car_Speed;

    public LocationInfo the_Location_Info;
    StatsUI the_Stats_UI;

    //Location and distance
    public string location_Name;
    public float destination_Distance;
    public int total_Distance;
    public static int location_Number;
    //speed of vehicle
    public int current_Speed;
    //location info & Time
    public GameObject map_Screen;
    public GameObject stats_Screen;
    //Player inventory
    public static int total_Food = 200;//total food
    public static float total_Fuel = 12;//total fuel
    public static int total_Scrap = 40;//total scrap
    public static int total_Ammo = 20;
    public int consume_Food;//food consume

    public void Awake()
    {
        the_Location_Info = FindObjectOfType<LocationInfo>();
        the_Stats_UI = FindObjectOfType<StatsUI>();
        the_Food_Consumption = FoodConsumption.Medium;
        the_Car_Speed = CarSpeed.Normal;
    }
    private void Start()
    {
        Time.timeScale = 1;
        LocationLegend();
        the_Stats_UI.BasicStats();
        InvokeRepeating("GameUpdate", 3, 3);
    }
    public void LocationLegend()
    {
        location_Name = the_Location_Info.the_Location_Legend[location_Number].the_Location_Name;
        destination_Distance = the_Location_Info.the_Location_Legend[location_Number].location_Distance;
    }
    void GameUpdate()
    {
        // Count and handle distance. If distance to location is more than 0, then value will continue to go down
        if (destination_Distance >= 0)
        {
            destination_Distance -= current_Speed;
            total_Food -= consume_Food;
        }
        if (destination_Distance <= 0)
        {
            destination_Distance = 0;
            ReachDestination();
        }
        if (total_Food >= 0)
        {
            EatingFood();
        }
        if (total_Fuel >= 0)
        {
            FuelUse();
        }

        the_Stats_UI.BasicStats();

        int percentage;

        percentage = Random.Range(0, 100);
        /*if (percentage <= the_Location_Info[location_Number].location_Risk)
        {
        }*/
    }
    //food consimption
    void EatingFood()
    {
        switch(the_Food_Consumption)
        {
            case FoodConsumption.Small:
                {
                    consume_Food = 10;
                    if (PlayerManager.health >= 0)
                    {
                        PlayerManager.health -= 1;
                    }
                }
                break;
            case FoodConsumption.Medium:
                {
                    consume_Food = 20;

                }
                break;
            case FoodConsumption.Large:
                {
                    consume_Food = 30;
                    if (PlayerManager.health <= 15)
                    {
                        PlayerManager.health += 1;
                    }
                }
                break;
        }
    }
    //fuel consumptiom
    void FuelUse()
    {
        switch(the_Car_Speed)
        {
            case CarSpeed.Slow:
                {
                    current_Speed = 15;
                    total_Fuel -= .25f;
                }
                break;
            case CarSpeed.Normal:
                {
                    current_Speed = 30;
                    total_Fuel -= .5f;
                }
                break;
            case CarSpeed.Fast:
                {
                    current_Speed = 60;
                    total_Fuel -= .75f;
                }
                break;
        }
    }
    void ReachDestination()
    {
        location_Number += 1;
        SceneManager.LoadScene("RestStop");
    }
}
