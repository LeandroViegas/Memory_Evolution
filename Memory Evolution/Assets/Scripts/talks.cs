using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class talks : MonoBehaviour {

    string Frase = "Leandro é um viado mentira isso é uma grande mentira. viados são bonitos eu não. Leandro é um viado mentira isso é uma grande mentira. viados são bonitos eu não. Leandro é um viado mentira isso é uma grande mentira. viados são bonitos eu não. Leandro é um viado mentira isso é uma grande mentira. viados são bonitos eu não. Leandro é um viado mentira isso é uma grande mentira. viados são bonitos eu não. Leandro é um viado mentira isso é uma grande mentira. viados são bonitos eu não.";
    float pos = 0;
    public GameObject txt;

    // Use this for initialization
    void Start () {
		
	}
	
	// Up4date is called once per frame
	void Update () {
        if(Convert.ToInt32(pos) < Frase.Length)
            pos += Time.deltaTime * 20f;
        txt.GetComponent<UnityEngine.UI.Text>().text = Frase.ToString().Substring(0, Convert.ToInt32(pos));
    }
}
