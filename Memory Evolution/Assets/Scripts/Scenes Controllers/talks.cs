using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class talks : MonoBehaviour {

    string frase;
    public bool falando = false;
    float pos = 0;
    public GameObject txt;


    // Use this for initialization
    void Start () {
		
	}
	
	// Up4date is called once per frame
	void Update () {
        if (falando)
        {
            if (Convert.ToInt32(pos) < frase.Length)
                pos += Time.deltaTime * 20f;
            else
                falando = false;
            txt.GetComponent<UnityEngine.UI.Text>().text = frase.ToString().Substring(0, Convert.ToInt32(pos));
        }
        
    }

    public void Falar(string fala)
    {
        frase = fala;
        falando = true;
    }
}
