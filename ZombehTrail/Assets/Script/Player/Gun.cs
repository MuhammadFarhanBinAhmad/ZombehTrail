using UnityEngine;

public class Gun : MonoBehaviour
{
    //bullet prefab
    public GameObject bullet;
    //fire rate
    public float fire_Rate;
    public float next_Fire;

    private void Update()
    {
        if (GameManager.total_Ammo > 0 && Input.GetMouseButtonDown(0) && Time.time >= next_Fire)
        {
            float r = Random.Range(-15, 15);
            Quaternion Q = Quaternion.Euler(transform.rotation.x, transform.rotation.y,transform.eulerAngles.z+r);

            GameManager.total_Ammo--;
            GameObject bull = Instantiate(bullet, transform.position, Q);
            next_Fire = Time.time + fire_Rate;
        }
    }
}
