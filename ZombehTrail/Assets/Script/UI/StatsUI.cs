using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    //Button UI
    public GameObject stats_Info;
    public GameObject health_Info;
    public GameObject map_Info;

    GameManager the_GM;
    //Text UI
    public Text LocationLegend_Text;
    public Text total_Distance_Text;
    public Text Destination_Distance_Text;
    public Text total_Fuel_Text;
    public Text total_Food_Text;
    public Text total_Scrap_Text;
    public Text total_Ammo_Text;

    //destination status

    public Image status_Bar;
    private void Start()
    {
        stats_Info.SetActive(true);
        health_Info.SetActive(false);
        map_Info.SetActive(false);
        the_GM = GetComponent<GameManager>();

    }
    public void BasicStats()
    {
        //Text
        LocationLegend_Text.text = "" + the_GM.location_Name;
        total_Distance_Text.text = "" + the_GM.total_Distance;
        Destination_Distance_Text.text = "" + the_GM.destination_Distance;
        total_Fuel_Text.text = "" + GameManager.total_Fuel;
        total_Food_Text.text = "" + GameManager.total_Food;
        total_Scrap_Text.text = "" + GameManager.total_Scrap;
        total_Ammo_Text.text = "" + GameManager.total_Ammo;
        status_Bar.fillAmount = the_GM.destination_Distance / the_GM.the_Location_Info.the_Location_Legend[GameManager.location_Number].location_Distance/the_GM.destination_Distance ;
        print(the_GM.destination_Distance);
        print(the_GM.the_Location_Info.the_Location_Legend[GameManager.location_Number].location_Distance);
    }
    public void HealthButton()
    {
        stats_Info.SetActive(false);
        health_Info.SetActive(true);
        map_Info.SetActive(false);
    }
    public void StatsButton()
    {
        stats_Info.SetActive(true);
        health_Info.SetActive(false);
        map_Info.SetActive(false);
    }
    public void MapButton()
    {
        stats_Info.SetActive(false);
        health_Info.SetActive(false);
        map_Info.SetActive(true);
    }
}
