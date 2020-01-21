using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestSceneManager : MonoBehaviour
{

    public List<string> scene_Name = new List<string>();

    public void ChangeScene(string name)
    {
        int I = Random.Range(0, scene_Name.Count - 1);
        SceneManager.LoadScene(scene_Name[I]);
    }
}
