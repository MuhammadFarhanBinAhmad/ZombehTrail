using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // player stats and movement
    public float speed;
    public static int health = 15;

    private void FixedUpdate()
    {
        FaceMouse();
        //Store the current horizontal input in the float moveHorizontal.
        //float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVetical = Input.GetAxisRaw("Vertical");
        //Use the two store floats to create a new Vector2 variable movement.
        transform.Translate(moveVetical * speed,0, 0);
    }
    void FaceMouse()
    {
        //follow mouse
        Vector3 mouse_Position = Input.mousePosition;
        mouse_Position = Camera.main.ScreenToWorldPoint(mouse_Position);

        Vector2 face_Direction = new Vector2(mouse_Position.x-transform.position.x, mouse_Position.y - transform.position.y);

        transform.right = face_Direction;
    }
}
