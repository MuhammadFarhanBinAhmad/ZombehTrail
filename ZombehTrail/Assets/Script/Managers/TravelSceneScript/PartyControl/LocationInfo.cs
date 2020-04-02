using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LocationLegend
{
    public string the_Location_Name;
    public float location_Distance;
    public int location_Risk;

    public LocationLegend(string name, int distance, int risk)//set up default name, distance and risk for location
    {
        the_Location_Name = name;
        location_Distance = distance;
        location_Risk = risk;
    }
}

public class LocationInfo : MonoBehaviour
{

    public List<LocationLegend> the_Location_Legend = new List<LocationLegend>();

    // Start is called before the first frame update
    void Awake()
    {
        the_Location_Legend.Add(new LocationLegend("The Mall", 150, 5));
        the_Location_Legend.Add(new LocationLegend("The Farm", 270, 5));
        the_Location_Legend.Add(new LocationLegend("The Base", 300, 5));
        the_Location_Legend.Add(new LocationLegend("The Forest", 420, 5));
        the_Location_Legend.Add(new LocationLegend("The Safehouse", 200, 5));
        the_Location_Legend.Add(new LocationLegend("The Moon", 7000, 5));
    }
}
