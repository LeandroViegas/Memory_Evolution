using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
