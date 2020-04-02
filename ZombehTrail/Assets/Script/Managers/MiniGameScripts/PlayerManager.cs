using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // player stats and movement
    public float speed;
    public static int health = 15;

    ScavengeGameManager the_SGM;

    bool is_hit;

    private void Start()
    {
        the_SGM = FindObjectOfType<ScavengeGameManager>();
    }
    private void FixedUpdate()
    {
        FaceMouse();
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVetical = Input.GetAxisRaw("Vertical");
        //Use the two store floats to create a new Vector2 variable movement.
        transform.Translate(moveVetical * speed, moveHorizontal * speed, 0);
    }
    void FaceMouse()
    {
        //follow mouse
        Vector3 mouse_Position = Input.mousePosition;
        mouse_Position = Camera.main.ScreenToWorldPoint(mouse_Position);

        Vector2 face_Direction = new Vector2(mouse_Position.x-transform.position.x, mouse_Position.y - transform.position.y);

        transform.right = face_Direction;
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
            health--;
            FindObjectOfType<ScavengeGameManager>().ScavengeOver();
            FindObjectOfType<ScavengeGameManager>().end_Text[1].SetActive(true);
        }
        if (other.name == "ExitPoint")
        {
            FindObjectOfType<ScavengeGameManager>().ScavengeOver();
            FindObjectOfType<ScavengeGameManager>().end_Text[0].SetActive(true);
        }
    }
}
