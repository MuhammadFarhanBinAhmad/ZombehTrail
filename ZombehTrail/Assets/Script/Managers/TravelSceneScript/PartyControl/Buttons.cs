using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{

    GameManager the_Game_Manager;

    // Start is called before the first frame update
    void Start()
    {
        the_Game_Manager = FindObjectOfType<GameManager>();
    }
    // Buttons for the food and speed of the car
    public void SmallFoodConsumption()
    {
        the_Game_Manager.the_Food_Consumption = GameManager.FoodConsumption.Small;
    }
    public void MediumFoodConsumption()
    {
        the_Game_Manager.the_Food_Consumption = GameManager.FoodConsumption.Medium;

    }
    public void LargeFoodConsumption()
    {
        the_Game_Manager.the_Food_Consumption = GameManager.FoodConsumption.Large;

    }
    public void SmallFuelConsumption()
    {
        the_Game_Manager.the_Car_Speed = GameManager.CarSpeed.Slow;
    }
    public void MediumFuelConsumption()
    {
        the_Game_Manager.the_Car_Speed = GameManager.CarSpeed.Slow;
    }
    public void LargeFuelConsumption()
    {
        the_Game_Manager.the_Car_Speed = GameManager.CarSpeed.Slow;
    }
}
