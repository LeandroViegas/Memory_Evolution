using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttonClick : MonoBehaviour {


    public void SetupButton()
    {
        var button = transform.GetComponent<Button>();
        button.onClick.AddListener(this.ButtonClicked);
    }

    public void ButtonClicked()
    {
        SceneManager.LoadScene("Entrada");
    }
}
