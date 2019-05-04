using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // player stats and movement
    public float speed;
    public int health;

    ScavengeGameManager the_SGM;

    private void Start()
    {
        the_SGM = FindObjectOfType<ScavengeGameManager>();
    }
    private void Update()
    {
        FaceMouse();
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVetical = Input.GetAxis("Vertical");
        //Use the two store floats to create a new Vector2 variable movement.
        transform.Translate(moveVetical * speed, moveHorizontal * speed, 0);
    }
    void FaceMouse()
    {
        //follow mouse
        Vector3 mouse_Position = Input.mousePosition;
        mouse_Position = Camera.main.ScreenToWorldPoint(mouse_Position);

        Vector2 face_Direction = new Vector2(mouse_Position.x, mouse_Position.y);

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
    }
}
