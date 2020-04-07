using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestSceneManager : MonoBehaviour
{
    public List<string> scavangeing_Scenes = new List<string>();

    public void ScavengingScene()
    {
        int i = Random.Range(0, scavangeing_Scenes.Count - 1);
        SceneManager.LoadScene(scavangeing_Scenes[i].ToString());
    }
    public void DepartScene(string scene_Name)
    {
        int I = GameManager.location_Number;
        SceneManager.LoadScene(scene_Name);
    }
    public void OtherScene(string scene_Name)
    {
        SceneManager.LoadScene(scene_Name);
    }
}
