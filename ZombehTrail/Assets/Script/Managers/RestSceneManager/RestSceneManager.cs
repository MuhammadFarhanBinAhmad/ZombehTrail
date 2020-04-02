using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestSceneManager : LocationInfo
{
    private void Start()
    {
        print(GameManager.location_Number);
    }
    public void ChangeScene(string scene_Name)
    {
        int I = GameManager.location_Number;
        SceneManager.LoadScene("TravelScene");
    }
}
