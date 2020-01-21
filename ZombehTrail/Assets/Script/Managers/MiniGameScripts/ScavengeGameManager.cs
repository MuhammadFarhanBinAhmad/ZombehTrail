using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScavengeGameManager : MonoBehaviour
{
    //time you have to scavenge
    public float scavenge_Time;
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
    //Show the amount you have left that item
    public Text total_Ammo_Text;
    public Text food_Gathered_Text;
    public Text fuel_Gathered_Text;
    public Text scrap_Gathered_Text;

    private void Start()
    {
        InvokeRepeating("SpawnItem", 15, 15);
    }

    void SpawnItem()
    {
        Vector3 pos = centre + new Vector2(Random.Range(-x_Axis, x_Axis), Random.Range(-y_Axis, y_Axis));//set pos of random range on X and Y Axis
        GameObject OBJ = Instantiate(drop_Items[Random.Range(0,3)], pos, transform.rotation);
    }

    void Update()
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
        if (scavenge_Time >= 0)
        {
            scavenge_Time -= Time.deltaTime;
        }
        else
        {
            ScavengeOver();
        }
    }
    void ScavengeOver()
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
