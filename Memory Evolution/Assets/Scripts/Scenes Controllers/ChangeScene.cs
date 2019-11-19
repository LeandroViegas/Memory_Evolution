using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    
    // Use this for initialization
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => { LoadScene(); });
    }

    public void LoadScene()
    { 
        SceneManager.LoadScene("Entrada");
    }
}
