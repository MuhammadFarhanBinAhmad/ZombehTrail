using UnityEngine;

public class PlayerScavangeScene : MonoBehaviour
{
    ScavengeGameManager the_SGM;

    private void Start()
    {
        the_SGM = FindObjectOfType<ScavengeGameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Item collection
        if (other.tag == "Scrap")
        {
            the_SGM.scrap_Gathered += Random.Range(15, 30);//get random amount of scrap from 15 - 30
            Destroy(other.gameObject);
        }
        if (other.tag == "Food")
        {
            the_SGM.food_Gathered += Random.Range(15, 30);//get random amount of scrap from 15 - 30
            Destroy(other.gameObject);
        }
        if (other.tag == "Fuel")
        {
            the_SGM.fuel_Gathered += Random.Range(15, 30);//get random amount of scrap from 15 - 30 from 15 - 30
            Destroy(other.gameObject);
        }
        if (other.GetComponent<Zombie>() != null)
        {
            PlayerManager.health--;
            if (the_SGM !=null)
            {
                the_SGM.ScavengeOver();
                the_SGM.end_Text[1].SetActive(true);
            }
        }
        if (other.name == "ExitPoint")
        {
            if (the_SGM!=null)
            {
                the_SGM.ScavengeOver();
                the_SGM.end_Text[0].SetActive(true);
            }
        }
    }
}
