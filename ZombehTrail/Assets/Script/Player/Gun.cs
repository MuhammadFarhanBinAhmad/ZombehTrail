using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public float fire_Rate;
    public float next_Fire;

    private void Update()
    {
        if (GameManager.total_Ammo > 0 && Input.GetMouseButtonDown(0) && Time.time >= next_Fire)
        {
            GameManager.total_Ammo--;
            GameObject bull = Instantiate(bullet, transform.position, transform.rotation);
            next_Fire = Time.time + fire_Rate;
        }
    }
}
